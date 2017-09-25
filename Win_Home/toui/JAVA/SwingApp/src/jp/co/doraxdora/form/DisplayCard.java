package jp.co.doraxdora.form;

import java.util.ArrayList;

public class DisplayCard 
{
	ArrayList<Integer> cardDefault = new ArrayList<Integer>();
	ArrayList<Integer> cardList = new ArrayList<Integer>();	
	ArrayList<Integer> selectCardList = new ArrayList<Integer>();
	
	ArrayList<String> imagePathList = new ArrayList<String>();
	
	public int[] DisplayArea = new int[2];
	Calculation Calculation = new Calculation();
	Translation Translation = new Translation();
	
	static int CARD_INITIAL =17;
	static int CARD_TOTAL = 54;
	
	//开始新一轮游戏
	public void StartCard()
	{
		CardDefault();
		SubCard();
		ImagePath();
		DisplayArea[0] = Calculation.Area(CARD_INITIAL);
		DisplayArea[1] = DisplayArea[0] + CARD_INITIAL ;
	}
	
	//出牌
	public void OutCard()
	{
		
	}
	
	//出牌选择
	public void OutCreaseCard(int index , String selectSwitch)
	{
		switch (selectSwitch)
		{
			case "Crease":
				selectCardList.add(Calculation.Search(selectCardList, cardList.get(index - DisplayArea[0])),cardList.get(index - DisplayArea[0]));
				break;
			
			case "Reduce":
				selectCardList.remove(selectCardList.indexOf(cardList.get(index - DisplayArea[0])));
				break;
		}	
	}
	
	//分牌前所有牌初期化
	public void CardDefault()
	{
		cardDefault.clear();
		for (int i=1; i<=CARD_TOTAL; i++)
		{
			cardDefault.add(i);
		}
	}

	//分牌
	public void SubCard()
	{
		for (int i=1; i<=CARD_INITIAL; i++)
		{
			int selectIndex = (int)(Math.random() * cardDefault.size());
			cardList.add(Calculation.Search(cardList, cardDefault.get(selectIndex)),cardDefault.get(selectIndex));
			cardDefault.remove(selectIndex);
		}	
	}
	
	//图片路径
	public void ImagePath()
	{
		imagePathList.clear();
		
		for (int i=0; i<cardList.size(); i++)
		{
			imagePathList.add(Translation.TranslationPicture(cardList.get(i)));
		}
	}
}