
package Com.OrderFood.Data;

import java.awt.GraphicsEnvironment;
import java.util.ArrayList;
import java.util.HashMap;

public class Variable {
    // Screen Class
    public static int FrameWidth;
    public static int FrameHeight;
    public static int UnitWidth;
    public static int UnitHeight;

    // Access Class
    public static boolean AccessConnectStatus;
    public static boolean AccessStatementStatus;

    public static String Command;
    public static int SQLType;
    public static ArrayList< String[] > ParameterData;
    public static ArrayList< HashMap< String, String > > ResultData;

    // Timer Class
    public static int TimerOut;
    public static boolean TimerStatus;
    public static long CurrentDate;
    public static long OldDate;

    // Log Class
    public static String CurrentLogFileName;
    public static String OldLogFileName;

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
        InitLogVariable ();
        InitDataVariable ();
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
        AccessConnectStatus = false;
        AccessStatementStatus = false;
    }

    // Timerパッケージ初期化
    private static void InitTimerVariable () {
        TimerStatus = false;
        CurrentDate = System.currentTimeMillis () / 1000;
        OldDate = CurrentDate
                - ( 30 * 24 * 60 * 60 );
    }

    // Logパッケージ初期化
    private static void InitLogVariable () {
        CurrentLogFileName = CurrentDate
                + ".log";
        OldLogFileName = OldDate
                + ".log";
    }

    // Dataパッケージ初期化
    private static void InitDataVariable () {

    }

    public static void DataClear () {
        Command = null;
        ParameterData = new ArrayList< String[] > ();
        ResultData = new ArrayList< HashMap< String, String > > ();
    }
}
