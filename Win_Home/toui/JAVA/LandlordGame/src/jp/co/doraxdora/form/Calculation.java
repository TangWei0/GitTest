package jp.co.doraxdora.form;

import java.util.ArrayList;

public class Calculation {
	static int cardNum = 20;
	
	//排序
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
	
	//随机抽牌
	public int SelectIndex(ArrayList<Integer> cardDefault)
	{	
		return (int)(Math.random() * cardDefault.size());
	}

	public int[] DisplayArea(int myCardListSize, int outCardListSize)
	{
		int[] DisplayArea = new int[2];
		if (myCardListSize != 0)
		{
			DisplayArea[0] = (int) Math.ceil((double)(myCardListSize + cardNum)/2) - myCardListSize;
		}
		else DisplayArea[0] = -1;
		
		if (outCardListSize != 0)
		{
			DisplayArea[1] = (int) Math.ceil((double)(outCardListSize + cardNum)/2) - outCardListSize;
		}
		else DisplayArea[1] = -1;
		
		return DisplayArea;
	}
	
	
}
