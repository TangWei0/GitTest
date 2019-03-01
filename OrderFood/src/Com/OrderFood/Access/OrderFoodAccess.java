
package Com.OrderFood.Access;

import Com.OrderFood.Data.OrderFoodVariable;
import Com.OrderFood.Data.OrderFoodStaticVariable;
import Com.OrderFood.Screen.OrderFoodApp;
import Com.OrderFood.Timer.OrderFoodTimerTask;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.ResultSetMetaData;
import java.sql.SQLException;
import java.util.HashMap;

public class OrderFoodAccess {
    public static OrderFoodTimerTask TimerTask = new OrderFoodTimerTask ();

    static Connection connection;
    static PreparedStatement statement;
    static ResultSet resultSet;
    static ResultSetMetaData resultSetMetaData;
    static String command;

    private boolean GetConnection () {
        boolean Ret = OrderFoodStaticVariable.LOG_JOB_OK;

        // Connectステタースをチェックする
        if ( !OrderFoodVariable.AccessConnectStatus ) { // Connect切断の場合
            // Connect接続処理を行う
            try {
                // Connect接続する
                connection = DriverManager.getConnection ( OrderFoodStaticVariable.url, OrderFoodStaticVariable.user,
                        OrderFoodStaticVariable.pass );
                OrderFoodApp.Log.WriteLogger ( "INFO", "Connect接続処理が成功です。" );
            } catch ( Exception e ) {
                Ret = OrderFoodStaticVariable.LOG_JOB_NG;
                OrderFoodApp.Log.WriteLogger ( "SEVERE", "Connect接続処理が失敗です。" );
            } finally {
                if ( Ret ) {
                    // Connectステタースを「true」に設定する
                    OrderFoodVariable.AccessConnectStatus = true;

                    // Access接続監視タイマーをスタートする
                    TimerTask.AccessTimerStart ();
                } else {
                    // 何もしない
                }
            }
        } else { // Connect接続の場合
            OrderFoodApp.Log.WriteLogger ( "INFO", "Connect接続中です。" );
        }

        return Ret;
    }

    /**
     * @Function : AccessConnect終了処理
     * @Description : Connect解放する
     *              : Connectステタースを「false」に設定する
     *              : Access接続監視タイマーをストップする
     * @Param : なし
     * @Return : LOG_JOB_OK(Connect終了成功)
     *         : LOG_JOB_NG(Connect終了失敗)
     */
    public boolean CloseAccessConnection () {
        boolean Ret = OrderFoodStaticVariable.LOG_JOB_OK;

        // Statementクリア処理を行う
        Ret = ClearAccessStatement ();
        if ( Ret ) {// Statementクリア処理成功の場合
            // Connect終了処理を行う
            try {
                // Connect解放する
                connection.close ();
                OrderFoodApp.Log.WriteLogger ( "INFO", "Connect終了処理が成功です。" );
            } catch ( SQLException e ) {
                Ret = OrderFoodStaticVariable.LOG_JOB_NG;
                OrderFoodApp.Log.WriteLogger ( "SEVERE", "Connect終了処理が失敗です。" );
            } finally {
                if ( Ret ) {
                    // Connectステタースが「false」に設定する
                    OrderFoodVariable.AccessConnectStatus = false;

                    // Access接続監視タイマーをストップする
                    TimerTask.AccessTimerStop ();
                } else {
                    // 何もしない
                }
            }
        } else {// Statementクリア処理失敗の場合
            // 何もしない
        }

        return Ret;
    }

    /**
     * @Function : Access Statement 終了処理
     * @Description : Access Connect終了を行う。
     * @Param : なし
     * @Return : LOG_JOB_OK(Statementクリア成功)
     *         : LOG_JOB_NG(Statementクリア失敗)
     */
    public boolean ClearAccessStatement () {
        boolean Ret = OrderFoodStaticVariable.LOG_JOB_OK;

        // Connectステタースをチェックする
        if ( OrderFoodVariable.AccessConnectStatus ) { // Connect接続の場合
            // Statementステタースをチェックする
            if ( OrderFoodVariable.AccessStatementStatus ) { // Statement存在する場合
                // Statementクリアする
                try {
                    // Statement解放する
                    statement.close ();
                    OrderFoodApp.Log.WriteLogger ( "INFO", "Statementクリアしました。" );

                    // Statementステタースを「false」に設定する
                    OrderFoodVariable.AccessStatementStatus = false;
                } catch ( SQLException e ) {
                    Ret = OrderFoodStaticVariable.LOG_JOB_NG;
                    OrderFoodApp.Log.WriteLogger ( "SEVERE", "Statementクリアが失敗です。" );
                }
            } else { // Connect切断の場合
                // 何もしない
            }
        } else { // Statement存在しない場合
            // 何もしない
        }

        return Ret;
    }

