
package Com.OrderFood.Access;

import Com.OrderFood.Data.OrderFoodVariable;
import Com.OrderFood.Screen.OrderFoodApp;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public class OrderFoodAccess {
	public Connection	     connection	  = null;

	public PreparedStatement	statement	= null;

	public ResultSet	     resultSet	  = null;

	// public ResultSet resultSet = null;

	public void getConnection () {
		//
		if ( !OrderFoodVariable.AccessConnectStatus ) {
			try {
				String url = "jdbc:ucanaccess://DB//orderfood.accdb";
				String user = "";
				String pass = "";
				connection = DriverManager.getConnection ( url, user, pass );
				OrderFoodVariable.AccessConnectStatus = true;
				OrderFoodApp.TimerTask.start();
				OrderFoodVariable.TimerStatus = true;
			} catch ( Exception e ) {
				throw new IllegalArgumentException ( e );
			}
		} else {
			System.out.println ( "Access既にアクセスしました" );
		}
	}

	/**
	 * @Function : Access Connect 終了処理
	 * @Description : Access Connect終了を行う。
	 * @Param : なし
	 * @Return : なし
	 * @Throws : 異常情報を出力し、アプリ終了する
	 */
	public void CloseAccessConnection () {
		// Access Connect ステタースをチェックする
		if ( OrderFoodVariable.AccessConnectStatus ) {
			// Access Statement　ステタースをチェックする
			if ( OrderFoodVariable.AccessStatementStatus ) {
				// Access Statement 終了処理
				CloseAccessStatement ();
			} else {
				// 何もしない
			}

			// connect中身をチェックする
			if ( connection != null ) {
				try {
					// connectクローズする
					connection.close ();
					
					OrderFoodApp.TimerTask.Timer.cancel ();
					// connects解放する
					// connection = null;

					// Access Connect ステタースが「false」に設定する
					OrderFoodVariable.AccessConnectStatus = false;
				} catch ( SQLException e ) {
					// 異常情報を出力する
					e.printStackTrace ();

					// アプリ終了する
					System.out.println ( "アプリ終了します。" );
					System.exit ( 0 );
				}
			} else {
				// 何もしない
			}
		} else {
			// 何もしない
		}
	}

	/**
	 * @Function : Access Statement 終了処理
	 * @Description : Access Connect終了を行う。
	 * @Param : なし
	 * @Return : なし
	 * @Throws : 異常情報を出力し、アプリ終了する
	 */
	public void CloseAccessStatement () {
		if ( statement != null ) {
			try {
				statement.close ();
			} catch ( SQLException e ) {
				e.printStackTrace ();
			}
		}
	}

	public void runSQL ( String sSQL ) {
		if ( OrderFoodVariable.AccessConnectStatus ) {
			try {// 执行数据库查询，返回结果
				statement = connection.prepareStatement ( sSQL );
				resultSet = statement.executeQuery ();
			} catch ( SQLException e ) {
				System.out.println ( e.getMessage () );
			}
		} else {
			System.out.println ( "Accessにアクセスしていない" );
		}
	}

}