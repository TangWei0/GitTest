package Declaration;

public class MathConstants {
	// privateコンストラクタでインスタンス生成を抑止
	private MathConstants() {
	}

	// 定数を定義する
	// フレームパラメータ
	public static final int FRAME_WIDTH = 800;
	public static final int FRAME_HIGHT = 600;

	//
	public static final int[][] DIGITAL_CARD = { { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 } };
	public static final int[] QUESTION_CARD = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
	public static final int USER_COUNT = 2;
	public static final int DIGITAL_PARAMETERS = DIGITAL_CARD.length;
	public static final int HALF_DIGITAL_SIZE = DIGITAL_CARD[0].length;
	public static final int DIGITAL_SIZE = DIGITAL_PARAMETERS * HALF_DIGITAL_SIZE;
	public static final int SELECT_DIGITAL_SIZE = 5;
	public static final int QUESTION_SIZE = QUESTION_CARD.length;
	public static final int SELECT_QUESTION_SIZE = 6;

	// カードパラメータ
	public static final int CARD_WIDTH = 80;
	public static final int CARD_HIGHT = 120;
	public static final int CARD_SPACING = 15;
	public static final int QUSETION_CARD_DX = FRAME_WIDTH / 2 - (CARD_WIDTH + CARD_SPACING) * SELECT_QUESTION_SIZE / 2
			+ CARD_SPACING / 2;
	public static final int QUSETION_CARD_DY = FRAME_HIGHT / 2 - CARD_HIGHT / 2;
	public static final int USER_DIGITAL_CARD_DX = FRAME_WIDTH / 2 - (CARD_WIDTH + CARD_SPACING) * (SELECT_DIGITAL_SIZE - 1) / 2
			- CARD_WIDTH / 2;
	public static final int USER_DIGITAL_CARD_DY = FRAME_HIGHT - FRAME_HIGHT / 6 - CARD_HIGHT / 2;

	public static final int BET_CARD_WIDTH = 60;
	public static final int BET_CARD_HIGHT = 80;
	public static final int BET_CARD_UP_DX = FRAME_WIDTH / 2 - (BET_CARD_WIDTH + CARD_SPACING) * HALF_DIGITAL_SIZE / 2
			+ CARD_SPACING / 2;
	public static final int BET_CARD_UP_DY = FRAME_HIGHT / 3 - FRAME_HIGHT / 9 - BET_CARD_HIGHT * 2 / 3;
	public static final int BET_CARD_DN_DX = BET_CARD_UP_DX;
	public static final int BET_CARD_DN_DY = BET_CARD_UP_DY * 2 + BET_CARD_HIGHT;

	// Centerボタンパラメータ
	public static final int CENTER_BUTTON_WIDTH = 200;
	public static final int CENTER_BUTTON_HIGHT = 100;
	public static final int CENTER_BUTTON_DX = FRAME_WIDTH / 2 - CENTER_BUTTON_WIDTH / 2;
	public static final int CENTER_BUTTON_DY = FRAME_HIGHT / 2 - CENTER_BUTTON_HIGHT / 2;

	// 右下ボタンのパラメータ
	public static final int RIGHT_BOTTOM_BUTTON_WIDTH = 100;
	public static final int RIGHT_BOTTOM_BUTTON_HIGHT = 50;
	public static final int RIGHT_BOTTOM_BUTTON_DX = 680;
	public static final int RIGHT_BOTTOM_BUTTON_DY = USER_DIGITAL_CARD_DY + CARD_HIGHT - RIGHT_BOTTOM_BUTTON_HIGHT;

	// BetInfoラベルのパラメータ
	public static final int BETINFO_LABEL_WIDTH = 750;
	public static final int BETINFO_LABEL_HIGHT = 300;
	public static final int BETINFO_LABEL_DX = 10;
	public static final int BETINFO_LABEL_DY = 10;

	//
	public static final int ALLUPDATE = 6;
	public static final int OVER = 128; // 128 = 無カード

