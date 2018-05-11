import java.awt.Color;
import java.awt.Container;
import java.awt.EventQueue;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.event.WindowEvent;
import java.awt.event.WindowListener;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.border.LineBorder;
import java.awt.Font;

public class tgrMain extends JFrame {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	// �萔���`����
	// �t���[���p�����[�^
	static int FRAME_WIDTH = 1280;
	static int FRAME_HIGHT = 960;

	//
	static int DIGITAL_PARAMETERS = 2;
	static int DIGITAL_SIZE = 20;
	static int HALF_DIGITAL_SIZE = DIGITAL_SIZE / 2;
	static int SELECT_DIGITAL_SIZE = 5;
	static int QUESTION_SIZE = 21;
	static int SELECT_QUESTION_SIZE = 6;

	// �J�[�h�p�����[�^
	static int CARD_WIDTH = 120;
	static int CARD_HIGHT = 160;
	static int CARD_SPACING = 40;
	static int QUSETION_CARD_DX = FRAME_WIDTH / 2 - (CARD_WIDTH + CARD_SPACING) * SELECT_QUESTION_SIZE / 2 + CARD_SPACING / 2;
	static int QUSETION_CARD_DY = FRAME_HIGHT / 2 - CARD_HIGHT / 2;
	static int USER1_DIGITAL_CARD_DX = FRAME_WIDTH / 2 - (CARD_WIDTH + CARD_SPACING) * (SELECT_DIGITAL_SIZE - 1) / 2 - CARD_WIDTH / 2;
	static int USER1_DIGITAL_CARD_DY = FRAME_HIGHT - FRAME_HIGHT / 6 - CARD_HIGHT / 2;
	static int USER2_DIGITAL_CARD_DX = USER1_DIGITAL_CARD_DX;
	static int USER2_DIGITAL_CARD_DY = FRAME_HIGHT / 6 - CARD_HIGHT / 2;;

	// �{�^���p�����[�^
	static int BUTTON_WIDTH = 200;
	static int BUTTON_HIGHT = 100;
	static int BUTTON_DX = FRAME_WIDTH / 2 - BUTTON_WIDTH / 2;
	static int BUTTON_DY = FRAME_HIGHT / 2 - BUTTON_HIGHT / 2;

	static int ALLUPDATE = 0;
	static int OVER = 128;

	boolean SUPPLEMENT = true;

	// ��ʃR���g���[��
	private JPanel panel = new JPanel();
	private JButton StartButton = new JButton("�J�n");

	private JLabel[] UserLabel1 = new JLabel[SELECT_DIGITAL_SIZE];
	private JLabel[] UserLabel2 = new JLabel[SELECT_DIGITAL_SIZE];
	private JLabel[] QusetionLabel = new JLabel[SELECT_QUESTION_SIZE];

	// �J���[�񋓎q���錾
	public enum ColorEnum {
		Red(1, "Red"), Blue(2, "Blue"), Green(3, "Green");

		private int id;
		private String color;

		public int getId() {
			return id;
		}

		public String getColor() {
			return color;
		}

		private ColorEnum(int id, String color) {
			this.id = id;
			this.color = color;
		}

		public static ColorEnum valueOf(int id) {
			ColorEnum[] array = values();
			for (ColorEnum num : array) {
				if (id == num.getId()) {
					return num;
				}
			}
			return null;
		}

		public static ColorEnum valueOfByName(String color) {
			ColorEnum[] array = values();
			for (ColorEnum num : array) {
				if (color.equals(num.getColor())) {
					return num;
				}
			}
			return null;
		}
	}

	// ���I�����J�[�h���`����
	public static int[][] User1DigitalCardArray = new int[SELECT_DIGITAL_SIZE][DIGITAL_PARAMETERS];
	public static int[][] User2DigitalCardArray = new int[SELECT_DIGITAL_SIZE][DIGITAL_PARAMETERS];

	// ���J�[�h���`����
	public static int[] usingQuestionCardArray = new int[SELECT_QUESTION_SIZE];

