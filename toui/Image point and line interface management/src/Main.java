import java.awt.Color;
import java.awt.Container;
import java.awt.EventQueue;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;
import java.util.Vector;

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
	public static final String LINE_SEPARATOR = System.getProperty("line.separator");

	static CSVReadWrite CSVReadWrite = new CSVReadWrite();
	static ShortestPath ShortestPath = new ShortestPath();
	static EditPoint EditPoint = new EditPoint();

	public static ArrayList<String> PointList = new ArrayList<String>();
	public static ArrayList<ArrayList<String>> EdgeList = new ArrayList<ArrayList<String>>();
	public static ArrayList<String> ImagePathList = new ArrayList<String>();

	// 画面コントロール
	static JPanel panel = new JPanel();
	static JLabel PointLabel = new JLabel("緊急な事故を発生した頂点を選んでください");
	static JButton ConfirmButton = new JButton("確定");
	static JButton SaveButton = new JButton("保存");
	static JButton RebackButton = new JButton("復帰");
	static JComboBox<String> PointComboBox = new JComboBox<String>();
	static JLabel ConfirmeLabel = new JLabel();
	
	static String SelectPoint = "";
	static String ConfirmPointText = "";
	
	static ArrayList<String> ConfirmPoint = new ArrayList<String>();
	
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
		CSVReadWrite.PointRead();

		setTitle("頂点管理システム");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setSize(800, 600);
		setLocationRelativeTo(null);
		ImageIcon icon = new ImageIcon("Picture/app.png");
		setIconImage(icon.getImage());
		setResizable(false);
		setVisible(true);

		Container contentPane = getContentPane();
		contentPane.add(panel);
		panel.setLayout(null);

		//確定ボタン
		ConfirmButton.setBounds(500, 100, 150, 50);
		ConfirmButton.setForeground(Color.blue);
		panel.add(ConfirmButton);

		ConfirmButton.addActionListener(new ConfirmButtonListener());

		//保存ボタン
		SaveButton.setBounds(500, 200, 150, 50);
		SaveButton.setForeground(Color.blue);
		panel.add(SaveButton);

		SaveButton.addActionListener(new SaveButtonListener());
		
		//復帰ボタン
		RebackButton.setBounds(500, 300, 150, 50);
		RebackButton.setForeground(Color.blue);
		panel.add(RebackButton);

		RebackButton.addActionListener(new RebackButtonListener());
		
		// 頂点comboBox
		Vector<String> combodata = new Vector<String>(PointList);
		PointComboBox = new JComboBox<String>(combodata);
		PointComboBox.setBounds(100, 100, 200, 30);
		panel.add(PointComboBox);
		PointComboBox.setVisible(true);

		PointComboBox.addActionListener(new boxListener());

		// 頂点Label
		PointLabel.setBounds(100, 70, 300, 30);
		panel.add(PointLabel);
		PointLabel.setVisible(true);
		
		//確定Label
		ConfirmeLabel.setBounds(100, 200, 300, 30);
		panel.add(ConfirmeLabel);
		ConfirmeLabel.setVisible(true);
	}

	public class RebackButtonListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			CSVReadWrite.CopyFile();
		}
		
	}
	
	public class SaveButtonListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			CSVReadWrite.PointWrite();
			ShortestPath.shortestPath();
		}
		
	}
	
	public class ConfirmButtonListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			if (ConfirmPoint.indexOf(SelectPoint) == -1)
			{
				EditPoint.EditPointDelectEdge(SelectPoint);
				ConfirmPoint.add(SelectPoint);
				ConfirmPointText += SelectPoint + LINE_SEPARATOR;
				ConfirmeLabel.setText(ConfirmPointText);
			}
		}

	}

	public class boxListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			SelectPoint = (String) PointComboBox.getSelectedItem();
		}

	}

}
