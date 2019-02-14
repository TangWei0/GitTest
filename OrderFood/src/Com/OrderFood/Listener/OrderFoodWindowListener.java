package Com.OrderFood.Listener;

import java.awt.event.WindowEvent;
import java.awt.event.WindowListener;

public class OrderFoodWindowListener implements WindowListener {
	public void windowOpened(WindowEvent e) {
		/* 処理したい内容をここに記述する */
	}

	public void windowClosing(WindowEvent e) {
		/* 処理したい内容をここに記述する */
		System.out.println("アプリ終了します");
	}

	public void windowClosed(WindowEvent e) {
		/* 処理したい内容をここに記述する */
	}

	public void windowIconified(WindowEvent e) {
		/* 処理したい内容をここに記述する */
	}

	public void windowDeiconified(WindowEvent e) {
		/* 処理したい内容をここに記述する */
	}

	public void windowActivated(WindowEvent e) {
		/* 処理したい内容をここに記述する */
	}

	public void windowDeactivated(WindowEvent e) {
		/* 処理したい内容をここに記述する */
	}
}