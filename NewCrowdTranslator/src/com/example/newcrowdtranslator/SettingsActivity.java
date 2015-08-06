package com.example.newcrowdtranslator;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.UUID;

import android.app.Activity;
import android.content.SharedPreferences;
import android.content.SharedPreferences.Editor;
import android.content.SharedPreferences.OnSharedPreferenceChangeListener;
import android.os.AsyncTask;
import android.os.Bundle;
import android.preference.EditTextPreference;
import android.preference.ListPreference;
import android.preference.Preference;
import android.preference.PreferenceFragment;
import android.widget.Toast;

import com.Wsdl2Code.WebServices.ServiceMobile.AgeDto;
import com.Wsdl2Code.WebServices.ServiceMobile.EducationDto;
import com.Wsdl2Code.WebServices.ServiceMobile.IncomeDto;
import com.Wsdl2Code.WebServices.ServiceMobile.RecruiteeDto;
import com.Wsdl2Code.WebServices.ServiceMobile.ServiceMobile;
import com.Wsdl2Code.WebServices.ServiceMobile.SkillDto1;
import com.julian.controls.CustomDialog;

public class SettingsActivity extends Activity{
	

	private static String EMAIL_PREFERENCE_KEY = "email_preference";	
	private static String AGE_PREFERENCE_KEY = "age_preference";
	private static String EDUCATION_PREFERENCE_KEY = "education_preference";
	private static String FIRSTNAME_PREFERENCE_KEY = "firstname_preference";
	private static String GENDER_PREFERENCE_KEY = "gender_preference";
	private static String INCOME_PREFERENCE_KEY = "income_preference";
	private static String LASTNAME_PREFERENCE_KEY = "lastname_preference";
	private static String SKILL_PREFERENCE_KEY = "skill_preference";
	
	
	private static RecruiteeDto recruitee = new RecruiteeDto();
	private static ArrayList<AgeDto> ageList;
	private static ArrayList<EducationDto> educationList;
	private static ArrayList<IncomeDto> incomeList;
	private static ArrayList<SkillDto1> skillList;
	public static final String PREFS_FILE = "preferences.xml";
	
	private static boolean noUser;
	private static boolean updateUser;
	private static String currentSkillId;
	
	private static String email;
	
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
				
