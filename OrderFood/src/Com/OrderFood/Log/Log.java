
package Com.OrderFood.Log;

import java.io.File;
import java.io.IOException;
import java.util.Date;
import java.util.logging.FileHandler;
import java.util.logging.Formatter;
import java.util.logging.Handler;
import java.util.logging.Level;
import java.util.logging.Logger;
import java.util.logging.SimpleFormatter;

import Com.OrderFood.Data.Variable;
import Com.OrderFood.Data.StaticVariable;

public class Log {
    // Loggerクラスのインスタンスを生成
    static Logger Log = Logger.getLogger ( Log.class.getName () );

    static String LogPath = new File ( "" ).getAbsolutePath () + "\\Log\\";
    static String OldLogPath = LogPath + "Old\\";

    public boolean CreatLogger () {
        boolean Ret = StaticVariable.LOG_JOB_OK;

        File[] FileList = new File ( LogPath ).listFiles ();
        for ( int i = 0; i < FileList.length; i++ ) {
            if ( FileList[i].isFile () ) {
                File fileOut = new File ( OldLogPath + FileList[i].getName () );
                FileList[i].renameTo ( fileOut );
            }
        }

        try {
            Handler handler = new FileHandler ( LogPath + Variable.CurrentLogFileName );
            handler.setEncoding ( "UTF-8" );
            Log.addHandler ( handler );

            // フォーマッターを作成してハンドラーに登録
            Formatter formatter = new SimpleFormatter ();
            handler.setFormatter ( formatter );

            // ログレベルの設定
            Log.setLevel ( Level.ALL );

        } catch ( IllegalArgumentException e ) {
            Ret = StaticVariable.LOG_JOB_NG;
            // デバッグ用メッセージ提示する
            System.out.println ( new Date () + "CreatLogger関数で例外のスローが発生しました。" );
        } catch ( SecurityException e ) {
            Ret = StaticVariable.LOG_JOB_NG;
            // デバッグ用メッセージ提示する
            System.out.println ( new Date () + "CreatLogger関数でセキュリティ異常が発生しました。" );
        } catch ( IOException e ) {
            Ret = StaticVariable.LOG_JOB_NG;
            // デバッグ用メッセージ提示する
            System.out.println ( new Date () + "CreatLogger関数で異常が発生しました。" );
        }
        return Ret;
    }

    public void DeleteLogger () {
        File[] FileList = new File ( OldLogPath ).listFiles ();
        for ( int i = 0; i < FileList.length; i++ ) {
            if ( FileList[i].isFile () ) {
                String fileName = FileList[i].getName ();
                if ( fileName.compareTo ( Variable.OldLogFileName ) < 0 ) {
                    FileList[i].delete ();
                } else {
                    break;
                }
            }
        }
    }

    public void WriteLogger ( String logType, String logMessage ) {
        switch ( logType ) {
            case "FINEST" :
                Log.finest ( logMessage );
                break;
            case "FINER" :
                Log.finer ( logMessage );
                break;
            case "FINE" :
                Log.fine ( logMessage );
                break;
            case "CONFIG" :
                Log.config ( logMessage );
                break;
            case "INFO" :
                Log.info ( logMessage );
                break;
            case "WARNING" :
                Log.warning ( logMessage );
                break;
            case "SEVERE" :
                Log.severe ( logMessage );
                break;
            default :
                break;
        }
    }

    public String getFileMethod () {
        StackTraceElement traceElement = ( ( new Exception () ).getStackTrace () )[1];
        StringBuffer toStringBuffer = new StringBuffer ( "[" ).append ( traceElement.getFileName () ).append ( " | " )
                .append ( traceElement.getLineNumber () ).append ( " | " ).append ( traceElement.getMethodName () )
                .append ( "] " );
        return toStringBuffer.toString ();
    }
}
