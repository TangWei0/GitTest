package Com.OrderFood.Log;

import java.io.File;
import java.io.IOException;
import java.util.logging.FileHandler;
import java.util.logging.Formatter;
import java.util.logging.Handler;
import java.util.logging.Level;
import java.util.logging.Logger;
import java.util.logging.SimpleFormatter;

public class OrderFoodLogger {
	final String CURRENT_PATH = new File("").getAbsolutePath();
	// Loggerクラスのインスタンスを生成
	static Logger ofLogger = Logger.getLogger(OrderFoodLogger.class.getName());
	long date = System.currentTimeMillis();

	String logpath = CURRENT_PATH + "\\Log";
	String filename = date + ".log";

	public void ofCheckLogger() {
		// Fileクラスのオブジェクトを生成する
		File dir = new File(logpath);

		// listFilesメソッドを使用して一覧を取得する
		File[] list = dir.listFiles();

		if (list != null) {
			System.out.println(list.length);
			for (int i = 0; i < list.length; i++) {

				// ファイルの場合
				if (list[i].isFile()) {
					System.out.println("ファイルです : " + list[i].toString());
				}
				// ディレクトリの場合
				else if (list[i].isDirectory()) {
					System.out.println("ディレクトリです : " + list[i].toString());
				}
			}
		} else {
			ofCreatLogger();
		}
	}

	public void ofCreatLogger() {
		try {
			Handler handler = new FileHandler(logpath + "//" + filename);
			ofLogger.addHandler(handler);

			// フォーマッターを作成してハンドラーに登録
			Formatter formatter = new SimpleFormatter();
			handler.setFormatter(formatter);

			// ログレベルの設定
			ofLogger.setLevel(Level.ALL);

		} catch (IllegalArgumentException e) {
			ofLogger.log(Level.INFO, "例外のスローを捕捉", e);
		} catch (SecurityException e) {
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

	public void ofWriteLogger(String ofLogType, String ofLogMessage) {
		switch (ofLogType) {
		case "FINEST":
			ofLogger.finest(ofLogMessage);
			break;
		case "FINER":
			ofLogger.finer(ofLogMessage);
			break;
		case "FINE":
			ofLogger.fine(ofLogMessage);
			break;
		case "CONFIG":
			ofLogger.config(ofLogMessage);
			break;
		case "INFO":
			ofLogger.info(ofLogMessage);
			break;
		case "WARNING":
			ofLogger.warning(ofLogMessage);
			break;
		case "SEVERE":
			ofLogger.severe(ofLogMessage);
			break;
		default:
			break;
		}
	}
}