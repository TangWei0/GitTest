package Servlet;

import java.io.IOException;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 * Servlet implementation class LoginServlet
 */
@WebServlet("/LoginServlet")
public class LoginServlet extends HttpServlet {
	private static final long serialVersionUID = 1L;

	/**
	 * @see HttpServlet#HttpServlet()
	 */
	public LoginServlet() {
		super();
		// TODO Auto-generated constructor stub
	}

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse
	 *      response)
	 */
	protected void doGet(HttpServletRequest request,
			HttpServletResponse response) throws ServletException, IOException {
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse
	 *      response)
	 */
	protected void doPost(HttpServletRequest request,
			HttpServletResponse response) throws ServletException, IOException {
		request.setCharacterEncoding("utf-8");

		// formから値を取得
		String Account = request.getParameter("Account");
		String Password = request.getParameter("Password");

		DataBaseDao DataBaseDao = new DataBaseDao();
		UserTable UserTable = DataBaseDao.FindAccount(Account,Password);

		boolean isLogin = (UserTable != null);
		//HttpSession session = request.getSession();
		//session.setAttribute("isLogin", isLogin);

		if (isLogin) {
			request.setAttribute("UserPosition", UserTable.getUserPosition());
			request.setAttribute("UserID", String.valueOf(UserTable.getUserID()));
			request.getRequestDispatcher("/WEB-INF/view/Main.jsp").forward(request, response);
		} else {
			request.setAttribute("error", "IDかパスワードが間違っています。\n再入力してください。");
			request.getRequestDispatcher("/Index.jsp").forward(request, response);
		}

		doGet(request, response);
	}

}
