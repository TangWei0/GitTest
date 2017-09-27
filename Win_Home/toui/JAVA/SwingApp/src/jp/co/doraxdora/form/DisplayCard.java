package jp.co.doraxdora.form;

import java.util.ArrayList;

public class DisplayCard 
{
	ArrayList<Integer> cardDefault = new ArrayList<Integer>();
	ArrayList<Integer> myCardList = new ArrayList<Integer>();	
	ArrayList<Integer> selectCardList = new ArrayList<Integer>();
	ArrayList<Integer> outCardList = new ArrayList<Integer>();
	
	ArrayList<String> myCardPathList = new ArrayList<String>();
	ArrayList<String> outCardPathList = new ArrayList<String>();
	
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
		DisplayArea = Calculation.DisplayArea(myCardList.size(),outCardList.size());
	}
	
	//出牌
	public void OutCard()
	{
		outCardList = new ArrayList<Integer>(selectCardList);
		outCardPathList = ImagePath(outCardList);
		for (int i=0;i<selectCardList.size();i++)
		{
			myCardList.remove(myCardList.indexOf(selectCardList.get(i)));
		}
		myCardPathList = ImagePath(myCardList);
		DisplayArea = Calculation.DisplayArea(myCardList.size(),outCardList.size());
		selectCardList.clear();
		
	}
	
	//出牌选择
	public void OutSelectCard(int index , String selectSwitch)
	{
		switch (selectSwitch)
		{
			case "Crease":
				selectCardList.add(Calculation.Search(selectCardList, myCardList.get(index - DisplayArea[0])),myCardList.get(index - DisplayArea[0]));
				break;
			
			case "Reduce":
				selectCardList.remove(selectCardList.indexOf(myCardList.get(index - DisplayArea[0])));
				break;
		}	
	}
	
	//初始化
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
			myCardList.add(Calculation.Search(myCardList, cardDefault.get(selectIndex)),cardDefault.get(selectIndex));
			cardDefault.remove(selectIndex);
		}
		myCardPathList = ImagePath(myCardList);
	
	}
	
	//牌面图像路径
	public ArrayList<String> ImagePath(ArrayList<Integer> list)
	{
		ArrayList<String> imagePathList = new ArrayList<String>();
		
		for (int i=0; i<list.size(); i++)
		{
			imagePathList.add(Translation.TranslationPicture(list.get(i)));
		}
		
		return imagePathList;
	}
}