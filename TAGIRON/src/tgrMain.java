public class tgrMain {
	public enum ColorEnum {
		Red(1, "Red"), Blue(2, "Blue"), Green(3, "Green");

		private int id;
		private String color;

		public int getId() {
			return id;
		}

		public String getColor() {
			return color;
		}

		private ColorEnum(int id, String color) {
			this.id = id;
			this.color = color;
		}

		public static ColorEnum valueOf(int id) {
			ColorEnum[] array = values();
			for (ColorEnum num : array) {
				if (id == num.getId()) {
					return num;
				}
			}
			return null;
		}

		public static ColorEnum valueOfByName(String color) {
			ColorEnum[] array = values();
			for (ColorEnum num : array) {
				if (color.equals(num.getColor())) {
					return num;
				}
			}
			return null;
		}
	}

	// 定数を定義する
	static int DIGITALPARAMETERS = 2;
	static int DIGITALSIZE = 20;
	static int DIGITALHALFSIZE = 10;
	static int SELECTDIGITALSIZE = 5;
	static int QUESTIONSIZE = 21;
	static int SELECTQUESTIONSIZE = 6;

	// 抽選数字カードを定義する
	public static Integer[][] User1DigitalCardArray = new Integer[SELECTDIGITALSIZE][DIGITALPARAMETERS];
	public static Integer[][] User2DigitalCardArray = new Integer[SELECTDIGITALSIZE][DIGITALPARAMETERS];

	// 問題カードを定義する
	public static Integer[] usingQuestionCardArray = new Integer[SELECTQUESTIONSIZE];
	public static Integer[] usedQuestionCardArray = new Integer[QUESTIONSIZE];

	static tgrCardStructure cardStructure = new tgrCardStructure();

	/**
	 * メインメソッド.
	 * 
	 * @param args
	 */
	static public void main(String[] args) {
		long start = System.currentTimeMillis();

		// 計測したい処理を記述
		cardStructure.tgrSelectDigitalCard();
		cardStructure.tgrSelectQuestionCard();

		System.out.println("User1のカード：");
		for (int j = 0; j < 5; j++) {
			if (j == 4) {
				System.out.println("[" + User1DigitalCardArray[j][0] + "," + ColorEnum.valueOf(User1DigitalCardArray[j][1]) + "]");
			} else {
				System.out.print("[" + User1DigitalCardArray[j][0] + "," + ColorEnum.valueOf(User1DigitalCardArray[j][1]) + "],");
			}
		}

		System.out.println("User2のカード：");
		for (int k = 0; k < 5; k++) {
			if (k == 4) {
				System.out.println("[" + User2DigitalCardArray[k][0] + "," + ColorEnum.valueOf(User2DigitalCardArray[k][1]) + "]");
			} else {
				System.out.print("[" + User2DigitalCardArray[k][0] + "," + ColorEnum.valueOf(User2DigitalCardArray[k][1]) + "],");
			}
		}

		System.out.println("問題カード：");
		for (int i = 0; i < 6; i++) {
			System.out.println("問題カード番号" + usingQuestionCardArray[i] + ":" + tgrQuestionShow(usingQuestionCardArray[i]));
		}

		long end = System.currentTimeMillis();
		System.out.println("処理時間：" + (end - start) + "ms");
	}

	public static String tgrQuestionShow(int num) {
		String title = "";
		switch (num) {
		case 0:
			title = "8または9はどこ？";
			break;
		case 1:
			title = "1または2はどこ？";
			break;
		case 2:
			title = "連番になっているタイルはどこ？";
			break;
		case 3:
			title = "青の数字タイルは何枚ある？";
			break;
		case 4:
			title = "偶数は何枚ある？";
			break;
		case 5:
			title = "赤の数字タイルは何枚ある？";
			break;
		case 6:
			title = "赤の数の合計数は？";
			break;
		case 7:
			title = "青の数の合計数は？";
			break;
		case 8:
			title = "5枚のタイルすべての合計数は？";
			break;
		case 9:
			title = "3または4はどこ？";
			break;
		case 10:
			title = "同じ数字タイルのペアは何組ある？";
			break;
		case 11:
			title = "中央の数字タイルの5以上？4以下？";
			break;
		case 12:
			title = "奇数は何枚ある？";
			break;
		case 13:
			title = "0はどこ？";
			break;
		case 14:
			title = "数字タイルの最大の数から最小の数を引いた数は？";
			break;
		case 15:
			title = "連続してとなり合っている色はどこ？";
			break;
		case 16:
			title = "小さいほうから3枚の合計数は？";
			break;
		case 17:
			title = "6または7はどこ？";
			break;
		case 18:
			title = "中央の3枚の合計数は？";
			break;
		case 19:
			title = "5はどこ？";
			break;
		case 20:
			title = "大きいほうから3枚の合計数は？";
			break;
		default:
			break;
		}
		return title;
	}
}