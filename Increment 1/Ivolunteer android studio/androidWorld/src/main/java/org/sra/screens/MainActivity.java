package org.sra.screens;

import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class MainActivity extends Activity implements OnClickListener {

	
	private Button mBtnSubmit,mBtnClear;
	private EditText mEtUnm,mEtPwd;
	
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        mEtPwd=(EditText)findViewById(R.id.etpwd);
        mEtUnm=(EditText)findViewById(R.id.etunm);
        mBtnClear=(Button)findViewById(R.id.btnclear);
        mBtnSubmit=(Button)findViewById(R.id.btnsubmit);
        mBtnClear.setOnClickListener(this);
        mBtnSubmit.setOnClickListener(this);
        
        
    }
    
    
    public void closeApp(View v){
    	
		finish();
    	
    }


	@Override
	public void onClick(View v) {
		if(v==mBtnClear){
			
			mEtPwd.setText("");
			mEtUnm.setText("");
			
		}else if(v==mBtnSubmit){
			String unm=mEtUnm.getText().toString();
			String pwd=mEtPwd.getText().toString();
			
			Toast.makeText(getApplicationContext(), "UNM :"+unm+"\n PWD:"+pwd,Toast.LENGTH_SHORT).show();
			
		}
		
	}
}