	static tgrCardStructure cardStructure = new tgrCardStructure();

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					new tgrMain();
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the frame.
	 */
	tgrMain() {
		setTitle("���c�_�Q�[��");
		setDefaultCloseOperation(JFrame.DO_NOTHING_ON_CLOSE);
		setSize(FRAME_WIDTH, FRAME_HIGHT);
		setLocationRelativeTo(null);

		// ToDo�@�摜��}������
		// ImageIcon icon = new ImageIcon("Picture/app.png");
		// setIconImage(icon.getImage());

		setResizable(false);
		setVisible(true);

		Container contentPane = getContentPane();
		contentPane.add(panel);
		panel.setLayout(null);

		this.addWindowListener(new WindowAdapter());

		// �J�n�{�^��
		StartButton.setBounds(BUTTON_DX, BUTTON_DY, BUTTON_WIDTH, BUTTON_HIGHT);
		StartButton.setForeground(Color.blue);
		StartButton.setFont(new Font("�l�r �S�V�b�N", Font.BOLD, 32));
		panel.add(StartButton);
		StartButton.addActionListener(new StartButtonListener());

		// ��ʂ�z�u����
		for (int i = 0; i < SELECT_DIGITAL_SIZE; i++) {
			// User1�J�[�h��z�u����
			UserLabel1[i] = new JLabel("", JLabel.CENTER);
			UserLabel1[i].setFont(new Font("�l�r �S�V�b�N", Font.BOLD, 32));
			UserLabel1[i].setBounds(USER1_DIGITAL_CARD_DX + i * (CARD_WIDTH + CARD_SPACING), USER1_DIGITAL_CARD_DY, CARD_WIDTH, CARD_HIGHT);
			UserLabel1[i].setVisible(false);
			panel.add(UserLabel1[i]);

			// User2�J�[�h��z�u����
			UserLabel2[i] = new JLabel("", JLabel.CENTER);
			UserLabel2[i].setFont(new Font("�l�r �S�V�b�N", Font.BOLD, 32));
			UserLabel2[i].setBounds(USER2_DIGITAL_CARD_DX + i * (CARD_WIDTH + CARD_SPACING), USER2_DIGITAL_CARD_DY, CARD_WIDTH, CARD_HIGHT);
			UserLabel2[i].setVisible(false);
			panel.add(UserLabel2[i]);
		}

		for (int i = 0; i < SELECT_QUESTION_SIZE; i++) {
			QusetionLabel[i] = new JLabel("", JLabel.CENTER);
			QusetionLabel[i].setFont(new Font("�l�r �S�V�b�N", Font.BOLD, 16));
			QusetionLabel[i].setBorder(new LineBorder(Color.orange, 5, true));
			QusetionLabel[i].setBounds(QUSETION_CARD_DX + i * (CARD_WIDTH + CARD_SPACING), QUSETION_CARD_DY, CARD_WIDTH, CARD_HIGHT);
			QusetionLabel[i].setVisible(false);
			panel.add(QusetionLabel[i]);

			QusetionLabel[i].addMouseListener(new MyMouseListener());
		}
	}

	private class WindowAdapter implements WindowListener {

		@Override
		public void windowOpened(WindowEvent e) {
			// TODO �����������ꂽ���\�b�h�E�X�^�u

		}

		@Override
		public void windowClosing(WindowEvent e) {
			// TODO �����������ꂽ���\�b�h�E�X�^�u
			int exitComfirm = JOptionPane.showConfirmDialog(null, "�L�����Z�����܂����H", "�ŏI�m�F", JOptionPane.YES_NO_OPTION, JOptionPane.WARNING_MESSAGE);
			// 0=yes, 1=no
			if (exitComfirm == 0) {
				System.exit(0);
			} else {
				return;
			}
		}

		@Override
		public void windowClosed(WindowEvent e) {
			// TODO �����������ꂽ���\�b�h�E�X�^�u

		}

		@Override
		public void windowIconified(WindowEvent e) {
			// TODO �����������ꂽ���\�b�h�E�X�^�u

		}

		@Override
		public void windowDeiconified(WindowEvent e) {
			// TODO �����������ꂽ���\�b�h�E�X�^�u

		}

		@Override
		public void windowActivated(WindowEvent e) {
			// TODO �����������ꂽ���\�b�h�E�X�^�u

		}

		@Override
		public void windowDeactivated(WindowEvent e) {
			// TODO �����������ꂽ���\�b�h�E�X�^�u

		}

	}

	private class MyMouseListener implements MouseListener {

		@Override
		public void mouseClicked(MouseEvent e) {
			// TODO �����������ꂽ���\�b�h�E�X�^�u
			for (int i = 0; i < SELECT_QUESTION_SIZE; i++) {
				if (e.getSource() == QusetionLabel[i]) {
					usingQuestionCardArray[i] = OVER;
					if (SUPPLEMENT == true) {
						SUPPLEMENT = cardStructure.tgrSupplementQuestionCard(i);
					}
					SreenUpdate(i);
					return;
				}
			}
		}

		@Override
		public void mouseEntered(MouseEvent e) {
			// TODO �����������ꂽ���\�b�h�E�X�^�u
			for (int i = 0; i < SELECT_QUESTION_SIZE; i++) {
				if (e.getSource() == QusetionLabel[i]) {
					if (usingQuestionCardArray[i] != OVER) {
						QusetionLabel[i].setFont(new Font("�l�r �S�V�b�N", Font.ITALIC, 16));
						QusetionLabel[i].setText(tgrQuestionShow(usingQuestionCardArray[i]));
					} else {
						QusetionLabel[i].setText("");
					}
					return;
				}
			}
		}

