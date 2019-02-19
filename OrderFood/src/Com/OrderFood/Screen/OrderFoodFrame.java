
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

        String sSQL = "SELECT * FROM account";
        boolean Ret = OrderFoodStaticVariable.LOG_JOB_OK;
        //ArrayList< OrderFoodAccount > AccountList = new ArrayList< OrderFoodAccount >();
        //OrderFoodAccount Account = new OrderFoodAccount ();
        Ret = OrderFoodApp.Access.RunSQLCommand ( sSQL );
        if ( Ret ) {
            if ( OrderFoodVariable.resultSet != null ) {
                while ( OrderFoodVariable.resultSet.next () ) {
                    OrderFoodVariable.Account = new OrderFoodAccount ();
                    OrderFoodVariable.Account.setID ( OrderFoodVariable.resultSet.getString ( "account_id" ) );
                    OrderFoodVariable.Account.setPassword ( OrderFoodVariable.resultSet.getString ( "account_password" ) );
                    OrderFoodVariable.AccountList.add ( OrderFoodVariable.Account );
                }

                OrderFoodVariable.resultSet = null;

                Ret = OrderFoodApp.Access.ClearAccessStatement ();
                if ( Ret ) {
                    // 何もしない
                } else {
                    OrderFoodApp.Log.WriteLogger ( "WARNING", "LoginFrameにて異常発生したのでアプリが終了します。" );
                    // アプリを終了する
                    System.exit ( 0 );
                }
            } else {
                OrderFoodApp.Log.WriteLogger ( "INFO", "データが存在しない。" );
            }
        } else {
            OrderFoodApp.Log.WriteLogger ( "WARNING", "LoginFrameにて異常発生したのでアプリが終了します。" );
            // アプリを終了する
            System.exit ( 0 );
        }
        OrderFoodApp.Log.WriteLogger ( "INFO", "Size:" + OrderFoodVariable.AccountList.size () );

        OrderFoodVariable.AccountList.forEach ( item -> OrderFoodApp.Log.WriteLogger ( "INFO", item.getID () + "+"
                + item.getPassword () ) );

        OrderFoodVariable.AccountList.forEach ( item -> {
            if ( "10001".equals ( item.getID () ) ) {
                OrderFoodApp.Log.WriteLogger ( "INFO", item.getPassword () );
            }
        } );
    }
}
