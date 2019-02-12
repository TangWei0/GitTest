package Com.OrdeFood.Screen;

import Com.OrderFood.Log.*;

import java.awt.Window;
import java.awt.event.WindowEvent;
import java.awt.event.WindowListener;

import javax.swing.JFrame;

public class OrderFoodFrame extends JFrame {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	static OrderFoodLogger ofLogger = new OrderFoodLogger();

	/**
	 * Create the frame.
	 * 
	 * @return
	 */
	public void ofLoginFrame() {
		ofLogger.ofWriteLogger("CONFIG", OrderFoodApp.ofWidth + " " + OrderFoodApp.ofHeight);
		Window frame = new JFrame();
		((JFrame) frame).setSize(OrderFoodApp.ofWidth, OrderFoodApp.ofHeight);
		((JFrame) frame).setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		((JFrame) frame).setVisible(true);
		((JFrame) frame).setResizable(false);
		((JFrame) frame).addWindowListener(new myListener());
	}
	
	public class myListener implements WindowListener{
		  public void windowOpened(WindowEvent e){
		    /* 処理したい内容をここに記述する */
		  }

		  public void windowClosing(WindowEvent e){
		    /* 処理したい内容をここに記述する */
			  ofLogger.ofWriteLogger("INFO", "アプリ終了しました。");
		  }

		  public void windowClosed(WindowEvent e){
		    /* 処理したい内容をここに記述する */
		  }

		  public void windowIconified(WindowEvent e){
		    /* 処理したい内容をここに記述する */
		  }

		  public void windowDeiconified(WindowEvent e){
		    /* 処理したい内容をここに記述する */
		  }

		  public void windowActivated(WindowEvent e){
		    /* 処理したい内容をここに記述する */
		  }

		  public void windowDeactivated(WindowEvent e){
		    /* 処理したい内容をここに記述する */
		  }
		}

	

}
