
package Com.OrderFood.Data;

import java.awt.GraphicsEnvironment;

public class OrderFoodVariable {
    // Screenパッケージ
    public static int FrameWidth;
    public static int FrameHeight;

    // Accessパッケージ
    public static boolean AccessConnectStatus;
    public static boolean AccessStatementStatus;

    // Timerパッケージ
    public static int TimerOut;
    public static boolean TimerStatus;
    public static long CurrentDate;
    public static long OldDate;

    // Logパッケージ
    public static String CurrentLogFileName;

    // 変数初期化
    public static void InitVariable () {
        InitScreenVariable ();
        InitAccessVariable ();
        InitTimerVariable ();
        InitLogVariable ();
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
        TimerOut = 20;
        TimerStatus = false;
        CurrentDate = System.currentTimeMillis ();
        OldDate = CurrentDate - 30 * 24 * 60 * 60 * 1000;
    }

    // Accessパッケージ初期化
    private static void InitLogVariable () {
        CurrentLogFileName = CurrentDate + ".log";
    }
}
