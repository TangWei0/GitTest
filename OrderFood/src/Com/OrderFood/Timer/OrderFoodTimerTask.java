
package Com.OrderFood.Timer;

import Com.OrderFood.Data.OrderFoodVariable;
import Com.OrderFood.Screen.OrderFoodApp;

import java.util.Date;
import java.util.Timer;
import java.util.TimerTask;

public class OrderFoodTimerTask extends TimerTask {
    private Timer Timer = null;

    @Override
    public void run () {
        OrderFoodApp.Access.CloseAccessConnection ();
        AccessTimerStop();
    }

    public void AccessTimerStart () {
        if ( !OrderFoodVariable.TimerStatus ) {
            System.out.println ( "タイマースタート：" + new Date () );
            Timer = new Timer ();
            Timer.schedule ( new OrderFoodTimerTask (), OrderFoodVariable.TimerOut * 1000 );
            OrderFoodVariable.TimerStatus = true;
        } else {
            // 何もしない
        }
    }

    public void AccessTimerReset () {
        AccessTimerStop ();
        AccessTimerStart ();
    }

    public void AccessTimerStop () {
        if ( OrderFoodVariable.TimerStatus ) {
            Timer.cancel ();
            System.out.println ( "タイマーストップ：" + new Date () );
            OrderFoodVariable.TimerStatus = false;
        } else {
            // 何もしない
        }
    }
}
