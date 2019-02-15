
package Com.OrderFood.Access;

import Com.OrderFood.Data.OrderFoodVariable;
import Com.OrderFood.Screen.OrderFoodApp;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Date;

public class OrderFoodAccess {
    private Connection connection = null;
    private PreparedStatement statement = null;
    public ResultSet resultSet = null;

    public void getConnection () {
        // Connect接続パラメータを設定する
        String url = "jdbc:ucanaccess://DB//orderfood.accdb";
        String user = "";
        String pass = "";

        // Connectステタースをチェックする
        if ( !OrderFoodVariable.AccessConnectStatus ) { // Connect切断の場合
            // Connect接続処理を行う
            try {
                // Connect接続する
                connection = DriverManager.getConnection ( url, user, pass );
                System.out.println ( "Access接続：" + new Date () );

                // Connectステタースを「true」に設定する
                OrderFoodVariable.AccessConnectStatus = true;

                // Access接続監視タイマーをスタートする
                OrderFoodApp.TimerTask.AccessTimerStart ();
            } catch ( Exception e ) {
                // 異常情報を出力する
                System.out.println ( e.getMessage () );

                // アプリ終了する
                System.out.println ( "アプリ終了します。" );
                System.exit ( 0 );
            }
        } else { // Connect接続の場合
            // メーセッジ出力する
            System.out.println ( "Access既にアクセスしました" );
        }
    }

    /**
     * @Function : AccessConnect終了処理
     * @Description : Connect解放する
     *              Access接続監視タイマーをストップする
     *              Connectステタースを「false」に設定する
     * @Param : なし
     * @Return : なし
     * @Throws : SQLException異常情報を出力し、アプリ終了する
     */
    public void CloseAccessConnection () {
        // Connectステタースをチェックする
        if ( OrderFoodVariable.AccessConnectStatus ) { // Connect接続の場合
            // Statementステタースをチェックする
            if ( OrderFoodVariable.AccessStatementStatus ) { // Statement存在する場合
                // Statementクリアする
                ClearAccessStatement ();
            } else {// Statement存在しない場合
                // 何もしない
            }

            // Connect終了処理を行う
            try {
                // Connect解放する
                connection.close ();
                System.out.println ( "Access切断：" + new Date () );

                // Access接続監視タイマーをストップする
                OrderFoodApp.TimerTask.AccessTimerStop ();

                // Connectステタースが「false」に設定する
                OrderFoodVariable.AccessConnectStatus = false;
            } catch ( SQLException e ) {
                // 異常情報を出力する
                System.out.println ( e.getMessage () );

                // アプリ終了する
                System.out.println ( "アプリ終了します。" );
                System.exit ( 0 );
            }

        } else { // Connect切断の場合
            // 何もしない
        }
    }

    /**
     * コメント未修正
     * 
     * @Function : Access Statement 終了処理
     * @Description : Access Connect終了を行う。
     * @Param : なし
     * @Return : なし
     * @Throws : 異常情報を出力し、アプリ終了する
     */
    public void ClearAccessStatement () {
        // Connectステタースをチェックする
        if ( OrderFoodVariable.AccessConnectStatus ) { // Connect接続の場合
            // Statementステタースをチェックする
            if ( OrderFoodVariable.AccessStatementStatus ) { // Statement存在する場合
                // Statementクリアする
                try {
                    // Statement解放する
                    statement.close ();

                    // Statementステタースを「false」に設定する
                    OrderFoodVariable.AccessStatementStatus = false;
                } catch ( SQLException e ) {
                    // 異常情報を出力する
                    System.out.println ( e.getMessage () );

                    // アプリ終了する
                    System.out.println ( "アプリ終了します。" );
                    System.exit ( 0 );
                }
            } else { // Connect切断の場合
                // 何もしない
            }
        } else { // Statement存在しない場合
            // 何もしない
        }
    }

    public void RunSQLCommand ( String sSQL ) {
        // Connectステタースをチェックする
        if ( !OrderFoodVariable.AccessConnectStatus ) { // Connect切断の場合
            // Connect接続する
            getConnection ();
        } else {// Connect接続の場合
            // 何もしない
        }

        // Statementステタースをチェックする
        if ( OrderFoodVariable.AccessStatementStatus ) { // Statement存在する場合
            // Statementクリアする
            ClearAccessStatement ();
        } else {// Statement存在しない場合
            // 何もしない
        }

        // SQL命令を実行する
        try {
            // SQL命令実行する
            statement = connection.prepareStatement ( sSQL );

            // SQL命令実行の結果を変数に格納する
            resultSet = statement.executeQuery ();
        } catch ( SQLException e ) {
            // 異常情報を出力する
            System.out.println ( e.getMessage () );

            // アプリ終了する
            System.out.println ( "アプリ終了します。" );
            System.exit ( 0 );
        }

    }

}
