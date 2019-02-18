
package Com.OrderFood.Screen;

import Com.OrderFood.Access.OrderFoodAccess;
import Com.OrderFood.Timer.*;
import Com.OrderFood.Data.*;
import Com.OrderFood.Log.*;

import java.awt.EventQueue;
import java.io.IOException;
import java.net.ServerSocket;

import javax.swing.JOptionPane;

public class OrderFoodApp {
    public static OrderFoodLogger ofLogger = new OrderFoodLogger ();
    public static OrderFoodAccess Access = new OrderFoodAccess ();
    public static OrderFoodTimerTask TimerTask = new OrderFoodTimerTask ();

    private static OrderFoodFrame ofFrame = new OrderFoodFrame ();

    static final int LOCK_PORT = 38629;
    static ServerSocket serverSocket = null;

    /**
     * Launch the application.
     */
    public static void main ( String[] args ) {
        boolean Ret = OrderFoodStaticVariable.LOG_JOB_OK;

        // Logger事前チェック処理を行う
        Ret = ofLogger.CheckLoggerPath ();
        if ( Ret ) {
            try {
                serverSocket = new ServerSocket ( LOCK_PORT );
                // 多重起動ではなかった
                EventQueue.invokeLater ( new Runnable () {
                    public void run () {
                        try {
                            OrderFoodVariable.InitVariable ();
                            ofLogger.CreatLogger ();
                            ofFrame.ofLoginFrame ();
                        } catch ( Exception e ) {
                            e.printStackTrace ();
                        }
                    }
                } );
            } catch ( IOException e ) {
                // 多重起動だった
                JOptionPane.showMessageDialog ( null, "多重起動" );
            }
        } else {
            // アプリ終了する
            System.out.println ( "アプリ終了します。" );
            System.exit ( 0 );
        }
    }
}
