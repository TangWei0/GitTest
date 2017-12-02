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
							break;
						case LONGITUDINAL:
							break;
						case PARTIAL:
							break;
						}
					}
				}
			}
		}
	}

	//横向对象排查
	public int[] HorizontalIndex(int i, int j) {
		for (int k = 0; k < SudokuGame.NUM_SIZE; k++)
		{
			if (k != i*SudokuGame.NUM_SIZE + j)
			{
				ObjectIndex[k] = i*SudokuGame.NUM_SIZE + k;
			}
		}
		//ObjectIndex
		return ObjectIndex;
	}
}
