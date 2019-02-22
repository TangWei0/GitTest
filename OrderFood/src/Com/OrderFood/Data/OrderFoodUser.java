
package Com.OrderFood.Data;

import java.sql.SQLException;
import java.util.Date;

import Com.OrderFood.Screen.OrderFoodApp;

public class OrderFoodUser {
    private String id;
    private String name;
    private int department_id;
    private Date joined;

    static OrderFoodUser User = new OrderFoodUser ();

    public static boolean setValue ( String[] col ) {
        boolean Ret = OrderFoodStaticVariable.LOG_JOB_OK;

        if ( col.length == 4 ) {
            try {
                while ( OrderFoodVariable.resultSet.next () ) {
                    User = new OrderFoodUser ();
                    User.setID ( OrderFoodVariable.resultSet.getString ( col[0] ) );
                    User.setName ( OrderFoodVariable.resultSet.getString ( col[1] ) );
                    User.setJoined ( OrderFoodVariable.resultSet.getDate ( col[2] ) );
                    User.setDepartmentID ( OrderFoodVariable.resultSet.getInt ( col[3] ) );
                    OrderFoodVariable.UserList.add ( User );
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

    public static void Dump () {
        for ( int i = 0; i < OrderFoodVariable.UserList.size (); i++ ) {
            System.out.println ( OrderFoodVariable.UserList.get ( i ).id );
            System.out.println ( OrderFoodVariable.UserList.get ( i ).name );
            System.out.println ( OrderFoodVariable.UserList.get ( i ).joined );
            System.out.println ( OrderFoodVariable.UserList.get ( i ).department_id );

        }
    }
    
    public static boolean SearchUserIndex ( String id ) {
        boolean Ret = OrderFoodStaticVariable.LOG_JOB_OK;
        int searchIndex;

        searchIndex = OrderFoodVariable.UserList.indexOf ( id );
        if ( searchIndex != -1 ) {
            OrderFoodVariable.AccountListIndex = searchIndex;
            
        } else {
            Ret = OrderFoodStaticVariable.LOG_JOB_NG;
        }

        return Ret;
    }

    public void setID ( String ID ) {
        this.id = ID;
    }

    public void setName ( String name ) {
        this.name = name;
    }

    public void setJoined ( Date joined ) {
        this.joined = joined;
    }

    public void setDepartmentID ( int department_id ) {
        this.department_id = department_id;
    }

    public String getID () {
        return id;
    }

    public String getName () {
        return name;
    }

    public Date getJoined () {
        return joined;
    }

    public int getDepartmentID () {
        return department_id;
    }
}
