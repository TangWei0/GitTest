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
	public static int ErrorCode = 0;

}
