
package Com.OrderFood.Data;

import java.sql.SQLException;
import java.util.ArrayList;

public class OrderFoodAccount {
    String id;
    String password;

    static OrderFoodAccount Account = new OrderFoodAccount ();

    public static boolean setValue ( String[] col ) {
        boolean Ret = OrderFoodStaticVariable.LOG_JOB_OK;

        try {
            while ( OrderFoodVariable.resultSet.next () ) {
                Account = new OrderFoodAccount ();
                if ( col.length == 2 ) {
                    Account.setID ( OrderFoodVariable.resultSet.getString ( col[0] ) );
                    Account.setPassword ( OrderFoodVariable.resultSet.getString ( col[1] ) );
                } else {
                    OrderFoodVariable.AccountList = new ArrayList< OrderFoodAccount > ();
                    Ret = OrderFoodStaticVariable.LOG_JOB_NG;
                    return Ret;
                }
                OrderFoodVariable.AccountList.add ( Account );
            }
        } catch ( SQLException e ) {
            Ret = OrderFoodStaticVariable.LOG_JOB_NG;
        }
        return Ret;
    }

    public static void Dump () {
        for ( int i = 0; i < OrderFoodVariable.AccountList.size (); i++ ) {
            System.out.println ( OrderFoodVariable.AccountList.get ( i ).id );
            System.out.println ( OrderFoodVariable.AccountList.get ( i ).password );

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
