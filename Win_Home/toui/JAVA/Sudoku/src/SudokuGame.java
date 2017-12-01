import java.awt.Container;
import java.awt.EventQueue;
import java.util.ArrayList;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;

public class SudokuGame extends JFrame {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	// データ
	public static ArrayList<ArrayList<Integer>> Candidate = new ArrayList<ArrayList<Integer>>();
	
	public static ArrayList<Integer> CandidateItem = new ArrayList<Integer>();
	public static ArrayList<Integer> DefaultCandidateItem = new ArrayList<Integer>();
	
	public static int WIDTH_SIZE = 800;
	public static int HEIGHT_SIZE = 800;
	public static int NUM_SIZE = 9;
	public static int BOTTOM_SIZE = 11;
	public static int BUTTON_SIZE = 49;
	public static int SPACING = 50;
	public static int SelectValue = 0;
	
	public static int[][] SudokuNum = new int[NUM_SIZE][NUM_SIZE];
	
	public static int[] SelectIndexValue = new int[3];
	
	public static boolean SudokuButtonCheck = false;
	public static boolean NumButtonCheck = false;

	// 画面コントロール
	public static Container contentPane = new Container();
	public static JPanel panel = new JPanel();
	public static JButton[][] SudokuButton = new JButton[NUM_SIZE][NUM_SIZE];
	public static JButton[] NumButton = new JButton[NUM_SIZE];
	public static JButton InitialButton = new JButton("初期化");

	//クラス
	static ScreenSetting ScreenSetting = new ScreenSetting();
	static Data Data = new Data();
	
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
		
		contentPane = getContentPane();
		
		Data.StatData();
		ScreenSetting.ButtonSetting();
	}
	
	public static void SelectUpdate()
	{
		Data.DataSelectUpdate();
	}
	
}
