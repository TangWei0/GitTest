import java.awt.Color;
import java.awt.Container;
import java.awt.EventQueue;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;

import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;

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
		setSize(800, 600);
		setLocationRelativeTo(null);
		ImageIcon icon = new ImageIcon("Picture/app.png");
		setIconImage(icon.getImage());
		setResizable(false);
		setVisible(true);

		JPanel panel = new JPanel();
		Container contentPane = getContentPane();
		contentPane.add(panel);
		panel.setLayout(null);

		//ç≈íZåoòHåvéZÉ{É^Éì
		JButton ShortestPathButton = new JButton("ç≈íZåoòHåvéZ");
		panel.add(ShortestPathButton);
		ShortestPathButton.setBounds(600, 500, 150, 50);
		ShortestPathButton.setForeground(Color.blue);
		ShortestPathButton.setFont(new Font("ÇlÇr ÇoÉSÉVÉbÉN", Font.BOLD | Font.ITALIC, 15));

		ShortestPathButton.addActionListener(new StartButtonListener());

		//
		String combodata[] = new String[PointList.size()];
		for (int i = 0; i < PointList.size(); i++) {
			
			combodata[i] = PointList.get(i);
		}
		
		//í∏ì_ComboBox
		JComboBox<Object> PointCombo = new JComboBox<Object>(combodata);
		PointCombo.setBounds(100, 100, 200, 50);
		panel.add(PointCombo);
		
		//í∏ì_Label
		JLabel PointLabel = new JLabel("í∏ì_ÇëIÇÒÇ≈Ç≠ÇæÇ≥Ç¢");
		PointLabel.setBounds(100, 60, 200,30);
		panel.add(PointLabel);
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
