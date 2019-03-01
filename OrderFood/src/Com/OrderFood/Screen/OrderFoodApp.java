
package Com.OrderFood.Screen;

import Com.OrderFood.Access.OrderFoodAccess;
import Com.OrderFood.Data.*;
import Com.OrderFood.Log.*;

import java.awt.EventQueue;
import java.io.IOException;
import java.net.ServerSocket;

import javax.swing.JOptionPane;

public class OrderFoodApp {
    public static OrderFoodLogger Log = new OrderFoodLogger ();
    public static OrderFoodAccess Access = new OrderFoodAccess ();

    private static OrderFoodFrame Frame = new OrderFoodFrame ();

    static final int LOCK_PORT = 38629;
    static ServerSocket serverSocket = null;

    /**
     * Launch the application.
     */
    public static void main ( String[] args ) {
        try {
            serverSocket = new ServerSocket ( LOCK_PORT );
            // 多重起動ではなかった
            EventQueue.invokeLater ( new Runnable () {
                public void run () {
                    boolean Ret = OrderFoodStaticVariable.LOG_JOB_OK;
                    OrderFoodVariable.InitVariable ();
                    Ret = Log.CreatLogger ();
                    if ( Ret ) {
                        if ( Ret ) {
                            Frame.LoginFrame ();
                        } else {
                            Log.WriteLogger ( "SEVERE", "異常が発生しましたので、アプリを終了します。" );
                            System.exit ( 0 );
                        }
                    } else {
                        JOptionPane.showMessageDialog ( null, "Logger作成処理にて異常発生したので、アプリが終了します。" );
                        // アプリ終了する
                        System.exit ( 0 );
                    }
                }
            } );
        } catch ( IOException e ) {
            JOptionPane.showMessageDialog ( null, "多重起動" );
            // アプリ終了する
            System.exit ( 0 );
        }

    }
}
