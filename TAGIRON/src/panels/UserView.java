package Panels;

import static Declaration.MathConstants.*;
import static Declaration.Variable.*;

import java.awt.Color;
///import java.awt.Container;
import java.awt.Font;
//import java.awt.event.ActionEvent;
//import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
//import javax.swing.JButton;
import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.border.LineBorder;

public class UserView extends JPanel {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	// 画面コントロール
	private JLabel[] UserLabel = new JLabel[SELECT_DIGITAL_SIZE];
	private JLabel[] QusetionLabel = new JLabel[SELECT_QUESTION_SIZE];
	private JButton BetButton = new JButton("宣言");

	private int nullQusetionCount = 0;

	public UserView(String viewName) {
		this.setLayout(null);
		this.setSize(FRAME_WIDTH, FRAME_HIGHT);
		this.setName(viewName);

		for (int j = 0; j < SELECT_DIGITAL_SIZE; j++) {
			// User1カードを配置する
			UserLabel[j] = new JLabel("", JLabel.CENTER);
			UserLabel[j].setFont(new Font("ＭＳ ゴシック", Font.BOLD, 32));
			UserLabel[j].setBounds(USER_DIGITAL_CARD_DX + j * (CARD_WIDTH + CARD_SPACING), USER_DIGITAL_CARD_DY,
							CARD_WIDTH, CARD_HIGHT);
			UserLabel[j].setVisible(true);
			if (this.getName() == PanelNames[2]) {
				UserLabel[j].setText(String.valueOf(UserDigitalCardArray[0][j][0]));
				UserLabel[j].setBorder(new LineBorder(tgrMain.tgrColorDisplay(UserDigitalCardArray[0][j][1]), 5, true));
			} else if (this.getName() == PanelNames[3]) {
				UserLabel[j].setText(String.valueOf(UserDigitalCardArray[1][j][0]));
				UserLabel[j].setBorder(new LineBorder(tgrMain.tgrColorDisplay(UserDigitalCardArray[1][j][1]), 5, true));
			} else {
				ErrorCode = SCREEN_TRANSITION_FAULT;
				JOptionPane.showMessageDialog(null, Error[ErrorCode]);
				System.exit(0);
			}
			this.add(UserLabel[j]);
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

		BetButton.setBounds(RIGHT_BOTTOM_BUTTON_DX, RIGHT_BOTTOM_BUTTON_DY, RIGHT_BOTTOM_BUTTON_WIDTH, RIGHT_BOTTOM_BUTTON_HIGHT);
		BetButton.setForeground(Color.blue);
		BetButton.setFont(new Font("ＭＳ ゴシック", Font.ITALIC, 16));
		BetButton.setVisible(true);
		this.add(BetButton);

		BetButton.addActionListener(new betButtonListener());

		SreenUpdate(ALLUPDATE);
	}

	private class betButtonListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			if (Number == USER1_DECISION) {
				tgrMain.user1View.setVisible(false);
				if (BetButton.getText() == "宣言") {
					tgrMain.betUser1View.setVisible(true);
				} else if (BetButton.getText() == "相手の番へ") {
					tgrMain.user2View.setVisible(true);
					Number = USER2_DECISION;
					BetButton.setText("宣言");
				} else {
					ErrorCode = BETBUTTON_FAULT;
					JOptionPane.showMessageDialog(null, Error[ErrorCode]);
					System.exit(0);
				}
			} else if (Number == USER2_DECISION) {
				tgrMain.user2View.setVisible(false);
				if (BetButton.getText() == "宣言") {
					tgrMain.betUser2View.setVisible(true);
				} else if (BetButton.getText() == "相手の番へ") {
					tgrMain.user1View.setVisible(true);
					Number = USER1_DECISION;
					BetButton.setText("宣言");
				} else {
					ErrorCode = BETBUTTON_FAULT;
					JOptionPane.showMessageDialog(null, Error[ErrorCode]);
					System.exit(0);
				}
			} else {
				ErrorCode = NUMBER_FAULT;
				JOptionPane.showMessageDialog(null, Error[ErrorCode]);
				System.exit(0);
			}
			return;
		}
	}

	private class MyMouseListener implements MouseListener {

		@Override
		public void mouseClicked(MouseEvent e) {
			// TODO 自動生成されたメソッド・スタブ
			if (Number != NO_DECISION) {
				if (BetButton.getText() == "宣言") {
					if (nullQusetionCount != SELECT_QUESTION_SIZE) {
						for (int i = 0; i < SELECT_QUESTION_SIZE; i++) {
							if (UsingQuestionCardArray[i] != OVER) {
								if (e.getSource() == QusetionLabel[i]) {
									if (QuestionCardArray.size() != 0) {
										tgrMain.betSubView.CardStructure.tgrSupplementQuestionCard(i);
									} else {
										UsingQuestionCardArray[i] = OVER;
										nullQusetionCount++;
									}
									SreenUpdate(i);
									if (Number == USER1_DECISION) {
										tgrMain.user2View.SreenUpdate(i);
									} else if (Number == USER2_DECISION) {
										tgrMain.user1View.SreenUpdate(i);
									} else {
										ErrorCode = NUMBER_FAULT;
										JOptionPane.showMessageDialog(null, Error[ErrorCode]);
										System.exit(0);
									}
									BetButton.setText("相手の番へ");
									if (nullQusetionCount == SELECT_QUESTION_SIZE) {
										ErrorCode = ALL_QUESTION_SELECTED;
										JOptionPane.showMessageDialog(null, Error[ErrorCode]);
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
						ErrorCode = ALL_QUESTION_SELECTED;
						JOptionPane.showMessageDialog(null, Error[ErrorCode]);
					}
				} else if (BetButton.getText() == "相手の番へ") {
					ErrorCode = NEXT_DECISION;
					JOptionPane.showMessageDialog(null, Error[ErrorCode]);
				} else {
					ErrorCode = BETBUTTON_FAULT;
					JOptionPane.showMessageDialog(null, Error[ErrorCode]);
					System.exit(0);
				}
			} else {
				ErrorCode = NUMBER_FAULT;
				JOptionPane.showMessageDialog(null, Error[ErrorCode]);
				System.exit(0);
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

	public void SreenUpdate(int updateSwitch) {
		if (updateSwitch == ALLUPDATE) {
			for (int i = 0; i < SELECT_QUESTION_SIZE; i++) {
				QusetionLabel[i].setText("問題" + String.valueOf(UsingQuestionCardArray[i]));
				QusetionLabel[i].setVisible(true);
			}

		} else if (updateSwitch >= 0 && updateSwitch < ALLUPDATE) {
			if (UsingQuestionCardArray[updateSwitch] != OVER) {
				QusetionLabel[updateSwitch].setText("問題" + String.valueOf(UsingQuestionCardArray[updateSwitch]));
				QusetionLabel[updateSwitch].setFont(new Font("ＭＳ ゴシック", Font.BOLD, 16));
			} else {
				QusetionLabel[updateSwitch].setText("");
			}
		} else {
			ErrorCode = QUESTION_CLICK_FAULT;
			JOptionPane.showMessageDialog(null, Error[ErrorCode]);
			System.exit(0);
		}
	}
}
