package jp.co.doraxdora.form;

import java.util.ArrayList;


public class DisplayCard 
{
	int num =(int)(Math.random() * 3) + 1;
	int cardNumber = 1;

		
	public String CardDisplay(int i)
	{
		String s ="";
		switch(i)
		{
		    case 1:
		    	s = "C:\\Users\\itou1\\Desktop\\GitTest\\work\\toui\\JAVA\\SwingApp\\Picture\\A_GrassFlowers.png";
		    break;
		    case 2:
		    	s = "C:\\Users\\itou1\\Desktop\\GitTest\\work\\toui\\JAVA\\SwingApp\\Picture\\A_SquarePiece.png";
		    break;
		    case 3:
		    	s = "C:\\Users\\itou1\\Desktop\\GitTest\\work\\toui\\JAVA\\SwingApp\\Picture\\A_RedHeart.png";
		    break;
		    case 4:
		    	s = "C:\\Users\\itou1\\Desktop\\GitTest\\work\\toui\\JAVA\\SwingApp\\Picture\\A_BlackPeach.png";
		    break;
		}
		return s;
	}
}
	