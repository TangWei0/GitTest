
package Test;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

public class Main {

    public static String getLongToString ( long longTime ) {
        SimpleDateFormat sdf = new SimpleDateFormat ( "yyyy-MM-dd HH:mm:ss" );
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

    public static void main ( String[] args ) {
        String connect="1970-01-01 09:00:01.000000";
        try {
            long s = getToLong(connect);
            System.out.println(s);
        } catch ( Exception e ) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }
        
        long CurrentDate = System.currentTimeMillis ();
        long s1 = 30 * 24 * 60 * 60 * 1000L;
        System.out.println ( s1 );
        long OldDate = CurrentDate - s1;
        System.out.println ( CurrentDate );
        System.out.println ( OldDate );
        
        String x1 = getLongToString(CurrentDate);
        String x2 = getLongToString(OldDate);
        
        System.out.println ( x1 );
        System.out.println ( x2 );
    }
}
