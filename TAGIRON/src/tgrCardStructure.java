import java.util.Arrays;
import java.util.Random;

public class tgrCardStructure {

	public void tgrSelectDigitalCard() {
		Random rand = new Random();
		Integer[] user1SelectedIndex = new Integer[tgrMain.SELECTDIGITALSIZE];
		Integer[] user2SelectedIndex = new Integer[tgrMain.SELECTDIGITALSIZE];
		int num1, num2;
		for (int i = 0; i < tgrMain.SELECTDIGITALSIZE; i++) {
			do {
				num1 = rand.nextInt(tgrMain.DIGITALSIZE);
				num2 = rand.nextInt(tgrMain.DIGITALSIZE);
			} while ((Arrays.asList(user1SelectedIndex).contains(num1)) ||
						(Arrays.asList(user1SelectedIndex).contains(num2)) ||
						(Arrays.asList(user2SelectedIndex).contains(num1)) ||
						(Arrays.asList(user2SelectedIndex).contains(num2)) ||
						(num1 == num2));
			tgrSelectedDigitalCardSort(user1SelectedIndex, num1);
			tgrSelectedDigitalCardSort(user2SelectedIndex, num2);
		}
		tgrMain.User1DigitalCardArray = tgrDigitalCardDefind(user1SelectedIndex);
		tgrMain.User2DigitalCardArray = tgrDigitalCardDefind(user2SelectedIndex);
	}

	private Integer[][] tgrDigitalCardDefind(Integer[] selectedIndex) {
		Integer[][] digitalCardArrayTmp = new Integer[tgrMain.SELECTDIGITALSIZE][tgrMain.DIGITALPARAMETERS];
		for (int i = 0; i < tgrMain.SELECTDIGITALSIZE; i++) {
			digitalCardArrayTmp[i][0] = selectedIndex[i] % tgrMain.DIGITALHALFSIZE;
			if (selectedIndex[i] % tgrMain.DIGITALHALFSIZE == 5) {
				digitalCardArrayTmp[i][1] = tgrMain.ColorEnum.valueOfByName("Green").getId();
			} else {
				if (selectedIndex[i] < tgrMain.DIGITALHALFSIZE) {
					digitalCardArrayTmp[i][1] = tgrMain.ColorEnum.valueOfByName("Red").getId();
				} else {
					digitalCardArrayTmp[i][1] = tgrMain.ColorEnum.valueOfByName("Blue").getId();
				}
			}
		}
		return digitalCardArrayTmp;
	}

	private void tgrSelectedDigitalCardSort(Integer[] selectedIndex, int num) {
		for (int i = 0; i < tgrMain.SELECTDIGITALSIZE; i++) {
			if (selectedIndex[i] == null) {
				selectedIndex[i] = num;
				return;
			} else {
				if ((num % tgrMain.DIGITALHALFSIZE < selectedIndex[i] % tgrMain.DIGITALHALFSIZE) ||
						((num % tgrMain.DIGITALHALFSIZE == selectedIndex[i] % tgrMain.DIGITALHALFSIZE) && (num < selectedIndex[i]))) {
					for (int j = tgrMain.SELECTDIGITALSIZE - 1; j > i; j--) {
						selectedIndex[j] = selectedIndex[j - 1];
					}
					selectedIndex[i] = num;
					return;
				} else {
					continue;
				}
			}
		}
	}

	public void tgrSelectQuestionCard() {
		int count = 0;
		for (Integer num : tgrMain.usingQuestionCardArray) {
			if (num != null) {

			} else {
				count++;
				if (count == tgrMain.SELECTQUESTIONSIZE) {
					tgrSelectQuestionCardInitialization();
				}
			}
		}
	}

	private void tgrSelectQuestionCardInitialization() {
		Random rand = new Random();
		int num;
		for (int i = 0; i < tgrMain.SELECTQUESTIONSIZE; i++) {
			do {
				num = rand.nextInt(tgrMain.QUESTIONSIZE);
			} while (Arrays.asList(tgrMain.usingQuestionCardArray).contains(num));
			tgrMain.usingQuestionCardArray[i] = num;
		}
	}
}