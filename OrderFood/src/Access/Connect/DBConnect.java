package Access.Connect;

import java.io.File;
import java.sql.*;

public class DBConnect {
	Connection getConnection() {
		try {
			String url = "jdbc:ucanaccess://DB//orderfood.accdb";
			String user = "";
			String pass = "";
			return DriverManager.getConnection(url, user, pass);
		} catch (Exception e) {
			throw new IllegalArgumentException(e);
		}
	}

	void Close(Connection connection) {
		if (connection != null) {
			try {
				connection.close();
			} catch (SQLException e) {
				e.printStackTrace();
			}
		}

	}

}