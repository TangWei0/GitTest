package jp.co.doraxdora.form;

import java.util.ArrayList;

public class Calculation {
	
	public int Search(ArrayList<Integer> list, int Data)
	{
		int index = 1;
		if (list.size() == 0 )
			return 0;
		do{
			  index++;
		}while(Data > list.get(index) );		
		return index;
	}

}
