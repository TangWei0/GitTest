package Test;

import java.io.File;
import java.io.IOException;
import java.util.logging.FileHandler;
import java.util.logging.Formatter;
import java.util.logging.Handler;
import java.util.logging.Level;
import java.util.logging.Logger;
import java.util.logging.SimpleFormatter;
 
public class LoggerSample {
    public static void main(String[] args) {
    	final String CURRENT_PATH = new File("").getAbsolutePath();    	
        // Loggerクラスのインスタンスを生成
        Logger logger = Logger.getLogger(LoggerSample.class.getName());
        long date = System.currentTimeMillis();
        System.out.println(CURRENT_PATH);
        try {
            Handler handler = new FileHandler(CURRENT_PATH +"\\Log\\" + date +".log");
            logger.addHandler(handler);

            // フォーマッターを作成してハンドラーに登録
            Formatter formatter =  new SimpleFormatter();
            handler.setFormatter(formatter);
            
            // ログレベルの設定
            logger.setLevel(Level.INFO);
 
            // Loggerクラスのメソッドを使ってメッセージを出力
            logger.finest("FINEST");
            logger.finer("FINER");
            logger.fine("FINE");
            logger.config("CONFIG");
            logger.info("INFO");
            logger.warning("WARNING");
            logger.severe("SEVERE");
 
            // 例外をスロー
            throw new IllegalArgumentException();
        } catch (IllegalArgumentException e) {
            logger.log(Level.INFO, "例外のスローを捕捉", e);
        } catch (SecurityException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}