package Panels;

import static Declaration.MathConstants.*;
import static Declaration.Variable.*;

import java.awt.Color;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.JButton;
import javax.swing.JPanel;

public class BetSubView extends JPanel {
	private static final long serialVersionUID = 1L;
	private JButton ReturnButton = new JButton("ñﬂÇÈ");
	private JButton StartStopButton = new JButton("ÉXÉ^Å[Ég");
	
	private String input1 = "";
	private String input2 = "";
	
	private int count = 1;
	
	public BetSubView() {
		this.setLayout(null);
		this.setSize(FRAME_WIDTH, FRAME_HIGHT);

		ReturnButton.setBounds(COMMON_BUTTON_DX, COMMON_BUTTON_DY, COMMON_BUTTON_WIDTH, COMMON_BUTTON_HIGHT);
		ReturnButton.setForeground(Color.blue);
		ReturnButton.setFont(new Font("ÇlÇr ÉSÉVÉbÉN", Font.ITALIC, 16));
		ReturnButton.setVisible(true);
		this.add(ReturnButton);

		ReturnButton.addActionListener(new returnButtonListener());
		
		StartStopButton.setBounds(START_BUTTON_DX, START_BUTTON_DY, START_BUTTON_WIDTH, START_BUTTON_HIGHT);
		StartStopButton.setForeground(Color.blue);
		StartStopButton.setFont(new Font("ÇlÇr ÉSÉVÉbÉN", Font.ITALIC, 16));
		StartStopButton.setVisible(true);
		this.add(StartStopButton);

		//StartStopButton.addActionListener(new returnButtonListener());

	}

	private class returnButtonListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			tgrMain.betSubView.setVisible(false);
			tgrMain.mainView.setVisible(true);
			Number = USER1_DECISION;
		}
	}
	
}
