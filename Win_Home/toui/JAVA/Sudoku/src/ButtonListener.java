import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class ButtonListener {

	public class SudokuButtonListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			// TODO 自動生成されたメソッド・スタブ
			if (SudokuGame.SudokuButtonCheck == true) {
				SudokuGame.NumButtonCheck = true;
				for (int i = 0; i < SudokuGame.NUM_SIZE; i++) {
					for (int j = 0; j < SudokuGame.NUM_SIZE; j++) {
						if (e.getSource() == SudokuGame.SudokuButton[i][j]) {
							SudokuGame.SelectIndexValue[0] = i;
							SudokuGame.SelectIndexValue[1] = j;
						}
					}
				}
			}
		}
	}

	public class NumButtonListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			// TODO 自動生成されたメソッド・スタブ
			if (SudokuGame.NumButtonCheck == true) {
				for (int i = 0; i < SudokuGame.NUM_SIZE; i++) {
					if (e.getSource() == SudokuGame.NumButton[i]) {
						SudokuGame.SelectIndexValue[2] = i + 1;
						SudokuGame.SelectUpdate();
						SudokuGame.NumButtonCheck = false;
					}
				}
			}
		}
	}

	public class InitialButtonListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent arg0) {
			// TODO 自動生成されたメソッド・スタブ
			SudokuGame.SudokuButtonCheck = true;
		}
	}

}
