package jp.co.doraxdora.form;

import java.util.ArrayList;

public class DisplayCard 
{
	ArrayList<Integer> cardList = new ArrayList<Integer>();
	ArrayList<Integer> cardDefault = new ArrayList<Integer>();
	Calculation Calculation = new Calculation();
	
	static int CARD_INITIAL =17;
	static int CARD_TOTAL = 54;
	
	public ArrayList<Integer> CardDefault()
	{
		cardDefault.clear();
		for (int i=1; i<=CARD_TOTAL; i++)
		{
			cardDefault.add(i);
		}
		return cardDefault;
	}
	
	public ArrayList<Integer> SelectCard()
	{
		CardDefault();
		for (int i=1; i<=CARD_INITIAL; i++)
		{
			int selectIndex = (int)(Math.random() * cardDefault.size());
			cardList.add(Calculation.Search(cardList, cardDefault.get(selectIndex)),cardDefault.get(selectIndex));
			cardDefault.remove(selectIndex);
		}		
		return cardList;
	}
		
	
}
	