package com.example.toui.hello;

import android.content.Intent;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.View;
import android.widget.TextView;

import java.util.ArrayList;

public class Main2Activity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.content_main2);

        TextView textView = (TextView) findViewById(R.id.textView3);
        Intent intent = getIntent();
        ArrayList info = intent.getStringArrayListExtra("so");
        int n = info.size();
        String t = "";
        for (int i=0;i<n;i++)
        {
            t += (String) info.get(i) + "\n";
        }
        textView.setText(t);
    }

}
