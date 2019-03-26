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
<link href="<%=path%>/CSS/main.css" rel="stylesheet">
</head>

<body>
	<%
		String UserPosition = (String) request.getAttribute("UserPosition");
			String UserID = (String) request.getAttribute("UserID");
	%>

	<form action="./Index.jsp" method="post">
		<Div class="common">
			<p>
				こんにちは、<%=UserID%>さん！
			</p>
			<button type="submit" class="LogOutbtn">ログアウト</button>
		</Div>
	</form>

	<Div class="title">
		<h1>ユーザ管理処理</h1>
	</Div>
	<Div class="process">
		<%
			if(UserPosition.equals("Administrator")){
		%>
		<button type="submit" class="btn">ユーザ一覧</button>
		<button type="submit" class="btn">ユーザ登録</button>
		<button type="submit" class="btn">ユーザ削除</button>
		<%
			}
		%>
		<button type="submit" class="btn">パスワード変更</button>
	</Div>
	<HR>
	
</body>
</html>