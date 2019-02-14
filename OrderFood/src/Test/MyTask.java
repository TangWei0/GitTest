package Test;

import java.util.Calendar;
import java.util.Date;
import java.util.Timer;
import java.util.TimerTask;

public class MyTask extends TimerTask {

    @Override
    public void run() {
        System.out.println("任务执行了，时间为" + new Date());
//        cancel();
        System.gc();
    }
    
    static Calendar calendarRef;
	static Date runDate;
	static MyTask task;
	static Timer timer;

	public static void main(String[] args) {
		start();
		sleep();
		stop();
		start();
	}

	static void sleep() {
		try {
			System.out.println("3秒一時停止します" + new Date());
			Thread.sleep(3000);
			System.out.println("一時停止を解除しました" + new Date());
		} catch (InterruptedException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

	static void init() {
		task = new MyTask();
		System.out.println("当前时间为：" + new Date());
		calendarRef = Calendar.getInstance();
		calendarRef.add(Calendar.SECOND, 10);
		runDate = calendarRef.getTime();
	}

	static void start() {
		init();
		System.out.println("Timer開始:" + new Date());
		timer = new Timer();
		timer.schedule(task, runDate);
	}

	static void stop() {
		System.out.println("Timer終了" + new Date());
		timer.cancel();
	}
}
