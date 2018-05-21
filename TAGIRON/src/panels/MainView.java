package Panels;

import static Declaration.MathConstants.*;
import static Declaration.Variable.*;

import java.awt.Color;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.border.LineBorder;

import Process.tgrCardStructure;

public class MainView extends JPanel {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	// 画面コントロール
	private JLabel[] UserLabel1 = new JLabel[SELECT_DIGITAL_SIZE];
	private JLabel[] UserLabel2 = new JLabel[SELECT_DIGITAL_SIZE];
	private JLabel[] QusetionLabel = new JLabel[SELECT_QUESTION_SIZE];

	tgrCardStructure CardStructure = new tgrCardStructure();

	private int nullQusetionCount = 0;

	public MainView() {
		this.setLayout(null);
		this.setSize(FRAME_WIDTH, FRAME_HIGHT);

		CardStructure.tgrCardDefind();
		// 画面を配置する
		for (int i = 0; i < SELECT_DIGITAL_SIZE; i++) {
			// User1カードを配置する
			UserLabel1[i] = new JLabel("", JLabel.CENTER);
			UserLabel1[i].setFont(new Font("ＭＳ ゴシック", Font.BOLD, 32));
			UserLabel1[i].setBounds(USER1_DIGITAL_CARD_DX + i * (CARD_WIDTH + CARD_SPACING), USER1_DIGITAL_CARD_DY,
					CARD_WIDTH, CARD_HIGHT);
			UserLabel1[i].setVisible(false);
			UserLabel1[i].setText(String.valueOf(User1DigitalCardArray[i][0]));
			switch (User1DigitalCardArray[i][1]) {
			case 1:
				UserLabel1[i].setBorder(new LineBorder(Color.red, 5, true));
				break;
			case 2:
				UserLabel1[i].setBorder(new LineBorder(Color.blue, 5, true));
				break;
			case 3:
				UserLabel1[i].setBorder(new LineBorder(Color.green, 5, true));
				break;
			}
			this.add(UserLabel1[i]);

			// User2カードを配置する
			UserLabel2[i] = new JLabel("", JLabel.CENTER);
			UserLabel2[i].setFont(new Font("ＭＳ ゴシック", Font.BOLD, 32));
			UserLabel2[i].setBounds(USER2_DIGITAL_CARD_DX + i * (CARD_WIDTH + CARD_SPACING), USER2_DIGITAL_CARD_DY,
					CARD_WIDTH, CARD_HIGHT);
			UserLabel2[i].setVisible(false);
			UserLabel2[i].setText(String.valueOf(User2DigitalCardArray[i][0]));
			switch (User2DigitalCardArray[i][1]) {
			case 1:
				UserLabel2[i].setBorder(new LineBorder(Color.red, 5, true));
				break;
			case 2:
				UserLabel2[i].setBorder(new LineBorder(Color.blue, 5, true));
				break;
			case 3:
				UserLabel2[i].setBorder(new LineBorder(Color.green, 5, true));
				break;
			}
			this.add(UserLabel2[i]);
		}

		for (int i = 0; i < SELECT_QUESTION_SIZE; i++) {
			QusetionLabel[i] = new JLabel("", JLabel.CENTER);
			QusetionLabel[i].setFont(new Font("ＭＳ ゴシック", Font.BOLD, 16));
			QusetionLabel[i].setBorder(new LineBorder(Color.orange, 5, true));
			QusetionLabel[i].setBounds(QUSETION_CARD_DX + i * (CARD_WIDTH + CARD_SPACING), QUSETION_CARD_DY, CARD_WIDTH,
					CARD_HIGHT);
			QusetionLabel[i].setVisible(false);
			this.add(QusetionLabel[i]);

			QusetionLabel[i].addMouseListener(new MyMouseListener());
		}

		// 先手を決めるボタン
		//BetButton.setBounds(COMMON_BUTTON_DX, COMMON_BUTTON_DY, COMMON_BUTTON_WIDTH, COMMON_BUTTON_HIGHT);
		//BetButton.setForeground(Color.blue);
		//BetButton.setFont(new Font("ＭＳ ゴシック", Font.ITALIC, 16));
		//this.add(BetButton);

		//BetButton.addActionListener(new BetButtonListener());

		SreenChange();
		SreenUpdate(ALLUPDATE);
	}

	private class MyMouseListener implements MouseListener {

