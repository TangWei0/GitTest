package Access.Connect;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Scanner;

public class DBTest {
	static DBConnect DBConnect = new DBConnect();
	static Connection connection = null;
	static PreparedStatement statement = null;

	private static void Close(PreparedStatement statement) {
		if (statement != null) {
			try {
				statement.close();
			} catch (SQLException e) {
				e.printStackTrace();
			}
		}
	}

	private static void A() {
		String sSQL = "SELECT * FROM account";
		// String sSQL = "SELECT count(*) as Count FROM account";
		try {// 执行数据库查询，返回结果
			
			statement = connection.prepareStatement(sSQL);
			ResultSet resultSet = statement.executeQuery();

			if (!resultSet.next()) {
				System.out.println("データが存在しない");
			}
			// resultSet.absolute(0);
			// System.out.print(resultSet.getInt("Count"));
			do {
				System.out.print(resultSet.getString("account_id") + "  ");
				System.out.print(resultSet.getString("account_password"));
				System.out.println();
			} while (resultSet.next());
		} catch (SQLException e) {
			System.out.println(e.getMessage());
		} finally {
			Close(statement);
		}
	}
	private static void B() {
		String sSQL = "SELECT * FROM account";
		// String sSQL = "SELECT count(*) as Count FROM account";
		try {// 执行数据库查询，返回结果
			statement = connection.prepareStatement(sSQL);
			ResultSet resultSet = statement.executeQuery();

			if (!resultSet.next()) {
				System.out.println("データが存在しない");
			}
			// resultSet.absolute(0);
			// System.out.print(resultSet.getInt("Count"));
			do {
				System.out.print(resultSet.getString("account_id") + "  ");
				System.out.print(resultSet.getString("account_password"));
				System.out.println();
			} while (resultSet.next());
		} catch (SQLException e) {
			System.out.println(e.getMessage());
		} finally {
			Close(statement);
		}
	}
	public static void main(String args[]) {
		connection = DBConnect.getConnection();
		A();
		Scanner scanner = new Scanner(System.in);
        String input;
        System.out.println("输入一个整数a:");
        input = scanner.next();
        int a = Integer.parseInt(input);
        System.out.printf("a=%d,类型是 %s\n", a, getType(a));
        scanner.close();
		B();
		DBConnect.Close(connection);
	}

	private static Object getType(int a) {
		// TODO Auto-generated method stub
		return null;
	}
}
