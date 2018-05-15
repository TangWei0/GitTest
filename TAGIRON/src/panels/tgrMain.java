package panels;

import static constants.MathConstants.*;

import java.awt.event.WindowEvent;
import java.awt.event.WindowListener;
import javax.swing.JFrame;
import javax.swing.JOptionPane;
import javax.swing.JPanel;

public class tgrMain extends JFrame {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	// 抽選数字カードを定義する
	public static int[][] User1DigitalCardArray = new int[SELECT_DIGITAL_SIZE][DIGITAL_PARAMETERS];
	public static int[][] User2DigitalCardArray = new int[SELECT_DIGITAL_SIZE][DIGITAL_PARAMETERS];

	// 問題カードを定義する
	public static int[] usingQuestionCardArray = new int[SELECT_QUESTION_SIZE];

	// 画面コントロール
	public String[] PanelNames = { "startSubView", "mainView", "betSubView" };
	StartSubView startSubView = new StartSubView(this, PanelNames[0]);
	MainView mainView = new MainView(this, PanelNames[1]);
	BetSubView betSubView = new BetSubView(this, PanelNames[2]);
	
	// カラー列挙子名宣言
	public enum ColorEnum {
		Red(1, "Red"), Blue(2, "Blue"), Green(3, "Green");

		private int id;
		private String color;

		public int getId() {
			return id;
		}

		public String getColor() {
			return color;
		}

		private ColorEnum(int id, String color) {
			this.id = id;
			this.color = color;
		}

		public static ColorEnum valueOf(int id) {
			ColorEnum[] array = values();
			for (ColorEnum num : array) {
				if (id == num.getId()) {
					return num;
				}
			}
			return null;
		}

		public static ColorEnum valueOfByName(String color) {
			ColorEnum[] array = values();
			for (ColorEnum num : array) {
				if (color.equals(num.getColor())) {
					return num;
				}
			}
			return null;
		}
	}

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		tgrMain tgr = new tgrMain();
		tgr.setDefaultCloseOperation(EXIT_ON_CLOSE);
		tgr.setVisible(true);
		tgr.setTitle("多議論ゲーム");		
		
		// ToDo 画像を挿入する
		// ImageIcon icon = new ImageIcon("Picture/app.png");
		// setIconImage(icon.getImage());

		tgr.setResizable(false);
		tgr.addWindowListener(new WindowAdapter());
	}

	/**
	 * Create the frame.
	 */
	public tgrMain() {
		this.add(startSubView);
		startSubView.setVisible(true);
		this.add(mainView);
		mainView.setVisible(false);
		this.add(betSubView);
		betSubView.setVisible(false);
		this.setSize(FRAME_WIDTH, FRAME_HIGHT);
		this.setLocationRelativeTo(null);
	}

	public void PanelChange(JPanel jp, String str) {
		System.out.println(jp.getName());
        String name = jp.getName();
        if(name==PanelNames[0]){
        	startSubView = (StartSubView)jp;
        	startSubView.setVisible(false);
        }else if(name==PanelNames[1]){
        	mainView = (MainView)jp;
        	mainView.setVisible(false);
        }else if(name==PanelNames[2]){
        	betSubView = (BetSubView)jp;
        	betSubView.setVisible(false);
        }
        if(str==PanelNames[0]){
        	startSubView.setVisible(true);
        }else if(str==PanelNames[1]){
        	mainView.setVisible(true);
        }else if(str==PanelNames[2]){
        	betSubView.setVisible(true);
        }
	}

	public static class WindowAdapter implements WindowListener {

		@Override
		public void windowOpened(WindowEvent e) {
			// TODO 自動生成されたメソッド・スタブ

		}

		@Override
		public void windowClosing(WindowEvent e) {
			// TODO 自動生成されたメソッド・スタブ
			int exitComfirm = JOptionPane.showConfirmDialog(null, "キャンセルしますか？", "最終確認", JOptionPane.YES_NO_OPTION,
					JOptionPane.WARNING_MESSAGE);
			// 0=yes, 1=no
			if (exitComfirm == 0) {
				System.exit(0);
			} else {
				return;
			}
		}

		@Override
		public void windowClosed(WindowEvent e) {
			// TODO 自動生成されたメソッド・スタブ

		}

		@Override
		public void windowIconified(WindowEvent e) {
			// TODO 自動生成されたメソッド・スタブ

		}

		@Override
		public void windowDeiconified(WindowEvent e) {
			// TODO 自動生成されたメソッド・スタブ

		}

		@Override
		public void windowActivated(WindowEvent e) {
			// TODO 自動生成されたメソッド・スタブ

		}

		@Override
		public void windowDeactivated(WindowEvent e) {
			// TODO 自動生成されたメソッド・スタブ

		}

	}

}
