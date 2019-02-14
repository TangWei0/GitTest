package Com.OrderFood.Screen;

import Com.OrderFood.Access.OrderFoodAccess;
import Com.OrderFood.Timer.OrderFoodTimerTask;
import Com.OrderFood.Data.*;
import Com.OrderFood.Log.*;

import java.awt.EventQueue;
import java.awt.GraphicsEnvironment;
import java.io.IOException;
import java.net.ServerSocket;

import javax.swing.JOptionPane;

public class OrderFoodApp {
	static OrderFoodFrame ofFrame = new OrderFoodFrame();
	public static OrderFoodLogger ofLogger = new OrderFoodLogger();
	public static OrderFoodAccess Access = new OrderFoodAccess();
	public static OrderFoodTimerTask TimerTask = new OrderFoodTimerTask();

	static final int LOCK_PORT = 38629;
	static ServerSocket serverSocket = null;

	public static int ofWidth;
	public static int ofHeight;
	
	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		try {
			//ofLogger.ofCheckLogger();
			serverSocket = new ServerSocket(LOCK_PORT);
			// 多重起動ではなかった
			EventQueue.invokeLater(new Runnable() {
				public void run() {
					try {
						OrderFoodVariable.InitVariable();
						//ofLogger.ofCheckLogger();
						ofGetMaxDisplay();
						ofFrame.ofLoginFrame();
					} catch (Exception e) {
						e.printStackTrace();
					}
				}
			});
		} catch (IOException e) {
			// 多重起動だった
			ofLogger.ofWriteLogger("SEVERE", "多重起動しました。");
			showDialog("多重起動");
		}
	}

	static void ofGetMaxDisplay() {
		GraphicsEnvironment env = GraphicsEnvironment
				.getLocalGraphicsEnvironment();
		ofWidth = (int) env.getMaximumWindowBounds().getWidth();
		ofHeight = (int) env.getMaximumWindowBounds().getHeight();
	}
	
	public static void showDialog(String msg){
		JOptionPane.showMessageDialog(null, msg);
	}

}