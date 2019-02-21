
package Com.OrderFood.Data;

import java.sql.SQLException;
import java.util.ArrayList;

public class OrderFoodDepartment {
    int id;
    String name;

    static OrderFoodDepartment Department = new OrderFoodDepartment ();

    public static boolean setValue ( String[] col ){
        boolean Ret = OrderFoodStaticVariable.LOG_JOB_OK;

        try {
            while ( OrderFoodVariable.resultSet.next () ) {
                Department = new OrderFoodDepartment ();
                if ( col.length == 2 ) {
                    Department.setID ( OrderFoodVariable.resultSet.getInt ( col[0] ) );
                    Department.setName ( OrderFoodVariable.resultSet.getString ( col[1] ) );
                } else {
                    OrderFoodVariable.DepartmentList = new ArrayList< OrderFoodDepartment > ();
                    Ret = OrderFoodStaticVariable.LOG_JOB_NG;
                    return Ret;
                }
                OrderFoodVariable.DepartmentList.add ( Department );
            }
        } catch ( SQLException e ) {
            Ret = OrderFoodStaticVariable.LOG_JOB_NG;
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
