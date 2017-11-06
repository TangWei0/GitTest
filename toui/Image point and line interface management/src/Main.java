import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.EventQueue;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;

public class Main extends JFrame {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private JPanel contentPane;
	private JButton StartButton = new JButton("ç≈íZåoòHåvéZ");

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
					Main frame = new Main();
					frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the frame.
	 */
	public Main() {
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(0, 0, 800, 600);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(0, 0, 0, 0));
		contentPane.setLayout(new BorderLayout(0, 0));
		setContentPane(contentPane);
		
		//äJénÉ{É^Éìê›íu
		StartButton.setBounds(800, 600, 80, 40);
	        StartButton.setForeground(Color.blue);
		StartButton.setFont(new Font("ÇlÇr ÇoÉSÉVÉbÉN", Font.BOLD | Font.ITALIC, 15));
		contentPane.add(StartButton);
	    StartButton.addActionListener(new StartButtonListener());
	    
	    CSVReadWrite.CSVRead(PointList, EdgeList, ImagePathList);
	}
	
	public class StartButtonListener implements ActionListener{
		public void actionPerformed(ActionEvent e){
			long start = System.currentTimeMillis();
			ShortestPath.shortestPath();
			long end = System.currentTimeMillis();
			System.out.println((end - start) + "ms");
		}		
	}

}
