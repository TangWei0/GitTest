package controller;

import java.io.IOException;
import java.io.PrintWriter;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 * Servlet implementation class HelloServlet
 */
@WebServlet("/HelloServlet")
public class HelloServlet extends HttpServlet {
	private static final long serialVersionUID = 1L;

	/**
	 * @see HttpServlet#HttpServlet()
	 */
	private String message;

	public void init() throws ServletException {
		// 执行必需的初始化
		message = "Hello World";
	}

	public void doGet(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		String name = (String) request.getAttribute("userName");

		if (name == null || "".equals(name)) {
			request.setAttribute("userName", "Guest");
		}

		String view = "/WEB-INF/view/index.jsp";
		RequestDispatcher dispatcher = request.getRequestDispatcher(view);

		dispatcher.forward(request, response);
	}

	protected void doPost(HttpServletRequest request,
			HttpServletResponse response) throws ServletException, IOException {
		request.setCharacterEncoding("utf-8");

		// formから値を取得
		String name = request.getParameter("name");
		request.setAttribute("userName", name);

		doGet(request, response);
	}

	public void destroy() {
		// 什么也不做
	}

}
