package Declaration;

import java.util.ArrayList;

public class Variable {
	// private�ŃC���X�^���X������}�~
	private Variable() {
	}
	
	public static ArrayList<Integer> DigitalCardArray = new ArrayList<Integer>();
	public static ArrayList<Integer> QuestionCardArray = new ArrayList<Integer>();
	
	// ���I�����J�[�h���`����
	public static int[][] User1DigitalCardArray = new int[MathConstants.SELECT_DIGITAL_SIZE][MathConstants.DIGITAL_PARAMETERS];
	public static int[][] User2DigitalCardArray = new int[MathConstants.SELECT_DIGITAL_SIZE][MathConstants.DIGITAL_PARAMETERS];

	// ���J�[�h���`����
	public static int[] UsingQuestionCardArray = new int[MathConstants.SELECT_QUESTION_SIZE];
	
	public static int Number = MathConstants.NO_DECISION;
	
}
