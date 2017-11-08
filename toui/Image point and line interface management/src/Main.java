import java.awt.Color;
import java.awt.Container;
import java.awt.EventQueue;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;
import java.util.Vector;

import javax.swing.ButtonGroup;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JRadioButton;

public class Main extends JFrame {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	static CSVReadWrite CSVReadWrite = new CSVReadWrite();
	static ShortestPath ShortestPath = new ShortestPath();

	public static ArrayList<String> PointList = new ArrayList<String>();
	public static ArrayList<ArrayList<String>> EdgeList = new ArrayList<ArrayList<String>>();
	public static ArrayList<String> ImagePathList = new ArrayList<String>();

	// 画面コントロール
	public static JPanel panel = new JPanel();
	public static JLabel PointLabel = new JLabel("頂点を選んでください");
	public static JButton ShortestPathButton = new JButton("最短経路計算");
	public static JComboBox<String> PointComboBox = new JComboBox<String>();
	public static JRadioButton EditPointRadioButton = new JRadioButton("頂点編集");
	public static JRadioButton AddPointRadioButton = new JRadioButton("頂点追加");
	public static ButtonGroup PointRadioButtonGroup = new ButtonGroup();

	public static String OperationType = "頂点編集";

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

		// 最短経路計算ボタン
		ShortestPathButton.setBounds(600, 500, 150, 50);
		ShortestPathButton.setForeground(Color.blue);
		panel.add(ShortestPathButton);

		ShortestPathButton.addActionListener(new ShortestPathButtonListener());

		/*
		 * String combodata[] = new String[PointList.size() + 2]; combodata[0] =
		 * "鬆らせ繧帝∈繧薙〒縺上□縺輔＞"; for (int i = 0; i < PointList.size(); i++) {
		 * combodata[i+1] = PointList.get(i); } combodata[PointList.size()+1] =
		 * "霑ｽ蜉�鬆らせ";
		 */

		// 頂点操作ラジオボタン
		EditPointRadioButton.setSelected(true);
		EditPointRadioButton.setBounds(100, 50, 100, 30);
		AddPointRadioButton.setBounds(200, 50, 100, 30);
		PointRadioButtonGroup.add(EditPointRadioButton);
		PointRadioButtonGroup.add(AddPointRadioButton);
		panel.add(EditPointRadioButton);
		panel.add(AddPointRadioButton);

		EditPointRadioButton.addActionListener(new OperationTypeButtonListener());
		AddPointRadioButton.addActionListener(new OperationTypeButtonListener());

		//頂点comboBox
		PointComboBoxUpdate(); 
		
		// 頂点Label
		PointLabel.setBounds(100, 70, 200, 30);
		panel.add(PointLabel);
		PointLabel.setVisible(true);
	}

	//頂点comboBoxの値更新
	public void PointComboBoxUpdate() {
		Vector<String> combodata = new Vector<String>(PointList);
		PointComboBox = new JComboBox<String>(combodata);
		PointComboBox.setBounds(100, 100, 200, 30);
		panel.add(PointComboBox);
		PointComboBox.setVisible(true);

		PointComboBox.addActionListener(new boxListener());
	}
	
	// 頂点comboBoxイベント
 	public class boxListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			String s = (String) PointComboBox.getSelectedItem();
			System.out.println(s);
		}

	}

	// 頂点操作ラジオボタンイベント
	public class OperationTypeButtonListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			if (OperationType != e.getActionCommand()) {
				if (e.getActionCommand() == "頂点追加") {
					PointComboBox.setVisible(false);
					PointLabel.setVisible(false);
				} else {
					PointComboBoxUpdate();
					PointLabel.setVisible(true);
				}
				OperationType = e.getActionCommand();
				System.out.println(OperationType);
			}
		}
	}

	// 最短経路計算ボタンイベント
	public class ShortestPathButtonListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			long start = System.currentTimeMillis();
			ShortestPath.shortestPath();
			long end = System.currentTimeMillis();
			System.out.println((end - start) + "ms");
		}
	}
}
