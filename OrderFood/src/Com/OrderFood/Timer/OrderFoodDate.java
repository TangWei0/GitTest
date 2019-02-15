
package Com.OrderFood.Timer;

import java.util.Calendar;

public class OrderFoodDate {
    static Calendar c = null;
    static int year;
    static int month;
    static int date;
    static int hour;
    static int minute;
    static int second;

    public static void getDate () {
        c = Calendar.getInstance ();
        System.out.println(c);
        year = c.get ( Calendar.YEAR );
        month = c.get ( Calendar.MONTH ) + 1;
        date = c.get ( Calendar.DATE );
        hour = c.get ( Calendar.HOUR_OF_DAY );
        minute = c.get ( Calendar.MINUTE );
        second = c.get ( Calendar.SECOND );
    }

    public static void creat () {
        getDate();
        String Date = "";
        Date = String.valueOf ( year ) + String.format ( "%2d", month ).replace ( " ", "0" )
                + String.format ( "%2d", date ).replace ( " ", "0" )
                + String.format ( "%2d", hour ).replace ( " ", "0" )
                + String.format ( "%2d", minute ).replace ( " ", "0" )
                + String.format ( "%2d", second ).replace ( " ", "0" );
        System.out.println(Date);
        

    }

}
