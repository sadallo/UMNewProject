package com.example.newcrowdtranslator;

import java.util.ArrayList;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.Wsdl2Code.WebServices.ServiceMobile.EducationDto;

public class EducationPreferenceAdapter extends ArrayAdapter<EducationDto>  {
	
	public EducationPreferenceAdapter(Context context, ArrayList<EducationDto> educationList)
	{
		super(context, R.layout.list_simple, educationList);
		// TODO Auto-generated constructor stub
	}
	
	// View lookup cache
    private static class ViewHolder 
    {
        TextView title;
    }
    

    
    @Override
    public View getView(int position, View convertView, ViewGroup parent) 
    {
       // Get the data item for this position
    	EducationDto edu = getItem(position);    
       // Check if an existing view is being reused, otherwise inflate the view
       ViewHolder viewHolder; // view lookup cache stored in tag
       if (convertView == null) 
       {
          viewHolder = new ViewHolder();
          LayoutInflater inflater = LayoutInflater.from(getContext());
          convertView = inflater.inflate(android.R.layout.preference_category, parent, false);
          viewHolder.title = (TextView) convertView.findViewById(android.R.layout.preference_category);
          convertView.setTag(viewHolder);
       } 
       else 
       {
           viewHolder = (ViewHolder) convertView.getTag();
       }
       // Populate the data into the template view using the data object
       viewHolder.title.setText(edu.educationDescription);
      
       // Return the completed view to render on screen
       return convertView;
	

    }
}