		@Override
		public void mouseClicked(MouseEvent e) {
			// TODO 自動生成されたメソッド・スタブ
			if (Number != NO_DECISION) {
				if (nullQusetionCount != SELECT_QUESTION_SIZE) {
					for (int i = 0; i < SELECT_QUESTION_SIZE; i++) {
						if (UsingQuestionCardArray[i] != OVER) {
							if (e.getSource() == QusetionLabel[i]) {
								if (QuestionCardArray.size() != 0) {
									CardStructure.tgrSupplementQuestionCard(i);
								} else {
									UsingQuestionCardArray[i] = OVER;
									nullQusetionCount++;
								}
								SreenUpdate(i);
								if (nullQusetionCount == SELECT_QUESTION_SIZE) {
									JOptionPane.showMessageDialog(null, ERROR_2);
								} else {
									// 何もしない
								}
								// ループから抜く
								break;
							} else {
								// 何もしない
							}
						} else {
							// 何もしない
						}
					}
				} else {
					JOptionPane.showMessageDialog(null, ERROR_2);
				}
			} else {
				JOptionPane.showMessageDialog(null, ERROR_1);
			}
		}

		@Override
		public void mouseEntered(MouseEvent e) {
			for (int i = 0; i < SELECT_QUESTION_SIZE; i++) {
				if (e.getSource() == QusetionLabel[i]) {
					if (UsingQuestionCardArray[i] != OVER) {
						QusetionLabel[i].setFont(new Font("ＭＳ ゴシック", Font.ITALIC, 16));
						QusetionLabel[i].setText(QuestionNames[UsingQuestionCardArray[i]]);
					} else {
						QusetionLabel[i].setText("");
					}
					// ループから抜く
					break;
				} else {
					// 何もしない
				}
			}
		}

		@Override
		public void mouseExited(MouseEvent e) {
			// TODO 自動生成されたメソッド・スタブ
			for (int i = 0; i < SELECT_QUESTION_SIZE; i++) {
				if (e.getSource() == QusetionLabel[i]) {
					if (UsingQuestionCardArray[i] != OVER) {
						QusetionLabel[i].setFont(new Font("ＭＳ ゴシック", Font.BOLD, 16));
						QusetionLabel[i].setText("問題" + String.valueOf(UsingQuestionCardArray[i]));
					} else {
						QusetionLabel[i].setText("");
					}
					// ループから抜く
					break;
				} else {
					// 何もしない
				}
			}
		}

		@Override
		public void mousePressed(MouseEvent arg0) {
			// TODO 自動生成されたメソッド・スタブ

		}

		@Override
		public void mouseReleased(MouseEvent arg0) {
			// TODO 自動生成されたメソッド・スタブ

		}

	}

	private class BetButtonListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			tgrMain.mainView.setVisible(false);
			tgrMain.betSubView.setVisible(true);
		}
	}

	private void SreenUpdate(int updateSwitch) {
		if (updateSwitch == ALLUPDATE) {
			for (int i = 0; i < SELECT_QUESTION_SIZE; i++) {
				QusetionLabel[i].setText("問題" + String.valueOf(UsingQuestionCardArray[i]));
				QusetionLabel[i].setVisible(true);
			}

		} else {
			if (UsingQuestionCardArray[updateSwitch] != OVER) {
				QusetionLabel[updateSwitch].setText("問題" + String.valueOf(UsingQuestionCardArray[updateSwitch]));
				QusetionLabel[updateSwitch].setFont(new Font("ＭＳ ゴシック", Font.BOLD, 16));
			} else {
				QusetionLabel[updateSwitch].setText("");
			}
		}
	}

	public void SreenChange() {
		switch (Number) {
		case NO_DECISION:
			for (int i = 0; i < SELECT_DIGITAL_SIZE; i++) {
				UserLabel1[i].setVisible(false);
				UserLabel2[i].setVisible(false);
			}
			break;
		case USER1_DECISION:
			for (int i = 0; i < SELECT_DIGITAL_SIZE; i++) {
				UserLabel1[i].setVisible(true);
				UserLabel2[i].setVisible(false);
			}
			break;
		case USER2_DECISION:
			for (int i = 0; i < SELECT_DIGITAL_SIZE; i++) {
				UserLabel1[i].setVisible(false);
				UserLabel2[i].setVisible(true);
			}
			break;
		}
	}
}

