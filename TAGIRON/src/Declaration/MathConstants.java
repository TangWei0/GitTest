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
	public static final int USER_COUNT = 2;
	public static final int DIGITAL_PARAMETERS = 2;
	public static final int DIGITAL_SIZE = 20;
	public static final int HALF_DIGITAL_SIZE = DIGITAL_SIZE / 2;
	public static final int SELECT_DIGITAL_SIZE = 5;
	public static final int QUESTION_SIZE = 21;
	public static final int SELECT_QUESTION_SIZE = 6;

	// �J�[�h�p�����[�^
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

	// Center�{�^���p�����[�^
	public static final int CENTER_BUTTON_WIDTH = 200;
	public static final int CENTER_BUTTON_HIGHT = 100;
	public static final int CENTER_BUTTON_DX = FRAME_WIDTH / 2 - CENTER_BUTTON_WIDTH / 2;
	public static final int CENTER_BUTTON_DY = FRAME_HIGHT / 2 - CENTER_BUTTON_HIGHT / 2;

	// �E��{�^���̃p�����[�^
	public static final int RIGHT_TOP_BUTTON_WIDTH = 150;
	public static final int RIGHT_TOP_BUTTON_HIGHT = 80;
	public static final int RIGHT_TOP_BUTTON_DX = 1100;
	public static final int RIGHT_TOP_BUTTON_DY = 10;

	// �E���{�^���̃p�����[�^
	public static final int RIGHT_BOTTOM_BUTTON_WIDTH = 150;
	public static final int RIGHT_BOTTOM_BUTTON_HIGHT = 80;
	public static final int RIGHT_BOTTOM_BUTTON_DX = 1100;
	public static final int RIGHT_BOTTOM_BUTTON_DY = 850;

	// BetInfo���x���̃p�����[�^
	public static final int BETINFO_LABEL_WIDTH = 900;
	public static final int BETINFO_LABEL_HIGHT = 400;
	public static final int BETINFO_LABEL_DX = 190;
	public static final int BETINFO_LABEL_DY = 50;

	//
	public static final int ALLUPDATE = 6;
	public static final int OVER = 128; // 128 = ���J�[�h

	// �������߂�
	// 0=���߂Ă��Ȃ�, 1=User1��, 2=User2��
	public static final int NO_DECISION = 0;
	public static final int USER1_DECISION = 1;
	public static final int USER2_DECISION = 2;
	public static final int TIMER_OVER = 30000;
	public static final int CLICK_COUNT_MAX = 128;

	public static final String[] PanelNames = {
			"startSubView", 
			"betSubView", 
			"user1View", 
			"user2View"
	};

	public static final String[] Error = {
			"�G���[�𔭐����܂����B�A�v�����I�����܂��B",
			"���ׂĖ��J�[�h��I�����܂����I",
			"���Ԃ������Ȃ̂ŁA������x���肢���܂�!",
			"�������߂Ă��Ȃ��ׁA��ʑJ�ڂ��邱�Ƃ��ł��܂���B",
			"error4",
			"error5",
			"error6",
			"error7"
	};

	public static final String[] TitleNames = {
			"<html>",
			"</html>",
			"<center>",
			"<br/>",
			"<a style='color:red'>",
			"</a>",
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
			TitleNames[0] + "8�܂���9�͂ǂ��H" + TitleNames[1],
			TitleNames[0] + "1�܂���2�͂ǂ��H" + TitleNames[1],
			TitleNames[0] + "�A�ԂɂȂ��Ă���^�C���͂ǂ��H" + TitleNames[1],
			TitleNames[0] + "�̐����^�C���͉�������H" + TitleNames[1],
			TitleNames[0] + "�����͉�������H" + TitleNames[1],
			TitleNames[0] + "�Ԃ̐����^�C���͉�������H" + TitleNames[1],
			TitleNames[0] + "�Ԃ̐��̍��v���́H" + TitleNames[1],
			TitleNames[0] + "�̐��̍��v���́H" + TitleNames[1],
			TitleNames[0] + "[����]5���̃^�C�����ׂĂ̍��v���́H" + TitleNames[1],
			TitleNames[0] + "3�܂���4�͂ǂ��H" + TitleNames[1],
			TitleNames[0] + "���������^�C���̃y�A�͉��g����H" + TitleNames[1],
			TitleNames[0] + "[����]�����̐����^�C����5�ȏ�H4�ȉ��H" + TitleNames[1],
			TitleNames[0] + "��͉�������H" + TitleNames[1],
			TitleNames[0] + "0�͂ǂ��H" + TitleNames[1],
			TitleNames[0] + "[����]�����^�C���̍ő�̐�����ŏ��̐������������́H" + TitleNames[1],
			TitleNames[0] + "�A�����ĂƂȂ荇���Ă���F�͂ǂ��H" + TitleNames[1],
			TitleNames[0] + "�������ق�����3���̍��v���́H" + TitleNames[1],
			TitleNames[0] + "6�܂���7�͂ǂ��H" + TitleNames[1],
			TitleNames[0] + "������3���̍��v���́H" + TitleNames[1],
			TitleNames[0] + "5�͂ǂ��H" + TitleNames[1],
			TitleNames[0] + "�傫���ق�����3���̍��v���́H" + TitleNames[1]
			};

}
