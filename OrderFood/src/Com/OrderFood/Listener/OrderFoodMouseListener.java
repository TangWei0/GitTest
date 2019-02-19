
package Com.OrderFood.Listener;

import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;

import Com.OrderFood.Access.*;
import Com.OrderFood.Data.OrderFoodStaticVariable;
import Com.OrderFood.Screen.OrderFoodApp;

public class OrderFoodMouseListener implements MouseListener {

    public void mouseClicked ( MouseEvent e ) {
        // TODO Auto-generated method stub
    }

    public void mousePressed ( MouseEvent e ) {
        // TODO Auto-generated method stub
        boolean Ret = OrderFoodStaticVariable.LOG_JOB_OK;

        Ret = OrderFoodAccess.TimerTask.AccessTimerReset ();
        if ( Ret ) {
            OrderFoodApp.Log.WriteLogger ( "INFO", "Mouse押す処理が正常終了します。" );
        } else {
            OrderFoodApp.Log.WriteLogger ( "WARNING", "Mouse押す処理が異常終了します。" );
        }
    }

    public void mouseReleased ( MouseEvent e ) {
        // TODO Auto-generated method stub
    }

    public void mouseEntered ( MouseEvent e ) {
        // TODO Auto-generated method stub
    }

    public void mouseExited ( MouseEvent e ) {
        // TODO Auto-generated method stub
    }

    public void mouseDragged ( MouseEvent e ) {
        // TODO Auto-generated method stub
    }

    public void mouseMoved ( MouseEvent e ) {
        // TODO Auto-generated method stub
    }

}
