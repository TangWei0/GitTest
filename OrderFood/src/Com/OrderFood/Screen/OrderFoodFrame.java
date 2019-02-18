
package Com.OrderFood.Screen;

import Com.OrderFood.Listener.*;
import Com.OrderFood.Data.*;

import java.sql.SQLException;
import java.util.ArrayList;

import javax.swing.JFrame;
import javax.swing.JButton;

public class OrderFoodFrame extends JFrame {
    public OrderFoodFrame() {
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
    public void ofLoginFrame () throws SQLException {
        OrderFoodApp.ofLogger.ofWriteLogger ( "CONFIG", OrderFoodVariable.FrameWidth + " "
                + OrderFoodVariable.FrameHeight );
        JFrame frame = new JFrame ();
        frame.getContentPane().setLayout ( null );

        JButton button1 = new JButton ( "開始" );
        button1.setBounds ( 157, 223, 91, 21 );
        frame.getContentPane().add ( button1 );

        JButton button2 = new JButton ( "終了" );
        button2.setBounds ( 307, 223, 91, 21 );
        frame.getContentPane().add ( button2 );

        JButton button3 = new JButton ( "リセット" );
        button3.setBounds ( 477, 223, 91, 21 );
        frame.getContentPane().add ( button3 );

        frame.setSize ( OrderFoodVariable.FrameWidth, OrderFoodVariable.FrameHeight );
        frame.setDefaultCloseOperation ( JFrame.EXIT_ON_CLOSE );
        frame.setVisible ( true );
        frame.setResizable ( false );
        OrderFoodVariable.TimerStatus = false;
        frame.addMouseListener ( new OrderFoodMouseListener () );
        frame.addWindowListener ( new OrderFoodWindowListener () );

        ArrayList< OrderFoodAccount > AccountList = new ArrayList< OrderFoodAccount > ();
        OrderFoodAccount Account = new OrderFoodAccount ();

        OrderFoodApp.Access.getConnection ();
        System.out.println ( OrderFoodVariable.AccessConnectStatus );
        String sSQL = "SELECT * FROM account";
        OrderFoodApp.Access.RunSQLCommand ( sSQL );
        if ( OrderFoodApp.Access.resultSet == null ) {
            System.out.println ( "データが存在しない" );
        }
        while ( OrderFoodApp.Access.resultSet.next () ) {
            Account = new OrderFoodAccount ();
            Account.setID ( OrderFoodApp.Access.resultSet.getString ( "account_id" ) );
            Account.setPassword ( OrderFoodApp.Access.resultSet.getString ( "account_password" ) );
            AccountList.add ( Account );
        }
        OrderFoodApp.Access.resultSet = null;

        OrderFoodApp.Access.ClearAccessStatement ();
        System.out.println ( OrderFoodVariable.AccessConnectStatus );

        System.out.println ( AccountList.size () );

        AccountList.forEach ( item -> System.out.println ( item.getID () + "+"
                + item.getPassword () ) );

        AccountList.forEach ( item -> {
            if ( "10001".equals ( item.getID () ) ) {
                System.out.println ( item.getPassword () );
            }
        } );
    }

}
