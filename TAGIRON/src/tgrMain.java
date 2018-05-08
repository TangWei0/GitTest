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

	// �萔���`����
	static int DIGITALPARAMETERS = 2;
	static int DIGITALSIZE = 20;
	static int DIGITALHALFSIZE = 10;
	static int SELECTDIGITALSIZE = 5;
	static int QUESTIONSIZE = 21;
	static int SELECTQUESTIONSIZE = 6;

	// ���I�����J�[�h���`����
	public static Integer[][] User1DigitalCardArray = new Integer[SELECTDIGITALSIZE][DIGITALPARAMETERS];
	public static Integer[][] User2DigitalCardArray = new Integer[SELECTDIGITALSIZE][DIGITALPARAMETERS];

	// ���J�[�h���`����
	public static Integer[] usingQuestionCardArray = new Integer[SELECTQUESTIONSIZE];
	public static Integer[] usedQuestionCardArray = new Integer[QUESTIONSIZE];

	static tgrCardStructure cardStructure = new tgrCardStructure();

	/**
	 * ���C�����\�b�h.
	 * 
	 * @param args
	 */
	static public void main(String[] args) {
		long start = System.currentTimeMillis();

		// �v���������������L�q
		cardStructure.tgrSelectDigitalCard();
		cardStructure.tgrSelectQuestionCard();

		System.out.println("User1�̃J�[�h�F");
		for (int j = 0; j < 5; j++) {
			if (j == 4) {
				System.out.println("[" + User1DigitalCardArray[j][0] + "," + ColorEnum.valueOf(User1DigitalCardArray[j][1]) + "]");
			} else {
				System.out.print("[" + User1DigitalCardArray[j][0] + "," + ColorEnum.valueOf(User1DigitalCardArray[j][1]) + "],");
			}
		}

		System.out.println("User2�̃J�[�h�F");
		for (int k = 0; k < 5; k++) {
			if (k == 4) {
				System.out.println("[" + User2DigitalCardArray[k][0] + "," + ColorEnum.valueOf(User2DigitalCardArray[k][1]) + "]");
			} else {
				System.out.print("[" + User2DigitalCardArray[k][0] + "," + ColorEnum.valueOf(User2DigitalCardArray[k][1]) + "],");
			}
		}

		System.out.println("���J�[�h�F");
		for (int i = 0; i < 6; i++) {
			System.out.println("���J�[�h�ԍ�" + usingQuestionCardArray[i] + ":" + tgrQuestionShow(usingQuestionCardArray[i]));
		}

		long end = System.currentTimeMillis();
		System.out.println("�������ԁF" + (end - start) + "ms");
	}

	public static String tgrQuestionShow(int num) {
		String title = "";
		switch (num) {
		case 0:
			title = "8�܂���9�͂ǂ��H";
			break;
		case 1:
			title = "1�܂���2�͂ǂ��H";
			break;
		case 2:
			title = "�A�ԂɂȂ��Ă���^�C���͂ǂ��H";
			break;
		case 3:
			title = "�̐����^�C���͉�������H";
			break;
		case 4:
			title = "�����͉�������H";
			break;
		case 5:
			title = "�Ԃ̐����^�C���͉�������H";
			break;
		case 6:
			title = "�Ԃ̐��̍��v���́H";
			break;
		case 7:
			title = "�̐��̍��v���́H";
			break;
		case 8:
			title = "5���̃^�C�����ׂĂ̍��v���́H";
			break;
		case 9:
			title = "3�܂���4�͂ǂ��H";
			break;
		case 10:
			title = "���������^�C���̃y�A�͉��g����H";
			break;
		case 11:
			title = "�����̐����^�C����5�ȏ�H4�ȉ��H";
			break;
		case 12:
			title = "��͉�������H";
			break;
		case 13:
			title = "0�͂ǂ��H";
			break;
		case 14:
			title = "�����^�C���̍ő�̐�����ŏ��̐������������́H";
			break;
		case 15:
			title = "�A�����ĂƂȂ荇���Ă���F�͂ǂ��H";
			break;
		case 16:
			title = "�������ق�����3���̍��v���́H";
			break;
		case 17:
			title = "6�܂���7�͂ǂ��H";
			break;
		case 18:
			title = "������3���̍��v���́H";
			break;
		case 19:
			title = "5�͂ǂ��H";
			break;
		case 20:
			title = "�傫���ق�����3���̍��v���́H";
			break;
		default:
			break;
		}
		return title;
	}
}