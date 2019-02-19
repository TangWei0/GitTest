
package Com.OrderFood.Access;

import Com.OrderFood.Data.OrderFoodVariable;
import Com.OrderFood.Data.OrderFoodStaticVariable;
import Com.OrderFood.Screen.OrderFoodApp;
import Com.OrderFood.Timer.OrderFoodTimerTask;

import java.sql.DriverManager;
import java.sql.SQLException;

public class OrderFoodAccess {
    public static OrderFoodTimerTask TimerTask = new OrderFoodTimerTask ();

    public boolean getConnection () {
        boolean Ret = OrderFoodStaticVariable.LOG_JOB_OK;

        // Connectステタースをチェックする
        if ( !OrderFoodVariable.AccessConnectStatus ) { // Connect切断の場合
            // Connect接続処理を行う
            try {
                // Connect接続する
                OrderFoodVariable.connection = DriverManager.getConnection ( OrderFoodStaticVariable.url, OrderFoodStaticVariable.user,
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
                    Ret = TimerTask.AccessTimerStart ();
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
                OrderFoodVariable.connection.close ();
                OrderFoodApp.Log.WriteLogger ( "INFO", "Connect終了処理が成功です。" );
            } catch ( SQLException e ) {
                Ret = OrderFoodStaticVariable.LOG_JOB_NG;
                OrderFoodApp.Log.WriteLogger ( "SEVERE", "Connect終了処理が失敗です。" );
            } finally {
                if ( Ret ) {
                    // Connectステタースが「false」に設定する
                    OrderFoodVariable.AccessConnectStatus = false;

                    // Access接続監視タイマーをストップする
                    Ret = TimerTask.AccessTimerStop ();
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
                    OrderFoodVariable.statement.close ();
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

    public boolean RunSQLCommand ( String sSQL ) {
        boolean Ret = OrderFoodStaticVariable.LOG_JOB_OK;

        // Connect接続処理を行う
        Ret = getConnection ();

        if ( Ret ) {// Connect接続処理成功の場合
            // Statementクリア処理を行う
            Ret = ClearAccessStatement ();

            if ( Ret ) { // Statementクリア処理成功の場合
                // SQL命令実行処理を行う
                try {
                    // SQL命令実行する
                    OrderFoodVariable.statement = OrderFoodVariable.connection.prepareStatement ( sSQL );

                    // SQL命令実行の結果を変数に格納する
                    OrderFoodVariable.resultSet = OrderFoodVariable.statement.executeQuery ();
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

}
