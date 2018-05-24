package Process;

import static Declaration.MathConstants.*;
import static Declaration.Variable.*;

import java.util.ArrayList;
import java.util.Random;

import Panels.tgrMain;

public class tgrCardStructure {

	private static int[] num = new int[USER_COUNT];
	private static ArrayList<ArrayList<Integer>> UserArray = new ArrayList<ArrayList<Integer>>();
	private static ArrayList<Integer> TmpArray = new ArrayList<Integer>();
	private static int selectValue, compareValue;

	private Random rand = new Random();

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
		UsingQuestionCardArray[index] = QuestionCardArray.get(num);
		QuestionCardArray.remove(num);
	}

	private void tgrCardInitialization() {
		UserDigitalCardArray = new int[USER_COUNT][SELECT_DIGITAL_SIZE][DIGITAL_PARAMETERS];
		UsingQuestionCardArray = new int[SELECT_QUESTION_SIZE];
		DigitalCardArray = new ArrayList<Integer>();
		QuestionCardArray = new ArrayList<Integer>();

		for (int i = 0; i < DIGITAL_PARAMETERS; i++) {
			for (int j = 0; j < HALF_DIGITAL_SIZE; j++) {
				DigitalCardArray.add(DIGITAL_CARD[i][j]);
			}
		}

		for (int i = 0; i < QUESTION_SIZE; i++) {
			QuestionCardArray.add(QUESTION_CARD[i]);
		}
	}

	private void tgrSelectDigitalCard() {
		UserArray = new ArrayList<ArrayList<Integer>>();
		for (int i = 0; i < SELECT_DIGITAL_SIZE; i++) {
			do {
				num[0] = rand.nextInt(DigitalCardArray.size());
				num[1] = rand.nextInt(DigitalCardArray.size());
			} while (num[0] == num[1]);
			tgrSelectedDigitalCardSort();
			DigitalCardArray.remove(num[0]);
			if (num[0] < num[1]) {
				DigitalCardArray.remove(num[1] - 1);
			} else {
				DigitalCardArray.remove(num[1]);
			}
		}
		tgrDigitalCardDefind();
	}

	private static void tgrDigitalCardDefind() {
		if (UserArray.get(0).size() != SELECT_DIGITAL_SIZE || UserArray.get(1).size() != SELECT_DIGITAL_SIZE) {
			ErrorCode = CARD_PROGRAM_FAULT;
			return;
		}
		for (int i = 0; i < USER_COUNT; i++) {
			for (int j = 0; j < SELECT_DIGITAL_SIZE; j++) {
				compareValue = UserArray.get(i).get(j);
				UserDigitalCardArray[i][j][0] = compareValue % 10;
				if (compareValue % 10 == 5) {
					UserDigitalCardArray[i][j][1] = tgrMain.ColorEnum.valueOfByName("Green").getId();
				} else {
					if (compareValue < HALF_DIGITAL_SIZE) {
						UserDigitalCardArray[i][j][1] = tgrMain.ColorEnum.valueOfByName("Red").getId();
					} else {
						UserDigitalCardArray[i][j][1] = tgrMain.ColorEnum.valueOfByName("Blue").getId();
					}
				}
			}
		}
	}

	private static void tgrSelectedDigitalCardSort() {
		if (UserArray.size() == 0) {
			for (int i = 0; i < USER_COUNT; i++) {
				TmpArray = new ArrayList<Integer>();
				TmpArray.add(DigitalCardArray.get(num[i]));
				UserArray.add(TmpArray);
			}
			return;
		} else if (UserArray.size() == 2) {
			for (int i = 0; i < USER_COUNT; i++) {
				selectValue = DigitalCardArray.get(num[i]);
				for (int j = 0; j < UserArray.get(i).size(); j++) {
					compareValue = UserArray.get(i).get(j);
					if (selectValue % 10 == compareValue % 10) {
						if (selectValue < compareValue) {
							UserArray.get(i).add(j, selectValue);
							break;
						} else {
							UserArray.get(i).add(j + 1, selectValue);
							break;
						}
					}
					if (selectValue % 10 < compareValue % 10) {
						UserArray.get(i).add(j, selectValue);
						break;
					}
					if (j == UserArray.get(i).size() - 1) {
						UserArray.get(i).add(selectValue);
						break;
					}
				}
			}
		} else {
			ErrorCode = CARD_PROGRAM_FAULT;
			return;
		}
	}

	private void tgrSelectQuestionCard() {
		int num;
		for (int i = 0; i < SELECT_QUESTION_SIZE; i++) {
			num = rand.nextInt(QuestionCardArray.size());
			UsingQuestionCardArray[i] = QuestionCardArray.get(num);
			QuestionCardArray.remove(num);
		}
	}
}
