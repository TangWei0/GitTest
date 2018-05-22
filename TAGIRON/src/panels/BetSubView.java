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
import javax.swing.Timer;

import Process.tgrCardStructure;

import java.util.Random;

public class BetSubView extends JPanel implements ActionListener {
	private static final long serialVersionUID = 1L;
	private Timer timer = new Timer(1000, this);
	private Random rand = new Random();

	private JButton CommonButton = new JButton("スタート");
	private JLabel ExpandLabel = new JLabel("", JLabel.CENTER);

	private String input0 = "";
	private String input1 = "";
	private String input2 = "";
	private String title = "";
	private String checkResult = "";

	private int sec = 0;
	private int clickCount = 0;
	private int expandTime;
	private int user1Time;
	private int user2Time;

	private long startTime;
	private long endTime;
	tgrCardStructure CardStructure = new tgrCardStructure();

	public BetSubView(String viewName) {
		this.setLayout(null);
		this.setSize(FRAME_WIDTH, FRAME_HIGHT);

		CardStructure.tgrCardDefind();
		if (ErrorCode == 4 || ErrorCode == 5) {
			JOptionPane.showMessageDialog(null, Error[ErrorCode]);
		}
		
		CommonButton.setBounds(CENTER_BUTTON_DX, CENTER_BUTTON_DY, CENTER_BUTTON_WIDTH, CENTER_BUTTON_HIGHT);
		CommonButton.setForeground(Color.blue);
		CommonButton.setFont(new Font("ＭＳ ゴシック", Font.ITALIC, 16));
		CommonButton.setVisible(true);
		this.add(CommonButton);

		CommonButton.addActionListener(new commonButtonListener());

		// 先手betInfo更新
		expandTime = rand.nextInt(9000) + 1000;
		input0 = String.valueOf((double) expandTime / 1000);
		tgrCreatTitle();

		ExpandLabel.setBounds(BETINFO_LABEL_DX, BETINFO_LABEL_DY, BETINFO_LABEL_WIDTH, BETINFO_LABEL_HIGHT);
		ExpandLabel.setFont(new Font("ＭＳ ゴシック", Font.BOLD, 32));
		ExpandLabel.setVisible(true);
		ExpandLabel.setText(title);
		this.add(ExpandLabel);
	}

	public void actionPerformed(ActionEvent e) {
		if (sec >= TIMER_OVER / 1000 + 1) {
			CommonButton.doClick();
		} else {
			sec++;
		}
	}

	private class commonButtonListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			if (clickCount != CLICK_COUNT_MAX) {
				clickCount++;
			} else {
				if (Number != NO_DECISION) {
					tgrMain.betSubView.setVisible(false);
					if (Number == USER1_DECISION) {
						tgrMain.user1View.setVisible(true);
					} else {
						tgrMain.user2View.setVisible(true);
					}
				} else {
					ErrorCode = 3;
					JOptionPane.showMessageDialog(null, Error[ErrorCode]);
				}
				return;
			}

			switch (clickCount) {
			case 1:
			case 3:
				sec = 0;
				timer.start();
				startTime = System.currentTimeMillis();
				CommonButton.setText("ストップ");
				break;
			case 2:
				timer.stop();
				endTime = System.currentTimeMillis();
				user1Time = (int) (endTime - startTime);
				input1 = String.valueOf((double) (user1Time) / 1000);
				user1Time = user1Time < expandTime ? expandTime - user1Time : TIMER_OVER;
				CommonButton.setText("スタート");
				break;
			case 4:
				timer.stop();
				sec = 1;
				endTime = System.currentTimeMillis();
				user2Time = (int) (endTime - startTime);
				input2 = String.valueOf((double) (user2Time) / 1000);
				user2Time = user2Time < expandTime ? expandTime - user2Time : TIMER_OVER;
				if (user1Time == user2Time) {
					ErrorCode = 2;
					JOptionPane.showMessageDialog(null, Error[ErrorCode]);
					// 先手Betがリトライする
					clickCount = 0;
					expandTime = rand.nextInt(9000) + 1000;
					input0 = String.valueOf((double) expandTime / 1000);
				}
				break;
			}
			// 先手betInfo更新
			tgrCreatTitle();
			ExpandLabel.setText(title);
		}
	}

	private void tgrCreatTitle() {
		switch (clickCount) {
		case 0:
			title = TitleNames[0] + TitleNames[2] + TitleNames[6] + input0 + TitleNames[11] + TitleNames[3]
					+ TitleNames[2] + TitleNames[7] + TitleNames[4] + TitleNames[9] + TitleNames[5] + TitleNames[1];
			break;
		case 1:
			//
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
			if (Number == USER1_DECISION) {
				checkResult = TitleNames[12];
			} else {
				checkResult = TitleNames[13];
			}
			title = TitleNames[0] + TitleNames[2] + TitleNames[6] + input0 + TitleNames[11] + TitleNames[3]
					+ TitleNames[2] + TitleNames[7] + input1 + TitleNames[11] + TitleNames[3] + TitleNames[2]
					+ TitleNames[8] + input2 + TitleNames[11] + TitleNames[3] + TitleNames[2] + TitleNames[4]
					+ checkResult + TitleNames[5] + TitleNames[3] + TitleNames[2] + TitleNames[14] + TitleNames[1];
			clickCount = CLICK_COUNT_MAX;
			CommonButton.setText("Nextへ");
			break;
		}
	}
}
