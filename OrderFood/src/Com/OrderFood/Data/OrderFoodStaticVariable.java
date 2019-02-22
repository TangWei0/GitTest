
package Com.OrderFood.Data;

import java.io.File;
import java.util.HashMap;

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

    public static HashMap< String, String[] > Tabel = new HashMap< String, String[] > ();
    
    public static String[] tabel = { "account", "user", "department" };

    public static String[] account_col = { "account_id", "account_password" };
    public static String[] user_col = { "user_id", "user_name", "user_joined", "dapartment_id" };
    public static String[] department_col = { "department_id", "department_name" };
    // Timer Class　変数
    public static int TimerOut = 1 * 60 * 1000;

}
