
package Com.OrderFood.Screen;

import Com.OrderFood.Data.*;
import Com.OrderFood.Log.*;
import Com.OrderFood.Timer.AccessTimerTask;
import Com.OrderFood.Timer.NetworkState;

import java.awt.EventQueue;
import java.io.IOException;
import java.net.ServerSocket;

import javax.swing.JOptionPane;

public class App {
    public static Log Log = new Log ();
    public static AccessTimerTask Timer = new AccessTimerTask();

    private static LoginFrame Frame = new LoginFrame ();

    static final int LOCK_PORT = 38629;
    static ServerSocket serverSocket = null;
    static NetworkState ns = new NetworkState ();
    

    /**
     * Launch the application.
     */
    public static void main ( String[] args ) {
        try {
            serverSocket = new ServerSocket ( LOCK_PORT );
            // 多重起動ではなかった
            EventQueue.invokeLater ( new Runnable () {
                public void run () {
                    boolean Ret = StaticVariable.LOG_JOB_OK;
                    Variable.InitVariable ();
                    new Thread ( ns ).start ();// 启动线程
                    Ret = Log.CreatLogger ();
                    if ( Ret ) {
                        Frame.FrameStart ();
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
