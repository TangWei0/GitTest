import java.awt.Color;
import java.awt.Container;
import java.awt.EventQueue;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.ItemEvent;
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

	public static ArrayList<String> PointList = new ArrayList<String>();
	public static ArrayList<ArrayList<String>> EdgeList = new ArrayList<ArrayList<String>>();
	public static ArrayList<String> ImagePathList = new ArrayList<String>();

	static CSVReadWrite CSVReadWrite = new CSVReadWrite();
	static ShortestPath ShortestPath = new ShortestPath();

	static ButtonGroup group = new ButtonGroup();
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

		JPanel panel = new JPanel();
		Container contentPane = getContentPane();
		contentPane.add(panel);
		panel.setLayout(null);

		//最短経路計算ボタン
		JButton ShortestPathButton = new JButton("最短経路計算");
		panel.add(ShortestPathButton);
		ShortestPathButton.setBounds(600, 500, 150, 50);
		ShortestPathButton.setForeground(Color.blue);

		ShortestPathButton.addActionListener(new StartButtonListener());

		/*
		String combodata[] = new String[PointList.size() + 2];
		combodata[0] = "頂点を選んでください";
		for (int i = 0; i < PointList.size(); i++) {		
			combodata[i+1] = PointList.get(i);
		}
		combodata[PointList.size()+1] = "追加頂点";
		*/
		
		//
		JRadioButton EditRadio = new JRadioButton("編集頂点");
		EditRadio.setBounds(100, 50, 100,30);
		JRadioButton AddRadio = new JRadioButton("追加頂点");
		AddRadio.setBounds(200, 50, 100,30);
		
		
		group.add(EditRadio);
		group.add(AddRadio);
		panel.add(EditRadio);
		panel.add(AddRadio);
		
		group.setOnCheckedChangeListener(new onCheckedChanged());
		
		Vector<String> combodata = new Vector<String>(PointList);
		//頂点ComboBox
		JComboBox<String> PointCombo = new JComboBox<String>(combodata);
		PointCombo.setBounds(100, 100, 200, 30);
		panel.add(PointCombo);
		
		//頂点Label
		JLabel PointLabel = new JLabel("頂点を選んでください");
		PointLabel.setBounds(100, 70, 200,30);
		panel.add(PointLabel);
	}
	
	public class onCheckedChanged implements ActionListener {  
        // TODO Auto-generated method stub  
        RadioButton tempButton = (RadioButton)findViewById(checkedId); // 通过RadioGroup的findViewById方法，找到ID为checkedID的RadioButton  
        // 以下就可以对这个RadioButton进行处理了  
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