		@Override
		public void mouseExited(MouseEvent e) {
			// TODO �����������ꂽ���\�b�h�E�X�^�u
			for (int i = 0; i < SELECT_QUESTION_SIZE; i++) {
				if (e.getSource() == QusetionLabel[i]) {
					if (usingQuestionCardArray[i] != OVER) {
						QusetionLabel[i].setFont(new Font("�l�r �S�V�b�N", Font.BOLD, 16));
						QusetionLabel[i].setText("���" + String.valueOf(usingQuestionCardArray[i]));
					} else {
						QusetionLabel[i].setText("");
					}
					return;
				}
			}
		}

		@Override
		public void mousePressed(MouseEvent arg0) {
			// TODO �����������ꂽ���\�b�h�E�X�^�u

		}

		@Override
		public void mouseReleased(MouseEvent arg0) {
			// TODO �����������ꂽ���\�b�h�E�X�^�u

		}

	}

	private class StartButtonListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			StartButton.setVisible(false);
			cardStructure.tgrCardDefind();
			SreenUpdate(ALLUPDATE);
		}
	}

	private String tgrQuestionShow(int num) {
		String title = "";
		switch (num) {
		case 0:
			title = "<html>8�܂���9�͂ǂ��H</html>";
			break;
		case 1:
			title = "<html>1�܂���2�͂ǂ��H</html>";
			break;
		case 2:
			title = "<html>�A�ԂɂȂ��Ă���^�C���͂ǂ��H</html>";
			break;
		case 3:
			title = "<html>�̐����^�C���͉�������H</html>";
			break;
		case 4:
			title = "<html>�����͉�������H</html>";
			break;
		case 5:
			title = "<html>�Ԃ̐����^�C���͉�������H</html>";
			break;
		case 6:
			title = "<html>�Ԃ̐��̍��v���́H</html>";
			break;
		case 7:
			title = "<html>�̐��̍��v���́H</html>";
			break;
		case 8:
			title = "<html>[����]5���̃^�C�����ׂĂ̍��v���́H</html>";
			break;
		case 9:
			title = "<html>3�܂���4�͂ǂ��H</html>";
			break;
		case 10:
			title = "<html>���������^�C���̃y�A�͉��g����H</html>";
			break;
		case 11:
			title = "<html>[����]�����̐����^�C����5�ȏ�H4�ȉ��H</html>";
			break;
		case 12:
			title = "<html>��͉�������H</html>";
			break;
		case 13:
			title = "<html>0�͂ǂ��H</html>";
			break;
		case 14:
			title = "<html>[����]�����^�C����<br/>�ő�̐�����ŏ��̐������������́H</html>";
			break;
		case 15:
			title = "<html>�A�����ĂƂȂ荇���Ă���F�͂ǂ��H</html>";
			break;
		case 16:
			title = "<html>�������ق�����3���̍��v���́H</html>";
			break;
		case 17:
			title = "<html>6�܂���7�͂ǂ��H</html>";
			break;
		case 18:
			title = "<html>������3���̍��v���́H</html>";
			break;
		case 19:
			title = "<html>5�͂ǂ��H</html>";
			break;
		case 20:
			title = "<html>�傫���ق�����3���̍��v���́H</html>";
			break;
		default:
			break;
		}
		return title;
	}

	private void SreenUpdate(int updateSwitch) {
		if (updateSwitch == ALLUPDATE) {
			for (int i = 0; i < SELECT_QUESTION_SIZE; i++) {
				QusetionLabel[i].setText("���" + String.valueOf(usingQuestionCardArray[i]));
				QusetionLabel[i].setVisible(true);
			}
			for (int j = 0; j < SELECT_DIGITAL_SIZE; j++) {
				UserLabel1[j].setText(String.valueOf(User1DigitalCardArray[j][0]));
				switch (User1DigitalCardArray[j][1]) {
				case 1:
					UserLabel1[j].setBorder(new LineBorder(Color.red, 5, true));
					break;
				case 2:
					UserLabel1[j].setBorder(new LineBorder(Color.blue, 5, true));
					break;
				case 3:
					UserLabel1[j].setBorder(new LineBorder(Color.green, 5, true));
					break;
				}
				UserLabel1[j].setVisible(true);
			}

			for (int k = 0; k < SELECT_DIGITAL_SIZE; k++) {
				UserLabel2[k].setText(String.valueOf(User2DigitalCardArray[k][0]));
				switch (User2DigitalCardArray[k][1]) {
				case 1:
					UserLabel2[k].setBorder(new LineBorder(Color.red, 5, true));
					break;
				case 2:
					UserLabel2[k].setBorder(new LineBorder(Color.blue, 5, true));
					break;
				case 3:
					UserLabel2[k].setBorder(new LineBorder(Color.green, 5, true));
					break;
				}
				UserLabel2[k].setVisible(true);
			}
		} else {
			if (usingQuestionCardArray[updateSwitch] != OVER) {
				QusetionLabel[updateSwitch].setText("���" + String.valueOf(usingQuestionCardArray[updateSwitch]));
				QusetionLabel[updateSwitch].setFont(new Font("�l�r �S�V�b�N", Font.BOLD, 16));
			} else {
				QusetionLabel[updateSwitch].setText("");
			}
		}
	}
}
