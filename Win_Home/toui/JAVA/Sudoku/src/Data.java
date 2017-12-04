import java.util.ArrayList;

public class Data {

	public int[] ObjectIndex = new int[SudokuGame.NUM_SIZE];

	public void StatData() {
		GameDefaultInitial();
		GameInitial();
	}

	public void GameDefaultInitial() {
		for (int i = 0; i < SudokuGame.NUM_SIZE; i++) {
			SudokuGame.DefaultCandidateItem.add(i + 1);
		}
	}

	public void GameInitial() {
		int count = 1;
		for (int i = 0; i < SudokuGame.NUM_SIZE; i++) {
			for (int j = 0; j < SudokuGame.NUM_SIZE; j++) {
				SudokuGame.SudokuNum[i][j] = -count;
				SudokuGame.Candidate.add(SudokuGame.DefaultCandidateItem);
				count++;
			}
		}
	}

	public void DataSelectUpdate() {
		// 候选ArrayList更新
		int SelectCandidateIndex = -SudokuGame.SudokuNum[SudokuGame.SelectIndexValue[0]][SudokuGame.SelectIndexValue[1]]
				- 1;
		SudokuGame.CandidateItem.add(SudokuGame.SelectIndexValue[2]);
		SudokuGame.Candidate.remove(SelectCandidateIndex);
		SudokuGame.Candidate.add(SelectCandidateIndex, SudokuGame.CandidateItem);

		// 数独数组更新
		SudokuGame.SudokuNum[SudokuGame.SelectIndexValue[0]][SudokuGame.SelectIndexValue[1]] = SudokuGame.SelectIndexValue[2];
	}

	public void TemporaryDataClear() {
		SudokuGame.CandidateItem = new ArrayList<Integer>();
		SudokuGame.SelectIndexValue = new int[3];
	}

	public void Calculate() {
		for (int i = 0; i < SudokuGame.NUM_SIZE; i++) {
			for (int j = 0; j < SudokuGame.NUM_SIZE; j++) {
				if (SudokuGame.SudokuNum[i][j] > 0) {
					for (SudokuGame.ExcludeObjects EObjects : SudokuGame.ExcludeObjects.values()) {
						switch (EObjects) {
						case HORIZONTAL:
							HorizontalIndex(i, j);
							NonObjectInvestigation(i, j);
							//display();
							break;
						case LONGITUDINAL:
							LongitudinalIndex(i, j);
							NonObjectInvestigation(i, j);
							//display();
							break;
						case PARTIAL:
							PartialIndex(i, j);
							NonObjectInvestigation(i, j);
							//display();
							break;
						}
					}
				}
			}
		}
	}

	// 横向对象范围
	public int[] HorizontalIndex(int i, int j) {
		for (int k = 0; k < SudokuGame.NUM_SIZE; k++) {
			if (k != j) {
				ObjectIndex[k] = i * SudokuGame.NUM_SIZE + k;
			} else {
				ObjectIndex[k] = -1;
			}
		}
		// ObjectIndex
		return ObjectIndex;
	}

	// 纵向对象范围
	public int[] LongitudinalIndex(int i, int j) {
		for (int k = 0; k < SudokuGame.NUM_SIZE; k++) {
			if (k != i) {
				ObjectIndex[k] = k * SudokuGame.NUM_SIZE + j;
			} else {
				ObjectIndex[k] = -1;
			}
		}
		// ObjectIndex
		return ObjectIndex;
	}

	// 局部对象范围
	public int[] PartialIndex(int i, int j) {
		int PartialFirstIndex = (i / SudokuGame.OBJECT_SIZE) * SudokuGame.OBJECT_SIZE * SudokuGame.NUM_SIZE
				+ (j / SudokuGame.OBJECT_SIZE) * SudokuGame.OBJECT_SIZE;
		for (int k = 0; k < SudokuGame.NUM_SIZE; k++) {
			int PartialCurrentIndex = PartialFirstIndex + (k / SudokuGame.OBJECT_SIZE) * SudokuGame.NUM_SIZE
					+ (k % SudokuGame.OBJECT_SIZE);
			if (PartialCurrentIndex != i * SudokuGame.NUM_SIZE + j) {
				ObjectIndex[k] = PartialCurrentIndex;
			} else {
				ObjectIndex[k] = -1;
			}
		}
		// ObjectIndex
		return ObjectIndex;
	}

	// 对象排除
	public void NonObjectInvestigation(int i, int j) {
		for (int k = 0; k < SudokuGame.NUM_SIZE; k++) {
			int a = ObjectIndex[k];
			if (a != -1 && SudokuGame.Candidate.get(a).size() > 1) {
				SudokuGame.CandidateItem = new ArrayList<Integer>(SudokuGame.Candidate.get(a));
				int index = SudokuGame.CandidateItem.indexOf(SudokuGame.SudokuNum[i][j]);
				SudokuGame.CandidateItem.remove(index);
				SudokuGame.Candidate.remove(a);
				SudokuGame.Candidate.add(a, SudokuGame.CandidateItem);
				if (SudokuGame.Candidate.get(a).size() == 1) {
					// 数组更新
					SudokuGame.SudokuNum[k/SudokuGame.NUM_SIZE][k%SudokuGame.NUM_SIZE] = SudokuGame.Candidate.get(a).get(0);
					// button显示
					SudokuGame.SudokuButton[k/SudokuGame.NUM_SIZE][k%SudokuGame.NUM_SIZE].setText(String.valueOf(SudokuGame.Candidate.get(a).get(0)));
				}
				SudokuGame.CandidateItem = new ArrayList<Integer>();
			}
		}

	}

	// 测试用
	public void display() {
		for (int k = 0; k < SudokuGame.NUM_SIZE; k++) {
			System.out.print(ObjectIndex[k] + ",");

		}
		System.out.println();
	}
}
