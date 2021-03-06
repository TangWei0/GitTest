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
	private int SelectCardCount = 0;
	
	private ImageIcon img;
	private JPanel contentPane = new JPanel();
	private JButton StartButton = new JButton("开　　始");
	private JButton OutButton = new JButton("出　　牌");
	private JLabel DisplayMyCard1 = new JLabel("");
	private JLabel DisplayMyCard2 = new JLabel("");
	private JLabel DisplayMyCard3 = new JLabel("");
	private JLabel DisplayMyCard4 = new JLabel("");
	private JLabel DisplayMyCard5 = new JLabel("");
	private JLabel DisplayMyCard6 = new JLabel("");
	private JLabel DisplayMyCard7 = new JLabel("");
	private JLabel DisplayMyCard8 = new JLabel("");
	private JLabel DisplayMyCard9 = new JLabel("");
	private JLabel DisplayMyCard10 = new JLabel("");
	private JLabel DisplayMyCard11 = new JLabel("");
	private JLabel DisplayMyCard12 = new JLabel("");
	private JLabel DisplayMyCard13 = new JLabel("");
	private JLabel DisplayMyCard14 = new JLabel("");
	private JLabel DisplayMyCard15 = new JLabel("");
	private JLabel DisplayMyCard16 = new JLabel("");
	private JLabel DisplayMyCard17 = new JLabel("");
	private JLabel DisplayMyCard18 = new JLabel("");
	private JLabel DisplayMyCard19 = new JLabel("");
	private JLabel DisplayMyCard20 = new JLabel("");
	
	private JLabel DisplayOutCard1 = new JLabel("");
	private JLabel DisplayOutCard2 = new JLabel("");
	private JLabel DisplayOutCard3 = new JLabel("");
	private JLabel DisplayOutCard4 = new JLabel("");
	private JLabel DisplayOutCard5 = new JLabel("");
	private JLabel DisplayOutCard6 = new JLabel("");
	private JLabel DisplayOutCard7 = new JLabel("");
	private JLabel DisplayOutCard8 = new JLabel("");
	private JLabel DisplayOutCard9 = new JLabel("");
	private JLabel DisplayOutCard10 = new JLabel("");
	private JLabel DisplayOutCard11 = new JLabel("");
	private JLabel DisplayOutCard12 = new JLabel("");
	private JLabel DisplayOutCard13 = new JLabel("");
	private JLabel DisplayOutCard14 = new JLabel("");
	private JLabel DisplayOutCard15 = new JLabel("");
	private JLabel DisplayOutCard16 = new JLabel("");
	private JLabel DisplayOutCard17 = new JLabel("");
	private JLabel DisplayOutCard18 = new JLabel("");
	private JLabel DisplayOutCard19 = new JLabel("");
	private JLabel DisplayOutCard20 = new JLabel("");
	
	private JLabel DisplayLandlordCard1 = new JLabel("");
	private JLabel DisplayLandlordCard2 = new JLabel("");
	private JLabel DisplayLandlordCard3 = new JLabel("");
	
	private JLabel DisplayMyCard[] = {
			DisplayMyCard1, DisplayMyCard2, DisplayMyCard3, DisplayMyCard4, DisplayMyCard5, 
			DisplayMyCard6, DisplayMyCard7, DisplayMyCard8, DisplayMyCard9, DisplayMyCard10,
			DisplayMyCard11, DisplayMyCard12, DisplayMyCard13, DisplayMyCard14, DisplayMyCard15, 
			DisplayMyCard16, DisplayMyCard17, DisplayMyCard18, DisplayMyCard19, DisplayMyCard20 
			};
	
	private JLabel DisplayOutCard[] = {
            DisplayOutCard1, DisplayOutCard2, DisplayOutCard3, DisplayOutCard4, DisplayOutCard5, 
            DisplayOutCard6, DisplayOutCard7, DisplayOutCard8, DisplayOutCard9, DisplayOutCard10,
            DisplayOutCard11, DisplayOutCard12, DisplayOutCard13, DisplayOutCard14, DisplayOutCard15, 
            DisplayOutCard16, DisplayOutCard17, DisplayOutCard18, DisplayOutCard19, DisplayOutCard20 
            };
	
	private JLabel DisplayLandlordCard[] = { DisplayLandlordCard1, DisplayLandlordCard2, DisplayLandlordCard3 };
	
	DisplayCard DisplayCard = new DisplayCard();
	
	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					MainForm frame = new MainForm();
					frame.getContentPane().setLayout(null);
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
		
	}
	
	//開始ボタンクリック事件
	public class StartButtonListener implements ActionListener{
		public void actionPerformed(ActionEvent e){
			StartButton.setVisible(false);
			DisplayCard.StartCard();
			ScreenUpdate();	
		}		
	}
	
	//出牌ボタンクリック事件
	public class OutButtonListener implements ActionListener{
			public void actionPerformed(ActionEvent e){
				DisplayCard.OutCard();
				ScreenUpdate();
			}		
		}
	
	//マウスクリック事件
	public class MyMouseListener implements MouseListener{
		public void mouseClicked(MouseEvent e){
			for (int i=DisplayCard.DisplayArea[0]; i<DisplayCard.DisplayArea[0] + DisplayCard.myCardList.size(); i++)
			{				
				if(e.getSource() == DisplayMyCard[i])
				{
					if (DisplayMyCard[i].getLocation().getY() == 750)
					{
						DisplayMyCard[i].setLocation(300 + i*CARD_WIDTH/2, 800);
						DisplayCard.OutSelectCard(i, "Reduce");
						SelectCardCount--;
					}
					else if (DisplayMyCard[i].getLocation().getY() == 800)
					{
						DisplayMyCard[i].setLocation(300 + i*CARD_WIDTH/2, 750);
						DisplayCard.OutSelectCard(i, "Crease");
						SelectCardCount++;
					}
					if (SelectCardCount == 0)
					{
						OutButton.setVisible(false);
					}
					else
					{
						OutButton.setVisible(true); 
					}
					
					return;
				}
			}
		}

		@Override
		public void mousePressed(MouseEvent e) {
			
		}

		@Override
		public void mouseReleased(MouseEvent e) {
			
		}

		@Override
		public void mouseEntered(MouseEvent e) {
			
		}

		@Override
		public void mouseExited(MouseEvent e) {
			
		}
		
	}
	
	public void SetScreen()
	{	 
		//画面設置
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(0, 0, 1920, 1080);
		
		//容器设置
		contentPane.setForeground(Color.BLACK);
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		//開始ボタン設置
		StartButton.setBounds(900, 450, 120, 80);
		StartButton.setForeground(Color.RED);
		StartButton.setFont(new Font("ＭＳ Ｐゴシック", Font.BOLD | Font.ITALIC, 20));
		StartButton.setVisible(true);
		contentPane.add(StartButton);
		StartButton.addActionListener(new StartButtonListener());	
		
		//トランプカード設定
		for (int i=LBLNEWLABEL_NUM-1; i>=0; i--)
		{
			DisplayMyCard[i].setBounds(300 + i*CARD_WIDTH/2, 800, CARD_WIDTH, CARD_HIGHT);
			DisplayOutCard[i].setBounds(300 + i*CARD_WIDTH/2, 400, CARD_WIDTH, CARD_HIGHT);
			DisplayMyCard[i].setVisible(false);
			DisplayOutCard[i].setVisible(false);
			contentPane.add(DisplayMyCard[i]);
			contentPane.add(DisplayOutCard[i]);
			if (i == 10)
			{
				DisplayMyCard[i].setHorizontalAlignment(SwingConstants.CENTER);
				DisplayOutCard[i].setHorizontalAlignment(SwingConstants.CENTER);
			}
			DisplayMyCard[i].addMouseListener(new MyMouseListener());
		}
		for (int i=0; i<3; i++)
		{
			DisplayLandlordCard[i].setBounds(750 + i*CARD_HIGHT, 50, CARD_WIDTH, CARD_HIGHT);
			DisplayLandlordCard[i].setVisible(false);
			contentPane.add(DisplayLandlordCard[i]);
		}
		
		
		//出牌ボタン設置
		OutButton.setBounds(870, 650, 180, 50);
		OutButton.setForeground(Color.RED);
		OutButton.setFont(new Font("ＭＳ Ｐゴシック", Font.BOLD | Font.ITALIC, 20));
		OutButton.setVisible(false);
		contentPane.add(OutButton);
		OutButton.addActionListener(new OutButtonListener());
	}

	//画面更新
	public void ScreenUpdate()
	{
		for (int i=0; i< DisplayLandlordCard.length; i++)
		{
			img = new ImageIcon(DisplayCard.defaultCardPathList.get(i));
			img.setImage(img.getImage().getScaledInstance(CARD_WIDTH, CARD_HIGHT, Image.SCALE_DEFAULT));
			DisplayLandlordCard[i].setVisible(true);
			DisplayLandlordCard[i].setIcon(img);			
		}
		
		for (int i=0; i< DisplayMyCard.length; i++)
		{
			DisplayMyCard[i].setLocation(300 + i*CARD_WIDTH/2, 800);
			if (DisplayCard.DisplayArea[0] == -1)
			{
				DisplayMyCard[i].setVisible(false);
				continue;
			}
			else
			{
				if (i<DisplayCard.DisplayArea[0] || i >= DisplayCard.DisplayArea[0] + DisplayCard.myCardList.size())
				{
					DisplayMyCard[i].setVisible(false);
					continue;
				}
				else
				{
					img = new ImageIcon(DisplayCard.myCardPathList.get(i-DisplayCard.DisplayArea[0]));
					img.setImage(img.getImage().getScaledInstance(CARD_WIDTH, CARD_HIGHT, Image.SCALE_DEFAULT));
					DisplayMyCard[i].setVisible(true);
					DisplayMyCard[i].setIcon(img);
				}
			}
		}
		
		for (int j=0; j< DisplayOutCard.length; j++)
		{
			if (DisplayCard.DisplayArea[1] == -1)
			{
				DisplayOutCard[j].setVisible(false);
				continue;
			}
			else
			{
				if (j<DisplayCard.DisplayArea[1] || j >= DisplayCard.DisplayArea[1] + DisplayCard.outCardList.size())
				{
					DisplayOutCard[j].setVisible(false);
					continue;
				}
				else
				{
					img = new ImageIcon(DisplayCard.outCardPathList.get(j-DisplayCard.DisplayArea[1]));
					img.setImage(img.getImage().getScaledInstance(CARD_WIDTH, CARD_HIGHT, Image.SCALE_DEFAULT));
					DisplayOutCard[j].setVisible(true);
					DisplayOutCard[j].setIcon(img);
				}
			}
		}
	}

}
