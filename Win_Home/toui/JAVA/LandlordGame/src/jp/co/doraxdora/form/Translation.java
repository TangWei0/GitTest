package jp.co.doraxdora.form;

public class Translation {
	
	static String rootPath = System.getProperty("user.dir")+ "\\Picture\\";
	static int CLASSIFY = 4;
	
	public String TranslationPicture (int Date)
	{
		String path = rootPath;
		int classNum = (int) Math.ceil((double)Date/CLASSIFY);
		int classColor = Date % CLASSIFY;
		return path + ClassNum(classNum) + ClassColor(classColor, classNum);
	}
	
	String ClassNum(int classNum)
	{
		String numPath= "";
		switch (classNum)
		{
			case 1:
				numPath = "3_";
				break;
			case 2:
				numPath = "4_";
				break;
			case 3:
				numPath = "5_";
				break;
			case 4:
				numPath = "6_";
				break;
			case 5:
				numPath = "7_";
				break;
			case 6:
				numPath = "8_";
				break;
			case 7:
				numPath = "9_";
				break;
			case 8:
				numPath = "10_";
				break;
			case 9:
				numPath = "J_";
				break;
			case 10:
				numPath = "Q_";
				break;
			case 11:
				numPath = "K_";
				break;
			case 12:
				numPath = "A_";
				break;
			case 13:
				numPath = "2_";
				break;
			case 14:
				numPath = "Joker_";
				break;
		}
		return numPath;
	}
	
	String ClassColor(int classColor, int classNum)
	{
		String numPath= "";
		switch (classColor)
		{
			case 0:
				numPath = "BlackPeach.png";
				break;
			case 1:
			if (classNum == 14)
			    numPath = "Small.png";
			else 
				numPath = "GrassFlowers.png";
				break;
			case 2:
			if (classNum == 14)
			    numPath = "Big.png";
			else 
				numPath = "SquarePiece.png";
				break;
			case 3:
				numPath = "RedHeart.png";
				break;
		}
		return numPath;
	}
}
