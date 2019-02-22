
package Com.OrderFood.Screen;

import Com.OrderFood.Listener.*;
import Com.OrderFood.Data.*;

import java.sql.SQLException;

import javax.swing.JFrame;
import javax.swing.JButton;

public class OrderFoodFrame extends JFrame {
    public OrderFoodFrame () {
    }
    /**
	 * 
	 */
    private static final long serialVersionUID = 1L;

    /**
     * Create the frame.
     * 
     * @return
     * @throws SQLException
     */
    public void LoginFrame () throws SQLException {
        OrderFoodApp.Log.WriteLogger ( "CONFIG", OrderFoodVariable.FrameWidth + " " + OrderFoodVariable.FrameHeight );
        JFrame frame = new JFrame ();
        frame.getContentPane ().setLayout ( null );

        JButton button1 = new JButton ( "開始" );
        button1.setBounds ( 157, 223, 91, 21 );
        frame.getContentPane ().add ( button1 );

        JButton button2 = new JButton ( "終了" );
        button2.setBounds ( 307, 223, 91, 21 );
        frame.getContentPane ().add ( button2 );

        JButton button3 = new JButton ( "リセット" );
        button3.setBounds ( 477, 223, 91, 21 );
        frame.getContentPane ().add ( button3 );

        frame.setSize ( OrderFoodVariable.FrameWidth, OrderFoodVariable.FrameHeight );
        frame.setDefaultCloseOperation ( JFrame.EXIT_ON_CLOSE );
        frame.setVisible ( true );
        frame.setResizable ( false );
        frame.addMouseListener ( new OrderFoodMouseListener () );
        frame.addWindowListener ( new OrderFoodWindowListener () );

        // ArrayList< OrderFoodAccount > AccountList = new ArrayList<
        // OrderFoodAccount >();
        // OrderFoodAccount Account = new OrderFoodAccount ();

        // OrderFoodApp.Log.WriteLogger ( "INFO", "Size:" +
        // OrderFoodVariable.AccountList.size () );

        /*
        OrderFoodVariable.AccountList.forEach ( item -> OrderFoodApp.Log.WriteLogger ( "INFO", item.getID () + "+"
                + item.getPassword () ) );

        */
        OrderFoodVariable.AccountList.forEach ( item -> {
            if ( ( "10201".equals ( item.getID () ) ) && ( "123456".equals ( item.getPassword () ) ) ) {
                OrderFoodApp.Log.WriteLogger ( "INFO", "ログイン成功" );
                OrderFoodVariable.AccountListIndex = OrderFoodVariable.AccountList.indexOf ( item );
            } else {
                OrderFoodApp.Log.WriteLogger ( "INFO", "ログイン失敗" );
            }
        } );

        OrderFoodVariable.UserList.forEach ( item -> {
            if ( ( OrderFoodVariable.AccountList.get ( OrderFoodVariable.AccountListIndex ).getID ().equals ( item
                    .getID () ) ) ) {
                OrderFoodVariable.UserListIndex = OrderFoodVariable.UserList.indexOf ( item );
            } else {
                //
            }
        } );

        OrderFoodVariable.DepartmentList.forEach ( item -> {
            if ( ( OrderFoodVariable.UserList.get ( OrderFoodVariable.UserListIndex ).getDepartmentID () == item
                    .getID () ) ) {
                OrderFoodVariable.DepartmentListIndex = OrderFoodVariable.DepartmentList.indexOf ( item );
            } else {
                //
            }
        } );

        System.out.println ( OrderFoodVariable.AccountListIndex );
        System.out.println ( OrderFoodVariable.UserListIndex );
        System.out.println ( OrderFoodVariable.DepartmentListIndex );

    }
}
