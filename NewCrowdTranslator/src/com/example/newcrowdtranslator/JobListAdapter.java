package com.example.newcrowdtranslator;

import java.util.ArrayList;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.Wsdl2Code.WebServices.ServiceMobile.JobDto;

public class JobListAdapter extends ArrayAdapter<JobDto>{
	
	// View lookup cache
    private static class ViewHolder 
    {
        TextView title;
        TextView caption;
    }
    
    public JobListAdapter(Context context, ArrayList<JobDto> jobList) 
    {
       super(context, R.layout.list_complex, jobList);
    }
    
    @Override
    public View getView(int position, View convertView, ViewGroup parent) 
    {
       // Get the data item for this position
    	JobDto job = getItem(position);    
       // Check if an existing view is being reused, otherwise inflate the view
       ViewHolder viewHolder; // view lookup cache stored in tag
       if (convertView == null) 
       {
          viewHolder = new ViewHolder();
          LayoutInflater inflater = LayoutInflater.from(getContext());
          convertView = inflater.inflate(R.layout.list_complex, parent, false);
          viewHolder.title = (TextView) convertView.findViewById(R.id.list_complex_title);
          viewHolder.caption = (TextView) convertView.findViewById(R.id.list_complex_caption);
          convertView.setTag(viewHolder);
       } 
       else 
       {
           viewHolder = (ViewHolder) convertView.getTag();
       }
       // Populate the data into the template view using the data object
       viewHolder.title.setText(job.jobDescription);
       //viewHolder.caption.setText(job.jobExperienceLevel);
      
       // Return the completed view to render on screen
       return convertView;
   }
}
