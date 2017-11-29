import java.awt.Container;
import java.awt.EventQueue;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;

public class SudokuGame extends JFrame {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	private static int WIDTH_SIZE = 800;
	private static int HEIGHT_SIZE = 800;
	private static int NUM_SIZE = 9;
	private static int BUTTON_SIZE = 49;
	private static int SPACING = 50;

	//データ
	public ArrayList<Integer> SudokuNumItem = new ArrayList<Integer>(); 
	public ArrayList<Integer>[][] SudokuNum = new ArrayList<Integer>[NUM_SIZE][NUM_SIZE]();
	// 画面コントロール
	static JPanel panel = new JPanel();
	static JButton[][] SudokuButton = new JButton[NUM_SIZE][NUM_SIZE];
	static JButton[] NumButton = new JButton[NUM_SIZE];
	static JButton InitialButton = new JButton("初期化");

	boolean SudokuButtonCheck = false;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					new SudokuGame();
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the frame.
	 */
	SudokuGame() {
		setTitle("数独");
		setSize(WIDTH_SIZE, HEIGHT_SIZE);
		setVisible(true);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setLocationRelativeTo(null);

		Container contentPane = getContentPane();
		contentPane.add(panel);
		panel.setLayout(null);
		panel.setOpaque(false);

		SetGameTable();
		SetNumTable();

		InitialButton.setBounds(11 * SPACING, SPACING, 2 * BUTTON_SIZE, BUTTON_SIZE);
		panel.add(InitialButton);

		InitialButton.addActionListener(new InitialButtonListener());
		// JButton button2 = new JButton("button2");
		// JButton button3 = new JButton("button3");
		// JButton button4 = new JButton("button4");

		// GridLayout layout = new GridLayout(9, 1);
		// panel.setLayout(null);
	}

	public void SetGameTable() {
		for (int i = 0; i < NUM_SIZE; i++) {
			for (int j = 0; j < NUM_SIZE; j++) {
				SudokuButton[i][j] = new JButton("");
				SudokuButton[i][j].setBounds((i + 1) * SPACING, (j + 1) * SPACING, BUTTON_SIZE, BUTTON_SIZE);
				panel.add(SudokuButton[i][j]);

				SudokuButton[i][j].addActionListener(new SudokuButtonListener());
			}
		}
	}

	public void SetNumTable() {
		for (int i = 0; i < NUM_SIZE; i++) {
			NumButton[i] = new JButton(String.valueOf(i + 1));
			NumButton[i].setBounds((i + 1) * SPACING, 11 * SPACING, BUTTON_SIZE, BUTTON_SIZE);
			panel.add(NumButton[i]);
			
			NumButton[i].addActionListener(new NumButtonListener());
		}
	}

	public class InitialButtonListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent arg0) {
			// TODO 自動生成されたメソッド・スタブ
			SudokuButtonCheck = true;
		}

	}

	public class SudokuButtonListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			// TODO 自動生成されたメソッド・スタブ
			if (SudokuButtonCheck == true) {
				System.out.println("按钮有效");
			}
		}

	}
	
	public class NumButtonListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			// TODO 自動生成されたメソッド・スタブ
			
		}

	}
}
