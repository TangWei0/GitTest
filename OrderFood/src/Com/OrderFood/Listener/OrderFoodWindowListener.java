
package Com.OrderFood.Listener;

import Com.OrderFood.Data.OrderFoodStaticVariable;
import Com.OrderFood.Data.OrderFoodStatus;
import Com.OrderFood.Screen.OrderFoodApp;

import java.awt.event.WindowEvent;
import java.awt.event.WindowListener;

public class OrderFoodWindowListener implements WindowListener {
    public void windowOpened ( WindowEvent e ) {
        /* 処理したい内容をここに記述する */
    }

    public void windowClosing ( WindowEvent e ) {
        /* 処理したい内容をここに記述する */
        boolean Ret1 = OrderFoodStaticVariable.LOG_JOB_OK;
        boolean Ret2 = OrderFoodStaticVariable.LOG_JOB_OK;

        OrderFoodStatus.SetDBLoginStatus ( false );

        Ret1 = OrderFoodApp.Access.CloseAccessConnection ();
        Ret2 = OrderFoodApp.Log.CheckLogger ( OrderFoodStaticVariable.OldLogCheck );

        if ( Ret1
                && Ret2 ) {
            OrderFoodApp.Log.WriteLogger ( "INFO", "アプリが正常終了します。" );
        } else {
            OrderFoodApp.Log.WriteLogger ( "WARNING", "アプリが異常終了します。" );
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
