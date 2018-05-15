package panels;

import java.awt.Color;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.JButton;
import javax.swing.JPanel;

public class BetSubView extends JPanel {
	private static final long serialVersionUID = 1L;

	private JButton button = new JButton("ñﬂÇÈ");
	tgrMain tgrMain;
	String str;
	public BetSubView(tgrMain tgr,String s) {
		tgrMain = tgr;
		str = s;
		this.setName("betSubView");
		this.setLayout(null);
		this.setSize(1280, 960);
		
		button.setBounds(10, 10, 150, 80);
		button.setForeground(Color.blue);
		button.setFont(new Font("ÇlÇr ÉSÉVÉbÉN", Font.ITALIC, 16));
		button.setVisible(true);
		this.add(button);

		button.addActionListener(new returnButtonListener());
	}
	
	private class returnButtonListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			pc();
		}
	}
	
	public void pc(){
		tgrMain.PanelChange((JPanel)this, tgrMain.PanelNames[1]);
    }
	
}
