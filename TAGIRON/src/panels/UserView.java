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

	// ��ʃR���g���[��
	private JLabel[] UserLabel = new JLabel[SELECT_DIGITAL_SIZE];
	private JLabel[] QusetionLabel = new JLabel[SELECT_QUESTION_SIZE];
	private JButton Button = new JButton("sss");

	private int nullQusetionCount = 0;

	public UserView(String viewName) {
		this.setLayout(null);
		this.setSize(FRAME_WIDTH, FRAME_HIGHT);
		this.setName(viewName);

		for (int j = 0; j < SELECT_DIGITAL_SIZE; j++) {
			// User1�J�[�h��z�u����
			UserLabel[j] = new JLabel("", JLabel.CENTER);
			UserLabel[j].setFont(new Font("�l�r �S�V�b�N", Font.BOLD, 32));
			UserLabel[j].setBounds(USER1_DIGITAL_CARD_DX + j * (CARD_WIDTH + CARD_SPACING), USER1_DIGITAL_CARD_DY,
							CARD_WIDTH, CARD_HIGHT);
			UserLabel[j].setVisible(true);
			if (this.getName() == PanelNames[2]) {
				UserLabel[j].setText(String.valueOf(UserDigitalCardArray[0][j][0]));
				UserLabel[j].setBorder(new LineBorder(tgrColorDisplay(UserDigitalCardArray[0][j][1]), 5, true));
			} else if (this.getName() == PanelNames[3]){
				UserLabel[j].setText(String.valueOf(UserDigitalCardArray[1][j][0]));
				UserLabel[j].setBorder(new LineBorder(tgrColorDisplay(UserDigitalCardArray[1][j][1]), 5, true));
			} else {
				ErrorCode = 7;
				JOptionPane.showMessageDialog(null, Error[ErrorCode]);
			}
			this.add(UserLabel[j]);
		}
		
		for (int i = 0; i < SELECT_QUESTION_SIZE; i++) {
			QusetionLabel[i] = new JLabel("", JLabel.CENTER);
			QusetionLabel[i].setFont(new Font("�l�r �S�V�b�N", Font.BOLD, 16));
			QusetionLabel[i].setBorder(new LineBorder(Color.orange, 5, true));
			QusetionLabel[i].setBounds(QUSETION_CARD_DX + i * (CARD_WIDTH + CARD_SPACING), QUSETION_CARD_DY, CARD_WIDTH,
					CARD_HIGHT);
			QusetionLabel[i].setVisible(false);
			this.add(QusetionLabel[i]);

			QusetionLabel[i].addMouseListener(new MyMouseListener());
		}

		Button.setBounds(10, 10, 100, 50);
		Button.setForeground(Color.blue);
		Button.setFont(new Font("�l�r �S�V�b�N", Font.ITALIC, 16));
		Button.setVisible(true);
		this.add(Button);

		Button.addActionListener(new ButtonListener());
		
		SreenUpdate(ALLUPDATE);
	}

	private Color tgrColorDisplay(int colorID) {
		Color color = null;
		switch (colorID) {
		case 1:
			color = Color.red;
			break;
		case 2:
			color = Color.blue;
			break;
		case 3:
			color = Color.green;
			break;
		}
		return color;
	}

	private class ButtonListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			tgrMain.betSubView.setVisible(true);
			tgrMain.user2View.setVisible(false);
			tgrMain.user1View.setVisible(false);
			return;
		}
	}

	private class MyMouseListener implements MouseListener {

		@Override
		public void mouseClicked(MouseEvent e) {
			// TODO �����������ꂽ���\�b�h�E�X�^�u
			if (Number != NO_DECISION) {
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
								if (nullQusetionCount == SELECT_QUESTION_SIZE) {
									ErrorCode = 1;
									JOptionPane.showMessageDialog(null, Error[ErrorCode]);
								} else {
									// �������Ȃ�
								}
								// ���[�v���甲��
								break;
							} else {
								// �������Ȃ�
							}
						} else {
							// �������Ȃ�
						}
					}
				} else {
					ErrorCode = 1;
					JOptionPane.showMessageDialog(null, Error[ErrorCode]);
				}
			} else {
				ErrorCode = 0;
				JOptionPane.showMessageDialog(null, Error[ErrorCode]);
				System.exit(0);
			}
		}

		@Override
		public void mouseEntered(MouseEvent e) {
			for (int i = 0; i < SELECT_QUESTION_SIZE; i++) {
				if (e.getSource() == QusetionLabel[i]) {
					if (UsingQuestionCardArray[i] != OVER) {
						QusetionLabel[i].setFont(new Font("�l�r �S�V�b�N", Font.ITALIC, 16));
						QusetionLabel[i].setText(QuestionNames[UsingQuestionCardArray[i]]);
					} else {
						QusetionLabel[i].setText("");
					}
					// ���[�v���甲��
					break;
				} else {
					// �������Ȃ�
				}
			}
		}

		@Override
		public void mouseExited(MouseEvent e) {
			// TODO �����������ꂽ���\�b�h�E�X�^�u
			for (int i = 0; i < SELECT_QUESTION_SIZE; i++) {
				if (e.getSource() == QusetionLabel[i]) {
					if (UsingQuestionCardArray[i] != OVER) {
						QusetionLabel[i].setFont(new Font("�l�r �S�V�b�N", Font.BOLD, 16));
						QusetionLabel[i].setText("���" + String.valueOf(UsingQuestionCardArray[i]));
					} else {
						QusetionLabel[i].setText("");
					}
					// ���[�v���甲��
					break;
				} else {
					// �������Ȃ�
				}
			}
		}

		@Override
		public void mousePressed(MouseEvent arg0) {
			// TODO �����������ꂽ���\�b�h�E�X�^�u

		}

		@Override
		public void mouseReleased(MouseEvent arg0) {
			// TODO �����������ꂽ���\�b�h�E�X�^�u

		}

	}

	private void SreenUpdate(int updateSwitch) {
		if (updateSwitch == ALLUPDATE) {
			for (int i = 0; i < SELECT_QUESTION_SIZE; i++) {
				QusetionLabel[i].setText("���" + String.valueOf(UsingQuestionCardArray[i]));
				QusetionLabel[i].setVisible(true);
			}

		} else {
			if (UsingQuestionCardArray[updateSwitch] != OVER) {
				QusetionLabel[updateSwitch].setText("���" + String.valueOf(UsingQuestionCardArray[updateSwitch]));
				QusetionLabel[updateSwitch].setFont(new Font("�l�r �S�V�b�N", Font.BOLD, 16));
			} else {
				QusetionLabel[updateSwitch].setText("");
			}
		}
	}
}
