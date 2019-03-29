
package Com.OrderFood.Timer;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
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
    boolean RetrySwitch = Enum.FALSE;
    int SleepTime = Enum.MinTime;
    int TimeCount = 0;
    int Count = 0;

    public void run () {
        JobResult JobResult = Enum.JobResult.SUCCESS;

        while ( ThreadResult.equals ( Enum.ThreadResult.RUNNING ) ) {
            TimeCount = 0;
            RetrySwitch = Enum.FALSE;
            try {
                InetAddress inet = InetAddress.getLocalHost ();
                if ( inet.getHostAddress ().toString ().equals ( Enum.host_ip ) ) {
                    Variable.NetworkStateResult = Enum.NetworkStateResult.DISCONNECTED;
                    setStatusBar ();
                } else {
                    inet = InetAddress.getByName ( Enum.DB_ip );
                    if ( inet.isReachable ( 1000 ) ) {
                        Variable.NetworkStateResult = Enum.NetworkStateResult.DISCOVERED;
                        if ( Count < 5 ) {
                            setStatusBar ();
                        } else {
                            // 何もしない
                        }
                    } else {
                        Variable.NetworkStateResult = Enum.NetworkStateResult.UNDISCOVERED;
                        setStatusBar ();
                    }
                }
            } catch ( UnknownHostException e1 ) {
                JobResult = Enum.JobResult.ABNORMAL_UNKNOWHOST;
            } catch ( IOException e ) {
                JobResult = Enum.JobResult.ABNORMAL_IO;
            }

            if ( JobResult.equals ( Enum.JobResult.SUCCESS ) ) {
                App.Log.WriteLogger ( "INFO", App.Log.getFileMethod ()
                        + Variable.NetworkStateResult.name ().toString () );
                sleep ();
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

    private void sleep () {
        JobResult JobResult = Enum.JobResult.SUCCESS;

        while ( TimeCount < SleepTime ) {
            try {
                Thread.sleep ( 1000 );
                if ( Variable.NetworkStateResult.equals ( Enum.NetworkStateResult.DISCOVERED ) | RetrySwitch ) {
                    break;
                } else {
                    TimeCount++;
                    Variable.StatusBarLabel.setText ( String.valueOf ( SleepTime - TimeCount )
                            + "秒後：ネットワークチェック処理リトライする" );
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

    private void setStatusBar () {
        Variable.StatusBarPanel.setVisible ( Enum.TRUE );
        if ( Variable.NetworkStateResult.equals ( Enum.NetworkStateResult.DISCOVERED ) ) {
            if ( Count == 0 ) {
                Variable.StatusBarLabel.setText ( "DB接続可能" );
                Variable.StatusBarButton.setVisible ( Enum.FALSE );
                SleepTime = Enum.MinTime;
            } else {
                // 何もしない
            }
            Count++;

            if ( Count < 5 ) {
                // 何もしない
            } else {
                Variable.StatusBarPanel.setVisible ( Enum.FALSE );
            }
        } else {
            Count = 0;
            setRetryTime ();
            Variable.StatusBarButton.setText ( "リトライ" );
            Variable.StatusBarButton.setVisible ( Enum.TRUE );
            Variable.StatusBarButton.addActionListener ( new ActionListener () {
                public void actionPerformed ( ActionEvent e ) {
                    RetrySwitch = Enum.TRUE;
                }
            } );
            if ( Variable.NetworkStateResult.equals ( Enum.NetworkStateResult.DISCONNECTED ) ) {
                Variable.StatusBarLabel.setText ( "ネットワーク未接続" );
            } else {
                Variable.StatusBarLabel.setText ( "DB接続不可" );
            }
        }
    }
}
