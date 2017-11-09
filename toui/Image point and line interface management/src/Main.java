import java.awt.Color;
import java.awt.Container;
import java.awt.EventQueue;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.WindowEvent;
import java.awt.event.WindowListener;
import java.util.ArrayList;
import java.util.Vector;

import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTextArea;

public class Main extends JFrame {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	static CSVReadWrite CSVReadWrite = new CSVReadWrite();
	static ShortestPath ShortestPath = new ShortestPath();
	static EditPoint EditPoint = new EditPoint();
	static ClientSend ClientSend = new ClientSend();

	public static ArrayList<String> NoTrespassingList = new ArrayList<String>();
	public static ArrayList<String> PointList = new ArrayList<String>();
	public static ArrayList<ArrayList<String>> EdgeList = new ArrayList<ArrayList<String>>();
	public static ArrayList<String> ImagePathList = new ArrayList<String>();

	// 画面コントロール
	static JPanel panel = new JPanel();
	static JLabel PointLabel = new JLabel("緊急な事故を発生した頂点を選んでください");
	static JLabel PointInforLabel = new JLabel("立ち入り禁止頂点：");
	static JLabel MessageLabel = new JLabel("最新最短経路ではないので、最短経路計算ボタンをクッリクしてください。");
	static JButton ConfirmButton = new JButton("確定");
	static JButton ShortestPathButton = new JButton("最短経路計算");
	static JButton RebackButton = new JButton("復帰");
	static JComboBox<String> PointComboBox = new JComboBox<String>();
	static JTextArea ConfirmeArea = new JTextArea();
	static JScrollPane scrollbar = new JScrollPane();

	static JButton bu = new JButton("送信");
	static String SelectPoint = "";
	static String ConfirmPointText = "";

	static boolean LeastestCheck = true;
	static boolean MessageCheck = true;

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
		setDefaultCloseOperation(JFrame.DO_NOTHING_ON_CLOSE);
		setSize(800, 600);
		setLocationRelativeTo(null);
		ImageIcon icon = new ImageIcon("Picture/app.png");
		setIconImage(icon.getImage());
		setResizable(false);
		setVisible(true);

		Container contentPane = getContentPane();
		contentPane.add(panel);
		panel.setLayout(null);

		// 確定ボタン
		ConfirmButton.setBounds(500, 100, 150, 50);
		ConfirmButton.setForeground(Color.blue);
		panel.add(ConfirmButton);

		ConfirmButton.addActionListener(new ConfirmButtonListener());

		// 最短経路計算ボタン
		ShortestPathButton.setBounds(500, 200, 150, 50);
		ShortestPathButton.setForeground(Color.blue);
		panel.add(ShortestPathButton);

		ShortestPathButton.addActionListener(new ShortestPathButtonListener());

		// 復帰ボタン
		RebackButton.setBounds(500, 300, 150, 50);
		RebackButton.setForeground(Color.blue);
		panel.add(RebackButton);

		RebackButton.addActionListener(new RebackButtonListener());

		//
		bu.setBounds(500, 400, 150, 50);
		bu.setForeground(Color.blue);
		panel.add(bu);

		bu.addActionListener(new buListener());

		// 頂点comboBox
		Vector<String> combodata = new Vector<String>(PointList);
		PointComboBox = new JComboBox<String>(combodata);
		PointComboBox.setBounds(100, 100, 200, 30);
		panel.add(PointComboBox);
		PointComboBox.setVisible(true);

		PointComboBox.addActionListener(new PointComboBoxListener());

		// 頂点Label
		PointLabel.setBounds(100, 70, 300, 30);
		panel.add(PointLabel);

		// 頂点Label
		PointInforLabel.setBounds(100, 170, 300, 30);
		panel.add(PointInforLabel);

		//
		NoTrespassingUpdate();
		ConfirmeArea.setVisible(true);
		ConfirmeArea.setEditable(false);

		scrollbar = new JScrollPane(ConfirmeArea, JScrollPane.VERTICAL_SCROLLBAR_AS_NEEDED,
				JScrollPane.HORIZONTAL_SCROLLBAR_NEVER);
		scrollbar.setBounds(100, 200, 200, 200);
		panel.add(scrollbar);

		// メッセージLabel
		MessageLabel.setBounds(100, 500, 500, 30);
		MessageLabel.setForeground(Color.red);
		panel.add(MessageLabel);
		MessageLabel.setVisible(false);

		this.addWindowListener(new WindowAdapter());
	}

	public class WindowAdapter implements WindowListener {

		@Override
		public void windowOpened(WindowEvent e) {
			// TODO 自動生成されたメソッド・スタブ

		}

		@Override
		public void windowClosing(WindowEvent e) {
			// TODO 自動生成されたメソッド・スタブ
			if (MessageCheck == false) {
				JOptionPane.showMessageDialog(null, "フレーム閉じることが出来ません。\r\n最新最短経路計算を行ってください。");
			} else {
				System.exit(0);
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

	public class buListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			// TODO 自動生成されたメソッド・スタブ
			ClientSend.send();
		}
		
	}
	
	public class RebackButtonListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			CSVReadWrite.CopyFile();
			NoTrespassingList = new ArrayList<String>();
			NoTrespassingUpdate();
			MessageLabel.setVisible(false);
			MessageCheck = true;
		}

	}

	public class ShortestPathButtonListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			CSVReadWrite.PointWrite();
			ShortestPath.shortestPath();
			NoTrespassingUpdate();

			MessageLabel.setVisible(false);
			MessageCheck = true;
		}

	}

	public class ConfirmButtonListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			if (NoTrespassingList.indexOf(SelectPoint) == -1) {
				EditPoint.EditPointDelectEdge(SelectPoint);
				SortList(SelectPoint);
				NoTrespassingUpdate();

				MessageLabel.setVisible(true);
				MessageCheck = false;
			}
		}

	}

	public class PointComboBoxListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			SelectPoint = (String) PointComboBox.getSelectedItem();
		}

	}

	public void NoTrespassingUpdate() {
		ConfirmeArea.setText("");
		if (NoTrespassingList.size() != 0) {
			for (int i = 0; i < NoTrespassingList.size(); i++) {
				ConfirmeArea.append(NoTrespassingList.get(i) + "\n");
			}
		}
	}

	public void SortList(String SelectPoint) {
		int compare = Integer.parseInt(SelectPoint.substring(4, 7));
		if (NoTrespassingList.size() == 0) {
			NoTrespassingList.add(SelectPoint);
		} else {
			for (int i = 0; i < NoTrespassingList.size(); i++) {
				int listnum = Integer.parseInt(NoTrespassingList.get(i).substring(4, 7));
				if (compare < listnum) {
					NoTrespassingList.add(i, SelectPoint);
					return;
				}
			}
			NoTrespassingList.add(NoTrespassingList.size(), SelectPoint);
		}
	}

}
