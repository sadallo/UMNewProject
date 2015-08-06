package com.example.newcrowdtranslator;

import java.util.Locale;

import android.app.ActionBar;
import android.app.Activity;
import android.app.Fragment;
import android.app.FragmentManager;
import android.app.FragmentTransaction;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.os.Bundle;
import android.preference.PreferenceManager;
import android.support.v13.app.FragmentPagerAdapter;
import android.support.v4.view.ViewPager;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Toast;

import com.Wsdl2Code.WebServices.ServiceMobile.RecruiteeDto;
import com.Wsdl2Code.WebServices.ServiceMobile.ServiceMobile;
import com.Wsdl2Code.WebServices.ServiceMobile.VectorAgeDto;
import com.Wsdl2Code.WebServices.ServiceMobile.VectorEducationDto;
import com.Wsdl2Code.WebServices.ServiceMobile.VectorIncomeDto;
import com.Wsdl2Code.WebServices.ServiceMobile.VectorJobDto;
import com.Wsdl2Code.WebServices.ServiceMobile.VectorSkillDto1;
import com.julian.controls.CustomDialog;

public class MainActivity extends Activity implements ActionBar.TabListener {
	
	private static JobsView allJobsView;
	private static RecommendedJobsView recommendedJobsView;
	private Context myContext;
	
	private static RecruiteeDto recruitee;
	private static VectorJobDto allJobsList;
	private static VectorJobDto recommendedJobsList;
	private static VectorEducationDto educationList;
	private static VectorIncomeDto incomeList;
	private static VectorSkillDto1 skillList;
	private static VectorAgeDto ageList;
	
	
	private static String EMAIL_PREFERENCE_KEY = "email_preference";	
	private static String AGE_PREFERENCE_KEY = "age_preference";
	private static String EDUCATION_PREFERENCE_KEY = "education_preference";
	private static String INCOME_PREFERENCE_KEY = "income_preference";
	private static String SKILL_PREFERENCE_KEY = "skill_preference";
	
	private static SharedPreferences sharedPreferences;
	private static boolean noUser;
	private static String email;


	//private static VectorJobDto recommendedJobsList;
	
	/**
	 * The {@link android.support.v4.view.PagerAdapter} that will provide
	 * fragments for each of the sections. We use a {@link FragmentPagerAdapter}
	 * derivative, which will keep every loaded fragment in memory. If this
	 * becomes too memory intensive, it may be best to switch to a
	 * {@link android.support.v13.app.FragmentStatePagerAdapter}.
	 */
	SectionsPagerAdapter mSectionsPagerAdapter;

