package Panels;

import static Declaration.MathConstants.*;
import static Declaration.Variable.*;

import java.awt.Color;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.Random;

import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.Timer;

import Process.tgrCardStructure;
import Process.tgrTextEditor;

public class StartView extends JPanel implements ActionListener {
	private static final long serialVersionUID = 1L;
	private JButton CommonButton = new JButton("");
	private JLabel ExpandLabel = new JLabel("", JLabel.CENTER);
	private Timer timer = new Timer(1000, this);
	private Random rand = new Random();

	tgrCardStructure CardStructure = new tgrCardStructure();
	tgrTextEditor TextEditor = new tgrTextEditor();
	
	public StartView(String viewName) {
		this.setLayout(null);
		this.setSize(FRAME_WIDTH, FRAME_HIGHT);
		this.setName(viewName);

		// 開始ボタン
		CommonButton.setBounds(CENTER_BUTTON_DX, CENTER_BUTTON_DY, CENTER_BUTTON_WIDTH, CENTER_BUTTON_HIGHT);
		CommonButton.setForeground(Color.blue);
		CommonButton.setFont(new Font("ＭＳ ゴシック", Font.BOLD, 32));
		if (this.getName() == PanelNames[0]) {
			CommonButton.setText("開始");
			CommonButton.addActionListener(new StartButtonListener());
			this.add(CommonButton);
		} else if (this.getName() == PanelNames[1]) {
			CardStructure.tgrCardDefind();
			if (ErrorCode == CARD_PROGRAM_FAULT) {
				JOptionPane.showMessageDialog(null, Error[ErrorCode]);
				System.exit(0);
			}
			CommonButton.setText("スタート");
			CommonButton.addActionListener(new commonButtonListener());
			this.add(CommonButton);
			
			// 先手betInfo更新
			expandTime = rand.nextInt(9000) + 1000;
			input0 = String.valueOf((double) expandTime / 1000);
			TextEditor.tgrBetTitle();

			ExpandLabel.setBounds(BETINFO_LABEL_DX, BETINFO_LABEL_DY, BETINFO_LABEL_WIDTH, BETINFO_LABEL_HIGHT);
			ExpandLabel.setFont(new Font("ＭＳ ゴシック", Font.BOLD, 32));
			ExpandLabel.setVisible(true);
			ExpandLabel.setText(BetTitle);
			this.add(ExpandLabel);
		} else {
			ErrorCode = SCREEN_TRANSITION_FAULT;
			JOptionPane.showMessageDialog(null, Error[ErrorCode]);
			System.exit(0);
		}
	}

	private class StartButtonListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			tgrMain.startSubView.setVisible(false);
			tgrMain.betSubView.setVisible(true);
		}
	}

	@Override
	public void actionPerformed(ActionEvent arg0) {
		// TODO 自動生成されたメソッド・スタブ
		if (sec >= TIMER_OVER / 1000 + 1) {
			CommonButton.doClick();
		} else {
			sec++;
		}
	}
	
	private class commonButtonListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			if (ClickCount != CLICK_COUNT_MAX) {
				ClickCount++;
			} else {
				if (Number != NO_DECISION) {
					tgrMain.betSubView.setVisible(false);
					if (Number == USER1_DECISION) {
						tgrMain.user1View.setVisible(true);
					} else {
						tgrMain.user2View.setVisible(true);
					}
				} else {
					ErrorCode = NOT_DECIDED;
					JOptionPane.showMessageDialog(null, Error[ErrorCode]);
				}
				return;
			}

			switch (ClickCount) {
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
			case CLICK_COUNT_MAX:
				timer.stop();
				sec = 1;
				endTime = System.currentTimeMillis();
				user2Time = (int) (endTime - startTime);
				input2 = String.valueOf((double) (user2Time) / 1000);
				user2Time = user2Time < expandTime ? expandTime - user2Time : TIMER_OVER;
				if (user1Time == user2Time) {
					ErrorCode = SAME_TIME;
					JOptionPane.showMessageDialog(null, Error[ErrorCode]);
					// 先手Betがリトライする
					ClickCount = 0;
					expandTime = rand.nextInt(9000) + 1000;
					input0 = String.valueOf((double) expandTime / 1000);
				}else {
					Number = user1Time < user2Time ? USER1_DECISION : USER2_DECISION;
					if (Number == USER1_DECISION) {
						checkResult = BetTitleNames[6];
					} else {
						checkResult = BetTitleNames[7];
					}
					CommonButton.setText("Nextへ");
				}
				break;
			}
			// 先手betInfo更新
			TextEditor.tgrBetTitle();
			ExpandLabel.setText(BetTitle);
		}
	}
}
