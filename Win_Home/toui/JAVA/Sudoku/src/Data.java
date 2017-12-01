import java.util.ArrayList;

public class Data {

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
	
	public void DataSelectUpdate() 
	{
		int SelectCandidateIndex = - SudokuGame.SudokuNum[SudokuGame.SelectIndexValue[0]][SudokuGame.SelectIndexValue[1]] -1;
		
		SudokuGame.CandidateItem = new ArrayList<Integer>(SudokuGame.SelectIndexValue[2]);
		
		//SudokuGame.SudokuNum[SudokuGame.SelectIndexValue[0]][SudokuGame.SelectIndexValue[1]]
		//SudokuGame.Candidate.get(SudokuGame.SelectIndexValue[0]).get(SudokuGame.SelectIndexValue[1])
		
		//for (int i = 0; i < SudokuGame.)
	}

}
