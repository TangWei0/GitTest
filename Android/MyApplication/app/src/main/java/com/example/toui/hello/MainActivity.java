package com.example.toui.hello;

import android.content.Intent;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.View;
import android.view.Menu;
import android.view.MenuItem;
import android.view.Window;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity {


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        getWindow().requestFeature(Window.FEATURE_ACTION_BAR);
        super.onCreate(savedInstanceState);

        setContentView(R.layout.content_main);
        Log.d("Kensyu", "OnCreated");
        Log.e("Kensyu", "OnCreated");
        Log.w("Kensyu", "OnCreated");
        Log.i("Kensyu", "OnCreated");
        Log.v("Kensyu", "OnCreated");
        Button button = (Button) findViewById(R.id.button);
        Button button1 = (Button) findViewById(R.id.button2);

        final RadioGroup radiogroup = (RadioGroup) findViewById(R.id.radiogroup);
        radiogroup.check(R.id.radioButton);



        button.setOnClickListener(new SampleButtonEventListener());

        ArrayAdapter<String> adapter = new ArrayAdapter<String>(this, android.R.layout.simple_spinner_item);
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);

        adapter.add("赤");
        adapter.add("緑");
        adapter.add("青");
        final Spinner spinner = (Spinner) findViewById(R.id.spinner);

        spinner.setAdapter(adapter);
        button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                RadioButton radiobutton = (RadioButton) findViewById(radiogroup.getCheckedRadioButtonId());
                EditText edittext = (EditText) findViewById(R.id.editText);
                String item = (String) spinner.getSelectedItem();
                Toast.makeText(MainActivity.this, item, Toast.LENGTH_SHORT).show();
            }
        });
        button1.setOnClickListener(new SmallButtonListener());

        Button button3 = (Button) findViewById(R.id.button3);
        button3.setOnClickListener(new nextPagesButtonListener());
    }

    private class nextPagesButtonListener implements View.OnClickListener{
        public void onClick(View v){
            Intent intent = new Intent();
            intent.setClass(MainActivity.this,Main2Activity.class);
            EditText edittext = (EditText) findViewById(R.id.editText);
            CheckBox checkbox1 = (CheckBox) findViewById(R.id.checkBox);
            CheckBox checkbox2 = (CheckBox) findViewById(R.id.checkBox2);
            CheckBox checkbox3 = (CheckBox) findViewById(R.id.checkBox3);
            RadioGroup radiogroup = (RadioGroup) findViewById(R.id.radiogroup);
            RadioButton radiobutton = (RadioButton) findViewById(radiogroup.getCheckedRadioButtonId());
            ArrayList info = new ArrayList();
            info.add(edittext.getText().toString());
            if (checkbox1.isChecked()){
                info.add(checkbox1.getText());
            }
            if (checkbox2.isChecked()){
                info.add(checkbox2.getText());
            }
            info.add(radiobutton.getText());
            intent.putExtra("so",info);
            startActivity(intent);
        }
    }
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuItem actionItem1 = menu.add("item1");
        MenuItem actionItem2 = menu.add("item2");
        MenuItem actionItem3 = menu.add("item3");
        MenuItem actionItem4 = menu.add("item4");

        actionItem1.setShowAsAction(MenuItem.SHOW_AS_ACTION_ALWAYS);
        actionItem2.setShowAsAction(MenuItem.SHOW_AS_ACTION_ALWAYS);
        actionItem3.setShowAsAction(MenuItem.SHOW_AS_ACTION_ALWAYS);
        actionItem4.setShowAsAction(MenuItem.SHOW_AS_ACTION_ALWAYS);

        // アイコンを設定
        actionItem1.setIcon(android.R.drawable.ic_menu_call);
        actionItem2.setIcon(android.R.drawable.ic_menu_add);
        actionItem3.setIcon(android.R.drawable.ic_menu_camera);
        actionItem4.setIcon(android.R.drawable.ic_menu_help);
        return true;
    }

    //@Override
    //public boolean onOptionsItemSelected(MenuItem item) {
      //  MenuItem actionItem1 = (MenuItem) findViewById(actionItem1)
        //return super.onOptionsItemSelected(item);
   // }

    private class SampleButtonEventListener implements View.OnClickListener {

        public void onClick(View v) {
            // Buttonが押されたら、onClickが呼び出されます。
            Spinner spinner = (Spinner) findViewById(R.id.spinner);
            String item = (String) spinner.getSelectedItem();
            Toast.makeText(MainActivity.this, item +
                    "が選択されました", Toast.LENGTH_LONG).show();
        }
    }


    private class SmallButtonListener implements View.OnClickListener {

        public void onClick(View v) {
            CheckBox checkbox1 = (CheckBox) findViewById(R.id.checkBox);
            CheckBox checkbox2 = (CheckBox) findViewById(R.id.checkBox2);
            CheckBox checkbox3 = (CheckBox) findViewById(R.id.checkBox3);
            if ((checkbox1.isChecked() || checkbox2.isChecked() || checkbox3.isChecked()) == true) {
                String chktxt = "が選択されました";
                String chk = "";
                if (checkbox1.isChecked()) {
                    chk = chk + checkbox1.getText();
                }
                if (checkbox2.isChecked()) {
                    if (chk.isEmpty()) {
                        chk = chk + checkbox2.getText();
                    } else
                        chk = chk + "と" + checkbox2.getText();
                }
                if (checkbox3.isChecked()) {
                    if (chk.isEmpty()) {
                        chk = chk + checkbox3.getText();
                    } else
                        chk = chk + "と" + checkbox3.getText();
                }
                Toast.makeText(MainActivity.this, chk + chktxt, Toast.LENGTH_LONG).show();
            } else
                Toast.makeText(MainActivity.this, "選択されません", Toast.LENGTH_LONG).show();

        }

    }
}