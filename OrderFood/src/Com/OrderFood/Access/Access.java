
package Com.OrderFood.Access;

import Com.OrderFood.Data.Variable;
import Com.OrderFood.Data.StaticVariable;
import Com.OrderFood.Screen.App;
import Com.OrderFood.Timer.AccessTimerTask;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.ResultSetMetaData;
import java.sql.SQLException;
import java.util.HashMap;

public class Access {
    static Connection connection;
    static PreparedStatement statement;
    static ResultSet resultSet;
    static ResultSetMetaData resultSetMetaData;
    static AccessTimerTask AccessTimerTask = new AccessTimerTask();
    
    static boolean GetConnection () {
        boolean Ret = StaticVariable.LOG_JOB_OK;

        if ( !Variable.AccessConnectStatus ) {
            App.Log.WriteLogger ( "FINER", App.Log.getFileMethod () + " Connectステタースチェック：FALSE" );

            try {
                connection = DriverManager
                        .getConnection ( StaticVariable.url, StaticVariable.user, StaticVariable.pass );
                App.Log.WriteLogger ( "FINER", App.Log.getFileMethod () + " Connect接続設定：TRUE" );

                App.Timer.AccessTimerStart ();
                Variable.AccessConnectStatus = true;
            } catch ( Exception e ) {
                App.Log.WriteLogger ( "SEVERE", App.Log.getFileMethod () + " Connect接続設定：FALSE" );

                Ret = StaticVariable.LOG_JOB_NG;
            }
        } else {
            App.Log.WriteLogger ( "FINER", App.Log.getFileMethod () + " Connectステタースチェック：TRUE" );
        }

        return Ret;
    }

    /**
     * @Function : Connect切断処理
     * @Description : Connect切断設定する
     *              : DB監視タイマーをストップする
     *              : Connectステタースを「FALSE」に設定する
     * @Param : なし
     * @Return : LOG_JOB_OK(Connect切断処理成功)
     *         : LOG_JOB_NG(Connect切断処理失敗)
     */
    public static boolean CloseAccessConnection () {
        boolean Ret = StaticVariable.LOG_JOB_OK;

        Ret = ClearAccessStatement ();
        if ( Ret ) {
            App.Log.WriteLogger ( "FINER", App.Log.getFileMethod () + " Statement終了処理：TRUE" );

            try {
                connection.close ();
                App.Log.WriteLogger ( "FINER", App.Log.getFileMethod () + " Connect切断設定：TRUE" );

                App.Timer.AccessTimerStop ();
                Variable.AccessConnectStatus = false;
            } catch ( SQLException e ) {
                App.Log.WriteLogger ( "SEVERE", App.Log.getFileMethod () + " Connect切断設定：FALSE" );

                Ret = StaticVariable.LOG_JOB_NG;
            }
        } else {
            App.Log.WriteLogger ( "SEVERE", App.Log.getFileMethod () + " Statement終了処理：FALSE" );
        }

        return Ret;
    }

    /**
     * @Function : Statement 終了処理
     * @Description : Statement 終了処理を行う。
     * @Param : なし
     * @Return : LOG_JOB_OK(Statement終了成功)
     *         : LOG_JOB_NG(Statement終了失敗)
     */
    public static boolean ClearAccessStatement () {
        boolean Ret = StaticVariable.LOG_JOB_OK;

        if ( Variable.AccessConnectStatus ) {
            App.Log.WriteLogger ( "FINER", App.Log.getFileMethod () + " Connectステタースチェック：TRUE" );

            if ( Variable.AccessStatementStatus ) {
                App.Log.WriteLogger ( "FINER", App.Log.getFileMethod () + " Statementステタースチェック：TRUE" );

                try {
                    statement.close ();
                    App.Log.WriteLogger ( "FINER", App.Log.getFileMethod () + " Statement終了処理：TRUE" );

                    Variable.AccessStatementStatus = false;
                } catch ( SQLException e ) {
                    App.Log.WriteLogger ( "SEVERE", App.Log.getFileMethod () + " Statement終了処理：FALSE" );

                    Ret = StaticVariable.LOG_JOB_NG;
                }
            } else {
                App.Log.WriteLogger ( "FINER", App.Log.getFileMethod () + " Statementステタースチェック：FALSE" );
            }
        } else {
            App.Log.WriteLogger ( "FINER", App.Log.getFileMethod () + " Connectステタースチェック：FALSE" );
        }

        return Ret;
    }

    public static boolean RunSQLCommand () {
        boolean Ret = StaticVariable.LOG_JOB_OK;
        int i;
        String[] item;

        Ret = Access.GetConnection ();
        if ( Ret ) {
            App.Log.WriteLogger ( "FINER", App.Log.getFileMethod () + " Connect接続処理：TRUE" );

            Ret = Access.ClearAccessStatement ();
            if ( Ret ) {
                App.Log.WriteLogger ( "FINER", App.Log.getFileMethod () + " Statement終了処理：TRUE" );

                try {
                    statement = connection.prepareStatement ( Variable.Command );
                    if ( Variable.ParameterData.isEmpty () ) {
                        App.Log.WriteLogger ( "FINER", App.Log.getFileMethod () + " SQL命令のパラメータ数チェック：0個" );
                    } else {
                        App.Log.WriteLogger ( "FINER", App.Log.getFileMethod () + " SQL命令のパラメータ数チェック：1個以上" );

                        for ( i = 0; i < Variable.ParameterData.size (); i++ ) {
                            item = Variable.ParameterData.get ( i );
                            if ( item[1].equals ( "string" ) ) {
                                statement.setString ( i + 1, item[0] );
                            } else if ( item[1].equals ( "int" ) ) {
                                statement.setInt ( i + 1, Integer.parseInt ( item[0] ) );
                            } else if ( item[1].equals ( "boolean" ) ) {
                                statement.setBoolean ( i + 1, Boolean.valueOf ( item[0] ) );
                            } else {
                                App.Log.WriteLogger ( "SEVERE", App.Log.getFileMethod () + " SQL命令のパラメータ設定：FALSE" );
                                Ret = StaticVariable.LOG_JOB_NG;
                                return Ret;
                            }
                        }
                        App.Log.WriteLogger ( "FINER", App.Log.getFileMethod () + " SQL命令のパラメータ設定：TRUE" );
                    }

                    if ( Variable.SQLType == StaticVariable.SQLTYPE_UPDATE ) {
                        App.Log.WriteLogger ( "FINER", App.Log.getFileMethod () + " SQL命令実行タイプチェック：更新" );

                        statement.executeUpdate ();
                    } else {
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
                            }
                        } else {
                            App.Log.WriteLogger ( "SEVERE", App.Log.getFileMethod () + " SQL検索命令実行結果チェック：なし" );

                            Ret = StaticVariable.LOG_JOB_NG;
                            return Ret;
                        }
                    }
                    App.Log.WriteLogger ( "FINER", App.Log.getFileMethod () + " SQL命令実行：TRUE" );
                } catch ( SQLException e ) {
                    App.Log.WriteLogger ( "SEVERE", App.Log.getFileMethod () + " SQL命令実行：FALSE" );

                    Ret = StaticVariable.LOG_JOB_NG;
                }
            } else {
                App.Log.WriteLogger ( "SEVERE", App.Log.getFileMethod () + " Statement終了処理：FALSE" );
            }
        } else {
            App.Log.WriteLogger ( "SEVERE", App.Log.getFileMethod () + " Connect接続処理：FALSE" );
        }

        return Ret;
    }
}
