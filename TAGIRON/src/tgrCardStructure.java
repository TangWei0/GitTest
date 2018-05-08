import java.util.Arrays;
import java.util.Random;

public class tgrCardStructure {

	// 定数を定義する
	static int DIGITALPARAMETERS = 2;
	static int DIGITALSIZE = 20;
	static int DIGITALHALFSIZE = 10;
	static int SELECTDIGITALSIZE = 5;
	static int QUESTIONSIZE = 21;
	static int SELECTQUESTIONSIZE = 6;

	// 抽選数字カードを定義する
	public int[][] User1DigitalCardArray = new int[SELECTDIGITALSIZE][DIGITALPARAMETERS];
	public int[][] User2DigitalCardArray = new int[SELECTDIGITALSIZE][DIGITALPARAMETERS];

	public void tgrSelectDigitalCard() {
		Random rand = new Random();
		Integer[] user1SelectedIndex = new Integer[SELECTDIGITALSIZE];
		Integer[] user2SelectedIndex = new Integer[SELECTDIGITALSIZE];
		int num1, num2;
		for (int i = 0; i < SELECTDIGITALSIZE; i++) {
			do {
				num1 = rand.nextInt(DIGITALSIZE);
				num2 = rand.nextInt(DIGITALSIZE);
			} while ((Arrays.asList(user1SelectedIndex).contains(num1)) ||
						(Arrays.asList(user1SelectedIndex).contains(num2)) ||
						(Arrays.asList(user2SelectedIndex).contains(num1)) ||
						(Arrays.asList(user2SelectedIndex).contains(num2)) ||
						(num1 == num2));
			tgrSelectedCardSort(user1SelectedIndex, num1);
			tgrSelectedCardSort(user2SelectedIndex, num2);
		}
		User1DigitalCardArray = tgrDigitalCardDefind(user1SelectedIndex);
		User2DigitalCardArray = tgrDigitalCardDefind(user2SelectedIndex);
	}

	private int[][] tgrDigitalCardDefind(Integer[] selectedIndex) {
		int[][] digitalCardArrayTmp = new int[SELECTDIGITALSIZE][DIGITALPARAMETERS];
		for (int i = 0; i < SELECTDIGITALSIZE; i++) {
			digitalCardArrayTmp[i][0] = selectedIndex[i] % DIGITALHALFSIZE;
			if (selectedIndex[i] % DIGITALHALFSIZE == 5) {
				digitalCardArrayTmp[i][1] = tgrMain.ColorEnum.valueOfByName("Green").getId();
			} else {
				if (selectedIndex[i] < DIGITALHALFSIZE) {
					digitalCardArrayTmp[i][1] = tgrMain.ColorEnum.valueOfByName("Red").getId();
				} else {
					digitalCardArrayTmp[i][1] = tgrMain.ColorEnum.valueOfByName("Blue").getId();
				}
			}
		}
		return digitalCardArrayTmp;
	}

	private void tgrSelectedCardSort(Integer[] selectedIndex, int num) {
		for (int i = 0; i < SELECTDIGITALSIZE; i++) {
			if (selectedIndex[i] == null) {
				selectedIndex[i] = num;
				return;
			} else {
				if ((num % DIGITALHALFSIZE < selectedIndex[i] % DIGITALHALFSIZE) ||
						((num % DIGITALHALFSIZE == selectedIndex[i] % DIGITALHALFSIZE) && (num < selectedIndex[i]))) {
					for (int j = SELECTDIGITALSIZE - 1; j > i; j--) {
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
}