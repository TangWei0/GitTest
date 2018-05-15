package constants;

public class MathConstants {
	// privateコンストラクタでインスタンス生成を抑止
	private MathConstants(){} 

	// 定数を定義する
	// フレームパラメータ
	public static final int FRAME_WIDTH = 1280;
	public static final int FRAME_HIGHT = 960;

	//
	public static final int DIGITAL_PARAMETERS = 2;
	public static final int DIGITAL_SIZE = 20;
	public static final int HALF_DIGITAL_SIZE = DIGITAL_SIZE / 2;
	public static final int SELECT_DIGITAL_SIZE = 5;
	public static final int QUESTION_SIZE = 21;
	public static final int SELECT_QUESTION_SIZE = 6;

	// カードパラメータ
	public static final int CARD_WIDTH = 120;
	public static final int CARD_HIGHT = 160;
	public static final int CARD_SPACING = 40;
	public static final int QUSETION_CARD_DX = FRAME_WIDTH / 2 - (CARD_WIDTH + CARD_SPACING) * SELECT_QUESTION_SIZE / 2
			+ CARD_SPACING / 2;
	public static final int QUSETION_CARD_DY = FRAME_HIGHT / 2 - CARD_HIGHT / 2;
	public static final int USER1_DIGITAL_CARD_DX = FRAME_WIDTH / 2 - (CARD_WIDTH + CARD_SPACING) * (SELECT_DIGITAL_SIZE - 1) / 2
			- CARD_WIDTH / 2;
	public static final int USER1_DIGITAL_CARD_DY = FRAME_HIGHT - FRAME_HIGHT / 6 - CARD_HIGHT / 2;
	public static final int USER2_DIGITAL_CARD_DX = USER1_DIGITAL_CARD_DX;
	public static final int USER2_DIGITAL_CARD_DY = FRAME_HIGHT / 6 - CARD_HIGHT / 2;

	// ボタンパラメータ
	public static final int BUTTON_WIDTH = 200;
	public static final int BUTTON_HIGHT = 100;
	public static final int BUTTON_DX = FRAME_WIDTH / 2 - BUTTON_WIDTH / 2;
	public static final int BUTTON_DY = FRAME_HIGHT / 2 - BUTTON_HIGHT / 2;
	
	public static final int ALLUPDATE = 128;
	public static final int OVER = 128;
}
