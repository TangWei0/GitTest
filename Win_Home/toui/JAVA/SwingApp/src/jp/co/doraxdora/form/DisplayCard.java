package jp.co.doraxdora.form;

import java.util.ArrayList;

public class DisplayCard 
{
	ArrayList<Integer> cardList = new ArrayList<Integer>();
	ArrayList<Integer> cardDefault = new ArrayList<Integer>();
	public int[] DisplayArea = new int[2];
	Calculation Calculation = new Calculation();
	Translation Translation = new Translation();
	
	static int CARD_INITIAL =17;
	static int CARD_TOTAL = 54;
	
	//开始新一轮游戏
	void StartCard()
	{
		CardDefault();
		SubCard();
		DisplayArea[0] = Calculation.Area(CARD_INITIAL);
		DisplayArea[1] = DisplayArea[0] + CARD_INITIAL ;
	}
	
	//分牌前所有牌初期化
	void CardDefault()
	{
		cardDefault.clear();
		for (int i=1; i<=CARD_TOTAL; i++)
		{
			cardDefault.add(i);
		}
	}

	//每人分牌17张
	void SubCard()
	{
		for (int i=1; i<=CARD_INITIAL; i++)
		{
			int selectIndex = (int)(Math.random() * cardDefault.size());
			cardList.add(Calculation.Search(cardList, cardDefault.get(selectIndex)),cardDefault.get(selectIndex));
			cardDefault.remove(selectIndex);
		}
	}

}