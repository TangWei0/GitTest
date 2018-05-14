import java.awt.Color;
import java.awt.Container;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;

public class BetSubView extends JFrame implements ActionListener {
	private static final long serialVersionUID = 1L;
	private JPanel panel = new JPanel();
	private JButton button = new JButton("�߂�");

	public BetSubView() {
		setTitle("���c�_�Q�[��");
		setDefaultCloseOperation(JFrame.DO_NOTHING_ON_CLOSE);
		setSize(tgrMain.FRAME_WIDTH, tgrMain.FRAME_HIGHT);
		setLocationRelativeTo(null);

		// ToDo �摜��}������
		// ImageIcon icon = new ImageIcon("Picture/app.png");
		// setIconImage(icon.getImage());

		setResizable(false);
		setVisible(true);

		Container contentPane = getContentPane();
		contentPane.add(panel);
		panel.setLayout(null);

		this.addWindowListener(new tgrMain.WindowAdapter());
		
		button.setBounds(10, 10, 150, 80);
		button.setForeground(Color.blue);
		button.setFont(new Font("�l�r �S�V�b�N", Font.ITALIC, 16));
		button.setVisible(true);
		panel.add(button);

		button.addActionListener(new returnButtonListener());
	}

	@Override
	public void actionPerformed(ActionEvent arg0) {
		// TODO �����������ꂽ���\�b�h�E�X�^�u
		
	}
	
	private class returnButtonListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			BetSubView.this.setVisible(false);
			StartSubView.panel.setVisible(true);
		}
	}
	
}