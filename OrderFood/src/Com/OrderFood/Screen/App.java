
package Com.OrderFood.Screen;

import Com.OrderFood.Data.*;
import Com.OrderFood.Log.*;
import Com.OrderFood.Timer.*;

import java.awt.EventQueue;
import java.awt.Insets;
import java.io.IOException;
import java.net.ServerSocket;

import javax.swing.JOptionPane;

public class App {
    public static Log Log = new Log ();
    public static NetworkState NetworkState = new NetworkState ();
    public static AccessTimerTask AccessTimerTask = new AccessTimerTask ();

    static final int LOCK_PORT = 38629;

    /**
     * Launch the application.
     */
    public static void main ( String[] args ) {
        try {
            new ServerSocket ( LOCK_PORT );
            // 多重起動ではなかった
            EventQueue.invokeLater ( new Runnable () {
                public void run () {
                    Variable.InitVariable ();
                    new Thread ( NetworkState ).start ();
                    Log.CreatLogger ();
                    new LoginFrame ( "ログイン" );
                }
            } );
        } catch ( IOException e ) {
            JOptionPane.showMessageDialog ( null, "多重起動" );
            // アプリ終了する
            System.exit ( 0 );
        }

    }
}
