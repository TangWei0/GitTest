package com.example.itou1.game2048;

import android.content.Context;
import android.util.AttributeSet;
import android.view.MotionEvent;
import android.view.View;
import android.widget.GridLayout;

public class GameView extends GridLayout{
    public GameView(Context context){
        super(context);
        initGameView();
    }

    public GameView(Context context, AttributeSet attrs){
        super(context,attrs);
        initGameView();
    }

    public GameView(Context context, AttributeSet attrs, int defStyle){
        super(context,attrs,defStyle);
        initGameView();
    }

    private void initGameView(){
        setOnTouchListener(new View.OnTouchListener(){

            private float startX, startY;
            private float endX, endY;
            private float offsetX, offsetY;

            @Override
            public boolean onTouch (View v, MotionEvent event){

                switch(event.getAction()){
                    case MotionEvent.ACTION_DOWN:
                        startX = event.getX();
                        startY = event.getY();
                        break;
                    case MotionEvent.ACTION_UP:
                        endX = event.getX();
                        endY = event.getY();

                        offsetX = endX - startX;
                        offsetY = endY - startY;

                        if (Math.abs(offsetX) > Math.abs(offsetY)){
                            if (offsetX < -8) {
                                System.out.println("Left");
                                MoveLeft();
                            }else if (offsetX > 8){
                                System.out.println("Right");
                                MoveRight();
                            }
                        } else {
                            if (offsetY < -8) {
                                System.out.println("Up");
                                MoveUp();
                            }else if (offsetY > 8){
                                System.out.println("Down");
                                MoveDown();
                            }
                        }
                        break;
                }
                return true;
            }
        });
    }

    private void MoveLeft(){

    }

    private void MoveRight(){

    }

    private void MoveUp(){

    }

    private void MoveDown(){

    }
}