	// 先手を決める
	public static final int NO_DECISION = 0;
	public static final int USER1_DECISION = 1;
	public static final int USER2_DECISION = 2;

	public static final int TIMER_OVER = 30000;
	public static final int CLICK_COUNT_MAX = 4;

	public static final int NO_LOWER = 5;
	public static final int NO_LIMIT = 6;
	public static final int NONE_BET = 7;
	public static final int ALL_BET = 8;
	public static final int OVER_BET = 9;
	
	//カラー情報
	public static final int RED = 1;
	public static final int BLUE = 2;
	public static final int GREEN = 3;
	
	// 奇偶数
	public static final int ODD = 1;
	public static final int EVEN = 0;
	
	// 大小指定
	public static final int SMALL = 0;
	public static final int CENTER = 1;
	public static final int BIG = 2;
	
	// エラーコード情報
	public static final int NONE_ERROR = 0;
	public static final int NUMBER_FAULT = 1;
	public static final int ALL_QUESTION_SELECTED = 2;
	public static final int SAME_TIME = 3;
	public static final int NOT_DECIDED = 4;
	public static final int CARD_PROGRAM_FAULT = 5;
	public static final int SCREEN_TRANSITION_FAULT = 6;
	public static final int QUESTION_CLICK_FAULT = 7;
	public static final int NEXT_DECISION = 8;
	public static final int BETBUTTON_FAULT = 9;
	public static final int BET_COUNT_MAX = 10;
	public static final int BET_PROGRAM_FAULT = 11;
	public static final int CLICK_FAULT = 12;

	public static final String[] PanelNames = {
			"startSubView",
			"betSubView",
			"user1View",
			"user2View",
			"betUser1View",
			"betUser2View"
	};

	public static final String[] Error = {
			"エラーなし",
			"相手の番が異常を発生しました。アプリを終了します。",
			"すべて問題カードを選択しました！",
			"時間が同じなので、もう一度お願いします！",
			"先手を決めていない為、画面遷移することができません。",
			"カード配るの問題が発生しました。アプリを終了します。",
			"画面遷移の問題を発生しました。アプリを終了します。",
			"問題カードクリックの問題を発生しました。アプリを終了します。",
			"相手の番です。「相手の番へ」ボタンをクリックお願いします！",
			"「宣言/相手の番へ」ボタンの問題を発生しました。アプリを終了します。",
			"既に宣言しました。",
			"宣言の問題を発生しました。アプリを終了します。",
			"クリックボタンの問題を発生しました。アプリを終了します。"
	};

	public static final String[] CommonTitleNames = {
			"<html>",
			"</html>",
			"<center>",
			"<br/>",
			"<a style='color:red'>",
			"</a>"
	};

	public static final String[] BetTitleNames = {
			"目標：",
			"User1：",
			"User2：",
			"スタートしてください！",
			"計時中...適当な時間にストップしてください！",
			"秒",
			"User1先手",
			"User2先手",
			"次へボタンをクリックし、ゲームしましょう!"
			};

	public static final String[] QuestionNames = {
			"8または9はどこ？",
			"1または2はどこ？",
			"連番になっているタイルはどこ？",
			"青の数字タイルは何枚ある？",
			"偶数は何枚ある？",
			"赤の数字タイルは何枚ある？",
			"赤の数の合計数は？",
			"青の数の合計数は？",
			"[共通]5枚のタイルすべての合計数は？",
			"3または4はどこ？",
			"同じ数字タイルのペアは何組ある？",
			"[共通]中央の数字タイルの5以上？4以下？",
			"奇数は何枚ある？",
			"0はどこ？",
			"[共通]数字タイルの最大の数から最小の数を引いた数は？",
			"連続してとなり合っている色はどこ？",
			"小さいほうから3枚の合計数は？",
			"6または7はどこ？",
			"中央の3枚の合計数は？",
			"5はどこ？",
			"大きいほうから3枚の合計数は？"
			};

}
