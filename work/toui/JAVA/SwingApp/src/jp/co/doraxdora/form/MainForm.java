package jp.co.doraxdora.form;

import java.awt.BorderLayout;
import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;
import javax.swing.JLabel;
import java.awt.CardLayout;
import javax.swing.ImageIcon;
import javax.swing.SwingConstants;
import java.awt.FlowLayout;
import java.util.ArrayList;

public class MainForm extends JFrame {

	private JPanel contentPane;

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
		ArrayList<Integer> list = new ArrayList<Integer>();
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 705, 563);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		JLabel lblNewLabel_3 = new JLabel("");		
		lblNewLabel_3.setBounds(350, 385, 40, 50);
		lblNewLabel_3.setVisible(false);
		contentPane.add(lblNewLabel_3);
		
		JLabel lblNewLabel_1 = new JLabel("");
		lblNewLabel_1.setBounds(330, 385, 40, 50);
		lblNewLabel_1.setHorizontalAlignment(SwingConstants.CENTER);
		lblNewLabel_1.setVisible(false);
		contentPane.add(lblNewLabel_1);
		
		JLabel lblNewLabel_2 = new JLabel("");
		lblNewLabel_2.setBounds(309, 385, 40, 50);
		lblNewLabel_2.setVisible(false);
		contentPane.add(lblNewLabel_2);
		
		DisplayCard display = new DisplayCard();
		for (int i=0;i<display.num;i++)
		{
		    int cardType =(int)(Math.random() * 4) + 1;
	        list.add(cardType);
		}
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
		}
	}
}
