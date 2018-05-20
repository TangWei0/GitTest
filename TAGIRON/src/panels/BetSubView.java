package Panels;

import static Declaration.MathConstants.*;
import static Declaration.Variable.*;

import java.awt.Color;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import java.util.Random;

public class BetSubView extends JPanel {
	private static final long serialVersionUID = 1L;
	private JButton ReturnButton = new JButton("戻る");
	private JButton StartStopButton = new JButton("スタート");
	private JLabel ExpandLabel = new JLabel("", JLabel.CENTER);

	private Random rand = new Random();

	private String input0 = "";
	private String input1 = "";
	private String input2 = "";

	private String title = "";

	private int clickCount = 0;

	private long startTime;
	private long endTime;
	private int expandTime;
	private int user1Time;
	private int user2Time;

	public BetSubView() {
		this.setLayout(null);
		this.setSize(FRAME_WIDTH, FRAME_HIGHT);

		ReturnButton.setBounds(COMMON_BUTTON_DX, COMMON_BUTTON_DY, COMMON_BUTTON_WIDTH, COMMON_BUTTON_HIGHT);
		ReturnButton.setForeground(Color.blue);
		ReturnButton.setFont(new Font("ＭＳ ゴシック", Font.ITALIC, 16));
		ReturnButton.setVisible(true);
		this.add(ReturnButton);

		ReturnButton.addActionListener(new returnButtonListener());

		StartStopButton.setBounds(START_BUTTON_DX, START_BUTTON_DY, START_BUTTON_WIDTH, START_BUTTON_HIGHT);
		StartStopButton.setForeground(Color.blue);
		StartStopButton.setFont(new Font("ＭＳ ゴシック", Font.ITALIC, 16));
		StartStopButton.setVisible(true);
		this.add(StartStopButton);

		StartStopButton.addActionListener(new startStopButtonListener());

		expandTime = rand.nextInt(9001) + 1000;
		input0 = String.valueOf((double) expandTime / 1000);
		tgrCreatTitle();
		ExpandLabel.setBounds(190, 50, 900, 400);
		ExpandLabel.setFont(new Font("ＭＳ ゴシック", Font.BOLD, 32));
		ExpandLabel.setVisible(true);
		ExpandLabel.setText(title);
		this.add(ExpandLabel);

	}

	private class returnButtonListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			if (Number != NO_DECISION) {
				tgrMain.betSubView.setVisible(false);
				tgrMain.mainView.setVisible(true);
			} else {
				JOptionPane.showMessageDialog(null, ERROR_4);
			}
		}
	}

	private class startStopButtonListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			if (clickCount < 4) {
				clickCount++;
			} else {
				// 何もしない
				return;
			}

			switch (clickCount) {
			case 1:
			case 3:
				startTime = System.currentTimeMillis();
				StartStopButton.setText("ストップ");
				break;
			case 2:
				endTime = System.currentTimeMillis();
				user1Time = (int) (endTime - startTime);
				input1 = String.valueOf((double) (user1Time) / 1000);
				user1Time = user1Time < expandTime ? expandTime - user1Time : TIMEROVER;
				StartStopButton.setText("スタート");
				break;
			case 4:
				endTime = System.currentTimeMillis();
				user2Time = (int) (endTime - startTime);
				input2 = String.valueOf((double) (user2Time) / 1000);
				user2Time = user2Time < expandTime ? expandTime - user2Time : TIMEROVER;
				if (user1Time == user2Time) {
					JOptionPane.showMessageDialog(null, ERROR_3);
					clickCount = 0;
					expandTime = rand.nextInt(9001) + 1000;
					input0 = String.valueOf((double) expandTime / 1000);
				}

				StartStopButton.setText("スタート");
				break;
			}
			tgrCreatTitle();
			ExpandLabel.setText(title);
		}
	}

	private void tgrCreatTitle() {
		title = "";
		switch (clickCount) {
		case 0:
			title = TitleNames[0] + TitleNames[2] + TitleNames[6] + input0 + TitleNames[11] + TitleNames[3]
					+ TitleNames[2] + TitleNames[7] + TitleNames[4] + TitleNames[9] + TitleNames[5] + TitleNames[1];
			break;
		case 1:
			title = TitleNames[0] + TitleNames[2] + TitleNames[6] + input0 + TitleNames[11] + TitleNames[3]
					+ TitleNames[2] + TitleNames[7] + TitleNames[4] + TitleNames[10] + TitleNames[5] + TitleNames[1];
			break;
		case 2:
			title = TitleNames[0] + TitleNames[2] + TitleNames[6] + input0 + TitleNames[11] + TitleNames[3]
					+ TitleNames[2] + TitleNames[7] + input1 + TitleNames[11] + TitleNames[3] + TitleNames[2]
					+ TitleNames[8] + TitleNames[4] + TitleNames[9] + TitleNames[5] + TitleNames[1];
			break;
		case 3:
			title = TitleNames[0] + TitleNames[2] + TitleNames[6] + input0 + TitleNames[11] + TitleNames[3]
					+ TitleNames[2] + TitleNames[7] + input1 + TitleNames[11] + TitleNames[3] + TitleNames[2]
					+ TitleNames[8] + TitleNames[4] + TitleNames[10] + TitleNames[5] + TitleNames[1];
			break;
		case 4:
			Number = user1Time < user2Time ? USER1_DECISION : USER2_DECISION;
			String checkResult = "";
			if (Number == USER1_DECISION) {
				checkResult = TitleNames[12];
			} else {
				checkResult = TitleNames[13];
			}
			title = TitleNames[0] + TitleNames[2] + TitleNames[6] + input0 + TitleNames[11] + TitleNames[3]
					+ TitleNames[2] + TitleNames[7] + input1 + TitleNames[11] + TitleNames[3] + TitleNames[2]
					+ TitleNames[8] + input2 + TitleNames[11] + TitleNames[3] + TitleNames[2] + TitleNames[4]
					+ checkResult + TitleNames[5] + TitleNames[3] + TitleNames[2] + TitleNames[14] + TitleNames[1];
			break;
		}
	}
}
