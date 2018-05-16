package panels;

import static constants.MathConstants.*;

import java.awt.Color;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.JButton;
import javax.swing.JPanel;

public class BetSubView extends JPanel {
	private static final long serialVersionUID = 1L;

	private JButton button = new JButton("ñﬂÇÈ");
	
	public BetSubView() {
		this.setLayout(null);
		this.setSize(FRAME_WIDTH, FRAME_HIGHT);

		button.setBounds(COMMON_BUTTON_DX, COMMON_BUTTON_DY, COMMON_BUTTON_WIDTH, COMMON_BUTTON_HIGHT);
		button.setForeground(Color.blue);
		button.setFont(new Font("ÇlÇr ÉSÉVÉbÉN", Font.ITALIC, 16));
		button.setVisible(true);
		this.add(button);

		button.addActionListener(new returnButtonListener());
	}
	
	private class returnButtonListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			tgrMain.betSubView.setVisible(false);
			tgrMain.mainView.setVisible(true);
		}
	}
	
}