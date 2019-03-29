
package Com.OrderFood.Access;

import Com.OrderFood.Data.Variable;
import Com.OrderFood.Data.Enum;
import Com.OrderFood.Data.Enum.JobResult;
import Com.OrderFood.Screen.App;
import Com.OrderFood.Timer.AccessTimerTask;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.ResultSetMetaData;
import java.sql.SQLException;
import java.util.HashMap;

import javax.swing.JOptionPane;

public class Access {
    static Connection connection;

    public static void GetConnection () {
        JobResult JobResult = Enum.JobResult.SUCCESS;

        if ( Variable.NetworkStateResult.equals ( Enum.NetworkStateResult.DISCOVERED ) ) {
            try {
                connection = DriverManager.getConnection ( Enum.url, Enum.user, Enum.pass );
                connection.setAutoCommit ( false );
                Variable.DBStateResult = Enum.DBStateResult.CONNECTING;

                // DB操作時間の監視Thread起動する
                App.AccessTimerTask = new AccessTimerTask ();
                new Thread ( App.AccessTimerTask ).start ();
            } catch ( SQLException e ) {
                JobResult = Enum.JobResult.ABNORMAL_SQL;
            }
        } else {

        }

        if ( JobResult.equals ( Enum.JobResult.SUCCESS ) ) {
            // 何もしない
        } else {
            // 異常処理を行う
            App.Log.ErrorMessage ( App.Log.getFileMethod () + JobResult.name ().toString () );
        }
    }

    /**
     * @Function : Connect切断処理
     * @Description : Connect切断設定する
     *              : DB監視タイマーをストップする
     *              : Connectステタースを「FALSE」に設定する
     * @Param : なし
     * @Return : OK(Connect切断処理成功)
     *         : NG(Connect切断処理失敗)
     */
    public static void CloseAccessConnection () {
        JobResult JobResult = Enum.JobResult.SUCCESS;

        try {
            connection.close ();
            Variable.DBStateResult = Enum.DBStateResult.DISCONNECTED;
            App.AccessTimerTask.myStop ();
        } catch ( SQLException e ) {
            JobResult = Enum.JobResult.ABNORMAL_SQL;
        }

        if ( JobResult.equals ( Enum.JobResult.SUCCESS ) ) {
            // 何もしない
        } else {
            App.Log.WriteLogger ( "SEVERE", App.Log.getFileMethod () + JobResult.name ().toString () );
            JOptionPane.showMessageDialog ( null, "異常発生したので、アプリを終了する" );
            System.exit ( 0 );
        }
    }

    public static boolean RunSQLCommand () {
        boolean Ret = true;
        PreparedStatement statement = null;
        ResultSet resultSet = null;
        ResultSetMetaData resultSetMetaData = null;
        int i;

        if ( Variable.DBStateResult.equals ( Enum.DBStateResult.DISCONNECTED ) ) {
            // DB接続処理を行う
            GetConnection ();
        } else {
            // 何もしない
        }

        if ( Ret ) {
            App.Log.WriteLogger ( "FINER", App.Log.getFileMethod () + " Connect接続処理：TRUE" );

            App.Log.WriteLogger ( "FINER", App.Log.getFileMethod () + " Statement終了処理：TRUE" );

            try {
                statement = connection.prepareStatement ( Variable.Command );
                if ( Variable.ParameterData.isEmpty () ) {
                    App.Log.WriteLogger ( "FINER", App.Log.getFileMethod () + " SQL命令のパラメータ数チェック：0個" );
                } else {
                    App.Log.WriteLogger ( "FINER", App.Log.getFileMethod () + " SQL命令のパラメータ数チェック：1個以上" );

                    for ( i = 0; i < Variable.ParameterData.size (); i++ ) {
                        switch ( Variable.ParameterDataType.get ( i ) ) {
                            case STRING :
                                statement.setString ( i + 1, Variable.ParameterData.get ( i ) );
                                break;
                            case INT :
                                statement.setInt ( i + 1, Integer.parseInt ( Variable.ParameterData.get ( i ) ) );
                                break;
                            case BOOLEAN :
                                statement.setBoolean ( i + 1, Boolean.valueOf ( Variable.ParameterData.get ( i ) ) );
                                break;
                            default :
                                break;
                        }
                    }
                    App.Log.WriteLogger ( "FINER", App.Log.getFileMethod () + " SQL命令のパラメータ設定：TRUE" );
                }

                switch ( Variable.SQLType ) {
                    case UPDATE :
                        App.Log.WriteLogger ( "FINER", App.Log.getFileMethod () + " SQL命令実行タイプチェック：更新" );

                        statement.executeUpdate ();
                        break;
                    case SEARCH :
                        App.Log.WriteLogger ( "FINER", App.Log.getFileMethod () + " SQL命令実行タイプチェック：検索" );

                        resultSet = statement.executeQuery ();
                        if ( resultSet != null ) {
                            App.Log.WriteLogger ( "FINER", App.Log.getFileMethod () + " SQL検索命令実行結果チェック：あり" );

                            while ( resultSet.next () ) {
                                HashMap< String, String > Map = new HashMap< String, String > ();
                                resultSetMetaData = resultSet.getMetaData ();
                                for ( i = 1; i <= resultSetMetaData.getColumnCount (); i++ ) {
                                    Map.put ( resultSetMetaData.getColumnName ( i ), resultSet.getString ( i ) );
                                }
                                Variable.ResultData.add ( Map );
                                System.out.println ( Variable.ResultData );
                            }
                        } else {
                            App.Log.WriteLogger ( "SEVERE", App.Log.getFileMethod () + " SQL検索命令実行結果チェック：なし" );

                            Ret = false;
                            return Ret;
                        }
                        break;
                    default :
                        break;
                }
                App.Log.WriteLogger ( "FINER", App.Log.getFileMethod () + " SQL命令実行：TRUE" );
            } catch ( SQLException e ) {
                App.Log.WriteLogger ( "SEVERE", App.Log.getFileMethod () + " SQL命令実行：FALSE" );

                Ret = false;
                
                try {
                    connection.rollback ();
                } catch ( SQLException e1 ) {
                    // TODO Auto-generated catch block
                    e1.printStackTrace();
                }
            } finally {
                try {
                    if ( resultSet != null ) {
                        resultSet.close ();
                    }

                    if ( statement != null ) {
                        statement.close ();
                    }
                } catch ( SQLException e ) {
                    // TODO Auto-generated catch block
                    e.printStackTrace ();
                }
            }
        } else {
            App.Log.WriteLogger ( "SEVERE", App.Log.getFileMethod () + " Connect接続処理：FALSE" );
        }

        return Ret;
    }
}
