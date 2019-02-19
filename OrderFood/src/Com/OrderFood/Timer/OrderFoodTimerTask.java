
package Com.OrderFood.Timer;

import Com.OrderFood.Data.OrderFoodStaticVariable;
import Com.OrderFood.Data.OrderFoodVariable;
import Com.OrderFood.Screen.OrderFoodApp;

import java.util.Timer;
import java.util.TimerTask;

public class OrderFoodTimerTask extends TimerTask {
    private Timer Timer = null;

    @Override
    public void run () {
        boolean Ret = OrderFoodStaticVariable.LOG_JOB_OK;

        Ret = OrderFoodApp.Access.CloseAccessConnection ();
        if ( Ret ) {
            OrderFoodApp.Log.WriteLogger ( "INFO", "タイムアウト処理が成功です。" );
        } else {
            OrderFoodApp.Log.WriteLogger ( "WARNING", "タイムアウト処理にて異常発生したのでアプリが終了します。" );
            // アプリを終了する
            System.exit ( 0 );
        }
    }

    public boolean AccessTimerStart () {
        boolean Ret = OrderFoodStaticVariable.LOG_JOB_OK;

        if ( !OrderFoodVariable.TimerStatus ) {
            Timer = new Timer ();
            Timer.schedule ( new OrderFoodTimerTask (), OrderFoodStaticVariable.TimerOut );
            OrderFoodApp.Log.WriteLogger ( "INFO", "Timerがスタートしました。" );
            OrderFoodVariable.TimerStatus = true;
        } else {
            OrderFoodApp.Log.WriteLogger ( "SEVERE", "Timerスタートが失敗です。" );
            Ret = OrderFoodStaticVariable.LOG_JOB_NG;
        }

        return Ret;
    }

    public boolean AccessTimerReset () {
        boolean Ret = OrderFoodStaticVariable.LOG_JOB_OK;

        if ( OrderFoodVariable.AccessConnectStatus ) {
            Ret = AccessTimerStop ();
            if ( Ret ) {
                Ret = AccessTimerStart ();
            } else {
                // 何もしない
            }
        } else {
            OrderFoodApp.Log.WriteLogger ( "INFO", "Access未接続です" );
        }

        return Ret;
    }

    public boolean AccessTimerStop () {
        boolean Ret = OrderFoodStaticVariable.LOG_JOB_OK;

        if ( OrderFoodVariable.TimerStatus ) {
            Timer.cancel ();
            OrderFoodApp.Log.WriteLogger ( "INFO", "Timerがストップしました。" );
            OrderFoodVariable.TimerStatus = false;
        } else {
            OrderFoodApp.Log.WriteLogger ( "SEVERE", "Timerストップが失敗です。" );
            Ret = OrderFoodStaticVariable.LOG_JOB_NG;
        }

        return Ret;
    }
}
