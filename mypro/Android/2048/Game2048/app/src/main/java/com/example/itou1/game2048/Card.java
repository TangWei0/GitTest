package com.example.itou1.game2048;

import android.content.Context;
import android.widget.FrameLayout;
import android.widget.TextView;

public class Card extends FrameLayout {
    public Card (Context context) {
        super(context);

        tvNumber = new TextView(getContext());
        tvNumber.setTextSize(32);

        LayoutParams lp = new LayoutParams(-1,-1);
        addView(tvNumber,lp);

        setNumber(0);
    }

    public int getNumber() {
        return number;
    }

    public void setNumber(int number) {
        this.number = number;

        tvNumber.setText(number + "");
    }

    private int number = 0;
    private TextView tvNumber;
}
