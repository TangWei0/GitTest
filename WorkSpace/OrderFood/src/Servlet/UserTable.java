package Servlet;

public class UserTable {
	private String UserPosition;
	private String UserName;
	private int UserID;

	public String getUserPosition() {
		return UserPosition;
	}

	public String getUserName() {
		return UserName;
	}

	public int getUserID() {
		return UserID;
	}

	public void setUserPosition(String UserPosition) {
		this.UserPosition = UserPosition;
	}

	public void setUserName(String UserName) {
		this.UserName = UserName;
	}

	public void setUserID(int UserID) {
		this.UserID = UserID;
	}
}
