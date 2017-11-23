import java.awt.Container;
import java.awt.Toolkit;
import javax.swing.JFrame;
import javax.swing.JPanel;

public class GomokuGame extends JFrame {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	static OperatorPane op = null;
	
	private static int BOARD_SIZE = 510;
	
	public static void main(String[] args) {
		// TODO 自動生成されたメソッド・スタブ
		new GomokuGame();
	}

	public GomokuGame()
	{
		this.setTitle("五子棋");
		this.setSize(BOARD_SIZE, BOARD_SIZE);
		
		int computer_width = Toolkit.getDefaultToolkit().getScreenSize().width;
		int computer_height = Toolkit.getDefaultToolkit().getScreenSize().height;
		
		//测试显示
		System.out.println("宽:" + computer_width +" 高度:" + computer_height);
		
		this.setLocation((computer_width-BOARD_SIZE)/2, (computer_height-BOARD_SIZE)/2);
		this.setVisible(true);
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		op = new OperatorPane();
		this.add(op);
		this.addMouseListener(op);
	}
	
	

}
