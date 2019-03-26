
package Com.OrderFood.Data;

public class StaticVariable {
    // 共通変数
    public static boolean LOG_JOB_OK = true;
    public static boolean LOG_JOB_NG = false;

    public static int DATA_STRING = 0;
    public static int DATA_INT = 1;
    public static int DATA_BOOLEAN = 2;

    public static int SQLTYPE_UPDATE = 0;
    public static int SQLTYPE_SEARCH = 1;

    // Access Class 変数
    public static String url = "jdbc:ucanaccess://DB//orderfood.accdb";
    public static String user = "";
    public static String pass = "";

    // Timer Class　変数
    public static int TimerOut = 1 * 60 * 1000;

}
