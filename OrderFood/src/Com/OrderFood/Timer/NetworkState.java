
package Com.OrderFood.Timer;

import java.io.IOException;
import java.net.InetAddress;
import java.net.UnknownHostException;

import javax.swing.JOptionPane;

import Com.OrderFood.Data.Enum;
import Com.OrderFood.Data.Enum.JobResult;
import Com.OrderFood.Data.Enum.ThreadResult;
import Com.OrderFood.Data.Variable;
import Com.OrderFood.Screen.App;

public class NetworkState extends Thread {
    ThreadResult ThreadResult = Enum.ThreadResult.RUNNING;
    int SleepTime = Enum.MinTime;
    int TimeCount = 0;
    int Count = 0;

    public void run () {
        JobResult JobResult = Enum.JobResult.SUCCESS;

        while ( ThreadResult.equals ( Enum.ThreadResult.RUNNING ) ) {
            TimeCount = 0;
            try {
                InetAddress inet = InetAddress.getLocalHost ();
                if ( inet.getHostAddress ().toString ().equals ( Enum.host_ip ) ) {
                    Variable.NetworkStateResult = Enum.NetworkStateResult.DISCONNECTED;
                    Variable.StatusBar.setText ( "ネットワーク未接続" );
                    Variable.StatusBarPanel.setVisible ( Enum.TRUE );
                    Count = 0;
                    setRetryTime ();
                } else {
                    inet = InetAddress.getByName ( Enum.DB_ip );
                    if ( inet.isReachable ( 1000 ) ) {
                        Variable.NetworkStateResult = Enum.NetworkStateResult.DISCOVERED;
                        Variable.StatusBar.setText ( "DB接続可能" + Count );
                        if ( Count < 5 ) {
                            Variable.StatusBarPanel.setVisible ( Enum.TRUE );
                        } else {
                            Variable.StatusBarPanel.setVisible ( Enum.FALSE );
                        }
                        Count++;
                        ResetRetryTime ();
                    } else {
                        Variable.NetworkStateResult = Enum.NetworkStateResult.UNDISCOVERED;
                        Variable.StatusBar.setText ( "DB接続不可" );
                        Variable.StatusBarPanel.setVisible ( Enum.TRUE );
                        Count = 0;
                        setRetryTime ();
                    }
                }
                App.Log.WriteLogger ( "INFO", App.Log.getFileMethod ()
                        + Variable.NetworkStateResult.name ().toString () );
                sleep ();
                System.out.println ( "Sleep終了" );
            } catch ( UnknownHostException e1 ) {
                JobResult = Enum.JobResult.ABNORMAL_UNKNOWHOST;
            } catch ( IOException e ) {
                JobResult = Enum.JobResult.ABNORMAL_IO;
            }

            if ( JobResult.equals ( Enum.JobResult.SUCCESS ) ) {
                // 何もしない
            } else {
                App.Log.WriteLogger ( "SEVERE", App.Log.getFileMethod () + JobResult.name ().toString () );
                JOptionPane.showMessageDialog ( null, "異常発生したので、アプリを終了する" );
                System.exit ( 0 );
            }
        }
    }

    private void setRetryTime () {
        SleepTime = SleepTime * 2;
        if ( SleepTime > Enum.MaxTime ) {
            SleepTime = Enum.MaxTime;
        } else {
            // 何もしない
        }
        System.out.println ( SleepTime );
    }

    private void ResetRetryTime () {
        SleepTime = Enum.MinTime;
    }

    private void sleep () {
        JobResult JobResult = Enum.JobResult.SUCCESS;

        while ( TimeCount < SleepTime ) {
            try {
                Thread.sleep ( 1000 );
                if ( Variable.NetworkStateResult.equals ( Enum.NetworkStateResult.DISCOVERED ) ) {
                    break;
                } else {
                    TimeCount++;
                    Variable.StatusBar.setText ( String.valueOf ( SleepTime - TimeCount ) + "秒後：ネットワークチェック処理リトライする" );
                }
            } catch ( InterruptedException e ) {
                JobResult = Enum.JobResult.ABNORMAL_INTERRUPTED;
            }
        }

        if ( JobResult.equals ( Enum.JobResult.SUCCESS ) ) {
            // 何もしない
        } else {

        }
    }
}
