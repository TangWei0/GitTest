
package Com.OrderFood.Data;

import java.sql.SQLException;

import Com.OrderFood.Screen.OrderFoodApp;

public class OrderFoodDepartment {
    int id;
    String name;

    static OrderFoodDepartment Department = new OrderFoodDepartment ();

    public static boolean setValue ( String[] col ) {
        boolean Ret = OrderFoodStaticVariable.LOG_JOB_OK;

        if ( col.length == 2 ) {
            try {
                while ( OrderFoodVariable.resultSet.next () ) {
                    Department = new OrderFoodDepartment ();
                    Department.setID ( OrderFoodVariable.resultSet.getInt ( col[0] ) );
                    Department.setName ( OrderFoodVariable.resultSet.getString ( col[1] ) );
                    OrderFoodVariable.DepartmentList.add ( Department );
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
        for ( int i = 0; i < OrderFoodVariable.DepartmentList.size (); i++ ) {
            System.out.println ( OrderFoodVariable.DepartmentList.get ( i ).id );
            System.out.println ( OrderFoodVariable.DepartmentList.get ( i ).name );

        }
    }

    public void setID ( int id ) {
        this.id = id;
    }

    public void setName ( String name ) {
        this.name = name;
    }

    public int getID () {
        return id;
    }

    public String getName () {
        return name;
    }

}
