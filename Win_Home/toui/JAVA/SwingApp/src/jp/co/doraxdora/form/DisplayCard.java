package jp.co.doraxdora.form;

import java.util.ArrayList;

public class DisplayCard 
{
	ArrayList<Integer> cardDefault = new ArrayList<Integer>();
	ArrayList<Integer> cardList = new ArrayList<Integer>();	
	ArrayList<Integer> selectCardList = new ArrayList<Integer>();
	ArrayList<Integer> outCardList = new ArrayList<Integer>();
	
	ArrayList<String> imagePathList = new ArrayList<String>();
	
	public int[] DisplayArea = new int[2];
	Calculation Calculation = new Calculation();
	Translation Translation = new Translation();
	
	static int CARD_INITIAL =17;
	static int CARD_TOTAL = 54;
	
	//ゲーム開始
	public void StartCard()
	{
		CardDefault();
		SubCard();
		DisplayArea[0] = Calculation.Area(CARD_INITIAL);
		DisplayArea[1] = DisplayArea[0] + CARD_INITIAL ;
	}
	
	//カード出す
	@SuppressWarnings("unchecked")
	public void OutCard()
	{
		outCardList.clear();
		outCardList = (ArrayList<Integer>) selectCardList.clone();
		
		for (int i=0;i<selectCardList.size();i++)
		{
			cardList.remove(cardList.indexOf(selectCardList.get(i)));
		}
	}
	
	//カード選択
	public void OutSelectCard(int index , String selectSwitch)
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
	
	//カード初期化
	public void CardDefault()
	{
		cardDefault.clear();
		for (int i=1; i<=CARD_TOTAL; i++)
		{
			cardDefault.add(i);
		}
	}

	//カード配る
	public void SubCard()
	{
		for (int i=1; i<=CARD_INITIAL; i++)
		{
			int selectIndex = (int)(Math.random() * cardDefault.size());
			cardList.add(Calculation.Search(cardList, cardDefault.get(selectIndex)),cardDefault.get(selectIndex));
			cardDefault.remove(selectIndex);
		}
		ImagePath(cardList);
	}
	
	//カード写真パスを求める
	public void ImagePath(ArrayList<Integer> list)
	{
		imagePathList.clear();
		
		for (int i=0; i<list.size(); i++)
		{
			imagePathList.add(Translation.TranslationPicture(list.get(i)));
		}
	}
}