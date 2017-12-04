import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JOptionPane;

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

	public class ModeButtonListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent arg0) {
			// TODO 自動生成されたメソッド・スタブ
			switch (SudokuGame.mode) 
			{
			case SELECT:
				SudokuGame.SudokuButtonCheck = true;
				SudokuGame.mode = SudokuGame.Mode.CONFIRM;
				SudokuGame.ScreenSetting.SetModeButton();
				break;
			case CONFIRM:
				SudokuGame.SudokuButtonCheck = false;
				SudokuGame.mode = SudokuGame.Mode.CALCULATE;
				SudokuGame.ScreenSetting.SetModeButton();
				break;
			case CALCULATE:
				SudokuGame.Data.Calculate();
				//SudokuGame.mode = SudokuGame.Mode.RETYR;
				//SudokuGame.ScreenSetting.SetModeButton();
				break;
			case RETYR:
				SudokuGame.mode = SudokuGame.Mode.SELECT;
				SudokuGame.ScreenSetting.SetModeButton();
				break;
			default:
				JOptionPane.showMessageDialog(null, "模式切换失败，请关闭界面重新进入游戏。");
				break;
			}
		}
	}

}
