package panels;

import static Declaration.MathConstants.*;
import process.tgrFirstMove;
import java.awt.Color;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

import javax.swing.JButton;
import javax.swing.JPanel;
import javax.swing.JTextArea;

public class BetSubView extends JPanel {
	private static final long serialVersionUID = 1L;
	private JButton button = new JButton("戻る");
	private JTextArea textArea = new JTextArea();
	tgrFirstMove FistMove = new tgrFirstMove();

	public BetSubView() {
		this.setLayout(null);
		this.setSize(FRAME_WIDTH, FRAME_HIGHT);

		button.setBounds(COMMON_BUTTON_DX, COMMON_BUTTON_DY, COMMON_BUTTON_WIDTH, COMMON_BUTTON_HIGHT);
		button.setForeground(Color.blue);
		button.setFont(new Font("ＭＳ ゴシック", Font.ITALIC, 16));
		button.setVisible(true);
		this.add(button);

		button.addActionListener(new returnButtonListener());
		System.out.println(this.isVisible());
		
        this.add(textArea);
        textArea.setBounds(300, 300, 900, 600);
        textArea.addKeyListener(new MyListener());
        textArea.append("?始?：\n");
        textArea.setVisible(true);

	}

	private class returnButtonListener implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			tgrMain.betSubView.setVisible(false);
			tgrMain.mainView.setVisible(true);
		}
	}
	
	class MyListener implements KeyListener {
        @Override // 按下
        public void keyPressed(KeyEvent e) {
            textArea.append("按下："+KeyEvent.getKeyText(e.getKeyCode()) + "\n");
        }
        @Override // 松?
        public void keyReleased(KeyEvent e) {
            textArea.append("松?：" + KeyEvent.getKeyText(e.getKeyCode()) + "\n");
            if(KeyEvent.getKeyText(e.getKeyCode()).equals("C")) {
                textArea.setText("");
            }
        }
        @Override // ?入的内容
        public void keyTyped(KeyEvent e) {
            textArea.append("?入：" + e.getKeyChar() + "\n");
        }
    }

	
}
