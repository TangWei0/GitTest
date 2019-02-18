
package Com.OrderFood.Data;

import java.io.File;

public class OrderFoodStaticVariable {
    // 共通変数
    public static boolean LOG_JOB_OK = true;
    public static boolean LOG_JOB_NG = false;

    // Log　Class　変数
    public static String LogPath = new File ( "" ).getAbsolutePath () + "\\Log\\";
    public static String OldLogPath = LogPath + "Old\\";
    public static int LogCheck = 0;
    public static int OldLogCheck = 1;

    // Access Class 変数
    public static String url = "jdbc:ucanaccess://DB//orderfood.accdb";
    public static String user = "";
    public static String pass = "";
}
