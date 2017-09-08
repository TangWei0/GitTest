package com.example.itou1.game2048;

import android.app.AlertDialog;
import android.content.Context;
import android.graphics.Point;
import android.test.mock.MockDialogInterface;
import android.util.AttributeSet;
import android.view.MotionEvent;
import android.view.View;
import android.widget.GridLayout;

import java.util.ArrayList;

public class GameView extends GridLayout{
    private Card[][] cardMap = new Card [6][6];
    private ArrayList<Point> emptyPoints = new ArrayList<>();

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
        setColumnCount(6);
        setBackgroundColor(0xFFBBADA0);
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
                                MoveLeft();
                            }else if (offsetX > 8){
                                MoveRight();
                            }
                        } else {
                            if (offsetY < -8) {
                                MoveUp();
                            }else if (offsetY > 8){
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

        boolean move = false;

        for (int i = 0; i < 6; i++) {
            for (int j = 0; j < 6; j++) {
                for (int y = j + 1 ; y < 6 ; y++) {
                    if (cardMap[i][y].getNumber() > 0) {
                        if (cardMap[i][j].getNumber() <= 0) {
                            cardMap[i][j].setNumber(cardMap[i][y].getNumber());
                            cardMap[i][y].setNumber(0);
                            y = j + 1;
                            move = true;
                        } else if (cardMap[i][j].equals(cardMap[i][y])) {
                            cardMap[i][j].setNumber(cardMap[i][j].getNumber() * 2);
                            cardMap[i][y].setNumber(0);
                            MainActivity.getMainActivity().addScore(cardMap[i][j].getNumber());
                            move = true;
                        }
                    }
                }
            }
        }

        if (move) {
            addRandomNumber();
            checkGame();
        }
    }

    private void MoveRight(){
        boolean move = false;

        for (int i = 0; i < 6; i++) {
            for (int j = 5; j >= 0; j--) {
                for (int y = j - 1 ; y >= 0 ; y--) {
                    if (cardMap[i][y].getNumber() > 0) {
                        if (cardMap[i][j].getNumber() <= 0) {
                            cardMap[i][j].setNumber(cardMap[i][y].getNumber());
                            cardMap[i][y].setNumber(0);
                            y = j - 1;
                            move = true;
                        } else if (cardMap[i][j].equals(cardMap[i][y])) {
                            cardMap[i][j].setNumber(cardMap[i][j].getNumber() * 2);
                            cardMap[i][y].setNumber(0);
                            MainActivity.getMainActivity().addScore(cardMap[i][j].getNumber());
                            move = true;
                        }
                    }
                }
            }
        }
        if (move) {
            addRandomNumber();
            checkGame();
        }
    }

    private void MoveUp() {
        boolean move = false;

        for (int j = 0; j < 6; j++) {
            for (int i = 0; i < 6; i++) {
                for (int x = i + 1 ; x < 6 ; x++) {
                    if (cardMap[x][j].getNumber() > 0) {
                        if (cardMap[i][j].getNumber() <= 0) {
                            cardMap[i][j].setNumber(cardMap[x][j].getNumber());
                            cardMap[x][j].setNumber(0);
                            x = i + 1;
                            move = true;
                        } else if (cardMap[i][j].equals(cardMap[x][j])) {
                            cardMap[i][j].setNumber(cardMap[i][j].getNumber() * 2);
                            cardMap[x][j].setNumber(0);
                            MainActivity.getMainActivity().addScore(cardMap[i][j].getNumber());
                            move = true;
                        }
                    }
                }
            }
        }
        if (move) {
            addRandomNumber();
            checkGame();
        }
    }

    private void MoveDown(){
        boolean move = false;

        for (int j = 0; j < 6; j++) {
            for (int i = 5; i >= 0; i--) {
                for (int x = i - 1 ; x >= 0 ; x--) {
                    if (cardMap[x][j].getNumber() > 0) {
                        if (cardMap[i][j].getNumber() <= 0) {
                            cardMap[i][j].setNumber(cardMap[x][j].getNumber());
                            cardMap[x][j].setNumber(0);
                            x = i - 1;
                            move = true;
                        } else if (cardMap[i][j].equals(cardMap[x][j])) {
                            cardMap[i][j].setNumber(cardMap[i][j].getNumber() * 2);
                            cardMap[x][j].setNumber(0);
                            MainActivity.getMainActivity().addScore(cardMap[i][j].getNumber());
                            move = true;
                        }
                    }
                }
            }
        }
        if (move) {
            addRandomNumber();
            checkGame();
        }
    }

    private void checkGame() {
        boolean complete = true;

        ALL:
        for (int i = 0; i < 6; i++) {
            for (int j = 0; j < 6; j++) {
                if (cardMap[i][j].getNumber() <= 0 ||
                        (i > 0 && cardMap[i][j].equals(cardMap[i - 1][j])) ||
                        (i < 6 && cardMap[i][j].equals(cardMap[i + 1][j])) ||
                        (j > 0 && cardMap[i][j].equals(cardMap[i][j - 1])) ||
                        (j < 6 && cardMap[i][j].equals(cardMap[i][j + 1]))) {
                    complete = false;
                    break ALL;
                }
            }
        }

        if (complete) {

        }
    }

    private void startGame() {
        //MainActivity.getMainActivity().clearScore();

        for (int i = 0; i < 6; i++) {
            for  (int j = 0; j < 6; j++) {
                cardMap[i][j].setNumber(0);
            }
        }

        addRandomNumber();
        addRandomNumber();
    }

    @Override
    protected  void  onSizeChanged(int w, int h, int oldw, int oldh) {
        super.onSizeChanged(w,h,oldw,oldh);

        int cardSize = (Math.min(w,h) - 10) / 6;
        addCards(cardSize);

        startGame();
    }

    private void addCards(int cardSize) {
        Card card;

        for (int i = 0; i < 6; i++) {
            for (int j = 0; j < 6; j++) {
                card = new Card(getContext());
                card.setNumber(0);
                addView(card, cardSize, cardSize);
                cardMap[i][j] = card;
            }
        }
    }

    private  void addRandomNumber() {
        emptyPoints.clear();

        for (int i = 0; i < 6; i++) {
            for (int j = 0; j < 6; j++) {
                if (cardMap[i][j].getNumber() <= 0) {
                    emptyPoints.add(new Point(i,j));
                }
            }
        }

        Point point = emptyPoints.remove((int) (Math.random() * emptyPoints.size()));
        cardMap[point.x][point.y].setNumber(Math.random() > 0.1 ? 2 : 4);
    }

}
