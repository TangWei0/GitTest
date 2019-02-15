
package Com.OrderFood.Listener;

import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;

import Com.OrderFood.Data.OrderFoodVariable;
import Com.OrderFood.Screen.OrderFoodApp;

public class OrderFoodMouseListener implements MouseListener {

    public void mouseClicked ( MouseEvent e ) {
        // TODO Auto-generated method stub
    }

    public void mousePressed ( MouseEvent e ) {
        // TODO Auto-generated method stub
        if ( OrderFoodVariable.AccessConnectStatus ) {
            OrderFoodApp.TimerTask.AccessTimerReset ();
        } else {
            // 何もしない
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
