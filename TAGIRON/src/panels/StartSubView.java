package panels;

import static constants.MathConstants.*;

import java.awt.Color;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.JButton;
import javax.swing.JPanel;

public class StartSubView extends JPanel {
	private static final long serialVersionUID = 1L;

	private JButton StartButton = new JButton("開始");
	tgrMain tgr;
	String str;

	public StartSubView(tgrMain Main, String s) {
		tgr = Main;
		str = s;
		this.setName("startSubView");
		this.setLayout(null);
		this.setSize(1280, 960);

		// 開始ボタン
		StartButton.setBounds(BUTTON_DX, BUTTON_DY,BUTTON_WIDTH, BUTTON_HIGHT);
		StartButton.setForeground(Color.blue);
		StartButton.setFont(new Font("ＭＳ ゴシック", Font.BOLD, 32));
		StartButton.addActionListener(new StartButtonListener());
		this.add(StartButton);
	}

	private class StartButtonListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			pc(tgr.PanelNames[1]);
		}
	}
	
	public void pc(String str){
		tgr.PanelChange((JPanel)this, str);
    }

}
