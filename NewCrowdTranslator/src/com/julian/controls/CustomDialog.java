package com.julian.controls;

import android.app.AlertDialog;
import android.content.Context;

public class CustomDialog extends AlertDialog.Builder
{

	public CustomDialog(Context context, String msg, String title) 
	{
		super(context);
		this.setMessage(msg);
		this.setPositiveButton("OK", null);
		this.setTitle(title);
		this.show();
	}
	
	public CustomDialog(Context context, String msg) 
	{
		super(context);
		this.setMessage(msg);
		this.setPositiveButton("OK", null);
	}
}
