package com.example.itou1.game2048;

import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.widget.TextView;


public class MainActivity extends AppCompatActivity {
    private TextView tvScore;
    private static MainActivity mainActivity = null;
    private int score = 0;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        tvScore = (TextView)findViewById(R.id.tvScore);

        mainActivity = this;
    }

    public static MainActivity getMainActivity() {
        return  mainActivity;
    }

    public void clearScore() {
        score = 0;
        showScore();
    }

    public void showScore() {
        tvScore.setText(score + "");
    }

    public void addScore(int s) {
        score += s;
        showScore();
    }
}

