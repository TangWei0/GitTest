import java.util.ArrayList;

public class Data {
	public static int[] Impossible = new int[SudokuGame.IMPOSSIBLE_SIZE];
	public static int[] Possible = new int[SudokuGame.POSSIBLE_SIZE];
	public static int[] Compare = new int[SudokuGame.NUM_SIZE];

	static int CurrentIndexX = 0;
	static int CurrentIndexY = 0;
	static int CurrentValue = 0;
	static int SolveCount = 0;

	public void SelectUpdate() {
		SudokuGame.CurrentObject.add(SudokuGame.Item);
		int CurrentObjectIndex = SudokuGame.CurrentObject.size() - 1;
		SudokuGame.SudokuNum[SudokuGame.Item.get(0)][SudokuGame.Item.get(1)] = SudokuGame.Item.get(2);
		SudokuGame.SudokuButton[SudokuGame.Item.get(0)][SudokuGame.Item.get(1)]
				.setText(String.valueOf(SudokuGame.Item.get(2)));
		SolveCount++;

		SudokuGame.Item = new ArrayList<Integer>();
		SudokuGame.Item.add(0);
		SudokuGame.Candidate.set(XYToIndex(SudokuGame.CurrentObject.get(CurrentObjectIndex).get(0),
				SudokuGame.CurrentObject.get(CurrentObjectIndex).get(1)), SudokuGame.Item);

		SudokuGame.Item = new ArrayList<Integer>();
	}

	public void Calculate() {
		do {
			for (int i = 0; i < SudokuGame.CurrentObject.size(); i++) {
				CurrentIndexX = SudokuGame.CurrentObject.get(i).get(0);
				CurrentIndexY = SudokuGame.CurrentObject.get(i).get(1);
				CurrentValue = SudokuGame.CurrentObject.get(i).get(2);

				RangeCheck();
				ImpossibleElementAdd();
				PossibleElementAdd();
			}

			CalculateCheck();
			
			SudokuGame.CurrentObject = new ArrayList<ArrayList<Integer>>(SudokuGame.NextObject);
			SudokuGame.NextObject = new ArrayList<ArrayList<Integer>>();

		} while (SolveCount < 81);

		
	}

	public void CalculateCheck() {
		for (int i = 0; i < 9; i++) {
			for (int j = 0; j < 9; j++) {
				if (SudokuGame.SudokuNum[i][j] != 0) {
					continue;
				}
				SudokuGame.Item = SudokuGame.Candidate.get(XYToIndex(i, j));
				outside: for (int k = 0; k < SudokuGame.Item.size(); k++) {
					if (SudokuGame.Item.get(k) < 0) {
						continue;
					}
					for (int l = 0; l < 3; l++) {
						ComparListCreat(i, j, l);
						int count = 0;
						for (int m = 0; m < 9; m++) {
							if (Compare[m] == -1) {
								continue;
							} else {
								if (SudokuGame.Candidate.get(Compare[m]).indexOf(-(SudokuGame.Item.get(k))) != -1) {
									break;
								} else {
									count++;
									if (count == 8) {
										SudokuGame.SudokuNum[i][j] = SudokuGame.Item.get(k);
										SudokuGame.SudokuButton[i][j].setText(String.valueOf(SudokuGame.Item.get(k)));
										SolveCount++;

										SudokuGame.Item = new ArrayList<Integer>();
										SudokuGame.Item.add(0);
										SudokuGame.Candidate.set(XYToIndex(i, j), SudokuGame.Item);

										SudokuGame.Item = new ArrayList<Integer>();
										SudokuGame.Item.add(i);
										SudokuGame.Item.add(j);
										SudokuGame.Item.add(SudokuGame.SudokuNum[i][j]);
										SudokuGame.NextObject.add(SudokuGame.Item);

										SudokuGame.Item = new ArrayList<Integer>();
										break outside;
									}
								}
							}
						}
					}
				}
			}
		}
	}

	public void ComparListCreat(int i, int j, int l) {
		switch (l) {
		case 0:
			for (int m = 0; m < 9; m++) {
				if (m == j) {
					Compare[m] = -1;
				} else {
					Compare[m] = XYToIndex(i, m);
				}
			}
			break;
		case 1:
			for (int m = 0; m < 9; m++) {
				if (m == i) {
					Compare[m] = -1;
				} else {
					Compare[m] = XYToIndex(m, j);
				}
			}
			break;
		case 2:
			int BlockX = i % 3;
			int BlockY = j % 3;
			for (int m = 0; m < 9; m++) {
				int TrackX = m / 3;
				int TrackY = m % 3;
				if ((TrackX == BlockX) && (TrackY == BlockY)) {
					Compare[m] = -1;
				} else {
					Compare[m] = XYToIndex(i - BlockX + TrackX, j - BlockY + TrackY);
				}
			}
			break;
		}

	}

	public void PossibleElementAdd() {
		for (int k = 0; k < SudokuGame.POSSIBLE_SIZE; k++) {
			SudokuGame.Item = SudokuGame.Candidate.get(Possible[k]);

			if (SudokuGame.Item.indexOf(0) == -1) {
				int CurrentValueIndex = SudokuGame.Item.indexOf(-CurrentValue);
				if (CurrentValueIndex == -1) {
					SudokuGame.Item.add(CurrentValue);
					SudokuGame.Candidate.set(Possible[k], SudokuGame.Item);
					SudokuGame.Item = new ArrayList<Integer>();
				}
			}
		}
	}

	public void ImpossibleElementAdd() {
		for (int k = 0; k < SudokuGame.IMPOSSIBLE_SIZE; k++) {
			SudokuGame.Item = SudokuGame.Candidate.get(Impossible[k]);
			if (SudokuGame.Item.indexOf(0) != -1) {
				continue;
			}
			if (SudokuGame.Item.indexOf(-CurrentValue) != -1)
			{
				continue;
			}
			int CurrentValueIndex = SudokuGame.Item.indexOf(CurrentValue);
			if (CurrentValueIndex != -1) {
				SudokuGame.Item.set(CurrentValueIndex, -CurrentValue);
			} else {
				SudokuGame.Item.add(-CurrentValue);
			}

			SudokuGame.Candidate.set(Impossible[k], SudokuGame.Item);
			SudokuGame.Item = new ArrayList<Integer>();
		}
	}

	public void RangeCheck() {
		int ImpossibleCount = 0;
		int PossibleCount = 0;
		for (int x = 0; x < SudokuGame.NUM_SIZE; x++) {
			for (int y = 0; y < SudokuGame.NUM_SIZE; y++) {
				if (x == CurrentIndexX && y == CurrentIndexY) {
					continue;
				}
				if (x == CurrentIndexX || y == CurrentIndexY) {
					Impossible[ImpossibleCount] = XYToIndex(x, y);
					ImpossibleCount++;
					continue;
				}
				if ((x / 3 == CurrentIndexX / 3) && (y / 3 == CurrentIndexY / 3)) {
					Impossible[ImpossibleCount] = XYToIndex(x, y);
					ImpossibleCount++;
					continue;
				}
				if ((x / 3 == CurrentIndexX / 3) || (y / 3 == CurrentIndexY / 3)) {
					Possible[PossibleCount] = XYToIndex(x, y);
					PossibleCount++;
					continue;
				}
				if (ImpossibleCount > SudokuGame.IMPOSSIBLE_SIZE && PossibleCount > SudokuGame.POSSIBLE_SIZE) {
					return;
				}
			}
		}
	}

	public int XYToIndex(int X, int Y) {
		return X * SudokuGame.NUM_SIZE + Y;
	}

}
