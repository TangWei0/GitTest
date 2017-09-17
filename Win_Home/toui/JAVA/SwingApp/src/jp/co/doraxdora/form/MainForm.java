package jp.co.doraxdora.form;

import java.awt.EventQueue;
import java.awt.Image;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.JLabel;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.SwingConstants;
import java.util.ArrayList;
import java.awt.Font;
import java.awt.Color;

public class MainForm extends JFrame {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	static int LBLNEWLABEL_NUM = 20;
	static int CARD_WIDTH = 120;
	static int CARD_HIGHT = 150;
	ArrayList<Integer> cardList = new ArrayList<Integer>();
	
	private ImageIcon img;
	private JPanel contentPane = new JPanel();
	private JButton btnNewBotton = new JButton("\u958B\u3000\u3000\u59CB");
	private JLabel lblNewLabel_1 = new JLabel("");
	private JLabel lblNewLabel_2 = new JLabel("");
	private JLabel lblNewLabel_3 = new JLabel("");
	private JLabel lblNewLabel_4 = new JLabel("");
	private JLabel lblNewLabel_5 = new JLabel("");
	private JLabel lblNewLabel_6 = new JLabel("");
	private JLabel lblNewLabel_7 = new JLabel("");
	private JLabel lblNewLabel_8 = new JLabel("");
	private JLabel lblNewLabel_9 = new JLabel("");
	private JLabel lblNewLabel_10 = new JLabel("");
	private JLabel lblNewLabel_11 = new JLabel("");
	private JLabel lblNewLabel_12 = new JLabel("");
	private JLabel lblNewLabel_13 = new JLabel("");
	private JLabel lblNewLabel_14 = new JLabel("");
	private JLabel lblNewLabel_15 = new JLabel("");
	private JLabel lblNewLabel_16 = new JLabel("");
	private JLabel lblNewLabel_17 = new JLabel("");
	private JLabel lblNewLabel_18 = new JLabel("");
	private JLabel lblNewLabel_19 = new JLabel("");
	private JLabel lblNewLabel_20 = new JLabel("");
	private JLabel Jlabel[] = { lblNewLabel_1, lblNewLabel_2, lblNewLabel_3, lblNewLabel_4, 
			            lblNewLabel_5, lblNewLabel_6, lblNewLabel_7, lblNewLabel_8, 
			            lblNewLabel_9, lblNewLabel_10,lblNewLabel_11, lblNewLabel_12, 
			            lblNewLabel_13, lblNewLabel_14, lblNewLabel_15, lblNewLabel_16, 
			            lblNewLabel_17, lblNewLabel_18, lblNewLabel_19, lblNewLabel_20};
	
	DisplayCard DisplayCard = new DisplayCard();
	Calculation Calculation = new Calculation();
	Translation Translation = new Translation();

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					MainForm frame = new MainForm();
					frame.setLayout(null);
					frame.setVisible(true);
					frame.setResizable(false);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the frame.
	 */
	public MainForm() {
		
		SetScreen();

		//マウス監視
		contentPane.addMouseListener(new MyMouseListener());
	}
	
	//開始ボタンクリック事件
	public class StartButtonListener implements ActionListener{
		public void actionPerformed(ActionEvent e){
			btnNewBotton.setVisible(false);
			DisplayCard.StartCard();
			ScreenUpdate();	
		}		
	}
	
	public class MyMouseListener implements MouseListener{
		
		//マウスクリック事件
		public void mouseClicked(MouseEvent e){
			System.out.println(e.getSource());

			int x=e.getX(); 
			int y=e.getY(); 
			
			String str="鼠标当前点击位置的坐标是(" + x + "," + y+")";
			System.out.println(str);
			
			
			
			if (y>=800 && y<=950)
			{
				
			}
		}

		@Override
		public void mousePressed(MouseEvent e) {
			// TODO 自動生成されたメソッド・スタブ
			
		}

		@Override
		public void mouseReleased(MouseEvent e) {
			// TODO 自動生成されたメソッド・スタブ
			
		}

		@Override
		public void mouseEntered(MouseEvent e) {
			// TODO 自動生成されたメソッド・スタブ
			
		}

		@Override
		public void mouseExited(MouseEvent e) {
			// TODO 自動生成されたメソッド・スタブ
			
		}
		
	}

	
	public void SetScreen()
	{
		//Container cont = getContentPane();

		

		 
		//画面設置
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(0, 0, 1920, 1080);
		
		
		contentPane.setForeground(Color.BLACK);
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		//this.setUndecorated(true);
		System.out.println(contentPane.getSize());
		
		//開始ボタン設置
		btnNewBotton.setBounds(923, 501, 153, 68);
		btnNewBotton.setForeground(Color.RED);
		btnNewBotton.setFont(new Font("ＭＳ Ｐゴシック", Font.BOLD | Font.ITALIC, 20));
		btnNewBotton.setVisible(true);
		contentPane.add(btnNewBotton);
		
		//トランプカード設定
		for (int i=LBLNEWLABEL_NUM-1; i>=0; i--)
		{
			Jlabel[i].setBounds(300 + i*CARD_WIDTH/2, 800, CARD_WIDTH, CARD_HIGHT);
			Jlabel[i].setVisible(false);
			contentPane.add(Jlabel[i]);
			if (i == 10)
			{
				Jlabel[i].setHorizontalAlignment(SwingConstants.CENTER);
			}
		}
		
		
		//開始ボタン監視
		btnNewBotton.addActionListener(new StartButtonListener());	
	}

	public void ScreenUpdate()
	{	
		int count = 0;
		for (int i=DisplayCard.DisplayArea[0]; i<DisplayCard.DisplayArea[1]; i++)
		{			
			img = new ImageIcon(Translation.TranslationPicture(DisplayCard.cardList.get(count)));
			img.setImage(img.getImage().getScaledInstance(CARD_WIDTH, CARD_HIGHT, Image.SCALE_DEFAULT));
			Jlabel[i].setVisible(true);
			Jlabel[i].setIcon(img);		
			count++;
		}
	}
}
