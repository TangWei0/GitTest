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
	public static final int OVER = 128; // 128 = 無カード

	// 先手をきめる
	// 0=決めていない, 1=User1番, 2=User2番
	public static final int NO_DECISION = 0;
	public static final int USER1_DECISION = 1;
	public static final int USER2_DECISION = 2;
	public static final int TIMEROVER = 65536;

	public static final String ERROR_1 = "先手を決めてからゲームを始めましょう！";
	public static final String ERROR_2 = "すべて問題カードを選択しました！";
	public static final String ERROR_3 = "時間が同じです、もう一度お願いします!";

	public static final String[] TitleNames = {
			"<html>",
			"</html>",
			"<center>",
			"<br/>",
			"<a style='color:red'>",
			"</a>",
			"目標：",
			"User1：",
			"User2：",
			"スタートしてください！",
			"計時中...適当な時間にストップしてください！",
			"秒",
			"User1先手",
			"User2先手",
			"画面を戻って、ゲームしましょう!"};

	public static final String[] QuestionNames = {
			TitleNames[0] + "8または9はどこ？" + TitleNames[1],
			TitleNames[0] + "1または2はどこ？" + TitleNames[1],
			TitleNames[0] + "連番になっているタイルはどこ？" + TitleNames[1],
			TitleNames[0] + "青の数字タイルは何枚ある？" + TitleNames[1],
			TitleNames[0] + "偶数は何枚ある？" + TitleNames[1],
			TitleNames[0] + "赤の数字タイルは何枚ある？" + TitleNames[1],
			TitleNames[0] + "赤の数の合計数は？" + TitleNames[1],
			TitleNames[0] + "青の数の合計数は？" + TitleNames[1],
			TitleNames[0] + "[共通]5枚のタイルすべての合計数は？" + TitleNames[1],
			TitleNames[0] + "3または4はどこ？" + TitleNames[1],
			TitleNames[0] + "同じ数字タイルのペアは何組ある？" + TitleNames[1],
			TitleNames[0] + "[共通]中央の数字タイルの5以上？4以下？" + TitleNames[1],
			TitleNames[0] + "奇数は何枚ある？" + TitleNames[1],
			TitleNames[0] + "0はどこ？" + TitleNames[1],
			TitleNames[0] + "[共通]数字タイルの最大の数から最小の数を引いた数は？" + TitleNames[1],
			TitleNames[0] + "連続してとなり合っている色はどこ？" + TitleNames[1],
			TitleNames[0] + "小さいほうから3枚の合計数は？" + TitleNames[1],
			TitleNames[0] + "6または7はどこ？" + TitleNames[1],
			TitleNames[0] + "中央の3枚の合計数は？" + TitleNames[1],
			TitleNames[0] + "5はどこ？" + TitleNames[1],
			TitleNames[0] + "大きいほうから3枚の合計数は？" + TitleNames[1] };

}
