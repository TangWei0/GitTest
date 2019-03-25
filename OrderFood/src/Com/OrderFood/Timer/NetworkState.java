
package Com.OrderFood.Timer;

import Com.OrderFood.Data.Enum;
import Com.OrderFood.Data.Variable;
import Com.OrderFood.Data.Enum.ThreadResult;
import Com.OrderFood.Data.Enum.JobResult;
import Com.OrderFood.Screen.App;

import java.io.IOException;
import java.net.InetAddress;
import java.net.UnknownHostException;

import javax.swing.JOptionPane;

public class NetworkState extends Thread {
	ThreadResult ThreadResult = Enum.ThreadResult.RUNNING;
	int sleepTime = Enum.MinTime;
	int count = 0;

	public void run() {
		JobResult JobResult = Enum.JobResult.SUCCESS;

		System.out.println("Run開始");

		while (ThreadResult.equals(Enum.ThreadResult.RUNNING)) {
			count = 0;
			System.out.println("テスト");
			try {
				InetAddress inet = InetAddress.getLocalHost();
				if (inet.getHostAddress().toString().equals(Enum.host_ip)) {
					Variable.NetworkStateResult = Enum.NetworkStateResult.DISCONNECTED;
					Variable.statusBar.setText("ネットワーク未接続");
					setRetryTime();
				} else {
					inet = InetAddress.getByName(Enum.DB_ip);
					if (inet.isReachable(1000)) {
						Variable.NetworkStateResult = Enum.NetworkStateResult.DISCOVERED;
						Variable.statusBar.setText("DB接続可能");
						ResetRetryTime();
					} else {
						Variable.NetworkStateResult = Enum.NetworkStateResult.UNDISCOVERED;
						Variable.statusBar.setText("DB接続不可");
						setRetryTime();
					}
				}
				App.Log.WriteLogger("INFO", App.Log.getFileMethod() + Variable.NetworkStateResult.name().toString());
				sleep();
				System.out.println("Sleep終了");
			} catch (UnknownHostException e1) {
				JobResult = Enum.JobResult.ABNORMAL_UNKNOWHOST;
			} catch (IOException e) {
				JobResult = Enum.JobResult.ABNORMAL_IO;
			}

			if (JobResult.equals(Enum.JobResult.SUCCESS)) {
				// 何もしない
			} else {
				App.Log.WriteLogger("SEVERE", App.Log.getFileMethod() + JobResult.name().toString());
				JOptionPane.showMessageDialog(null, "異常発生したので、アプリを終了する");
				System.exit(0);
			}
		}
	}

	private void setRetryTime() {
		sleepTime = sleepTime * 2;
		if (sleepTime > Enum.MaxTime) {
			sleepTime = Enum.MaxTime;
		} else {
			// 何もしない
		}
		System.out.println(sleepTime);
	}

	private void ResetRetryTime() {
		sleepTime = Enum.MinTime;
	}

	private void sleep() {
		JobResult JobResult = Enum.JobResult.SUCCESS;

		while (count < sleepTime) {
			try {
				Thread.sleep(1000);
				if (Variable.NetworkStateResult.equals(Enum.NetworkStateResult.DISCOVERED)) {
					count = 0;
				} else {
					count++;
					Variable.statusBar.setText(String.valueOf(sleepTime - count) + "秒後：ネットワークチェック処理リトライする");
				}
			} catch (InterruptedException e) {
				JobResult = Enum.JobResult.ABNORMAL_INTERRUPTED;
			}
		}

		if (JobResult.equals(Enum.JobResult.SUCCESS)) {
			// 何もしない
		} else {

		}
	}
}
