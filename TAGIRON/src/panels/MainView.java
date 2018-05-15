package panels;

import static constants.MathConstants.*;

import java.awt.Color;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;

import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.border.LineBorder;

public class MainView extends JPanel {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	
	// 画面コントロール
	private JButton BetButton = new JButton("先手を決める");

	private JLabel[] UserLabel1 = new JLabel[SELECT_DIGITAL_SIZE];
	private JLabel[] UserLabel2 = new JLabel[SELECT_DIGITAL_SIZE];
	private JLabel[] QusetionLabel = new JLabel[SELECT_QUESTION_SIZE];
	
	static tgrCardStructure cardStructure = new tgrCardStructure();
	tgrMain tgrMain;
	String str;
	
	public MainView(tgrMain tgr,String s){
		tgrMain = tgr;
		str = s;
		cardStructure.tgrCardDefind();
		this.setName("mainView");
		this.setLayout(null);
		this.setSize(1280, 960);
		// 画面を配置する
		for (int i = 0; i < SELECT_DIGITAL_SIZE; i++) {
			// User1カードを配置する
			UserLabel1[i] = new JLabel("", JLabel.CENTER);
			UserLabel1[i].setFont(new Font("ＭＳ ゴシック", Font.BOLD, 32));
			UserLabel1[i].setBounds(USER1_DIGITAL_CARD_DX + i * (CARD_WIDTH + CARD_SPACING), USER1_DIGITAL_CARD_DY,
					CARD_WIDTH, CARD_HIGHT);
			UserLabel1[i].setVisible(false);
			this.add(UserLabel1[i]);

			// User2カードを配置する
			UserLabel2[i] = new JLabel("", JLabel.CENTER);
			UserLabel2[i].setFont(new Font("ＭＳ ゴシック", Font.BOLD, 32));
			UserLabel2[i].setBounds(USER2_DIGITAL_CARD_DX + i * (CARD_WIDTH + CARD_SPACING), USER2_DIGITAL_CARD_DY,
					CARD_WIDTH, CARD_HIGHT);
			UserLabel2[i].setVisible(false);
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
		// 　定数をstaticにする
		BetButton.setBounds(10, 10, 150, 80);
		BetButton.setForeground(Color.blue);
		BetButton.setFont(new Font("ＭＳ ゴシック", Font.ITALIC, 16));
		BetButton.setVisible(true);
		this.add(BetButton);

		BetButton.addActionListener(new BetButtonListener());

		SreenUpdate(ALLUPDATE);
	}
	
	private class MyMouseListener implements MouseListener {

		@Override
		public void mouseClicked(MouseEvent e) {
			// TODO 自動生成されたメソッド・スタブ
			for (int i = 0; i < SELECT_QUESTION_SIZE; i++) {
				if (panels.tgrMain.usingQuestionCardArray[i] != OVER) {
					if (e.getSource() == QusetionLabel[i]) {
						if (cardStructure.QuestionCardArray.size() != 0) {
							cardStructure.tgrSupplementQuestionCard(i);
						} else {
							panels.tgrMain.usingQuestionCardArray[i] = OVER;
						}
						SreenUpdate(i);
						return;
					}
				}
			}
		}

		@Override
		public void mouseEntered(MouseEvent e) {
			for (int i = 0; i < SELECT_QUESTION_SIZE; i++) {
				if (e.getSource() == QusetionLabel[i]) {
					if (panels.tgrMain.usingQuestionCardArray[i] != OVER) {
						QusetionLabel[i].setFont(new Font("ＭＳ ゴシック", Font.ITALIC, 16));
						QusetionLabel[i].setText(tgrQuestionShow(panels.tgrMain.usingQuestionCardArray[i]));
					} else {
						QusetionLabel[i].setText("");
					}
					return;
				}
			}
		}

		@Override
		public void mouseExited(MouseEvent e) {
			// TODO 自動生成されたメソッド・スタブ
			for (int i = 0; i < SELECT_QUESTION_SIZE; i++) {
				if (e.getSource() == QusetionLabel[i]) {
					if (panels.tgrMain.usingQuestionCardArray[i] != OVER) {
						QusetionLabel[i].setFont(new Font("ＭＳ ゴシック", Font.BOLD, 16));
						QusetionLabel[i].setText("問題" + String.valueOf(panels.tgrMain.usingQuestionCardArray[i]));
					} else {
						QusetionLabel[i].setText("");
					}
					return;
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
			pc();
		}
	}
	
	public void pc(){
		tgrMain.PanelChange((JPanel)this, tgrMain.PanelNames[2]);
    }

	private String tgrQuestionShow(int num) {
		String title = "";
		switch (num) {
		case 0:
			title = "<html>8または9はどこ？</html>";
			break;
		case 1:
			title = "<html>1または2はどこ？</html>";
			break;
		case 2:
			title = "<html>連番になっているタイルはどこ？</html>";
			break;
		case 3:
			title = "<html>青の数字タイルは何枚ある？</html>";
			break;
		case 4:
			title = "<html>偶数は何枚ある？</html>";
			break;
		case 5:
			title = "<html>赤の数字タイルは何枚ある？</html>";
			break;
		case 6:
			title = "<html>赤の数の合計数は？</html>";
			break;
		case 7:
			title = "<html>青の数の合計数は？</html>";
			break;
		case 8:
			title = "<html>[共通]5枚のタイルすべての合計数は？</html>";
			break;
		case 9:
			title = "<html>3または4はどこ？</html>";
			break;
		case 10:
			title = "<html>同じ数字タイルのペアは何組ある？</html>";
			break;
		case 11:
			title = "<html>[共通]中央の数字タイルの5以上？4以下？</html>";
			break;
		case 12:
			title = "<html>奇数は何枚ある？</html>";
			break;
		case 13:
			title = "<html>0はどこ？</html>";
			break;
		case 14:
			title = "<html>[共通]数字タイルの<br/>最大の数から最小の数を引いた数は？</html>";
			break;
		case 15:
			title = "<html>連続してとなり合っている色はどこ？</html>";
			break;
		case 16:
			title = "<html>小さいほうから3枚の合計数は？</html>";
			break;
		case 17:
			title = "<html>6または7はどこ？</html>";
			break;
		case 18:
			title = "<html>中央の3枚の合計数は？</html>";
			break;
		case 19:
			title = "<html>5はどこ？</html>";
			break;
		case 20:
			title = "<html>大きいほうから3枚の合計数は？</html>";
			break;
		default:
			break;
		}
		return title;
	}

	private void SreenUpdate(int updateSwitch) {
		if (updateSwitch == ALLUPDATE) {
			for (int i = 0; i < SELECT_QUESTION_SIZE; i++) {
				QusetionLabel[i].setText("問題" + String.valueOf(panels.tgrMain.usingQuestionCardArray[i]));
				QusetionLabel[i].setVisible(true);
			}
			for (int j = 0; j < SELECT_DIGITAL_SIZE; j++) {
				UserLabel1[j].setText(String.valueOf(panels.tgrMain.User1DigitalCardArray[j][0]));
				switch (panels.tgrMain.User1DigitalCardArray[j][1]) {
				case 1:
					UserLabel1[j].setBorder(new LineBorder(Color.red, 5, true));
					break;
				case 2:
					UserLabel1[j].setBorder(new LineBorder(Color.blue, 5, true));
					break;
				case 3:
					UserLabel1[j].setBorder(new LineBorder(Color.green, 5, true));
					break;
				}
				UserLabel1[j].setVisible(true);
			}

			for (int k = 0; k < SELECT_DIGITAL_SIZE; k++) {
				UserLabel2[k].setText(String.valueOf(panels.tgrMain.User2DigitalCardArray[k][0]));
				switch (panels.tgrMain.User2DigitalCardArray[k][1]) {
				case 1:
					UserLabel2[k].setBorder(new LineBorder(Color.red, 5, true));
					break;
				case 2:
					UserLabel2[k].setBorder(new LineBorder(Color.blue, 5, true));
					break;
				case 3:
					UserLabel2[k].setBorder(new LineBorder(Color.green, 5, true));
					break;
				}
				UserLabel2[k].setVisible(true);
			}
		} else {
			if (panels.tgrMain.usingQuestionCardArray[updateSwitch] != OVER) {
				QusetionLabel[updateSwitch].setText("問題" + String.valueOf(panels.tgrMain.usingQuestionCardArray[updateSwitch]));
				QusetionLabel[updateSwitch].setFont(new Font("ＭＳ ゴシック", Font.BOLD, 16));
			} else {
				QusetionLabel[updateSwitch].setText("");
			}
		}
	}
}

