package panels;

import static constants.MathConstants.*;

import java.awt.Color;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.JButton;
import javax.swing.JPanel;


public class StartSubView extends JPanel {
	private static final long serialVersionUID = 1L;

	private JButton StartButton = new JButton("開始");
	

	public StartSubView() {
		this.setLayout(null);
		this.setSize(FRAME_WIDTH, FRAME_HIGHT);

		// 開始ボタン
		StartButton.setBounds(START_BUTTON_DX, START_BUTTON_DY, START_BUTTON_WIDTH, START_BUTTON_HIGHT);
		StartButton.setForeground(Color.blue);
		StartButton.setFont(new Font("ＭＳ ゴシック", Font.BOLD, 32));
		StartButton.addActionListener(new StartButtonListener());
		this.add(StartButton);
	}
	
	private class StartButtonListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			tgrMain.startSubView.setVisible(false);
			tgrMain.mainView.setVisible(true);
		}
	}
}
