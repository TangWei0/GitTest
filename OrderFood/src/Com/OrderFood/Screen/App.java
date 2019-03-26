
package Com.OrderFood.Screen;

import Com.OrderFood.Data.*;
import Com.OrderFood.Data.Enum;
import Com.OrderFood.Data.Enum.JobResult;
import Com.OrderFood.Log.*;
import Com.OrderFood.Timer.*;

import java.awt.EventQueue;
import java.io.IOException;
import java.net.ServerSocket;

import javax.swing.JOptionPane;

public class App {
	public static Log Log = new Log();
	public static NetworkState NetworkState = new NetworkState();
	public static AccessTimerTask AccessTimerTask = new AccessTimerTask();

	static final int LOCK_PORT = 38629;
	static ServerSocket ServerSocket = null;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		AppStart();
	}

	public static void AppStart() {
		JobResult JobResult = Enum.JobResult.SUCCESS;
		try {
			ServerSocket = new ServerSocket(LOCK_PORT);
			// 多重起動ではなかった
			EventQueue.invokeLater(new Runnable() {
				public void run() {
					Variable.InitVariable();
					new Thread(NetworkState).start();
					Log.CreatLogger();
					new LoginFrame("ログイン");
				}
			});
		} catch (IOException e) {
			JobResult = Enum.JobResult.ABNORMAL_IO;
		}

		if (JobResult.equals(Enum.JobResult.SUCCESS)) {
			// 何もしない
		} else {
			JOptionPane.showMessageDialog(null, "多重起動");
			// アプリ終了する
			System.exit(0);
		}
	}

	public static void AppStop() {
		JobResult JobResult = Enum.JobResult.SUCCESS;
		try {
			ServerSocket.close();
		} catch (IOException e) {
			JobResult = Enum.JobResult.ABNORMAL_IO;
		}

		if (JobResult.equals(Enum.JobResult.SUCCESS)) {
			JOptionPane.showMessageDialog(null, "アプリが正常に終了します。");
		} else {
			JOptionPane.showMessageDialog(null, "アプリが異常に終了します。");
		}

		System.exit(0);
	}
}
