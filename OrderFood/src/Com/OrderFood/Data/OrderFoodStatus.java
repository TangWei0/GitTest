
package Com.OrderFood.Data;

import java.util.ArrayList;

import Com.OrderFood.Screen.OrderFoodApp;

public class OrderFoodStatus {
    private ArrayList< String > IDStatus = new ArrayList< String > ();
    private ArrayList< Boolean > LoginStatus = new ArrayList< Boolean > ();

    public boolean getLoginStatus ( int index ) {
        return this.LoginStatus.get ( index );
    }

    public int getLoginStatusSize () {
        return this.LoginStatus.size ();
    }

    public static boolean GetDBLoginStatus () {
        statusupdate ();
        boolean Ret = OrderFoodStaticVariable.LOG_JOB_OK;
        String[] tmp;

        OrderFoodVariable.DataClear ();
        OrderFoodVariable.ParameterTabel = "status";
        OrderFoodVariable.ParameterSelect = "status_login";
        OrderFoodVariable.ParameterWhere = "status_id = ?";

        tmp = new String[] {
                    OrderFoodVariable.ID, "string"
        };
        OrderFoodVariable.ParameterData.add ( tmp );

        OrderFoodApp.Log.WriteLogger ( "INFO", "LoginStatus取得：開始" );
        Ret = OrderFoodApp.Access.Search ();
        if ( Ret ) {
            OrderFoodApp.Log.WriteLogger ( "INFO", "LoginStatus取得：OK" );

            OrderFoodVariable.ResultData.forEach ( item -> {
                System.out.println ( item.get ( "status_login" ) );
                OrderFoodVariable.Status.LoginStatus.add ( Boolean.valueOf ( item.get ( "status_login" ) ) );
            } );
        } else {
            OrderFoodApp.Log.WriteLogger ( "SERVER", "LoginStatus取得：NG" );
        }
        return Ret;
    }

    public static boolean SetDBLoginStatus ( boolean value ) {
        boolean Ret = OrderFoodStaticVariable.LOG_JOB_OK;
        String[] tmp;

        OrderFoodVariable.DataClear ();
        OrderFoodVariable.ParameterTabel = "status";
        OrderFoodVariable.ParameterSet = "status_login = ?";
        OrderFoodVariable.ParameterWhere = "status_id = ?";

        tmp = new String[] {
                    String.valueOf ( value ), "boolean"
        };
        OrderFoodVariable.ParameterData.add ( tmp );

        tmp = new String[] {
                    OrderFoodVariable.ID, "string"
        };
        OrderFoodVariable.ParameterData.add ( tmp );

        Ret = OrderFoodApp.Access.Update ();
        if ( Ret ) {
            OrderFoodApp.Log.WriteLogger ( "INFO", "Status更新成功しました。" );
        } else {
            OrderFoodApp.Log.WriteLogger ( "WARNING", "Status更新失敗しました。" );
        }
        statusupdate ();
        return Ret;
    }

    public static boolean statusupdate () {
        boolean Ret = OrderFoodStaticVariable.LOG_JOB_OK;

        OrderFoodVariable.DataClear ();
        OrderFoodVariable.ParameterTabel = "status";
        OrderFoodVariable.ParameterSelect = "*";

        Ret = OrderFoodApp.Access.Search ();
        if ( Ret ) {
            OrderFoodApp.Log.WriteLogger ( "INFO", "Status更新成功しました。" );
        } else {
            OrderFoodApp.Log.WriteLogger ( "WARNING", "Status更新失敗しました。" );
        }

        OrderFoodVariable.ResultData.forEach ( item -> {
            System.out.println ( item.get ( "status_id" ) );
            System.out.println ( item.get ( "status_login" ) );
        } );
        return Ret;
    }
}
