
package Com.OrderFood.Data;

import java.sql.SQLException;

import Com.OrderFood.Screen.OrderFoodApp;

public class OrderFoodAccount {
    private String id;
    private String password;

    static OrderFoodAccount Account = new OrderFoodAccount ();

    public static boolean setValue ( String[] col ) {
        boolean Ret = OrderFoodStaticVariable.LOG_JOB_OK;

        if ( col.length == 2 ) {
            try {
                while ( OrderFoodVariable.resultSet.next () ) {
                    Account = new OrderFoodAccount ();
                    Account.setID ( OrderFoodVariable.resultSet.getString ( col[0] ) );
                    Account.setPassword ( OrderFoodVariable.resultSet.getString ( col[1] ) );
                    OrderFoodVariable.AccountList.add ( Account );
                }
            } catch ( SQLException e ) {
                Ret = OrderFoodStaticVariable.LOG_JOB_NG;
                OrderFoodApp.Log.WriteLogger ( "SEVERE", "SQL実行結果が異常です。" );
            }
        } else {
            Ret = OrderFoodStaticVariable.LOG_JOB_NG;
            OrderFoodApp.Log.WriteLogger ( "SEVERE", "引数のサイズが異常です。" );
        }

        return Ret;
    }

    public boolean SearchAccountIndex ( String id, String password ) {
        boolean Ret = OrderFoodStaticVariable.LOG_JOB_OK;
        int searchIndex;

        Account = new OrderFoodAccount ();
        Account.setID ( id );
        Account.setPassword ( password );

        searchIndex = OrderFoodVariable.AccountList.indexOf ( Account );
        if ( searchIndex != -1 ) {
            OrderFoodApp.Log.WriteLogger ( "INFO", "ログイン成功です。" );
            OrderFoodVariable.AccountListIndex = searchIndex;
            Ret = OrderFoodUser.SearchUserIndex ( id );
            if ( Ret ) {

            } else {
                OrderFoodApp.Log.WriteLogger ( "SERVER", "Accessデータ構造が不備です。" );
            }
        } else {
            OrderFoodApp.Log.WriteLogger ( "INFO", "ログイン失敗です。" );
            Ret = OrderFoodStaticVariable.LOG_JOB_NG;
        }

        return Ret;
    }

    public static void Dump () {
        for ( int i = 0; i < OrderFoodVariable.AccountList.size (); i++ ) {
            System.out.println ( OrderFoodVariable.AccountList.get ( i ).getID () );
            System.out.println ( OrderFoodVariable.AccountList.get ( i ).getPassword () );

        }
    }

    public void setID ( String ID ) {
        this.id = ID;
    }

    public void setPassword ( String password ) {
        this.password = password;
    }

    public String getID () {
        return id;
    }

    public String getPassword () {
        return password;
    }

}
