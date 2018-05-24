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

public class BetView extends JPanel {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	private JLabel[] UserLabel = new JLabel[SELECT_DIGITAL_SIZE];
	private JLabel[][] BetLabel = new JLabel[DIGITAL_PARAMETERS][HALF_DIGITAL_SIZE];
	private JButton ConfirmButton = new JButton("確定");

	private int[] userData = new int[SELECT_DIGITAL_SIZE];
	private int[][] betData = new int[DIGITAL_PARAMETERS][HALF_DIGITAL_SIZE];

	private int betPrevious = NO_LOWER;
	private int betCurrent = NONE_BET;
	private int betNext = NO_LIMIT;

	public BetView(String viewName) {
		this.setLayout(null);
		this.setSize(FRAME_WIDTH, FRAME_HIGHT);
		this.setName(viewName);

		for (int i = 0; i < SELECT_DIGITAL_SIZE; i++) {
			userData[i] = OVER;
			UserLabel[i] = new JLabel("", JLabel.CENTER);
			UserLabel[i].setFont(new Font("ＭＳ ゴシック", Font.ITALIC, 16));
			UserLabel[i].setBounds(USER_DIGITAL_CARD_DX + i * (CARD_WIDTH + CARD_SPACING), USER_DIGITAL_CARD_DY,
					CARD_WIDTH, CARD_HIGHT);
			UserLabel[i].setBorder(new LineBorder(Color.orange, 5, true));
			UserLabel[i].setVisible(true);
			this.add(UserLabel[i]);

			UserLabel[i].addMouseListener(new CancelMouseListener());
		}

		for (int i = 0; i < DIGITAL_PARAMETERS; i++) {
			for (int j = 0; j < HALF_DIGITAL_SIZE; j++) {
				betData[i][j] = DIGITAL_CARD[i][j];
				BetLabel[i][j] = new JLabel("", JLabel.CENTER);
				BetLabel[i][j].setFont(new Font("ＭＳ ゴシック", Font.ITALIC, 16));
				if (i == 0) {
					BetLabel[i][j].setBounds(BET_CARD_UP_DX + j * (BET_CARD_WIDTH + CARD_SPACING), BET_CARD_UP_DY,
							BET_CARD_WIDTH, BET_CARD_HIGHT);
					if (j == 5) {
						BetLabel[i][j].setBorder(new LineBorder(
								tgrMain.tgrColorDisplay(tgrMain.ColorEnum.valueOfByName("Green").getId()), 5, true));
					} else {
						BetLabel[i][j].setBorder(new LineBorder(
								tgrMain.tgrColorDisplay(tgrMain.ColorEnum.valueOfByName("Red").getId()), 5, true));
					}
				} else {
					BetLabel[i][j].setBounds(BET_CARD_DN_DX + j * (BET_CARD_WIDTH + CARD_SPACING), BET_CARD_DN_DY,
							BET_CARD_WIDTH, BET_CARD_HIGHT);
					if (j == 5) {
						BetLabel[i][j].setBorder(new LineBorder(
								tgrMain.tgrColorDisplay(tgrMain.ColorEnum.valueOfByName("Green").getId()), 5, true));
					} else {
						BetLabel[i][j].setBorder(new LineBorder(
								tgrMain.tgrColorDisplay(tgrMain.ColorEnum.valueOfByName("Blue").getId()), 5, true));
					}
				}
				BetLabel[i][j].setVisible(true);
				this.add(BetLabel[i][j]);

				BetLabel[i][j].addMouseListener(new BetMouseListener());
			}
		}

		ConfirmButton.setBounds(RIGHT_BOTTOM_BUTTON_DX, RIGHT_BOTTOM_BUTTON_DY, RIGHT_BOTTOM_BUTTON_WIDTH,
				RIGHT_BOTTOM_BUTTON_HIGHT);
		ConfirmButton.setForeground(Color.blue);
		ConfirmButton.setFont(new Font("ＭＳ ゴシック", Font.ITALIC, 16));
		ConfirmButton.setVisible(false);
		this.add(ConfirmButton);

		ConfirmButton.addActionListener(new confirmButtonListener());

		tgrAssistBetDisplay();
		betCurrent = 0;
	}

