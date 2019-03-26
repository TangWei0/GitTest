
package Test;

import java.io.IOException;
import java.net.InetAddress;
import java.net.UnknownHostException;
import java.text.SimpleDateFormat;
import java.util.Date;

public class NetworkState implements Runnable {

    // 判断网络状态
    public void isConnect () throws UnknownHostException {
        InetAddress inetAddress = InetAddress.getByName ( "10.25.109.29" );

        // isReachableメソッドでpingが実現できます。引数はタイムアウト(ミリ秒指定)。
        boolean pingdata;
        try {
            pingdata = inetAddress.isReachable ( 1000 );
        } catch ( IOException e ) {
            // TODO Auto-generated catch block
            pingdata = false;
        }
        System.out.println ( "結果:" + pingdata + getCurrentTime () );
    }

    // 获得当前时间
    public String getCurrentTime () {
        SimpleDateFormat sdf = new SimpleDateFormat ( "yyyy-MM-dd HH:mm:ss" );
        String time = sdf.format ( new Date () );
        return time;
    }

    @Override
    public void run () {
        // TODO Auto-generated method stub
        while ( true ) {
            try {
                this.isConnect ();
                // 每隔3秒钟测试一次网络是否连通
                Thread.sleep ( 3000 );
            } catch ( InterruptedException | UnknownHostException e ) {
                // TODO Auto-generated catch block
                e.printStackTrace ();
            }
        }
    }

}
