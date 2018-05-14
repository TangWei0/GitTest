import java.awt.Color;
import java.awt.Container;
import java.awt.EventQueue;
import java.awt.Font;
import java.awt.Frame;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.WindowEvent;
import java.awt.event.WindowListener;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JOptionPane;
import javax.swing.JPanel;

public class tgrMain extends JFrame {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	// �萔���`����
	// �t���[���p�����[�^
	static int FRAME_WIDTH = 1280;
	static int FRAME_HIGHT = 960;

	// �{�^���p�����[�^
	static int BUTTON_WIDTH = 200;
	static int BUTTON_HIGHT = 100;
	static int BUTTON_DX = FRAME_WIDTH / 2 - BUTTON_WIDTH / 2;
	static int BUTTON_DY = FRAME_HIGHT / 2 - BUTTON_HIGHT / 2;

	// ��ʃR���g���[��
	private static JPanel panel = new JPanel();
	private JButton StartButton = new JButton("�J�n");

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
	public tgrMain() {
		setTitle("���c�_�Q�[��");
		setDefaultCloseOperation(JFrame.DO_NOTHING_ON_CLOSE);
		setSize(FRAME_WIDTH, FRAME_HIGHT);
		setLocationRelativeTo(null);

		// ToDo �摜��}������
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
		StartButton.setVisible(true);
		StartButton.addActionListener(new StartButtonListener());
	}

	public static class WindowAdapter implements WindowListener {

		@Override
		public void windowOpened(WindowEvent e) {
			// TODO �����������ꂽ���\�b�h�E�X�^�u

		}

		@Override
		public void windowClosing(WindowEvent e) {
			// TODO �����������ꂽ���\�b�h�E�X�^�u
			int exitComfirm = JOptionPane.showConfirmDialog(null, "�L�����Z�����܂����H", "�ŏI�m�F", JOptionPane.YES_NO_OPTION,
					JOptionPane.WARNING_MESSAGE);
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

	private class StartButtonListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			StartSubView startSubView = new StartSubView();
			startSubView.setVisible(true);
			tgrMain.this.setVisible(false);
		}
	}
}
