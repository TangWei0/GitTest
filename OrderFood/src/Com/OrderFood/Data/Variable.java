
package Com.OrderFood.Data;

import java.awt.GraphicsEnvironment;
import java.util.ArrayList;
import java.util.HashMap;

import javax.swing.JLabel;
import javax.swing.JPanel;

import Com.OrderFood.Data.Enum.AccessTimerResult;
import Com.OrderFood.Data.Enum.DBStateResult;
import Com.OrderFood.Data.Enum.JobResult;
import Com.OrderFood.Data.Enum.NetworkStateResult;
import Com.OrderFood.Data.Enum.ParameterDataType;
import Com.OrderFood.Data.Enum.SQLType;
import Com.OrderFood.Data.Enum.ThreadResult;

public class Variable {
    // Screen Class
    public static int FrameWidth;
    public static int FrameHeight;
    public static int UnitWidth;
    public static int UnitHeight;
    public static JLabel StatusBar = new JLabel ( "" );
    public static JPanel StatusBarPanel = new JPanel();

    // Access Class
    public static NetworkStateResult NetworkStateResult;
    public static DBStateResult DBStateResult;
    public static ThreadResult ThreadResult = Enum.ThreadResult.RUNNING;
    public static boolean AccessConnectStatus;
    public static boolean AccessStatementStatus;

    public static String Command;
    public static SQLType SQLType;
    public static JobResult JobResult;
    public static ArrayList< ParameterDataType > ParameterDataType;
    public static ArrayList< String > ParameterData;
    public static ArrayList< HashMap< String, String > > ResultData;

    // Timer Class
    public static int TimerOut;
    public static AccessTimerResult AccessTimerResult;
    public static long CurrentDate;
    public static long OldDate;

    // Data Class
    public static Account Account = new Account ();
    public static Department Department = new Department ();
    public static User User = new User ();
    public static Status Status = new Status ();

    public static String ID;
    public static String Password;

    // 変数初期化
    public static void InitVariable () {
        InitScreenVariable ();
        InitAccessVariable ();
        InitTimerVariable ();
    }

    // Screenパッケージ初期化
    private static void InitScreenVariable () {
        GraphicsEnvironment env = GraphicsEnvironment.getLocalGraphicsEnvironment ();
        FrameWidth = ( int ) env.getMaximumWindowBounds ().getWidth ();
        FrameHeight = ( int ) env.getMaximumWindowBounds ().getHeight ();
        UnitWidth = FrameWidth / 20;
        UnitHeight = FrameHeight / 20;
    }

    // Accessパッケージ初期化
    private static void InitAccessVariable () {
        NetworkStateResult = Enum.NetworkStateResult.DISCONNECTED;
        DBStateResult = Enum.DBStateResult.DISCONNECTED;
        AccessConnectStatus = false;
        AccessStatementStatus = false;
    }

    // Timerパッケージ初期化
    private static void InitTimerVariable () {
        AccessTimerResult = Enum.AccessTimerResult.STOPED;
        CurrentDate = System.currentTimeMillis ();
        OldDate = CurrentDate - ( 30 * 24 * 60 * 60 * 1000L );
        TimerOut = Enum.TimerOut;
    }

    public static void DataClear () {
        Command = null;
        ParameterDataType = new ArrayList< ParameterDataType > ();
        ParameterData = new ArrayList< String > ();
        ResultData = new ArrayList< HashMap< String, String > > ();
    }
}
