package Declaration;

public class MathConstants {
	// privateコンストラクタでインスタンス生成を抑止
	private MathConstants() {
	}
	
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

	// 開始ボタンパラメータ
	public static final int START_BUTTON_WIDTH = 200;
	public static final int START_BUTTON_HIGHT = 100;
	public static final int START_BUTTON_DX = FRAME_WIDTH / 2 - START_BUTTON_WIDTH / 2;
	public static final int START_BUTTON_DY = FRAME_HIGHT / 2 - START_BUTTON_HIGHT / 2;
	
	// 先手を決めるボタンと戻るボタンのパラメータ
	public static final int COMMON_BUTTON_WIDTH = 150;
	public static final int COMMON_BUTTON_HIGHT = 80;
	public static final int COMMON_BUTTON_DX = 10;
	public static final int COMMON_BUTTON_DY = 10;

	// 
	public static final int ALLUPDATE = 6;
	public static final int OVER = 128; //128 = 無カード

	// 先手をきめる
	//　0=決めていない, 1=User1番, 2=User2番
	public static final int NO_DECISION = 0;
	public static final int USER1_DECISION = 1;
	public static final int USER2_DECISION = 2;
	
	public static final String ERROR_1 = "先手を決めてからゲームを始めましょう！";
	public static final String ERROR_2 = "すべて問題カードを選択しました！";
	
	public static String[] QuestionNames = {
			"<html>8または9はどこ？</html>",
			"<html>1または2はどこ？</html>",
			"<html>連番になっているタイルはどこ？</html>",
			"<html>青の数字タイルは何枚ある？</html>",
			"<html>偶数は何枚ある？</html>",
			"<html>赤の数字タイルは何枚ある？</html>",
			"<html>赤の数の合計数は？</html>",
			"<html>青の数の合計数は？</html>",
			"<html>[共通]5枚のタイルすべての合計数は？</html>",
			"<html>3または4はどこ？</html>",
			"<html>同じ数字タイルのペアは何組ある？</html>",
			"<html>[共通]中央の数字タイルの5以上？4以下？</html>",
			"<html>奇数は何枚ある？</html>",
			"<html>0はどこ？</html>",
			"<html>[共通]数字タイルの<br/>最大の数から最小の数を引いた数は？</html>",
			"<html>連続してとなり合っている色はどこ？</html>",
			"<html>小さいほうから3枚の合計数は？</html>",
			"<html>6または7はどこ？</html>",
			"<html>中央の3枚の合計数は？</html>",
			"<html>5はどこ？</html>",
			"<html>大きいほうから3枚の合計数は？</html>" };

}
