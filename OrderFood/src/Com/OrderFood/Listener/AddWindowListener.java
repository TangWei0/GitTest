
package Com.OrderFood.Listener;

import Com.OrderFood.Data.StaticVariable;
import Com.OrderFood.Data.Status;
import Com.OrderFood.Screen.App;

import java.awt.event.WindowEvent;
import java.awt.event.WindowListener;

import javax.swing.JOptionPane;

public class AddWindowListener implements WindowListener {
    public void windowOpened ( WindowEvent e ) {
        /* 処理したい内容をここに記述する */
    }

    public void windowClosing ( WindowEvent e ) {
        /* 処理したい内容をここに記述する */
        boolean Ret = StaticVariable.LOG_JOB_OK;

        //Ret = Status.setDBLoginStatus ( false );
        if ( Ret ) {
            App.Log.WriteLogger ( "FINER", App.Log.getFileMethod () + " DBのLoginStatus設定処理結果チェック：TRUE" );

            App.Log.DeleteLogger ();

            JOptionPane.showMessageDialog ( null, "アプリが正常終了します。" );
            System.exit ( 0 );
        } else {
            App.Log.WriteLogger ( "SERVER", App.Log.getFileMethod () + " DBのLoginStatus設定処理結果チェック：FALSE" );

            JOptionPane.showMessageDialog ( null, "アプリが異常終了します。" );
            System.exit ( 0 );
        }
    }

    public void windowClosed ( WindowEvent e ) {
        /* 処理したい内容をここに記述する */
    }

    public void windowIconified ( WindowEvent e ) {
        /* 処理したい内容をここに記述する */
    }

    public void windowDeiconified ( WindowEvent e ) {
        /* 処理したい内容をここに記述する */
    }

    public void windowActivated ( WindowEvent e ) {
        /* 処理したい内容をここに記述する */
    }

    public void windowDeactivated ( WindowEvent e ) {
        /* 処理したい内容をここに記述する */
    }
}
