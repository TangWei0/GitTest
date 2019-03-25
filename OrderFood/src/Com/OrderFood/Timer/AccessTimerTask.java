
package Com.OrderFood.Timer;

import Com.OrderFood.Access.Access;
import Com.OrderFood.Data.Enum;
import Com.OrderFood.Data.Variable;
import Com.OrderFood.Data.Enum.JobResult;

import java.util.Date;

public class AccessTimerTask extends Thread {
    // public static ThreadResult ThreadResult = Enum.ThreadResult.RUNNING;
    int count = 0;

    public void run () {
        JobResult JobResult = Enum.JobResult.SUCCESS;
        while ( !Variable.ThreadResult.equals ( Enum.ThreadResult.STOP ) ) {
            if ( Variable.DBStateResult.equals ( Enum.DBStateResult.CONNECTING ) ) {
                if ( Variable.ThreadResult.equals ( Enum.ThreadResult.SUSPEND ) ) {
                    System.out.println ( "一旦停止" );
                } else {
                    if ( count < Enum.TimerOut ) {
                        try {
                            Thread.sleep ( 1000 );
                        } catch ( InterruptedException e ) {
                            JobResult = Enum.JobResult.ABNORMAL_INTERRUPTED;
                        }
                        count++;
                        System.out.println ( count + "秒" + " " + new Date () );
                        if ( count == Enum.TimerOut ) {
                            Access.CloseAccessConnection ();
                        }
                    }
                }

                if ( JobResult.equals ( Enum.JobResult.SUCCESS ) ) {
                    // 何もしない
                } else {

                }
                System.out.println ( "over" );
            } else {
                if ( count == 0 ) {
                    // 何もしない
                } else {
                    mySuspend ();
                }
            }
        }
    }

    public synchronized void myResume () {
        Variable.ThreadResult = Enum.ThreadResult.RUNNING;
        notifyAll ();
    }

    public void mySuspend () {
        Variable.ThreadResult = Enum.ThreadResult.SUSPEND;
        count = 0;
    }

    public void myStop () {
        Variable.ThreadResult = Enum.ThreadResult.STOP;
    }
}
