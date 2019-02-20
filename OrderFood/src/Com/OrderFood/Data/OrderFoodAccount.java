
package Com.OrderFood.Data;

import java.sql.SQLException;

public class OrderFoodAccount {
    String ID;
    String Password;

    static OrderFoodAccount Account = new OrderFoodAccount ();

    public static void setValue () throws SQLException {
        while ( OrderFoodVariable.resultSet.next () ) {
            Account = new OrderFoodAccount ();
            for ( int i = 0; i < OrderFoodStaticVariable.account_col.length; i++ ) {
                switch ( OrderFoodStaticVariable.account_col[i] ) {
                    case "account_id" :
                        Account.setID ( OrderFoodVariable.resultSet.getString ( OrderFoodStaticVariable.account_col[i] ) );
                        break;
                    case "account_password" :
                        Account.setPassword ( OrderFoodVariable.resultSet
                                .getString ( OrderFoodStaticVariable.account_col[i] ) );
                        break;
                    default :
                        break;
                }
            }
            OrderFoodVariable.AccountList.add ( Account );
        }

    }

    public static void Dump () {
        for ( int i = 0; i < OrderFoodVariable.AccountList.size (); i++ ) {
            System.out.println ( OrderFoodVariable.AccountList.get ( i ).ID );
            System.out.println ( OrderFoodVariable.AccountList.get ( i ).Password );

        }
    }

    public void setID ( String ID ) {
        this.ID = ID;
    }

    public void setPassword ( String Password ) {
        this.Password = Password;
    }

    public String getID () {
        return ID;
    }

    public String getPassword () {
        return Password;
    }

}
