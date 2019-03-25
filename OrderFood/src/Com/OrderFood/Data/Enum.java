
package Com.OrderFood.Data;

public class Enum {
    // 関数実行結果
    public enum JobResult {
        SUCCESS, ABNORMAL_UNKNOWHOST, ABNORMAL_IO, ABNORMAL_INTERRUPTED, ABNORMAL_ILLEGAL_ARGUMENT, ABNORMAL_SECURITY, ABNORMAL_SQL
    }

    public enum NetworkStateResult {
        DISCONNECTED, // ネットワーク未接続
        UNDISCOVERED, // DB接続不可
        DISCOVERED // DB接続可能
    }

    public enum DBStateResult {
        DISCONNECTED, // DB未接続
        CONNECTING, // DB接続中
    }

    public enum AccessTimerResult {
        STOPED, STARTING
    }

    public enum ThreadResult {
        STOP, SUSPEND, RUNNING
    }

    public enum ParameterDataType {
        STRING, INT, BOOLEAN
    }

    public enum SQLType {
        UPDATE, SEARCH
    }

    // Access Class 変数
    public static final String DB_ip = "10.25.109.31";
    public static final String host_ip = "127.0.0.1";
    public static final String url = "jdbc:ucanaccess://DB//orderfood.accdb";
    public static final String user = "";
    public static final String pass = "";

    // Timer Class　変数
    public static final int TimerOut = 60;
    public static final int MinTime = 1000;
    public static final int MaxTime = 600000;
}
