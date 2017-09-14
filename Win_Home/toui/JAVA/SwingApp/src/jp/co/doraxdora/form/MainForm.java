package jp.co.doraxdora.form;

import java.awt.BorderLayout;
import java.awt.EventQueue;
import java.awt.Image;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;
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
	
	JPanel contentPane;
	JButton btnNewBotton = new JButton("\u958B\u3000\u3000\u59CB");
	JLabel lblNewLabel_1 = new JLabel("");
	JLabel lblNewLabel_2 = new JLabel("");
	JLabel lblNewLabel_3 = new JLabel("");
	JLabel lblNewLabel_4 = new JLabel("");
	JLabel lblNewLabel_5 = new JLabel("");
	JLabel lblNewLabel_6 = new JLabel("");
	JLabel lblNewLabel_7 = new JLabel("");
	JLabel lblNewLabel_8 = new JLabel("");
	JLabel lblNewLabel_9 = new JLabel("");
	JLabel lblNewLabel_10 = new JLabel("");
	JLabel lblNewLabel_11 = new JLabel("");
	JLabel lblNewLabel_12 = new JLabel("");
	JLabel lblNewLabel_13 = new JLabel("");
	JLabel lblNewLabel_14 = new JLabel("");
	JLabel lblNewLabel_15 = new JLabel("");
	JLabel lblNewLabel_16 = new JLabel("");
	JLabel lblNewLabel_17 = new JLabel("");
	JLabel lblNewLabel_18 = new JLabel("");
	JLabel lblNewLabel_19 = new JLabel("");
	JLabel lblNewLabel_20 = new JLabel("");
	JLabel Jlabel[] = { lblNewLabel_1, lblNewLabel_2, lblNewLabel_3, lblNewLabel_4, 
			            lblNewLabel_5, lblNewLabel_6, lblNewLabel_7, lblNewLabel_8, 
			            lblNewLabel_9, lblNewLabel_10,lblNewLabel_11, lblNewLabel_12, 
			            lblNewLabel_13, lblNewLabel_14, lblNewLabel_15, lblNewLabel_16, 
			            lblNewLabel_17, lblNewLabel_18, lblNewLabel_19, lblNewLabel_20};
	
	DisplayCard display = new DisplayCard();
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
	public MainForm() {
		
		cardList = display.SelectCard();
				
		SetScreen();
		//ScreenUpdate();
	}

	public void SetScreen()
	{
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(0, 0, 1920, 1080);
		contentPane = new JPanel();
		contentPane.setForeground(Color.BLACK);
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		btnNewBotton.setForeground(Color.RED);
		btnNewBotton.setFont(new Font("�l�r �o�S�V�b�N", Font.BOLD | Font.ITALIC, 20));	
		btnNewBotton.setBounds(923, 501, 153, 68);
		btnNewBotton.setVisible(true);
		contentPane.add(btnNewBotton);
		
		for (int i=LBLNEWLABEL_NUM-1; i>=0; i--)
		{
			Jlabel[i].setBounds(300 + i*CARD_WIDTH/2, 840, CARD_WIDTH, CARD_HIGHT);
			Jlabel[i].setVisible(false);
			contentPane.add(Jlabel[i]);
			if (i == 10)
			{
				Jlabel[i].setHorizontalAlignment(SwingConstants.CENTER);
			}
		}
	}

	public void ScreenUpdate()
	{	
		int count = 0;
		for (int i=Calculation.Aear(cardList.size()); i<Calculation.Aear(cardList.size()) + cardList.size(); i++)
		{			
			img = new ImageIcon(Translation.TranslationPicture(cardList.get(count)));
			img.setImage(img.getImage().getScaledInstance(CARD_WIDTH, CARD_HIGHT, Image.SCALE_DEFAULT));
			Jlabel[i].setVisible(true);
			Jlabel[i].setIcon(img);		
			count++;
		}
	}
}
