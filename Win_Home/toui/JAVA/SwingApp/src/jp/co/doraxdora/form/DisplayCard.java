package jp.co.doraxdora.form;

import java.util.ArrayList;
import java.util.Collections;

public class DisplayCard 
{
	ArrayList<Integer> cardList = new ArrayList<Integer>();
	ArrayList<Integer> cardDefault = new ArrayList<Integer>();
	Calculation Calculation = new Calculation();
	
	int num =(int)(Math.random() * 20) + 1;
	
	public ArrayList<Integer> CardDefault()
	{
		cardDefault.clear();
		for (int i=1; i<=54; i++)
		{
			cardDefault.add(i);
		}
		return cardDefault;
	}
	
	public ArrayList<Integer> SelectCard()
	{
		CardDefault();
		for (int i=1; i<=num; i++)
		{
			int selectIndex = (int)(Math.random() * cardDefault.size());
			cardList.add(Calculation.Search(cardList, cardDefault.get(selectIndex)),cardDefault.get(selectIndex));
			cardDefault.remove(selectIndex);
		}		
		return cardList;
	}
		
	public String CardDisplay(int i)
	{
		String s ="";
		switch(i)
		{
		    case 1:
		    	s = "C:\\Users\\itou1\\Desktop\\GitTest\\Win_Home\\toui\\JAVA\\SwingApp\\Picture\\A_GrassFlowers.png";
		    break;
		    case 2:
		    	s = "C:\\Users\\itou1\\Desktop\\GitTest\\Win_Home\\toui\\JAVA\\SwingApp\\Picture\\A_SquarePiece.png";
		    break;
		    case 3:
		    	s = "C:\\Users\\itou1\\Desktop\\GitTest\\Win_Home\\toui\\JAVA\\SwingApp\\Picture\\A_RedHeart.png";
		    break;
		    case 4:
		    	s = "C:\\Users\\itou1\\Desktop\\GitTest\\Win_Home\\toui\\JAVA\\SwingApp\\Picture\\A_BlackPeach.png";
		    break;
		}
		return s;
	}
}
	