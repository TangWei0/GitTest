import java.awt.Color;

import javax.swing.JLabel;
import javax.swing.JPanel;

public class BetPanel extends JPanel {
    /**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	JLabel paneltitle = new JLabel("これは"
            +getClass().getCanonicalName()+"クラスのパネルです");
    public BetPanel(){
        this.setLayout(null);
        this.setSize(400, 200);
        paneltitle.setBounds(0, 5, 400, 30);
        this.add(paneltitle);
        this.setBackground(Color.getHSBColor(205, 0.5f, 0.8f));
    }
}
