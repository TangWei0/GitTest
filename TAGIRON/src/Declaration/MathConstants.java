package Declaration;

public class MathConstants {
	// private�R���X�g���N�^�ŃC���X�^���X������}�~
	private MathConstants() {
	}

	// �萔���`����
	// �t���[���p�����[�^
	public static final int FRAME_WIDTH = 1280;
	public static final int FRAME_HIGHT = 960;

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

	// �J�[�h�p�����[�^
	public static final int CARD_WIDTH = 120;
	public static final int CARD_HIGHT = 160;
	public static final int CARD_SPACING = 40;
	public static final int QUSETION_CARD_DX = FRAME_WIDTH / 2 - (CARD_WIDTH + CARD_SPACING) * SELECT_QUESTION_SIZE / 2
			+ CARD_SPACING / 2;
	public static final int QUSETION_CARD_DY = FRAME_HIGHT / 2 - CARD_HIGHT / 2;
	public static final int USER_DIGITAL_CARD_DX = FRAME_WIDTH / 2 - (CARD_WIDTH + CARD_SPACING) * (SELECT_DIGITAL_SIZE - 1) / 2
			- CARD_WIDTH / 2;
	public static final int USER_DIGITAL_CARD_DY = FRAME_HIGHT - FRAME_HIGHT / 6 - CARD_HIGHT / 2;

	public static final int BET_CARD_WIDTH = 80;
	public static final int BET_CARD_HIGHT = 120;
	public static final int BET_CARD_UP_DX = FRAME_WIDTH / 2 - (BET_CARD_WIDTH + CARD_SPACING) * HALF_DIGITAL_SIZE / 2
			+ CARD_SPACING / 2;
	public static final int BET_CARD_UP_DY = FRAME_HIGHT / 3 - FRAME_HIGHT / 9 - BET_CARD_HIGHT * 2 / 3;
	public static final int BET_CARD_DN_DX = BET_CARD_UP_DX;
	public static final int BET_CARD_DN_DY = BET_CARD_UP_DY * 2 + BET_CARD_HIGHT;

	// Center�{�^���p�����[�^
	public static final int CENTER_BUTTON_WIDTH = 200;
	public static final int CENTER_BUTTON_HIGHT = 100;
	public static final int CENTER_BUTTON_DX = FRAME_WIDTH / 2 - CENTER_BUTTON_WIDTH / 2;
	public static final int CENTER_BUTTON_DY = FRAME_HIGHT / 2 - CENTER_BUTTON_HIGHT / 2;

	// �E���{�^���̃p�����[�^
	public static final int RIGHT_BOTTOM_BUTTON_WIDTH = 150;
	public static final int RIGHT_BOTTOM_BUTTON_HIGHT = 80;
	public static final int RIGHT_BOTTOM_BUTTON_DX = 1100;
	public static final int RIGHT_BOTTOM_BUTTON_DY = USER_DIGITAL_CARD_DY + CARD_HIGHT - RIGHT_BOTTOM_BUTTON_HIGHT;

	// BetInfo���x���̃p�����[�^
	public static final int BETINFO_LABEL_WIDTH = 900;
	public static final int BETINFO_LABEL_HIGHT = 400;
	public static final int BETINFO_LABEL_DX = 190;
	public static final int BETINFO_LABEL_DY = 50;

	//
	public static final int ALLUPDATE = 6;
	public static final int OVER = 128; // 128 = ���J�[�h

	// �������߂�
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
	
	//�J���[���
	public static final int RED = 1;
	public static final int BLUE = 2;
	public static final int GREEN = 3;
	
	// �����
	public static final int ODD = 1;
	public static final int EVEN = 0;
	
	// �召�w��
	public static final int SMALL = 0;
	public static final int CENTER = 1;
	public static final int BIG = 2;
	
	// �G���[�R�[�h���
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
			"�G���[�Ȃ�",
			"����̔Ԃ��ُ�𔭐����܂����B�A�v�����I�����܂��B",
			"���ׂĖ��J�[�h��I�����܂����I",
			"���Ԃ������Ȃ̂ŁA������x���肢���܂��I",
			"�������߂Ă��Ȃ��ׁA��ʑJ�ڂ��邱�Ƃ��ł��܂���B",
			"�J�[�h�z��̖�肪�������܂����B�A�v�����I�����܂��B",
			"��ʑJ�ڂ̖��𔭐����܂����B�A�v�����I�����܂��B",
			"���J�[�h�N���b�N�̖��𔭐����܂����B�A�v�����I�����܂��B",
			"����̔Ԃł��B�u����̔Ԃցv�{�^�����N���b�N���肢���܂��I",
			"�u�錾/����̔Ԃցv�{�^���̖��𔭐����܂����B�A�v�����I�����܂��B",
			"���ɐ錾���܂����B",
			"�錾�̖��𔭐����܂����B�A�v�����I�����܂��B",
			"�N���b�N�{�^���̖��𔭐����܂����B�A�v�����I�����܂��B"
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
			"�ڕW�F",
			"User1�F",
			"User2�F",
			"�X�^�[�g���Ă��������I",
			"�v����...�K���Ȏ��ԂɃX�g�b�v���Ă��������I",
			"�b",
			"User1���",
			"User2���",
			"���փ{�^�����N���b�N���A�Q�[�����܂��傤!"
			};

	public static final String[] QuestionNames = {
			"8�܂���9�͂ǂ��H",
			"1�܂���2�͂ǂ��H",
			"�A�ԂɂȂ��Ă���^�C���͂ǂ��H",
			"�̐����^�C���͉�������H",
			"�����͉�������H",
			"�Ԃ̐����^�C���͉�������H",
			"�Ԃ̐��̍��v���́H",
			"�̐��̍��v���́H",
			"[����]5���̃^�C�����ׂĂ̍��v���́H",
			"3�܂���4�͂ǂ��H",
			"���������^�C���̃y�A�͉��g����H",
			"[����]�����̐����^�C����5�ȏ�H4�ȉ��H",
			"��͉�������H",
			"0�͂ǂ��H",
			"[����]�����^�C���̍ő�̐�����ŏ��̐������������́H",
			"�A�����ĂƂȂ荇���Ă���F�͂ǂ��H",
			"�������ق�����3���̍��v���́H",
			"6�܂���7�͂ǂ��H",
			"������3���̍��v���́H",
			"5�͂ǂ��H",
			"�傫���ق�����3���̍��v���́H"
			};

}
