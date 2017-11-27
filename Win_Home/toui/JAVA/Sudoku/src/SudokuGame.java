import java.awt.BasicStroke;
import java.awt.Color;
import java.awt.Container;
import java.awt.EventQueue;
import java.awt.Graphics;
import java.awt.Graphics2D;
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

	// 画面コントロール
	static JPanel panel = new JPanel();
	static JButton[][] sudoku = new JButton[NUM_SIZE][NUM_SIZE];

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

		JButton button1 = new JButton("button1");
		JButton button2 = new JButton("button2");
		JButton button3 = new JButton("button3");
		JButton button4 = new JButton("button4");
		JButton button5 = new JButton("button5");
		JButton button6 = new JButton("button6");
		JButton button7 = new JButton("button7");
		JButton button8 = new JButton("button8");
		JButton button9 = new JButton("button9");
		button1.setBounds(50, 50, 50, 50);
		button2.setBounds(50, 100, 50, 50);
		button3.setBounds(50, 150, 50, 50);
		button4.setBounds(50, 200, 50, 50);
		button5.setBounds(50, 250, 50, 50);
		button6.setBounds(50, 300, 50, 50);
		button7.setBounds(50, 350, 50, 50);
		button8.setBounds(50, 400, 50, 50);
		button9.setBounds(50, 450, 50, 50);
		// JButton button2 = new JButton("button2");
		// JButton button3 = new JButton("button3");
		// JButton button4 = new JButton("button4");

		// GridLayout layout = new GridLayout(9, 1);
		// panel.setLayout(null);

		button1.setContentAreaFilled(false);
		button2.setContentAreaFilled(false);
		button3.setContentAreaFilled(false);
		button4.setContentAreaFilled(false);
		button5.setContentAreaFilled(false);
		button6.setContentAreaFilled(false);
		button7.setContentAreaFilled(false);
		button8.setContentAreaFilled(false);
		button9.setContentAreaFilled(false);

		panel.add(button1);
		panel.add(button2);
		panel.add(button3);
		panel.add(button4);
		panel.add(button5);
		panel.add(button6);
		panel.add(button7);
		panel.add(button8);
		panel.add(button9);

		panel.repaint();

	}

	public void paint(Graphics g) {
		super.paint(g);
		Graphics2D g2 = (Graphics2D) g;
		g2.setColor(Color.BLACK);
		g2.setStroke(new BasicStroke(3.0f));
		g2.drawLine(50, 50, 50, 500);
	}

}
