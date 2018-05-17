package Process;

import java.util.Scanner;

public class tgrFirstMove {
	public void in(){
	System.out.println("文字を入力して下さい。");

    Scanner scan = new Scanner(System.in);

    String str = scan.next();
    System.out.println("最初のトークンは: "+ str);

    str = scan.next();
    System.out.println("次のトークンは  : "+ str);

	}	
}
