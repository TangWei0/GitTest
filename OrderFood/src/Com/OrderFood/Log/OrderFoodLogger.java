
package Com.OrderFood.Log;

import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.logging.FileHandler;
import java.util.logging.Formatter;
import java.util.logging.Handler;
import java.util.logging.Level;
import java.util.logging.Logger;
import java.util.logging.SimpleFormatter;

import Com.OrderFood.Data.OrderFoodVariable;

public class OrderFoodLogger {
    // Loggerクラスのインスタンスを生成
    static Logger ofLogger = Logger.getLogger ( OrderFoodLogger.class.getName () );
    Handler handler = null;
    String LogPath = new File ( "" ).getAbsolutePath () + "\\Log\\";
    String OldLogPath = LogPath + "Old\\";

    public void CheckLogger () {
        try {
            if ( !Files.isDirectory ( Paths.get ( LogPath ) ) ) {
                Files.createDirectory ( Paths.get ( LogPath ) );
            } else {
                // 何もしない
            }
            if ( !Files.isDirectory ( Paths.get ( OldLogPath ) ) ) {
                Files.createDirectory ( Paths.get ( OldLogPath ) );
            } else {
                // 何もしない
            }
        } catch ( IOException e ) {
            e.printStackTrace ();
        }
    }

    public void CreatLogger () {
        // Fileクラスのオブジェクトを生成する
        File dir = new File ( LogPath );

        // listFilesメソッドを使用して一覧を取得する
        File[] list = dir.listFiles ();
        if ( list.length != 1 ) {
            for ( int i = 0; i < list.length; i++ ) {
                // ファイルの場合
                if ( list[i].isFile () ) {
                    MoveLogFile ( list[i].toString () );
                } else {
                    // 何もしない
                }
            }
        } else {
            // 何もしない
        }
        try {
            handler = new FileHandler ( LogPath + OrderFoodVariable.CurrentLogFileName );
            handler.setEncoding ( "UTF-8" );
            ofLogger.addHandler ( handler );

            // フォーマッターを作成してハンドラーに登録
            Formatter formatter = new SimpleFormatter ();
            handler.setFormatter ( formatter );

            // ログレベルの設定
            ofLogger.setLevel ( Level.ALL );

        } catch ( IllegalArgumentException e ) {
            ofLogger.log ( Level.INFO, "例外のスローを捕捉", e );
        } catch ( SecurityException e ) {
            e.printStackTrace ();
        } catch ( IOException e ) {
            e.printStackTrace ();
        }
    }

    public void MoveLogFile ( String FileName ) {
        try {
            Files.move ( Paths.get ( FileName ),
                    Paths.get ( OldLogPath + new File ( FileName ).getName () ) );
        } catch ( IOException e ) {
            e.printStackTrace ();
        }

    }

    public void ofWriteLogger ( String ofLogType, String ofLogMessage ) {
        switch ( ofLogType ) {
            case "FINEST" :
                ofLogger.finest ( ofLogMessage );
                break;
            case "FINER" :
                ofLogger.finer ( ofLogMessage );
                break;
            case "FINE" :
                ofLogger.fine ( ofLogMessage );
                break;
            case "CONFIG" :
                ofLogger.config ( ofLogMessage );
                break;
            case "INFO" :
                ofLogger.info ( ofLogMessage );
                break;
            case "WARNING" :
                ofLogger.warning ( ofLogMessage );
                break;
            case "SEVERE" :
                ofLogger.severe ( ofLogMessage );
                break;
            default :
                break;
        }
    }
}
