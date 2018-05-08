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
		
		System.out.println("User1のカード：");
		for (int j = 0; j < 5; j++) {
			System.out.println(cardStructure.User1DigitalCardArray[j][0] + "," +
					cardStructure.User1DigitalCardArray[j][1] + "→" +
					ColorEnum.valueOf(cardStructure.User1DigitalCardArray[j][1]));
		}
		System.out.println("User2のカード：");
		for (int k = 0; k < 5; k++) {
			System.out.println(cardStructure.User2DigitalCardArray[k][0] + "," +
					cardStructure.User2DigitalCardArray[k][1] + "→" +
					ColorEnum.valueOf(cardStructure.User2DigitalCardArray[k][1]));
		}

		long end = System.currentTimeMillis();
		System.out.println("処理時間：" + (end - start) + "ms");		
	}
}