		getFragmentManager().beginTransaction()
        .replace(android.R.id.content, new PlaceholderFragment())
        .commit();	
	}
	
	public void onStart()
	{
		super.onStart();
	}
	
	public void onResume()
	{
		super.onResume();
		
		updateUser = false;
	}
	
	
	/**
	 * A placeholder fragment containing a simple view.
	 */
	public static class PlaceholderFragment extends PreferenceFragment implements OnSharedPreferenceChangeListener  {
		
		private static SharedPreferences sharedPreferences;

		public PlaceholderFragment() {
		}
		
		@SuppressWarnings("unchecked")
		public void onCreate(Bundle savedInstanceState)
		{
			super.onCreate(savedInstanceState);
			
			try{							
				addPreferencesFromResource(R.xml.preferences);
							
				Bundle receiveBundle = getActivity().getIntent().getExtras();
				
				ageList = (ArrayList<AgeDto>)receiveBundle.getSerializable(AGE_PREFERENCE_KEY);
				educationList = (ArrayList<EducationDto>)receiveBundle.getSerializable(EDUCATION_PREFERENCE_KEY);
				incomeList = (ArrayList<IncomeDto>)receiveBundle.getSerializable(INCOME_PREFERENCE_KEY);
				skillList = (ArrayList<SkillDto1>)receiveBundle.getSerializable(SKILL_PREFERENCE_KEY);
				
				final ListPreference listPreferenceAge = (ListPreference) findPreference(AGE_PREFERENCE_KEY);
				final ListPreference listPreferenceEducation = (ListPreference) findPreference(EDUCATION_PREFERENCE_KEY);
				final ListPreference listPreferenceIncome = (ListPreference) findPreference(INCOME_PREFERENCE_KEY);
				final ListPreference listPreferenceSkill = (ListPreference) findPreference(SKILL_PREFERENCE_KEY);
									
				setListPreferenceDataAge(listPreferenceAge);
				setListPreferenceDataEducation(listPreferenceEducation);
				setListPreferenceDataIncome(listPreferenceIncome);
				setListPreferenceDataSkill(listPreferenceSkill);
				
				
		        for(int i=0;i<getPreferenceScreen().getPreferenceCount();i++)
				{
				    Preference connectionPref = getPreferenceScreen().getPreference(i);	
					persistPreference(connectionPref, getPreferenceScreen().getSharedPreferences(), connectionPref.getKey());
				}  
		        		        
		        currentSkillId = getPreferenceScreen().getSharedPreferences().getString(SKILL_PREFERENCE_KEY, "");
			}
			catch(Exception ex)
			{
				new CustomDialog(getActivity(), "Check internet settings and try again", "No Data Posted").show();
			}
					
		}
		
		
		
		@Override
		public void onResume() {
		    super.onResume();
		    getPreferenceScreen().getSharedPreferences()
		            .registerOnSharedPreferenceChangeListener(this);
				
			email = getPreferenceScreen().getSharedPreferences().getString(EMAIL_PREFERENCE_KEY, null);
			
			

			if (!isValidEmail(email))
			{
				noUser = true;
				findPreference(SKILL_PREFERENCE_KEY).setEnabled(false);
				findPreference(FIRSTNAME_PREFERENCE_KEY).setEnabled(false);
        		findPreference(LASTNAME_PREFERENCE_KEY).setEnabled(false);
        		findPreference(GENDER_PREFERENCE_KEY).setEnabled(false);
        		findPreference(AGE_PREFERENCE_KEY).setEnabled(false);
        		findPreference(EDUCATION_PREFERENCE_KEY).setEnabled(false);
        		findPreference(INCOME_PREFERENCE_KEY).setEnabled(false);
			}
			else
			{
				findPreference(EMAIL_PREFERENCE_KEY).setEnabled(false);
			}
			
		    (new DataRetriever()).execute();
		    		    
		}

		@Override
		public void onPause() {
		    super.onPause();
		    getPreferenceScreen().getSharedPreferences()
		    		.unregisterOnSharedPreferenceChangeListener(this);
		    
		    (new DataRetriever()).execute();
		    
		}
		
		public void onSharedPreferenceChanged(SharedPreferences sharedPreferences,
	        String key) {				
            	Preference connectionPref = findPreference(key);            	
            	persistPreference(connectionPref, sharedPreferences, key);
            	updateUser = true;
    			Editor editor = sharedPreferences.edit();

            	if(key.equals(EMAIL_PREFERENCE_KEY))
            	{
            		if(isValidEmail(((EditTextPreference)connectionPref).getText()))
            		{                        			
            			connectionPref.setEnabled(false);
            			findPreference(SKILL_PREFERENCE_KEY).setEnabled(true);
            		}
            		else
            		{
                    	updateUser = false;

            			((EditTextPreference)connectionPref).setText("");
            			((EditTextPreference)connectionPref).setSummary(R.string.invalid_email);

            		}
            	}
            	else if(key.equals(SKILL_PREFERENCE_KEY))
            	{
            		findPreference(FIRSTNAME_PREFERENCE_KEY).setEnabled(true);
            		findPreference(LASTNAME_PREFERENCE_KEY).setEnabled(true);
            		findPreference(GENDER_PREFERENCE_KEY).setEnabled(true);
            		findPreference(AGE_PREFERENCE_KEY).setEnabled(true);
            		findPreference(EDUCATION_PREFERENCE_KEY).setEnabled(true);
            		findPreference(INCOME_PREFERENCE_KEY).setEnabled(true);
            		
            	}
            	editor.commit();            	
    	}
		
		public class DataRetriever extends AsyncTask<Void, Void, Void>
		{

			private boolean completedWithError=false;
		
			protected void onPreExecute() 
			{
				Toast.makeText(getActivity(), "Retrieving Data...", Toast.LENGTH_SHORT).show();
			}

			protected Void doInBackground(Void... params) 
			{ 		
				try 
				{
					ServiceMobile svc = new ServiceMobile();
					 
					if(updateUser)
					{
						sharedPreferences = getPreferenceScreen().getSharedPreferences();
						if(noUser)
						{
							String newEmail = sharedPreferences.getString(EMAIL_PREFERENCE_KEY, null);
							RecruiteeDto newRecruitee = svc.selectRecruiteeByEmail(newEmail);
							if(newRecruitee.recruiteeId != null)
							{
								recruitee = newRecruitee;
							}
							else
							{
								String id = UUID.randomUUID().toString();
								String eS = getString(R.string.empty_string);
								String dG = getString(R.string.default_value_gender);
								svc.insertRecruitee(id, eS, 0, false, newEmail, eS, eS, dG, eS, eS, eS);
								
								recruitee = svc.selectRecruiteeById(id);
								if(recruitee == null || recruitee.recruiteeId == null)
								{
									completedWithError = true;
								}
								else
								{
									noUser = false;
								}
							}
						}
						
						if(isValidEmail(recruitee.email))
						{
							String newSkillId = sharedPreferences.getString(SKILL_PREFERENCE_KEY, null);
							if(currentSkillId != newSkillId)
							{
								svc.removeSkillFromRecruitee(recruitee.recruiteeId, currentSkillId);
								svc.addSkillToRecruitee(recruitee.recruiteeId, newSkillId);
							}
							
							recruitee.firstName = sharedPreferences.getString(FIRSTNAME_PREFERENCE_KEY, recruitee.firstName);
							recruitee.lastName = sharedPreferences.getString(LASTNAME_PREFERENCE_KEY, recruitee.lastName);
							recruitee.ageId = sharedPreferences.getString(AGE_PREFERENCE_KEY, recruitee.ageId);
							recruitee.educationId = sharedPreferences.getString(EDUCATION_PREFERENCE_KEY, recruitee.educationId);
							recruitee.gender = sharedPreferences.getString(GENDER_PREFERENCE_KEY, recruitee.gender);
							recruitee.incomeId = sharedPreferences.getString(INCOME_PREFERENCE_KEY, recruitee.incomeId);
													
							svc.updateRecruitee(recruitee.recruiteeId, recruitee.rankingId, recruitee.rankingValue, false, recruitee.email, recruitee.firstName, recruitee.lastName, recruitee.gender, recruitee.ageId, recruitee.educationId, recruitee.incomeId);
							recruitee = svc.selectRecruiteeById(recruitee.recruiteeId);
							if(recruitee == null || recruitee.recruiteeId == null)
							{
								completedWithError = true;
							}
						}				
						
					}
					
					
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
			}
		}
		
		

		public void persistPreference(Preference connectionPref, SharedPreferences sharedPreferences, String key)
		{
			boolean completedWithError=false;

			try{
				if(key.equals(EMAIL_PREFERENCE_KEY))
	        	{ 
	        		connectionPref.setSummary(sharedPreferences.getString(key, ""));
	        	}
	        	if(connectionPref instanceof EditTextPreference)
	        	{
	        		// Set summary to be the user-description for the selected value
	        		connectionPref.setSummary(sharedPreferences.getString(key, ""));
	        	}	        		
	        	else if(key.equals(GENDER_PREFERENCE_KEY))
	        	{            
	        		String[] texts = getResources().getStringArray(R.array.gender_values_array);
	        		String[] values = getResources().getStringArray(R.array.gender_array);
	        		 
	        		String gender_option = values[Arrays.asList(texts).indexOf(sharedPreferences.getString(key, getString(R.string.default_value_gender)))];
	        		connectionPref.setSummary(gender_option);
	        	}
	        	else if(key.equals(AGE_PREFERENCE_KEY) || key.equals(EDUCATION_PREFERENCE_KEY) || 
	        			key.equals(INCOME_PREFERENCE_KEY) || key.equals(SKILL_PREFERENCE_KEY))
	        	{            
	        		ListPreference lp = (ListPreference) connectionPref;
	        		CharSequence entry = lp.getEntry();
	        		if(entry != null)
	        		{
	        			connectionPref.setSummary(entry.toString());
	        		}
	        	}
			}
			catch(Exception ex)
			{
				completedWithError=true;
			}
			
			if(completedWithError)
			{
				new CustomDialog(getActivity(), "Check internet settings and try again", "No Data Posted").show();
			}
		}
		
		protected static void setListPreferenceDataAge(ListPreference lp) {
			List<String> listEntries = new ArrayList<>();
			List<String> listEntryValues = new ArrayList<>();
			for(AgeDto age : ageList)
			{
				listEntries.add(age.ageDescription);
				listEntryValues.add(age.ageId);
			}
			
			CharSequence[] entries = listEntries.toArray(new CharSequence[listEntries.size()]);
			CharSequence[] entryValues = listEntryValues.toArray(new CharSequence[listEntries.size()]);
			            
            lp.setEntries(entries);
            lp.setEntryValues(entryValues);
		}
		
		protected static void setListPreferenceDataEducation(ListPreference lp) {
			List<String> listEntries = new ArrayList<>();
			List<String> listEntryValues = new ArrayList<>();
			for(EducationDto edu : educationList)
			{
				listEntries.add(edu.educationDescription);
				listEntryValues.add(edu.educationId);
			}
			
			CharSequence[] entries = listEntries.toArray(new CharSequence[listEntries.size()]);
			CharSequence[] entryValues = listEntryValues.toArray(new CharSequence[listEntryValues.size()]);
			            
            lp.setEntries(entries);
            lp.setEntryValues(entryValues);
		}
		
		protected static void setListPreferenceDataIncome(ListPreference lp) {
		
			List<String> listEntries = new ArrayList<>();
			List<String> listEntryValues = new ArrayList<>();
			for(IncomeDto inc : incomeList)
			{
				listEntries.add(inc.incomeDescription);
				listEntryValues.add(inc.incomeId);
			}
			
			CharSequence[] entries = listEntries.toArray(new CharSequence[listEntries.size()]);
			CharSequence[] entryValues = listEntryValues.toArray(new CharSequence[listEntryValues.size()]);
			            
            lp.setEntries(entries);
            lp.setEntryValues(entryValues);
		}
		
		protected static void setListPreferenceDataSkill(ListPreference lp) {
			
			List<String> listEntries = new ArrayList<>();
			List<String> listEntryValues = new ArrayList<>();
			for(SkillDto1 inc : skillList)
			{
				listEntries.add(inc.skillDescription);
				listEntryValues.add(inc.skillId);
			}
			
			CharSequence[] entries = listEntries.toArray(new CharSequence[listEntries.size()]);
			CharSequence[] entryValues = listEntryValues.toArray(new CharSequence[listEntryValues.size()]);
			            
            lp.setEntries(entries);
            lp.setEntryValues(entryValues);
		}
		
		public boolean isValidEmail(CharSequence target) {
		    if (target == null) 
		        return false;

		    return android.util.Patterns.EMAIL_ADDRESS.matcher(target).matches();
		}
		
		
		
	
	}	
}
