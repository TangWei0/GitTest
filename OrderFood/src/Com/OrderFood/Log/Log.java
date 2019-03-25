
package Com.OrderFood.Log;

import java.io.File;
import java.io.IOException;
import java.util.logging.FileHandler;
import java.util.logging.Formatter;
import java.util.logging.Handler;
import java.util.logging.Level;
import java.util.logging.Logger;
import java.util.logging.SimpleFormatter;

import javax.swing.JOptionPane;

import Com.OrderFood.Data.Variable;
import Com.OrderFood.Data.Enum;
import Com.OrderFood.Data.Enum.JobResult;
import Com.OrderFood.Screen.App;

public class Log {
    // Loggerクラスのインスタンスを生成
    static Logger Log = Logger.getLogger ( Log.class.getName () );

    static String LogPath = new File ( "" ).getAbsolutePath () + "\\Log\\";
    static String OldLogPath = LogPath + "Old\\";

    public void CreatLogger () {
        JobResult JobResult = Enum.JobResult.SUCCESS;

        File[] FileList = new File ( LogPath ).listFiles ();
        for ( int i = 0; i < FileList.length; i++ ) {
            if ( FileList[i].isFile () ) {
                File fileOut = new File ( OldLogPath + FileList[i].getName () );
                FileList[i].renameTo ( fileOut );
            }
        }

        try {
            Handler handler = new FileHandler ( LogPath + Variable.CurrentDate + ".log" );
            handler.setEncoding ( "UTF-8" );
            Log.addHandler ( handler );

            // フォーマッターを作成してハンドラーに登録
            Formatter formatter = new SimpleFormatter ();
            handler.setFormatter ( formatter );

            // ログレベルの設定
            Log.setLevel ( Level.ALL );
            JobResult = Enum.JobResult.SUCCESS;
        } catch ( IllegalArgumentException e ) {
            JobResult = Enum.JobResult.ABNORMAL_ILLEGAL_ARGUMENT;
        } catch ( SecurityException e ) {
            JobResult = Enum.JobResult.ABNORMAL_SECURITY;
        } catch ( IOException e ) {
            JobResult = Enum.JobResult.ABNORMAL_IO;
        }

        if ( JobResult.equals ( Enum.JobResult.SUCCESS ) ) {
            // 何もしない
        } else {
            App.Log.WriteLogger ( "SEVERE", App.Log.getFileMethod () + JobResult.name ().toString () );
            JOptionPane.showMessageDialog ( null, "異常発生したので、アプリを終了する" );
            System.exit ( 0 );
        }
    }

    public void DeleteLogger () {
        File[] FileList = new File ( OldLogPath ).listFiles ();
        for ( int i = 0; i < FileList.length; i++ ) {
            if ( FileList[i].isFile () ) {
                String[] fileName = FileList[i].getName ().split ( "\\." );
                long compar = Long.valueOf ( fileName[0] );
                if ( compar < Variable.OldDate ) {
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
    
    public void ErrorMessage(String Message){
        App.Log.WriteLogger ( "SEVERE", Message );
        JOptionPane.showMessageDialog ( null, "異常発生したので、アプリを終了する" );
        System.exit ( 0 );
    }
}
