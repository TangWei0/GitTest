
package Com.OrderFood.Listener;

import Com.OrderFood.Data.OrderFoodStaticVariable;
import Com.OrderFood.Data.OrderFoodVariable;
import Com.OrderFood.Screen.OrderFoodApp;

import java.awt.event.WindowEvent;
import java.awt.event.WindowListener;

public class OrderFoodWindowListener implements WindowListener {
    public void windowOpened ( WindowEvent e ) {
        /* 処理したい内容をここに記述する */
    }

    public void windowClosing ( WindowEvent e ) {
        /* 処理したい内容をここに記述する */
        boolean Ret;
        if ( OrderFoodVariable.AccessConnectStatus ) {
            OrderFoodApp.Access.CloseAccessConnection ();
        }
        Ret = OrderFoodApp.ofLogger.CheckLogger ( OrderFoodStaticVariable.OldLogCheck );
        if ( Ret ) {
            OrderFoodApp.ofLogger.ofWriteLogger ( "INFO", "アプリが終了します。" );
        } else {
            OrderFoodApp.ofLogger.ofWriteLogger ( "WARNING", "アプリが終了します。" );
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
