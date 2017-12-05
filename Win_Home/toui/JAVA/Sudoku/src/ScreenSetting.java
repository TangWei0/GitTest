import javax.swing.JButton;
import javax.swing.JOptionPane;

public class ScreenSetting {

	ButtonListener ButtonListener = new ButtonListener();

	public void ButtonSetting() {
		SudokuGame.contentPane.add(SudokuGame.panel);
		SudokuGame.panel.setLayout(null);
		SudokuGame.panel.setOpaque(false);
		SudokuGame.ModeButton.setBounds(SudokuGame.BOTTOM_SIZE * SudokuGame.SPACING, SudokuGame.SPACING,
				2 * SudokuGame.BUTTON_SIZE, SudokuGame.BUTTON_SIZE);
		SudokuGame.panel.add(SudokuGame.ModeButton);
		SudokuGame.ModeButton.addActionListener(ButtonListener.new ModeButtonListener());

		// 以下是图形设置
		SetGameTable();
		SetNumTable();
		SudokuGame.mode = SudokuGame.Mode.SELECT;
		SetModeButton();
	}

	public void SetModeButton() {
		if (SudokuGame.mode != SudokuGame.Mode.INITIALIZATION) {
			switch (SudokuGame.mode) {
			case SELECT:
				SudokuGame.ModeButton.setText("选择初期数值");
				break;
			case CONFIRM:
				SudokuGame.ModeButton.setText("初期数值确定");
				break;
			case CALCULATE:
				SudokuGame.ModeButton.setText("数独计算");
				break;
			case RETYR:
				SudokuGame.ModeButton.setText("重新开始");
				break;
			default:
				JOptionPane.showMessageDialog(null, "模式初始化失败，请关闭界面重新进入游戏。");
				break;
			}
		} else {
			JOptionPane.showMessageDialog(null, "模式初始化失败，请关闭界面重新进入游戏。");
		}
	}

	public void SetGameTable() {
		for (int i = 0; i < SudokuGame.NUM_SIZE; i++) {
			for (int j = 0; j < SudokuGame.NUM_SIZE; j++) {
				SudokuGame.SudokuButton[i][j] = new JButton("");
				SudokuGame.SudokuButton[i][j].setBounds((j + 1) * SudokuGame.SPACING, (i + 1) * SudokuGame.SPACING,
						SudokuGame.BUTTON_SIZE, SudokuGame.BUTTON_SIZE);
				SudokuGame.panel.add(SudokuGame.SudokuButton[i][j]);

				SudokuGame.SudokuButton[i][j].addActionListener(ButtonListener.new SudokuButtonListener());
			}
		}
	}

	public void SetNumTable() {
		for (int i = 0; i < SudokuGame.NUM_SIZE; i++) {
			SudokuGame.NumButton[i] = new JButton(String.valueOf(i + 1));
			SudokuGame.NumButton[i].setBounds((i + 1) * SudokuGame.SPACING, SudokuGame.BOTTOM_SIZE * SudokuGame.SPACING,
					SudokuGame.BUTTON_SIZE, SudokuGame.BUTTON_SIZE);
			SudokuGame.panel.add(SudokuGame.NumButton[i]);

			SudokuGame.NumButton[i].addActionListener(ButtonListener.new NumButtonListener());
		}
	}

	public void SelectButtonUpdate() {
		
	}
	
	public void ButtonUpdate() 
	{
		
	}

}
