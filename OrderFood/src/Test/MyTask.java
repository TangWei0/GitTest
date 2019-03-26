
package Test;

public class MyTask implements Runnable {

    static int time = 20;

    public void run () {
        while ( time > 0 ) {
            time--;
            try {
                Thread.sleep ( 1000 );
                int ss = time % 60;
                System.out.println ( "还剩" + ss + "秒" );
            } catch ( InterruptedException e ) {
                e.printStackTrace ();
            }
        }
    }

    public static void main ( String[] args ) {
        MyTask MyTask = new MyTask ();
        new Thread ( MyTask ).start ();
        sleep ();
    }

    static void sleep () {
        try {
            Thread.sleep ( 3000 );
            time = 20;
        } catch ( InterruptedException e ) {
            // TODO Auto-generated catch block
            e.printStackTrace ();
        }
    }
}
