package com.example.itou1.game2048;

import android.content.Context;
import android.view.Gravity;
import android.widget.FrameLayout;
import android.widget.TextView;

public class Card extends FrameLayout {

    private int number = 0;
    private TextView tvNumber;

    public Card (Context context) {
        super(context);

        tvNumber = new TextView(getContext());
        tvNumber.setTextSize(32);
        tvNumber.setBackgroundColor(0x33FFFFFF);
        tvNumber.setGravity(Gravity.CENTER);

        LayoutParams lp = new LayoutParams(-1,-1);
        lp.setMargins(10, 10, 0, 0);
        addView(tvNumber,lp);

        setNumber(0);
    }

    public int getNumber() {
        return number;
    }

    public void setNumber(int number) {
        this.number = number;

        if (number > 0) {
            tvNumber.setText(number + "");
        } else {
            tvNumber.setText("");
        }
    }

    public boolean equals(Card o){
        return getNumber() == o.getNumber();
    }

}
