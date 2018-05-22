package Panels;

import static Declaration.MathConstants.*;

import java.awt.AWTEvent;
import java.awt.event.WindowEvent;
import javax.swing.JFrame;
import javax.swing.JOptionPane;

public class tgrMain extends JFrame {

	private static final long serialVersionUID = 1L;

	public static StartSubView startSubView = new StartSubView(PanelNames[0]);
	public static BetSubView betSubView = new BetSubView(PanelNames[1]);
	public static UserView user1View = new UserView(PanelNames[2]);
	public static UserView user2View = new UserView(PanelNames[3]);

	

	public static void main(String[] args) {
		
		new tgrMain();
	}

	public tgrMain() {

		this.add(startSubView);
		startSubView.setVisible(true);
		this.add(betSubView);
		betSubView.setVisible(false);
		this.add(user1View);
		user1View.setVisible(false);
		this.add(user2View);
		user2View.setVisible(false);
		this.setSize(FRAME_WIDTH, FRAME_HIGHT);
		this.setLocationRelativeTo(null);

		setDefaultCloseOperation(EXIT_ON_CLOSE);

		setVisible(true);
		setTitle("���c�_�Q�[��");

		// ToDo �摜��}������
		// ImageIcon icon = new ImageIcon("Picture/app.png");
		// setIconImage(icon.getImage());

		setResizable(false);

		try {
			enableEvents(AWTEvent.WINDOW_EVENT_MASK);
		} catch (Exception e) {
		}
	}

	protected void processWindowEvent(WindowEvent e) {
		boolean enable = false;
		if (e.getID() == WindowEvent.WINDOW_CLOSING) {
			int exitComfirm = JOptionPane.showConfirmDialog(null, "�L�����Z�����܂����H", "�ŏI�m�F", JOptionPane.YES_NO_OPTION, JOptionPane.WARNING_MESSAGE);
			enable = (exitComfirm == 1);
		}
		if (!enable) {
			super.processWindowEvent(e);
		}
	}
}
