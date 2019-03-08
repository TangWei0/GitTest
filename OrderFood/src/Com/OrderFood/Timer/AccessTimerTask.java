
package Com.OrderFood.Timer;

import Com.OrderFood.Access.Access;
import Com.OrderFood.Data.StaticVariable;
import Com.OrderFood.Data.Variable;
import Com.OrderFood.Screen.App;

import java.util.Timer;
import java.util.TimerTask;

public class AccessTimerTask extends TimerTask {
    private Timer Timer = null;

    @Override
    public void run () {
        boolean Ret = StaticVariable.LOG_JOB_OK;

        Ret = Access.CloseAccessConnection ();
        if ( Ret ) {
            App.Log.WriteLogger ( "INFO", "タイムアウト処理が成功です。" );
        } else {
            App.Log.WriteLogger ( "WARNING", "タイムアウト処理にて異常発生したのでアプリが終了します。" );
            // アプリを終了する
            System.exit ( 0 );
        }
    }

    public void AccessTimerStart () {
        if ( !Variable.TimerStatus ) {
            Timer = new Timer ();
            Timer.schedule ( new AccessTimerTask (), StaticVariable.TimerOut );
            App.Log.WriteLogger ( "INFO", "Timerがスタートしました。" );
            Variable.TimerStatus = true;
        } else {
            App.Log.WriteLogger ( "INFO", "Timerが既にスタートしました。" );
        }
    }

    public void AccessTimerReset () {
        if ( Variable.AccessConnectStatus ) {
            AccessTimerStop ();
            AccessTimerStart ();
        } else {
            App.Log.WriteLogger ( "INFO", "Access未接続です" );
        }
    }

    public void AccessTimerStop () {
        if ( Variable.TimerStatus ) {
            Timer.cancel ();
            App.Log.WriteLogger ( "INFO", "Timerがストップしました。" );
            Variable.TimerStatus = false;
        } else {
            App.Log.WriteLogger ( "INFO", "Timerが既にストップしました。" );
        }
    }
}
