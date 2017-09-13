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
	JLabel Jlabel[] = { lblNewLabel_1, lblNewLabel_2, lblNewLabel_3, lblNewLabel_4, 
			            lblNewLabel_5, lblNewLabel_6, lblNewLabel_7, lblNewLabel_8, 
			            lblNewLabel_9, lblNewLabel_10,lblNewLabel_11, lblNewLabel_12, 
			            lblNewLabel_13, lblNewLabel_14, lblNewLabel_15, lblNewLabel_16, 
			            lblNewLabel_17, lblNewLabel_18, lblNewLabel_19, lblNewLabel_20};

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
		
		DisplayCard display = new DisplayCard();
		Calculation Calculation = new Calculation();
		Translation Translation = new Translation();
		cardList = display.SelectCard();
		
		
		SetScreen();
		ScreenUpdate();
		
		for (int i=0;i<cardList.size();i++)
		{
			System.out.println(cardList.get(i));
			System.out.println(Translation.TranslationPicture(cardList.get(i)));
		}
		System.out.println();
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
		
		for (int i=19; i>=0; i--)
		{
			Jlabel[i].setBounds(130 + i*20, 385, 40, 50);
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
		//Calculation.
		Translation.
	}
}
