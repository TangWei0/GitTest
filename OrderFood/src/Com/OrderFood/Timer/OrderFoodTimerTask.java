
package Com.OrderFood.Timer;

import Com.OrderFood.Screen.OrderFoodApp;

import java.util.Date;
import java.util.Timer;
import java.util.TimerTask;

public class OrderFoodTimerTask extends TimerTask {
	public Timer	Timer	= null;

	@Override
	public void run () {
		System.out.println ( "Access切断時間：" + new Date () );
		OrderFoodApp.Access.CloseAccessConnection ();
	}

	public void start () {
		//TimerTask TimerTask = new OrderFoodTimerTask ();
		System.out.println ( "Access接続時間：" + new Date () );
		Timer = new Timer ();
		Timer.schedule ( new OrderFoodTimerTask (), 10 * 1000 );
	}
}
