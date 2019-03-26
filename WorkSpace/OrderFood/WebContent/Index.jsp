<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>ログインフォーム</title>
<%
	String path = request.getContextPath();
%>
<link href="<%=path%>/CSS/login.css" rel="stylesheet">
</head>

<body>
	<Div class="title">
		<h1>ユーザログイン</h1>
	</Div>

	<BR>

	<form action="./LoginServlet" method="post">
		<table align="center" border="0">
			<tr>
				<td>アカウントID：</td>
				<td><input type="text" name="Account"></td>
			</tr>
			<tr>
				<td>パスワード：</td>
				<td><input type="password" name="Password"></td>
			</tr>
		</table>

		<%
			String error = (String) request.getAttribute("error");
			if (error != null) {
		%>
		<p style="text-align: center; color: red; font-size: larger;"><%=error%></p>
		<%
			} else {
		%>
		<BR>
		<%
			}
		%>

		<div class="button">
			<button class="btn" style="margin-right: 50px;">ログイン</button>
			<input type="reset" class="btn" name="リセット">
		</div>

	</form>

</body>
</html>