    private boolean RunSQLCommand ( int SQLType ) {
        boolean Ret = OrderFoodStaticVariable.LOG_JOB_OK;
        int i;
        String[] item;

        // Connect接続処理を行う
        Ret = GetConnection ();

        if ( Ret ) {// Connect接続処理成功の場合
            // Statementクリア処理を行う
            Ret = ClearAccessStatement ();

            if ( Ret ) { // Statementクリア処理成功の場合
                // SQL命令実行処理を行う
                try {
                    // SQL命令実行する
                    statement = connection.prepareStatement ( command );
                    if ( OrderFoodVariable.ParameterData.isEmpty () ) {
                        // 何もしない
                    } else {
                        for ( i = 0; i < OrderFoodVariable.ParameterData.size (); i++ ) {
                            item = OrderFoodVariable.ParameterData.get ( i );
                            if ( item[1].equals ( "string" ) ) {
                                statement.setString ( i + 1, item[0] );
                            } else if ( item[1].equals ( "int" ) ) {
                                statement.setInt ( i + 1, Integer.parseInt ( item[0] ) );
                            } else if ( item[1].equals ( "boolean" ) ) {
                                statement.setBoolean ( i + 1, Boolean.valueOf ( item[0] ) );
                            } else {
                                OrderFoodApp.Log.WriteLogger ( "SEVERE", "SQL命令パラメータが設定異常です。" );
                                Ret = OrderFoodStaticVariable.LOG_JOB_NG;
                                return Ret;
                            }
                        }
                    }
                    if ( SQLType == OrderFoodStaticVariable.SQLTYPE_UPDATE ) {
                        // SQL更新命令実行する
                        statement.executeUpdate ();
                    } else {
                        // SQL検索命令実行の結果を変数に格納する
                        resultSet = statement.executeQuery ();
                        if ( resultSet != null ) {
                            // 何もしない
                        } else {
                            Ret = OrderFoodStaticVariable.LOG_JOB_NG;
                            OrderFoodApp.Log.WriteLogger ( "SEVERE", "SQL命令実行結果取得が失敗です。" );
                        }
                        while ( resultSet.next () ) {
                            HashMap< String, String > Map = new HashMap< String, String > ();
                            resultSetMetaData = resultSet.getMetaData ();
                            for ( i = 1; i <= resultSetMetaData.getColumnCount (); i++ ) {
                                Map.put ( resultSetMetaData.getColumnName ( i ), resultSet.getString ( i ) );
                            }
                            OrderFoodVariable.ResultData.add ( Map );
                        }
                    }
                } catch ( SQLException e ) {
                    Ret = OrderFoodStaticVariable.LOG_JOB_NG;// 異常情報を出力する
                    OrderFoodApp.Log.WriteLogger ( "SEVERE", "SQL命令実行が失敗です。" );
                }
            } else { // Statementクリア処理失敗の場合
                // 何もしない
            }
        } else {// Connect接続処理失敗の場合
            // 何もしない
        }

        return Ret;
    }

    public boolean Update () {
        boolean Ret = OrderFoodStaticVariable.LOG_JOB_OK;
        command = null;

        command = "UPDATE "
                + OrderFoodVariable.ParameterTabel
                + " SET "
                + OrderFoodVariable.ParameterSet;

        if ( OrderFoodVariable.ParameterWhere == null ) {
            // 何もしない
        } else {
            command += " WHERE "
                    + OrderFoodVariable.ParameterWhere;
        }
        
        OrderFoodApp.Log.WriteLogger ( "INFO", "SQL命令実行：開始" );
        Ret = RunSQLCommand ( OrderFoodStaticVariable.SQLTYPE_UPDATE );
        if ( Ret ) {
            OrderFoodApp.Log.WriteLogger ( "INFO", "SQL命令実行：成功" );
        } else {
            OrderFoodApp.Log.WriteLogger ( "WARNING", "SQL命令実行：失敗" );
        }
        return Ret;
    }

    public boolean Search () {
        boolean Ret = OrderFoodStaticVariable.LOG_JOB_OK;
        command = null;

        command = "SELECT "
                + OrderFoodVariable.ParameterSelect
                + " FROM "
                + OrderFoodVariable.ParameterTabel;
        if ( OrderFoodVariable.ParameterInner == null ) {
            // 何もしない
        } else {
            command += " INNER JOIN "
                    + OrderFoodVariable.ParameterInner;
        }

        if ( OrderFoodVariable.ParameterOn == null ) {
            // 何もしない
        } else {
            command += " ON "
                    + OrderFoodVariable.ParameterOn;
        }

        if ( OrderFoodVariable.ParameterWhere == null ) {
            // 何もしない
        } else {
            command += " WHERE "
                    + OrderFoodVariable.ParameterWhere;
        }
        
        OrderFoodApp.Log.WriteLogger ( "INFO", "SQL命令実行：開始" );
        Ret = RunSQLCommand ( OrderFoodStaticVariable.SQLTYPE_SEARCH );
        if ( Ret ) {
            OrderFoodApp.Log.WriteLogger ( "INFO", "SQL命令実行：成功" );
        } else {
            OrderFoodApp.Log.WriteLogger ( "WARNING", "SQL命令実行：失敗" );
        }
        return Ret;
    }
}
