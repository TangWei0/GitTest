
package Com.OrderFood.Data;

import java.util.ArrayList;

import Com.OrderFood.Screen.OrderFoodApp;

public class OrderFoodAccount {
    private ArrayList<String> Password = new ArrayList<String>();

    public String getPassword ( int index ) {
        return this.Password.get(index);
    }

    public int getPasswordSize () {
        return this.Password.size();
    }

    public static boolean GetPassword ( ) {
        boolean Ret = OrderFoodStaticVariable.LOG_JOB_OK;
        String[] tmp;

        OrderFoodVariable.DataClear ();
        OrderFoodVariable.ParameterSelect = "account_password";
        OrderFoodVariable.ParameterTabel = "account";
        OrderFoodVariable.ParameterWhere = "account_id = ?";

        tmp = new String[] {
                    OrderFoodVariable.ID, "string"
        };
        OrderFoodVariable.ParameterData.add ( tmp );

        OrderFoodApp.Log.WriteLogger ( "INFO", "SQL Search関数：開始" );
        Ret = OrderFoodApp.Access.Search ();
        if ( Ret ) {
            OrderFoodApp.Log.WriteLogger ( "INFO", "SQL Search関数実行：OK" );

            OrderFoodVariable.ResultData.forEach ( item -> {
                OrderFoodVariable.Account.Password.add (item.get ( "account_password" ) );
            } );
        } else {
            OrderFoodApp.Log.WriteLogger ( "SERVER", "SQL Search関数実行：NG" );
        }

        return Ret;
    }

}
