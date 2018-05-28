package Declaration;

import java.util.ArrayList;

public class Variable {
	// privateでインスタンス生成を抑止
	private Variable() {
	}

	public static ArrayList<Integer> DigitalCardArray = new ArrayList<Integer>();
	public static ArrayList<Integer> QuestionCardArray = new ArrayList<Integer>();

	// 抽選数字カードを定義する
	public static int[][][] UserDigitalCardArray = new int[MathConstants.USER_COUNT][MathConstants.SELECT_DIGITAL_SIZE][MathConstants.DIGITAL_PARAMETERS];

	// 問題カードを定義する
	public static int[] UsingQuestionCardArray = new int[MathConstants.SELECT_QUESTION_SIZE];

	public static int Number = MathConstants.NO_DECISION;
	public static int ErrorCode = MathConstants.NONE_ERROR;

	public static int ClickCount = 0;
	public static String input0 = "";
	public static String input1 = "";
	public static String input2 = "";
	public static String title = "";
	public static String checkResult = "";

	public static int sec = 0;

	public static int expandTime;
	public static int user1Time;
	public static int user2Time;

	public static long startTime;
	public static long endTime;

	public static String User1Title = "";
	public static String User2Title = "";

	public static String QuestionTitle = "";
	public static String BetTitle = "";

}
