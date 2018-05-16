package process;

import static constants.MathConstants.*;

import java.util.ArrayList;
import java.util.Random;

import panels.tgrMain;

public class tgrCardStructure {

	// カラー列挙子名宣言
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

	public ArrayList<Integer> DigitalCardArray = new ArrayList<Integer>();
	public ArrayList<Integer> QuestionCardArray = new ArrayList<Integer>();

	Random rand = new Random();

	// STARTボタンを押した後、数字カードと問題カードを抽選する
	public void tgrCardDefind() {

		// 数字カードと問題カードを初期化する
		tgrCardInitialization();

		// 数字カードと問題カードを抽選する
		tgrSelectDigitalCard();
		tgrSelectQuestionCard();
	}

	public void tgrSupplementQuestionCard(int index) {
		int num = rand.nextInt(QuestionCardArray.size());
		tgrMain.usingQuestionCardArray[index] = QuestionCardArray.get(num);
		QuestionCardArray.remove(num);
	}

	private void tgrCardInitialization() {
		tgrMain.User1DigitalCardArray = new int[SELECT_DIGITAL_SIZE][DIGITAL_PARAMETERS];
		tgrMain.User2DigitalCardArray = new int[SELECT_DIGITAL_SIZE][DIGITAL_PARAMETERS];
		tgrMain.usingQuestionCardArray = new int[SELECT_QUESTION_SIZE];
		DigitalCardArray = new ArrayList<Integer>();
		QuestionCardArray = new ArrayList<Integer>();

		for (int i = 0; i < DIGITAL_SIZE; i++) {
			DigitalCardArray.add(i);
		}

		for (int i = 0; i < QUESTION_SIZE; i++) {
			QuestionCardArray.add(i);
		}
	}

	private void tgrSelectDigitalCard() {
		int num1, num2;
		ArrayList<Integer> User1Array = new ArrayList<Integer>();
		ArrayList<Integer> User2Array = new ArrayList<Integer>();
		for (int i = 0; i < SELECT_DIGITAL_SIZE; i++) {
			do {
				num1 = rand.nextInt(DigitalCardArray.size());
				num2 = rand.nextInt(DigitalCardArray.size());
			} while (num1 == num2);
			tgrSelectedDigitalCardSort(User1Array, DigitalCardArray.get(num1));
			tgrSelectedDigitalCardSort(User2Array, DigitalCardArray.get(num2));
			if (num1 < num2) {
				int tmp = num2;
				num2 = num1;
				num1 = tmp;
			}
			DigitalCardArray.remove(num1);
			DigitalCardArray.remove(num2);
		}
		tgrMain.User1DigitalCardArray = tgrDigitalCardDefind(User1Array);
		tgrMain.User2DigitalCardArray = tgrDigitalCardDefind(User2Array);
	}

	private static int[][] tgrDigitalCardDefind(ArrayList<Integer> UserArray) {
		int[][] TmpArray = new int[SELECT_DIGITAL_SIZE][DIGITAL_PARAMETERS];
		for (int i = 0; i < SELECT_DIGITAL_SIZE; i++) {
			TmpArray[i][0] = UserArray.get(i) % 10;

			if (UserArray.get(i) % 10 == 5) {
				TmpArray[i][1] = ColorEnum.valueOfByName("Green").getId();
			} else {
				if (UserArray.get(i) < HALF_DIGITAL_SIZE) {
					TmpArray[i][1] = ColorEnum.valueOfByName("Red").getId();
				} else {
					TmpArray[i][1] = ColorEnum.valueOfByName("Blue").getId();
				}
			}
		}
		return TmpArray;
	}

	private static void tgrSelectedDigitalCardSort(ArrayList<Integer> UserArray, int num) {
		if (UserArray.size() == 0) {
			UserArray.add(num);
			return;
		}
		for (int i = 0; i < UserArray.size(); i++) {
			if (num % 10 == UserArray.get(i) % 10) {
				if (num < UserArray.get(i)) {
					UserArray.add(i, num);
					return;
				} else {
					UserArray.add(i + 1, num);
					return;
				}
			}
			if (num % 10 < UserArray.get(i) % 10) {
				UserArray.add(i, num);
				return;
			}
			if (i == UserArray.size() - 1) {
				UserArray.add(num);
				return;
			}
		}
	}

	private void tgrSelectQuestionCard() {
		int num;
		for (int i = 0; i < SELECT_QUESTION_SIZE; i++) {
			num = rand.nextInt(QuestionCardArray.size());
			tgrMain.usingQuestionCardArray[i] = QuestionCardArray.get(num);
			QuestionCardArray.remove(num);
		}
	}
}