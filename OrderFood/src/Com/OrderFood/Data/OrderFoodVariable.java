
package Com.OrderFood.Data;

import java.awt.GraphicsEnvironment;
import java.sql.ResultSet;
import java.util.ArrayList;

public class OrderFoodVariable {
    // Screen Class
    public static int FrameWidth;
    public static int FrameHeight;

    // Access Class
    public static boolean AccessConnectStatus;
    public static boolean AccessStatementStatus;
    public static ResultSet resultSet;

    // Timer Class
    public static int TimerOut;
    public static boolean TimerStatus;
    public static long CurrentDate;
    public static long OldDate;

    // Log Class
    public static String CurrentLogFileName;
    public static String OldLogFileName;
    public static boolean DeleteLogFileStatus;

    // Data Class
    public static ArrayList< OrderFoodAccount > AccountList = new ArrayList< OrderFoodAccount > ();

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
        OldDate = CurrentDate - 30 * 24 * 60 * 60;
    }

    // Logパッケージ初期化
    private static void InitLogVariable () {
        CurrentLogFileName = CurrentDate + ".log";
        OldLogFileName = OldDate + ".log";
        DeleteLogFileStatus = true;
    }

    // Dataパッケージ初期化
    private static void InitDataVariable () {

    }
}
