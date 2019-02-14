package Test;

import java.util.Calendar;
import java.util.Date;
import java.util.Timer;

public class TimeTask {
	static Calendar calendarRef;
	static Date runDate;
	static MyTask task;
	static Timer timer;

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

	public static void init() {
		task = new MyTask();
		System.out.println("当前时间为：" + new Date());
		calendarRef = Calendar.getInstance();
		calendarRef.add(Calendar.SECOND, 10);
		runDate = calendarRef.getTime();
	}

	public static void start() {
		init();
		System.out.println("Timer開始:" + new Date());
		timer = new Timer();
		timer.schedule(task, runDate);
	}

	public static void stop() {
		System.out.println("Timer終了" + new Date());
		timer.cancel();
	}
}
