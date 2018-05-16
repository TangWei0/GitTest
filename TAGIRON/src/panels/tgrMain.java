package panels;

import static constants.MathConstants.*;

import java.awt.AWTEvent;
import java.awt.event.WindowEvent;
import javax.swing.JFrame;
import javax.swing.JOptionPane;

public class tgrMain extends JFrame {

	private static final long serialVersionUID = 1L;
	
	// ���I�����J�[�h���`����
	public static int[][] User1DigitalCardArray = new int[SELECT_DIGITAL_SIZE][DIGITAL_PARAMETERS];
	public static int[][] User2DigitalCardArray = new int[SELECT_DIGITAL_SIZE][DIGITAL_PARAMETERS];

	// ���J�[�h���`����
	public static int[] usingQuestionCardArray = new int[SELECT_QUESTION_SIZE];
	
	public static StartSubView startSubView = new StartSubView();
	public static MainView mainView = new MainView();
	public static BetSubView betSubView = new BetSubView();
	
	
	public static void main(String[] args) {
	new tgrMain();
	}

	public tgrMain() {
		this.add(startSubView);
		startSubView.setVisible(true);
		this.add(mainView);
		mainView.setVisible(false);
		this.add(betSubView);
		betSubView.setVisible(false);
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
