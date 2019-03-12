package Servlet;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public class DataBaseDao {

	private static Connection getConnection() {
		try {
			Class.forName("com.mysql.jdbc.Driver");
			return DriverManager.getConnection("jdbc:mysql://localhost:3306/order_db", "root", "");
		} catch (Exception e) {
			throw new IllegalArgumentException(e);
		}
	}

	private static void allClose(PreparedStatement statement,
			Connection connection) {
		if (statement != null) {
			try {
				statement.close();
			} catch (SQLException e) {
				e.printStackTrace();
			}
		}
		if (connection != null) {
			try {
				connection.close();
			} catch (SQLException e) {
				e.printStackTrace();
			}
		}

	}

	static Connection connection = null;
	static PreparedStatement statement = null;

	public UserTable FindAccount(String account, String password) {
		String sql = "SELECT users.UserPosition, account.UserID "
				+ "FROM users NATURAL JOIN account "
				+ "WHERE account.Account=? AND account.Password=?";
		UserTable UserTable = new UserTable();

		try {
			connection = getConnection();
			statement = connection.prepareStatement(sql);
			statement.setString(1, account);
			statement.setString(2, password);
			ResultSet resultSet = statement.executeQuery();

			if (!resultSet.next()) {
				return null;
			}

			UserTable.setUserPosition(resultSet.getString("UserPosition"));
			UserTable.setUserID(resultSet.getInt("UserID"));

		} catch (SQLException e) {
			e.printStackTrace();
		} finally {
			allClose(statement, connection);
		}
		return UserTable;
	}

}
