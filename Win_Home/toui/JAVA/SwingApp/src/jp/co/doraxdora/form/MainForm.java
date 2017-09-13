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
		ScreenUpdate();
	}

	public void SetScreen()
	{
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 1024, 768);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		for (int i=19; i>=0; i--)
		{
			Jlabel[i].setBounds(50 + i*40, 600, 80, 100);
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
			Jlabel[i].setVisible(true);
			System.out.println(Translation.TranslationPicture(cardList.get(count)));
			Jlabel[i].setIcon(new ImageIcon(Translation.TranslationPicture(cardList.get(count))));
			count++;
		}
	}
}
