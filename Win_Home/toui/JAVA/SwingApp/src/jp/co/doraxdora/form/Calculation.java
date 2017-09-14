package jp.co.doraxdora.form;

import java.util.ArrayList;

public class Calculation {
	
	public int Search(ArrayList<Integer> list, int Date)
	{
		if (list.size() == 0 )
			return 0;
		int index = list.size();
		if (Date < list.get(index - 1))
			return index;
		for (int i=index-1; i>=0; i--)
		{
			if(Date < list.get(i) && Date > list.get(i+1))
			{
				return i+1;
			}
		}
		return 0;
	}

	public int Area(int Date)
	{
		return (int) Math.ceil((double)(Date + MainForm.LBLNEWLABEL_NUM)/2) - Date;
	}
}
