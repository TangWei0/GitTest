
package Com.OrderFood.Data;

public class User {
    private String Names;
    private int DepartID;

    public void setNames ( String setValue ) {
        this.Names = setValue;
    }

    public void setDepartID ( int setValue ) {
        this.DepartID = setValue;
    }

    public String getNames () {
        return this.Names;
    }

    public int getDepartID () {
        return this.DepartID;
    }
}
