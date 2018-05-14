import java.util.ArrayList;
import java.util.Random;

public class tgrCardStructure {

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
		StartSubView.usingQuestionCardArray[index] = QuestionCardArray.get(num);
		QuestionCardArray.remove(num);
	}

	private void tgrCardInitialization() {
		StartSubView.User1DigitalCardArray = new int[StartSubView.SELECT_DIGITAL_SIZE][StartSubView.DIGITAL_PARAMETERS];
		StartSubView.User2DigitalCardArray = new int[StartSubView.SELECT_DIGITAL_SIZE][StartSubView.DIGITAL_PARAMETERS];
		StartSubView.usingQuestionCardArray = new int[StartSubView.SELECT_QUESTION_SIZE];
		DigitalCardArray = new ArrayList<Integer>();
		QuestionCardArray = new ArrayList<Integer>();

		for (int i = 0; i < StartSubView.DIGITAL_SIZE; i++) {
			DigitalCardArray.add(i);
		}

		for (int i = 0; i < StartSubView.QUESTION_SIZE; i++) {
			QuestionCardArray.add(i);
		}
	}

	private void tgrSelectDigitalCard() {
		int num1, num2;
		ArrayList<Integer> User1Array = new ArrayList<Integer>();
		ArrayList<Integer> User2Array = new ArrayList<Integer>();
		for (int i = 0; i < StartSubView.SELECT_DIGITAL_SIZE; i++) {
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
		StartSubView.User1DigitalCardArray = tgrDigitalCardDefind(User1Array);
		StartSubView.User2DigitalCardArray = tgrDigitalCardDefind(User2Array);
	}

	private int[][] tgrDigitalCardDefind(ArrayList<Integer> UserArray) {
		int[][] TmpArray = new int[StartSubView.SELECT_DIGITAL_SIZE][StartSubView.DIGITAL_PARAMETERS];
		for (int i = 0; i < StartSubView.SELECT_DIGITAL_SIZE; i++) {
			TmpArray[i][0] = UserArray.get(i) % 10;

			if (UserArray.get(i) % 10 == 5) {
				TmpArray[i][1] = tgrMain.ColorEnum.valueOfByName("Green").getId();
			} else {
				if (UserArray.get(i) < StartSubView.HALF_DIGITAL_SIZE) {
					TmpArray[i][1] = tgrMain.ColorEnum.valueOfByName("Red").getId();
				} else {
					TmpArray[i][1] = tgrMain.ColorEnum.valueOfByName("Blue").getId();
				}
			}
		}
		return TmpArray;
	}

	private void tgrSelectedDigitalCardSort(ArrayList<Integer> UserArray, int num) {
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
		for (int i = 0; i < StartSubView.SELECT_QUESTION_SIZE; i++) {
			num = rand.nextInt(QuestionCardArray.size());
			StartSubView.usingQuestionCardArray[i] = QuestionCardArray.get(num);
			QuestionCardArray.remove(num);
		}
	}
}