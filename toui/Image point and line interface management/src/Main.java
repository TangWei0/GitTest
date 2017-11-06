import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Container;
import java.awt.EventQueue;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;

import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;

public class Main extends JFrame {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	
	public static ArrayList<String> PointList = new ArrayList<String>();
	public static ArrayList<ArrayList<String>> EdgeList = new ArrayList<ArrayList<String>>();
	public static ArrayList<String> ImagePathList = new ArrayList<String>();

	static CSVReadWrite CSVReadWrite = new CSVReadWrite();
	static ShortestPath ShortestPath = new ShortestPath();

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					new Main();
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the frame.
	 */
	Main() {
		CSVReadWrite.CSVRead(PointList, EdgeList, ImagePathList);
		
		setTitle("í∏ì_ä«óù");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setSize(800,600);
		setLocationRelativeTo(null);
		ImageIcon icon = new ImageIcon("Picture/app.png");
	    setIconImage(icon.getImage());
	    setResizable(false); 
	    setVisible(true);
		
	    JPanel panel = new JPanel();
	    Container contentPane = getContentPane();
	    contentPane.add(panel, BorderLayout.CENTER);
		panel.setLayout(null);

		JButton StartButton = new JButton("ç≈íZåoòHåvéZ");
		panel.add(StartButton);
		StartButton.setBounds(600, 500, 150, 50);
		StartButton.setForeground(Color.blue);
		StartButton.setFont(new Font("ÇlÇr ÇoÉSÉVÉbÉN", Font.BOLD | Font.ITALIC, 15));
		StartButton.addActionListener(new StartButtonListener());
		
	}

	public class StartButtonListener implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			long start = System.currentTimeMillis();
			ShortestPath.shortestPath();
			long end = System.currentTimeMillis();
			System.out.println((end - start) + "ms");
		}
	}

}
