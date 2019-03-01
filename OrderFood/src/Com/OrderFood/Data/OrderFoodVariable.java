
package Com.OrderFood.Data;

import java.awt.GraphicsEnvironment;
import java.util.ArrayList;
import java.util.HashMap;

public class OrderFoodVariable {
    // Screen Class
    public static int FrameWidth;
    public static int FrameHeight;
    public static int UnitWidth;
    public static int UnitHeight;

    // Access Class
    public static boolean AccessConnectStatus;
    public static boolean AccessStatementStatus;

    public static ArrayList< String[] > ParameterData;
    public static String ParameterTabel;
    public static String ParameterInner;
    public static String ParameterSelect;
    public static String ParameterSet;
    public static String ParameterWhere;
    public static String ParameterOn;
    public static ArrayList< HashMap< String, String > > ResultData;

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
    public static OrderFoodAccount Account = new OrderFoodAccount ();
    public static OrderFoodDepartment Department = new OrderFoodDepartment ();
    public static OrderFoodUser User = new OrderFoodUser ();
    public static OrderFoodStatus Status = new OrderFoodStatus ();

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
        DeleteLogFileStatus = true;
    }

    // Dataパッケージ初期化
    private static void InitDataVariable () {

    }

    public static void DataClear () {

        ParameterData = new ArrayList< String[] > ();
        ParameterTabel = null;
        ParameterInner = null;
        ParameterSelect = null;
        ParameterSet = null;
        ParameterWhere = null;
        ParameterOn = null;
        ResultData = new ArrayList< HashMap< String, String > > ();
    }
}
