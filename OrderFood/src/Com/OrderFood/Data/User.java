
package Com.OrderFood.Data;

public class User {
    private String Names;
    private byte DepartID;

    public void setNames ( String setValue ) {
        this.Names = setValue;
    }

    public void setDepartID ( String setValue ) {
        this.DepartID = Byte.valueOf ( setValue );
    }

    public String getNames () {
        return this.Names;
    }

    public byte getDepartID () {
        return this.DepartID;
    }
}
