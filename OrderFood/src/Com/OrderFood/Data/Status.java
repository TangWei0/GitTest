
package Com.OrderFood.Data;

import Com.OrderFood.Timer.TimeChange;

public class Status {
    private boolean LoginStatus;
    private long ConnectTime;

    public void setLoginStatus ( String setValue ) {
        this.LoginStatus = Boolean.valueOf ( setValue );
    }

    public void setConnectTime ( String setValue ) {
        this.ConnectTime = TimeChange.getToLong ( setValue );
    }

    public boolean getLoginStatus () {
        return this.LoginStatus;
    }

    public long getConnectTime () {
        return this.ConnectTime;
    }

}
