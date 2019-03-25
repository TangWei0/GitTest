package Com.OrderFood.Timer;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

public class TimeChange {
    public static String getLongToString ( long longTime ) {
        SimpleDateFormat sdf = new SimpleDateFormat ( "yyyy-MM-dd HH:mm:ss.SSSSSS" );
        String time = sdf.format ( Long.valueOf ( longTime ) );
        return time;
    }

    // 将字符串时间格式转为long形
    public static long getToLong ( String DateTime ) {
        SimpleDateFormat sdf = new SimpleDateFormat ( "yyyy-MM-dd HH:mm:ss.SSSSSS" );
        Date time = null;
        try {
            time = sdf.parse ( DateTime );           
        } catch ( ParseException e ) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }
        return time.getTime ();
    }
}
