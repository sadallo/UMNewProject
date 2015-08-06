package com.julian.controls;

import android.app.AlertDialog;
import android.content.Context;
import android.widget.EditText;

public class CustomInputDialog extends AlertDialog.Builder
{
	private EditText input;
		
	public CustomInputDialog(Context context, String msg, String hint)
	{
		super(context);
		this.setMessage(msg);
		// Set an EditText view to get user input 
		input = new EditText(context);
		input.setHint(hint);		
		this.setView(input);
	}

	public EditText getInput() 
	{
		return input;
	}

	public void setInput(EditText input) 
	{
		this.input = input;
	}

	
	
	
}