	private class confirmButtonListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			JOptionPane.showMessageDialog(null, "宣言チェックが飛ばす、false⇒画面に戻る");
			if (Number == USER1_DECISION) {
				tgrMain.betUser1View.setVisible(false);
				tgrMain.user1View.setVisible(true);
			} else if (Number == USER2_DECISION) {
				tgrMain.betUser2View.setVisible(false);
				tgrMain.user2View.setVisible(true);
			} else {
				ErrorCode = NUMBER_FAULT;
				JOptionPane.showMessageDialog(null, Error[ErrorCode]);
				System.exit(0);
			}
		}
	}

	private void tgrAssistBetDisplay() {
		int displayStart, displayEnd, checkStartUpDN, checkEndUpDN;
		if (betPrevious == NO_LOWER) {
			displayStart = 0;
			checkStartUpDN = -1;
		} else {
			displayStart = userData[betPrevious] % 10;
			checkStartUpDN = userData[betPrevious] / 10;
		}
		if (betNext == NO_LIMIT) {
			displayEnd = 9;
			checkEndUpDN = 2;
		} else {
			displayEnd = userData[betNext] % 10;
			checkEndUpDN = userData[betNext] / 10;
		}

		for (int i = 0; i < DIGITAL_PARAMETERS; i++) {
			for (int j = 0; j < HALF_DIGITAL_SIZE; j++) {
				if (betCurrent == NONE_BET) {
					BetLabel[i][j].setText(String.valueOf(betData[i][j] % 10));
				} else if (betCurrent == ALL_BET) {
					BetLabel[i][j].setText("");
				} else {
					if (((j > displayStart) && (j < displayEnd)) || ((j == displayStart) && (i > checkStartUpDN))
							|| ((j == displayEnd) && (i < checkEndUpDN))) {
						BetLabel[i][j].setText(String.valueOf(betData[i][j] % 10));
					} else {
						BetLabel[i][j].setText("");
					}
				}
			}
		}
	}

	private class CancelMouseListener implements MouseListener {

		@Override
		public void mouseClicked(MouseEvent e) {
			// TODO 自動生成されたメソッド・スタブ
			if (Number != NO_DECISION) {
				if (betCurrent != NONE_BET) {
					for (int k = 0; k < SELECT_DIGITAL_SIZE; k++) {
						if (e.getSource() == UserLabel[k]) {
							if (userData[k] != OVER) {
								if (k < betCurrent) {
									betCurrent = k;
									for (int i = betCurrent; i >= 0; i--) {
										if (i == 0) {
											betPrevious = NO_LOWER;
											break;
										} else {
											if (userData[i - 1] != OVER) {
												betPrevious = k - 1;
												break;
											} else {
												// 何もしない
											}
										}
									}
									for (int l = betCurrent + 1; l < SELECT_DIGITAL_SIZE; l++) {
										if (userData[l] != OVER) {
											betNext = l;
											break;
										} else {
											if (l == SELECT_DIGITAL_SIZE - 1) {
												betNext = NO_LIMIT;
											} else {
												// 何もしない
											}
										}
									}
								} else {
									if (k == betNext) {
										for (int l = betNext + 1; l < SELECT_DIGITAL_SIZE; l++) {
											if (userData[l] != OVER) {
												betNext = l;
												break;
											} else {
												if (l == SELECT_DIGITAL_SIZE - 1) {
													betNext = NO_LIMIT;
												} else {
													// 何もしない
												}
											}
										}
									} else {
										// 何もしない
									}
								}
								tgrAssistBetDisplay();
								userData[k] = OVER;
								UserLabel[k].setText("");
								UserLabel[k].setBorder(new LineBorder(Color.orange, 5, true));
								if (ConfirmButton.isVisible()) {
									ConfirmButton.setVisible(false);
								} else {
									// 何もしない
								}
								return;
							} else {
								// 何もしない
							}
						} else {
							// 何もしない
						}
					}
				} else {
					// 何もしない
				}
			} else {
				ErrorCode = NUMBER_FAULT;
				JOptionPane.showMessageDialog(null, Error[ErrorCode]);
				System.exit(0);
			}
		}

		@Override
		public void mouseEntered(MouseEvent e) {
			// TODO 自動生成されたメソッド・スタブ

		}

		@Override
		public void mouseExited(MouseEvent e) {
			// TODO 自動生成されたメソッド・スタブ

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

	private class BetMouseListener implements MouseListener {

		@Override
		public void mouseClicked(MouseEvent e) {
			// TODO 自動生成されたメソッド・スタブ
			if (Number != NO_DECISION) {
				if (betCurrent != ALL_BET) {
					for (int i = 0; i < DIGITAL_PARAMETERS; i++) {
						for (int j = 0; j < HALF_DIGITAL_SIZE; j++) {
							if (e.getSource() == BetLabel[i][j]) {
								if (betData[i][j] == OVER) {
									return;
								} else {
									if (userData[betCurrent] == OVER) {
										userData[betCurrent] = betData[i][j];
										UserLabel[betCurrent].setText(BetLabel[i][j].getText());
										UserLabel[betCurrent].setBorder(BetLabel[i][j].getBorder());
										for (int k = betCurrent; k < SELECT_DIGITAL_SIZE; k++) {
											if (k + 1 == SELECT_DIGITAL_SIZE) {
												betCurrent = ALL_BET;
												ConfirmButton.setVisible(true);
												break;
											} else {
												if (userData[k + 1] == OVER) {
													betCurrent = k + 1;
													betPrevious = k;
													for (int l = betCurrent + 1; l < SELECT_DIGITAL_SIZE; l++) {
														if (userData[l] != OVER) {
															betNext = l;
															break;
														} else {
															if (l == SELECT_DIGITAL_SIZE - 1) {
																betNext = NO_LIMIT;
															} else {
																// 何もしない
															}
														}
													}
													break;
												} else {
													// 何もしない
												}
											}
										}
										tgrAssistBetDisplay();
										return;
									} else {
										ErrorCode = BET_PROGRAM_FAULT;
										JOptionPane.showMessageDialog(null, Error[ErrorCode]);
										System.exit(0);
									}
								}
							} else {
								// 何もしない
							}
						}
					}
				} else {
					ErrorCode = BET_COUNT_MAX;
					JOptionPane.showMessageDialog(null, Error[ErrorCode]);
				}
			} else {
				ErrorCode = NUMBER_FAULT;
				JOptionPane.showMessageDialog(null, Error[ErrorCode]);
				System.exit(0);
			}
		}

		@Override
		public void mouseEntered(MouseEvent e) {
			// TODO 自動生成されたメソッド・スタブ

		}

		@Override
		public void mouseExited(MouseEvent e) {
			// TODO 自動生成されたメソッド・スタブ

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
}
