
package Com.OrderFood.Data;

import java.util.Date;

public class OrderFoodUser {
    private String id;
    private String name;
    private int department_id;
    private Date joined;

    public void setID ( String id ) {
        this.id = id;
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
