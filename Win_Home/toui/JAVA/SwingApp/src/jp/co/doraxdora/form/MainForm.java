package jp.co.doraxdora.form;

import java.awt.EventQueue;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;
import javax.swing.JLabel;
import javax.swing.ImageIcon;
import javax.swing.SwingConstants;
import java.util.ArrayList;
import java.util.Collections;

public class MainForm extends JFrame {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	static int LBLNEWLABEL_NUM = 20;
	ArrayList<Integer> cardList = new ArrayList<Integer>();
	JPanel contentPane;
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
	
	JLabel Jlabel[] =new JLabel[LBLNEWLABEL_NUM];

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
		
		//画面を設定する
		SetScreen();
		
		DisplayCard display = new DisplayCard();
		cardList = display.SelectCard();
		
		//画面を更新する
		//ScreenUpdate();
		
		Translation Translation = new Translation();
		
		for (int i=0;i<cardList.size();i++)
		{
			System.out.println(cardList.get(i));
			System.out.println(Translation.TranslationPicture(cardList.get(i)));
		}
		System.out.println();
		
		Calculation Calculation = new Calculation();
		System.out.println(Calculation.Aear(cardList.size()));

		/*
		System.out.println(display.num);
		for (int i=0;i<list.size();i++)
		{
			System.out.println(list.get(i));
		}
		
		switch (display.num) {
		case 1:
			lblNewLabel_1.setVisible(true);
			lblNewLabel_1.setIcon(new ImageIcon(display.CardDisplay(list.get(0))));
			break;
		case 2:
			lblNewLabel_1.setVisible(true);
			lblNewLabel_1.setIcon(new ImageIcon(display.CardDisplay(list.get(0))));
			lblNewLabel_2.setVisible(true);
			lblNewLabel_2.setIcon(new ImageIcon(display.CardDisplay(list.get(1))));
			break;
		case 3:
			lblNewLabel_1.setVisible(true);
			lblNewLabel_1.setIcon(new ImageIcon(display.CardDisplay(list.get(0))));
			lblNewLabel_2.setVisible(true);
			lblNewLabel_2.setIcon(new ImageIcon(display.CardDisplay(list.get(1))));
			lblNewLabel_3.setVisible(true);
			lblNewLabel_3.setIcon(new ImageIcon(display.CardDisplay(list.get(2))));
			break;
		}*/
	}
	
	public void SetScreen()
	{
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 705, 563);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		lblNewLabel_20.setBounds(510, 385, 40, 50);
		lblNewLabel_20.setVisible(false);
		contentPane.add(lblNewLabel_20);
		
		lblNewLabel_19.setBounds(490, 385, 40, 50);
		lblNewLabel_19.setVisible(false);
		contentPane.add(lblNewLabel_19);
		
		lblNewLabel_18.setBounds(470, 385, 40, 50);
		lblNewLabel_18.setVisible(false);
		contentPane.add(lblNewLabel_18);
		
		lblNewLabel_17.setBounds(450, 385, 40, 50);
		lblNewLabel_17.setVisible(false);
		contentPane.add(lblNewLabel_17);
		
		lblNewLabel_16.setBounds(430, 385, 40, 50);
		lblNewLabel_16.setVisible(false);
		contentPane.add(lblNewLabel_16);
		
		lblNewLabel_15.setBounds(410, 385, 40, 50);
		lblNewLabel_15.setVisible(false);
		contentPane.add(lblNewLabel_15);
		
		lblNewLabel_14.setBounds(390, 385, 40, 50);
		lblNewLabel_14.setVisible(false);
		contentPane.add(lblNewLabel_14);
		
		lblNewLabel_13.setBounds(370, 385, 40, 50);
		lblNewLabel_13.setVisible(false);
		contentPane.add(lblNewLabel_13);
		
		lblNewLabel_12.setBounds(350, 385, 40, 50);
		lblNewLabel_12.setVisible(false);
		contentPane.add(lblNewLabel_12);
		
		lblNewLabel_11.setBounds(330, 385, 40, 50);
		lblNewLabel_11.setHorizontalAlignment(SwingConstants.CENTER);
		lblNewLabel_11.setVisible(false);
		contentPane.add(lblNewLabel_11);
		
		lblNewLabel_10.setBounds(310, 385, 40, 50);
		lblNewLabel_10.setVisible(false);
		contentPane.add(lblNewLabel_10);
		
		lblNewLabel_9.setBounds(290, 385, 40, 50);
		lblNewLabel_9.setVisible(false);
		contentPane.add(lblNewLabel_9);
		
		lblNewLabel_8.setBounds(270, 385, 40, 50);
		lblNewLabel_8.setVisible(false);
		contentPane.add(lblNewLabel_8);
		
		lblNewLabel_7.setBounds(250, 385, 40, 50);
		lblNewLabel_7.setVisible(false);
		contentPane.add(lblNewLabel_7);
		
		lblNewLabel_6.setBounds(230, 385, 40, 50);
		lblNewLabel_6.setVisible(false);
		contentPane.add(lblNewLabel_6);
		
		lblNewLabel_5.setBounds(210, 385, 40, 50);
		lblNewLabel_5.setVisible(false);
		contentPane.add(lblNewLabel_5);
		
		lblNewLabel_4.setBounds(190, 385, 40, 50);
		lblNewLabel_4.setVisible(false);
		contentPane.add(lblNewLabel_4);
		
		lblNewLabel_3.setBounds(170, 385, 40, 50);
		lblNewLabel_3.setVisible(false);
		contentPane.add(lblNewLabel_3);
		
		lblNewLabel_2.setBounds(150, 385, 40, 50);
		lblNewLabel_2.setVisible(false);
		contentPane.add(lblNewLabel_2);
		
		lblNewLabel_1.setBounds(130, 385, 40, 50);
		lblNewLabel_1.setVisible(false);
		contentPane.add(lblNewLabel_1);
	}

    public void ScreenUpdate()
    {
    	
    }
}
