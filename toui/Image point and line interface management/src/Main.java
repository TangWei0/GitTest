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

		setTitle("頂点管理");
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

		//最短経路計算ボタン
		JButton ShortestPathButton = new JButton("最短経路計算");
		panel.add(ShortestPathButton);
		ShortestPathButton.setBounds(600, 500, 150, 50);
		ShortestPathButton.setForeground(Color.blue);
		ShortestPathButton.setFont(new Font("ＭＳ Ｐゴシック", Font.BOLD | Font.ITALIC, 15));

		ShortestPathButton.addActionListener(new StartButtonListener());

		//
		String combodata[] = new String[PointList.size()];
		for (int i = 0; i < PointList.size(); i++) {
			
			combodata[i] = PointList.get(i);
		}
		
		//頂点ComboBox
		JComboBox<Object> PointCombo = new JComboBox<Object>(combodata);
		PointCombo.setBounds(100, 100, 200, 50);
		panel.add(PointCombo);
		
		//頂点Label
		JLabel PointLabel = new JLabel("頂点を選んでください");
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
