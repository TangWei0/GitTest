
package Com.OrderFood.Log;

import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.Date;
import java.util.logging.FileHandler;
import java.util.logging.Formatter;
import java.util.logging.Handler;
import java.util.logging.Level;
import java.util.logging.Logger;
import java.util.logging.SimpleFormatter;

import Com.OrderFood.Data.OrderFoodVariable;
import Com.OrderFood.Data.OrderFoodStaticVariable;

public class OrderFoodLogger {
    // Loggerクラスのインスタンスを生成
    static Logger Log = Logger.getLogger ( OrderFoodLogger.class.getName () );

    public boolean CheckLoggerPath () {
        boolean Ret = OrderFoodStaticVariable.LOG_JOB_OK;
        try {
            if ( !Files.isDirectory ( Paths.get ( OrderFoodStaticVariable.LogPath ) ) ) {
                Files.createDirectory ( Paths.get ( OrderFoodStaticVariable.LogPath ) );
            } else {
                // 何もしない
            }
            if ( !Files.isDirectory ( Paths.get ( OrderFoodStaticVariable.OldLogPath ) ) ) {
                Files.createDirectory ( Paths.get ( OrderFoodStaticVariable.OldLogPath ) );
            } else {
                // 何もしない
            }
        } catch ( IOException e ) {
            Ret = OrderFoodStaticVariable.LOG_JOB_NG;
            // デバッグ用メッセージ提示する
            System.out.println ( new Date () + "CheckLoggerPath関数で異常が発生しました。" );
        }
        return Ret;
    }

    public boolean CheckLogger ( int CheckType ) {
        boolean Ret = OrderFoodStaticVariable.LOG_JOB_OK;
        String Path = null;
        File dir = null;
        File[] list = null;

        if ( CheckType == OrderFoodStaticVariable.LogCheck ) {
            Path = OrderFoodStaticVariable.LogPath;
        } else if ( CheckType == OrderFoodStaticVariable.OldLogCheck ) {
            Path = OrderFoodStaticVariable.OldLogPath;
        } else {
            Ret = OrderFoodStaticVariable.LOG_JOB_NG;
            // デバッグ用メッセージ提示する
            System.out.println ( new Date () + "パラメータ設定エラー" );
        }

        if ( Ret ) {
            // Fileクラスのオブジェクトを生成する
            dir = new File ( Path );

            // listFilesメソッドを使用して一覧を取得する
            list = dir.listFiles ();
            for ( int i = 0; i < list.length; i++ ) {
                // ファイルの場合
                if ( list[i].isFile () ) {
                    if ( CheckType == OrderFoodStaticVariable.LogCheck ) {
                        // 以前LogファイルがOldフォルダに移動処理を行う
                        Ret = MoveLogFile ( list[i].toString () );
                        if ( Ret ) {
                            // 何もしない
                        } else {
                            return Ret;
                        }
                    } else if ( CheckType == OrderFoodStaticVariable.OldLogCheck ) {
                        // 30日間以前のLogファイルを削除処理を行う
                        if ( OrderFoodVariable.DeleteLogFileStatus ) {
                            Ret = DeleteLogFile ( list[i].toString () );
                            if ( Ret ) {
                                // 何もしない
                            } else {
                                return Ret;
                            }
                        } else {
                            return Ret;
                        }
                    } else {
                        Ret = OrderFoodStaticVariable.LOG_JOB_NG;
                        // デバッグ用メッセージ提示する
                        System.out.println ( new Date () + "パラメータ設定エラー" );
                        return Ret;
                    }
                } else {
                    // 何もしない
                }
            }
        } else {
            // 何もしない
        }

        return Ret;
    }

    public boolean CreatLogger () {
        boolean Ret = OrderFoodStaticVariable.LOG_JOB_OK;

        Ret = CheckLoggerPath ();
        if ( Ret ) {
            Ret = CheckLogger ( OrderFoodStaticVariable.LogCheck );
            if ( Ret ) {
                try {
                    Handler handler = new FileHandler ( OrderFoodStaticVariable.LogPath
                            + OrderFoodVariable.CurrentLogFileName );
                    handler.setEncoding ( "UTF-8" );
                    Log.addHandler ( handler );

                    // フォーマッターを作成してハンドラーに登録
                    Formatter formatter = new SimpleFormatter ();
                    handler.setFormatter ( formatter );

                    // ログレベルの設定
                    Log.setLevel ( Level.ALL );

                } catch ( IllegalArgumentException e ) {
                    Ret = OrderFoodStaticVariable.LOG_JOB_NG;
                    // デバッグ用メッセージ提示する
                    System.out.println ( new Date () + "CreatLogger関数で例外のスローが発生しました。" );
                } catch ( SecurityException e ) {
                    Ret = OrderFoodStaticVariable.LOG_JOB_NG;
                    // デバッグ用メッセージ提示する
                    System.out.println ( new Date () + "CreatLogger関数でセキュリティ異常が発生しました。" );
                } catch ( IOException e ) {
                    Ret = OrderFoodStaticVariable.LOG_JOB_NG;
                    // デバッグ用メッセージ提示する
                    System.out.println ( new Date () + "CreatLogger関数で異常が発生しました。" );
                }
            } else {
                // 何もしない
            }
        } else {
            // 何もしない
        }

        return Ret;
    }

    private boolean MoveLogFile ( String FileName ) {
        boolean Ret = OrderFoodStaticVariable.LOG_JOB_OK;

        try {
            Files.move ( Paths.get ( FileName ),
                    Paths.get ( OrderFoodStaticVariable.OldLogPath + new File ( FileName ).getName () ) );
        } catch ( IOException e ) {
            // デバッグ用メッセージ提示する
            Ret = OrderFoodStaticVariable.LOG_JOB_NG;
            System.out.println ( new Date () + "MoveLogFile関数で異常が発生しました。" );
        }

        return Ret;
    }

    private boolean DeleteLogFile ( String FileName ) {
        boolean Ret = OrderFoodStaticVariable.LOG_JOB_OK;
        File file = null;

        String fileName = new File ( FileName ).getName ();
        if ( fileName.compareTo ( OrderFoodVariable.OldLogFileName ) < 0 ) {
            try {
                file = new File ( FileName );
                // deleteメソッドを使用してファイルを削除する
                file.delete ();
                WriteLogger ( "INFO", fileName + "削除しました。" );
            } catch ( Exception e ) {
                Ret = OrderFoodStaticVariable.LOG_JOB_NG;
                WriteLogger ( "WARNING", "DeleteLogFile関数で異常が発生しました。" );
            }
        } else {
            OrderFoodVariable.DeleteLogFileStatus = false;
        }

        return Ret;
    }

    public void WriteLogger ( String ofLogType, String ofLogMessage ) {
        switch ( ofLogType ) {
            case "FINEST" :
                Log.finest ( ofLogMessage );
                break;
            case "FINER" :
                Log.finer ( ofLogMessage );
                break;
            case "FINE" :
                Log.fine ( ofLogMessage );
                break;
            case "CONFIG" :
                Log.config ( ofLogMessage );
                break;
            case "INFO" :
                Log.info ( ofLogMessage );
                break;
            case "WARNING" :
                Log.warning ( ofLogMessage );
                break;
            case "SEVERE" :
                Log.severe ( ofLogMessage );
                break;
            default :
                break;
        }
    }
}
