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

	// �J�n�{�^���p�����[�^
	public static final int START_BUTTON_WIDTH = 200;
	public static final int START_BUTTON_HIGHT = 100;
	public static final int START_BUTTON_DX = FRAME_WIDTH / 2 - START_BUTTON_WIDTH / 2;
	public static final int START_BUTTON_DY = FRAME_HIGHT / 2 - START_BUTTON_HIGHT / 2;

	// �������߂�{�^���Ɩ߂�{�^���̃p�����[�^
	public static final int COMMON_BUTTON_WIDTH = 150;
	public static final int COMMON_BUTTON_HIGHT = 80;
	public static final int COMMON_BUTTON_DX = 10;
	public static final int COMMON_BUTTON_DY = 10;

	//
	public static final int ALLUPDATE = 6;
	public static final int OVER = 128; // 128 = ���J�[�h

	// �������߂�
	// 0=���߂Ă��Ȃ�, 1=User1��, 2=User2��
	public static final int NO_DECISION = 0;
	public static final int USER1_DECISION = 1;
	public static final int USER2_DECISION = 2;
	public static final int TIMEROVER = 65536;

	public static final String ERROR_1 = "�������߂Ă���Q�[�����n�߂܂��傤�I";
	public static final String ERROR_2 = "���ׂĖ��J�[�h��I�����܂����I";
	public static final String ERROR_3 = "���Ԃ������ł��A������x���肢���܂�!";

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
			"��ʂ�߂��āA�Q�[�����܂��傤!"};

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
			TitleNames[0] + "�傫���ق�����3���̍��v���́H" + TitleNames[1] };

}
