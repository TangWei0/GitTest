package Servlet;

public class AccountTable {

    private String Account;
    private String Password;
    private int UserID;
       
    public String getAccount() {
        return Account;
    }
    public String getPassword() {
        return Password;
    }
    public int getUserID() {
        return UserID;
    }

    public void setAccount(String Account) {
        this.Account = Account;
    }
    public void setPassword(String Password) {
        this.Password = Password;
    }
    public void setUserID(int UserID) {
        this.UserID = UserID;
    }
}