	/**
	 * The {@link ViewPager} that will host the section contents.
	 */
	ViewPager mViewPager;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);

		myContext = this;
		// Set up the action bar.
		final ActionBar actionBar = getActionBar();
		actionBar.setNavigationMode(ActionBar.NAVIGATION_MODE_TABS);

		// Create the adapter that will return a fragment for each of the three
		// primary sections of the activity.
		mSectionsPagerAdapter = new SectionsPagerAdapter(getFragmentManager());

		// Set up the ViewPager with the sections adapter.
		mViewPager = (ViewPager) findViewById(R.id.pager);
		mViewPager.setAdapter(mSectionsPagerAdapter);
		//mViewPager.setOffscreenPageLimit(1);

		// When swiping between different sections, select the corresponding
		// tab. We can also use ActionBar.Tab#select() to do this if we have
		// a reference to the Tab.
		mViewPager
				.setOnPageChangeListener(new ViewPager.SimpleOnPageChangeListener() {
					@Override
					public void onPageSelected(int position) {
						actionBar.setSelectedNavigationItem(position);
					}
				});

		// For each of the sections in the app, add a tab to the action bar.
		for (int i = 0; i < mSectionsPagerAdapter.getCount(); i++) {
			// Create a tab with text corresponding to the page title defined by
			// the adapter. Also specify this Activity object, which implements
			// the TabListener interface, as the callback (listener) for when
			// this tab is selected.
			actionBar.addTab(actionBar.newTab()
					.setText(mSectionsPagerAdapter.getPageTitle(i))
					.setTabListener(this));
		}
		
		PreferenceManager.setDefaultValues(this, R.xml.preferences,false);
		
		sharedPreferences = PreferenceManager.getDefaultSharedPreferences(this);
	}
	
	public void onStart()
	{
		super.onStart();
	}
	
	public void onResume()
	{
		super.onResume();
		SharedPreferences sharedPref = PreferenceManager.getDefaultSharedPreferences(this);
		email = sharedPref.getString(EMAIL_PREFERENCE_KEY, null);
	
		
		
		(new DataRetriever()).execute();		
	}
	
	public class DataRetriever extends AsyncTask<Void, Void, Void>
	{
		private boolean completedWithError=false;
	
		protected void onPreExecute() 
		{
			Toast.makeText(getApplicationContext(), "Retrieving Data...", Toast.LENGTH_SHORT).show();
		}

		protected Void doInBackground(Void... params) 
		{ 		
			try 
			{
				noUser = true;
				ServiceMobile svc = new ServiceMobile();
				
				// select general stuff				
				ageList = svc.selectAllAge();
				educationList = svc.selectAllEducation();				
				incomeList = svc.selectAllIncome();
				skillList = svc.selectAllSkillRecruitee();
				
				if(ageList == null || educationList == null 
						|| incomeList == null || skillList == null )
				{
					completedWithError=true;
				}
				else if(isValidEmail(email))
				{
					recruitee = svc.selectRecruiteeByEmail(email);		
					
					if(recruitee.recruiteeId != null)
					{
						noUser = false;
						allJobsList = svc.selectJobNotDoneByRecruiteeId(recruitee.recruiteeId);
						
						recommendedJobsList = svc.selectJobNotDoneByRecruiteeIdRecommendation(recruitee.recruiteeId);
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
				new CustomDialog(myContext, "Check internet settings and try again", "No Data Posted").show();
			}
			else if(noUser)
			{
				CustomDialog customDialog = new CustomDialog(myContext, "Go to Settings and fill out your profile information.");
				
				
				customDialog.setPositiveButton("Edit Settings", new DialogInterface.OnClickListener() {
		            public void onClick(DialogInterface dialog, int whichButton) {
		                startSettingsActivity(noUser);
		            }
		        }).show();
				
				
			}
			else
			{
				bindData();
			}
			
			Toast.makeText(getApplicationContext(), "Data Retrieved", Toast.LENGTH_SHORT).show();


		}
	}
	
	

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		// Handle action bar item clicks here. The action bar will
		// automatically handle clicks on the Home/Up button, so long
		// as you specify a parent activity in AndroidManifest.xml.
		int id = item.getItemId();
		if (id == R.id.action_settings) {
			startSettingsActivity(false);
			return true;
		}
		return super.onOptionsItemSelected(item);
	}

	@Override
	public void onTabSelected(ActionBar.Tab tab,
			FragmentTransaction fragmentTransaction) {
		// When the given tab is selected, switch to the corresponding page in
		// the ViewPager.
		mViewPager.setCurrentItem(tab.getPosition());
	}

	@Override
	public void onTabUnselected(ActionBar.Tab tab,
			FragmentTransaction fragmentTransaction) {
	}

	@Override
	public void onTabReselected(ActionBar.Tab tab,
			FragmentTransaction fragmentTransaction) {
	}
	
	public boolean startSettingsActivity(boolean no_user)
	{
		Intent intent = new Intent(this, SettingsActivity.class);
		Bundle sendBundle = new Bundle();
    	//sendBundle.putBoolean(NO_USER, no_user);
    	sendBundle.putSerializable(AGE_PREFERENCE_KEY, ageList);
    	sendBundle.putSerializable(EDUCATION_PREFERENCE_KEY, educationList);
    	sendBundle.putSerializable(INCOME_PREFERENCE_KEY, incomeList);
    	sendBundle.putSerializable(SKILL_PREFERENCE_KEY, skillList);

    	intent.putExtras(sendBundle);
		this.startActivity(intent);
		return true;
	}
	

	/**
	 * A {@link FragmentPagerAdapter} that returns a fragment corresponding to
	 * one of the sections/tabs/pages.
	 */
	public class SectionsPagerAdapter extends FragmentPagerAdapter {

		public SectionsPagerAdapter(FragmentManager fm) {
			super(fm);
		}

		@Override
		public Fragment getItem(int position) {
			// getItem is called to instantiate the fragment for the given page.
			// Return a PlaceholderFragment (defined as a static inner class
			// below).
			
			switch(position)
			{
				case 0:
					allJobsView = JobsView.newInstance(allJobsList, recruitee);
					return allJobsView;				
				case 1:
					recommendedJobsView = RecommendedJobsView.newInstance(recommendedJobsList, recruitee);
					return recommendedJobsView;	
				default:
					allJobsView = JobsView.newInstance(allJobsList, recruitee);
					return allJobsView;
			}
					
		}

		@Override
		public int getCount() {
			// Show 2 total pages.
			return 2;
		}

		@Override
		public CharSequence getPageTitle(int position) {
			Locale l = Locale.getDefault();
			switch (position) {
			case 0:
				return getString(R.string.title_section0).toUpperCase(l);
			case 1:
				return getString(R.string.title_section1).toUpperCase(l);
			}
			return null;
		}
	}

	@Override
	public void onBackPressed()
	{
		finish();
	}
	
	
	/**
	 * A placeholder fragment containing a simple view.
	 */
	public static class PlaceholderFragment extends Fragment {
		/**
		 * The fragment argument representing the section number for this
		 * fragment.
		 */
		private static final String ARG_SECTION_NUMBER = "section_number";

		/**
		 * Returns a new instance of this fragment for the given section number.
		 */
		public static PlaceholderFragment newInstance(int sectionNumber) {
			PlaceholderFragment fragment = new PlaceholderFragment();
			Bundle args = new Bundle();
			args.putInt(ARG_SECTION_NUMBER, sectionNumber);
			fragment.setArguments(args);
			return fragment;
		}

		public PlaceholderFragment() {
		}

		@Override
		public View onCreateView(LayoutInflater inflater, ViewGroup container,
				Bundle savedInstanceState) {			
			
			View rootView = inflater.inflate(R.layout.fragment_main, container,
						false);
		
			return rootView;
		}
	}
	
	public void bindData()
	{
		if(allJobsList != null && recruitee != null && recruitee.recruiteeId != null)
		{
			allJobsView.setJobsList(allJobsList, recruitee);
			allJobsView.bindDataToListView();
		}
		
		if(recommendedJobsList != null && recruitee != null && recruitee.recruiteeId != null)
		{
			recommendedJobsView.setJobsList(recommendedJobsList, recruitee);
			recommendedJobsView.bindDataToListView();
		}

		Toast.makeText(getApplicationContext(), "Data Retrieved", Toast.LENGTH_SHORT).show();
	}
	
	
	
	
	public boolean isValidEmail(CharSequence target) {
	    if (target == null) 
	        return false;
	    return android.util.Patterns.EMAIL_ADDRESS.matcher(target).matches();
	}
	
	

}
