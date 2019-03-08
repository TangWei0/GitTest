
package Com.OrderFood.Data;

public class Status {
    private boolean LoginStatus;
    private boolean ExitStatus;

    public void setLoginStatus (boolean setValue) {
        this.LoginStatus = setValue;
    }

    public void setExitStatus (boolean setValue) {
        this.ExitStatus = setValue;
    }

    public boolean getLoginStatus () {
        return this.LoginStatus;
    }

    public boolean getExitStatus () {
        return this.ExitStatus;
    }
    
}
