package com.example.newcrowdtranslator;

import java.util.ArrayList;
import java.util.UUID;

import android.app.Fragment;
import android.content.DialogInterface;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.Toast;

import com.Wsdl2Code.WebServices.ServiceMobile.JobDto;
import com.Wsdl2Code.WebServices.ServiceMobile.RecruiteeDto;
import com.Wsdl2Code.WebServices.ServiceMobile.ServiceMobile;
import com.Wsdl2Code.WebServices.ServiceMobile.TaskDto;
import com.Wsdl2Code.WebServices.ServiceMobile.VectorJobDto;
import com.julian.controls.CustomDialog;
import com.julian.controls.CustomInputDialog;

public class JobsView extends Fragment implements OnItemClickListener{

	private static VectorJobDto jobsList;
	private static RecruiteeDto recruitee;

	private JobListAdapter jobListAdapter;
	private JobDto selectedJob;
	private ListView jobsListView;
	private CustomInputDialog inputDialog;
	private String translation;
	
	public JobsView() {
		super();
	}
	
	@Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View v = inflater.inflate(R.layout.fragment_generic_list, container, false);
    
       ListView jobs =  (ListView)v.findViewById(R.id.generic_list);
       jobs.setOnItemClickListener(this);
       
	   return v;
    }
	
	
	public void setJobsList(VectorJobDto jobsList, RecruiteeDto recruitee) 
   	{
		JobsView.jobsList = jobsList;
		JobsView.recruitee = recruitee;
   	}
	
	public void onStart()
    {
    	super.onStart();
    	this.bindDataToListView();
    }
	
	
	@Override
	public void onItemClick(AdapterView<?> parent, View view, int position,
			long id) {
		// TODO Auto-generated method stub
		selectedJob = jobListAdapter.getItem(position);
		
		inputDialog = new CustomInputDialog(getActivity(), selectedJob.jobDescription, "Type the translation here");
		
		final EditText input = inputDialog.getInput();
		inputDialog.setPositiveButton("OK", new DialogInterface.OnClickListener() 
		{
			public void onClick(DialogInterface dialog, int whichButton) 
			{
				translation = input.getText().toString();
				if(!translation.equals(""))
				{
					(new DataRetriever()).execute();	
					jobListAdapter.remove(selectedJob);
				}
			}		
			
		});
		
		inputDialog.setOnKeyListener(new DialogInterface.OnKeyListener() {

			@Override
			public boolean onKey(DialogInterface dialog, int keyCode, KeyEvent event) {
				// TODO Auto-generated method stub				
				if (KeyEvent.KEYCODE_ENTER == keyCode) {
					dialog.dismiss();
					translation = input.getText().toString();
					if(!translation.equals(""))
					{
						(new DataRetriever()).execute();
						jobListAdapter.remove(selectedJob);
					}
					return true;
				}
				return false;
			}
		});

		inputDialog.setNegativeButton("Cancel", new DialogInterface.OnClickListener() 
		{
			public void onClick(DialogInterface dialog, int whichButton) 
			{
				// Canceled.
			}
		});
		
		inputDialog.show();
	
		
	}
	
	public class DataRetriever extends AsyncTask<Void, Void, Void>
	{
		private boolean completedWithError=false;
	
		protected void onPreExecute() 
		{
			Toast.makeText(getActivity(), "Sending translation...", Toast.LENGTH_SHORT).show();
		}

		protected Void doInBackground(Void... params) 
		{ 		
			try 
			{
				ServiceMobile svc = new ServiceMobile();
				TaskDto task = new TaskDto();
				task.jobId = selectedJob.jobId;
				task.recruiteeId = recruitee.recruiteeId;
				task.taskId = UUID.randomUUID().toString();
				task.taskDescription = translation;
				task.rating = 0;
				
				svc.insertTask(task.taskId, task.jobId, task.recruiteeId, task.taskDescription, task.rating, false);
					
				
			}	 
			catch (Exception e) 
			{	 
				completedWithError=true;
			}	
			return null;
		}	

		protected void onPostExecute(Void result) 
		{	 
			
			if(completedWithError)
			{
				new CustomDialog(getActivity(), "Check internet settings and try again", "No Data Posted").show();
			}
			else
			{
				Toast.makeText(getActivity(), "Translation sent", Toast.LENGTH_SHORT).show();
			}
			


		}
	}
	
	protected void bindDataToListView()
    {
    	ArrayList<JobDto> data0 = new ArrayList<JobDto>();
    	
    	if(jobsList != null)
    	{
    		for(JobDto job : jobsList)
    		{
    			data0.add(job);
    		}
    	}
    	
    	jobListAdapter = new JobListAdapter(getActivity().getApplicationContext(), data0);
    	
    	View view = getView();
    	if(view !=null)
    	{
        	// Get a reference to the ListView holder
    		jobsListView = (ListView) view.findViewById(R.id.generic_list);
    		
    		// Set the adapter on the ListView holder
    		jobsListView.setAdapter(jobListAdapter);
    	}
    }
	
	public static JobsView newInstance(VectorJobDto jobsList, RecruiteeDto recruitee)
	{
		JobsView.jobsList = jobsList;
		JobsView.recruitee = recruitee;
		
        return new JobsView();
    }

}
