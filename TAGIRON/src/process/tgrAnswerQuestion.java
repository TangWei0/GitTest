package Process;

import static Declaration.MathConstants.*;
import static Declaration.Variable.*;

public class tgrAnswerQuestion {

	public static void WhereConsistentColor() {
		boolean recodeSwitch = false;
		int startIndex = 0;
		int endIndex = 0;
		String title = "";
		if (Number == USER1_DECISION) {
			for (int i = 0; i < SELECT_DIGITAL_SIZE - 1; i++) {
				if (UserDigitalCardArray[1][i][1] == UserDigitalCardArray[1][i + 1][1]) {
					if (i == SELECT_DIGITAL_SIZE - 2) {
						if (recodeSwitch) {
							recodeSwitch = false;
							endIndex = SELECT_DIGITAL_SIZE;
							if (title == "") {
								title = "�A�����ĂƂȂ荇���Ă���F�́A������" + startIndex + "�Ԗڂ���" + endIndex + "�Ԗڂ܂�";
							} else {
								title += "�ƍ�����" + startIndex + "�Ԗڂ���" + endIndex + "�Ԗڂ܂�";
							}
						} else {
							// �������Ȃ�
						}
					} else {
						if (!recodeSwitch) {
							recodeSwitch = true;
							startIndex = i + 1;
						} else {
							// �������Ȃ�
						}
					}
				} else {
					if (recodeSwitch) {
						recodeSwitch = false;
						endIndex = i + 1;
						if (title == "") {
							title = "�A�����ĂƂȂ荇���Ă���F�́A������" + startIndex + "�Ԗڂ���" + endIndex + "�Ԗڂ܂�";
						} else {
							title += "�ƍ�����" + startIndex + "�Ԗڂ���" + endIndex + "�Ԗڂ܂�";
						}
					} else {
						// �������Ȃ�
					}
				}
			}
			if (title == "") {
				title = "�A�����ĂƂȂ荇���Ă���F�́A�Ȃ�";
			} else {
				// �������Ȃ�
			}
			User1Title = User1Title.replaceFirst(CommonTitleNames[1], CommonTitleNames[3] + CommonTitleNames[2] + title + CommonTitleNames[1]);
		} else {
			for (int i = 0; i < SELECT_DIGITAL_SIZE - 1; i++) {
				if (UserDigitalCardArray[0][i][1] == UserDigitalCardArray[0][i + 1][1]) {
					if (i == SELECT_DIGITAL_SIZE - 2) {
						if (recodeSwitch) {
							recodeSwitch = false;
							endIndex = SELECT_DIGITAL_SIZE;
							if (title == "") {
								title = "�A�����ĂƂȂ荇���Ă���F�́A������" + startIndex + "�Ԗڂ���" + endIndex + "�Ԗڂ܂�";
							} else {
								title += "�ƍ�����" + startIndex + "�Ԗڂ���" + endIndex + "�Ԗڂ܂�";
							}
						} else {
							// �������Ȃ�
						}
					} else {
						if (!recodeSwitch) {
							recodeSwitch = true;
							startIndex = i + 1;
						} else {
							// �������Ȃ�
						}
					}
				} else {
					if (recodeSwitch) {
						recodeSwitch = false;
						endIndex = i + 1;
						if (title == "") {
							title = "�A�����ĂƂȂ荇���Ă���F�́A������" + startIndex + "�Ԗڂ���" + endIndex + "�Ԗڂ܂�";
						} else {
							title += "�ƍ�����" + startIndex + "�Ԗڂ���" + endIndex + "�Ԗڂ܂�";
						}
					} else {
						// �������Ȃ�
					}
				}
			}
			if (title == "") {
				title = "�A�����ĂƂȂ荇���Ă���F�́A�Ȃ�";
			} else {
				// �������Ȃ�
			}
			User2Title = User2Title.replaceFirst(CommonTitleNames[1], CommonTitleNames[3] + CommonTitleNames[2] + title + CommonTitleNames[1]);
		}
	}

	public static void WhereConsistentDigital() {
		boolean recodeSwitch = false;
		int startIndex = 0;
		int endIndex = 0;
		String title = "";
		if (Number == USER1_DECISION) {
			for (int i = 0; i < SELECT_DIGITAL_SIZE - 1; i++) {
				if (UserDigitalCardArray[1][i][0] == UserDigitalCardArray[1][i + 1][0] - 1) {
					if (i == SELECT_DIGITAL_SIZE - 2) {
						if (recodeSwitch) {
							recodeSwitch = false;
							endIndex = SELECT_DIGITAL_SIZE;
							if (title == "") {
								title = "�A�ԂɂȂ��Ă���^�C���́A������" + startIndex + "�Ԗڂ���" + endIndex + "�Ԗڂ܂�";
							} else {
								title += "�ƍ�����" + startIndex + "�Ԗڂ���" + endIndex + "�Ԗڂ܂�";
							}
						} else {
							// �������Ȃ�
						}
					} else {
						if (!recodeSwitch) {
							recodeSwitch = true;
							startIndex = i + 1;
						} else {
							// �������Ȃ�
						}
					}
				} else {
					if (recodeSwitch) {
						recodeSwitch = false;
						endIndex = i + 1;
						if (title == "") {
							title = "�A�ԂɂȂ��Ă���^�C���́A������" + startIndex + "�Ԗڂ���" + endIndex + "�Ԗڂ܂�";
						} else {
							title += "�ƍ�����" + startIndex + "�Ԗڂ���" + endIndex + "�Ԗڂ܂�";
						}
					} else {
						// �������Ȃ�
					}
				}
			}
			if (title == "") {
				title = "�A�ԂɂȂ��Ă���^�C���́A�Ȃ�";
			} else {
				// �������Ȃ�
			}
			User1Title = User1Title.replaceFirst(CommonTitleNames[1], CommonTitleNames[3] + CommonTitleNames[2] + title + CommonTitleNames[1]);
		} else {
			for (int i = 0; i < SELECT_DIGITAL_SIZE - 1; i++) {
				if (UserDigitalCardArray[0][i][0] == UserDigitalCardArray[0][i + 1][0] - 1) {
					if (i == SELECT_DIGITAL_SIZE - 2) {
						if (recodeSwitch) {
							recodeSwitch = false;
							endIndex = SELECT_DIGITAL_SIZE;
							if (title == "") {
								title = "�A�ԂɂȂ��Ă���^�C���́A������" + startIndex + "�Ԗڂ���" + endIndex + "�Ԗڂ܂�";
							} else {
								title += "�ƍ�����" + startIndex + "�Ԗڂ���" + endIndex + "�Ԗڂ܂�";
							}
						} else {
							// �������Ȃ�
						}
					} else {
						if (!recodeSwitch) {
							recodeSwitch = true;
							startIndex = i + 1;
						} else {
							// �������Ȃ�
						}
					}
				} else {
					if (recodeSwitch) {
						recodeSwitch = false;
						endIndex = i + 1;
						if (title == "") {
							title = "�A�ԂɂȂ��Ă���^�C���́A������" + startIndex + "�Ԗڂ���" + endIndex + "�Ԗڂ܂�";
						} else {
							title += "�ƍ�����" + startIndex + "�Ԗڂ���" + endIndex + "�Ԗڂ܂�";
						}
					} else {
						// �������Ȃ�
					}
				}
			}
			if (title == "") {
				title = "�A�ԂɂȂ��Ă���^�C���́A�Ȃ�";
			} else {
				// �������Ȃ�
			}
			User2Title = User2Title.replaceFirst(CommonTitleNames[1], CommonTitleNames[3] + CommonTitleNames[2] + title + CommonTitleNames[1]);
		}
	}

	public static void HowManyPar() {
		String title = "";
		int count = 0;
		if (Number == USER1_DECISION) {
			for (int i = 0; i < SELECT_DIGITAL_SIZE - 1; i++) {
				if (UserDigitalCardArray[1][i][0] == UserDigitalCardArray[1][i + 1][0]) {
					count++;
					i++;
				} else {
					// �������Ȃ�
				}
			}
			title = "���������^�C���̃y�A��" + count + "�g����";
			User1Title = User1Title.replaceFirst(CommonTitleNames[1], CommonTitleNames[3] + CommonTitleNames[2] + title + CommonTitleNames[1]);
		} else {
			for (int i = 0; i < SELECT_DIGITAL_SIZE - 1; i++) {
				if (UserDigitalCardArray[0][i][0] == UserDigitalCardArray[0][i + 1][0]) {
					count++;
					i++;
				} else {
					// �������Ȃ�
				}
			}
			title = "���������^�C���̃y�A��" + count + "�g����";
			User2Title = User2Title.replaceFirst(CommonTitleNames[1], CommonTitleNames[3] + CommonTitleNames[2] + title + CommonTitleNames[1]);
		}
	}

	public static void HowManyOdd(int odd) {
		String title = "";
		int count = 0;
		if (Number == USER1_DECISION) {
			for (int i = 0; i < SELECT_DIGITAL_SIZE; i++) {
				if (UserDigitalCardArray[1][i][0] % 2 == odd) {
					count++;
				} else {
					// �������Ȃ�
				}
			}
			if (odd == ODD) {
				title = "��́A" + count + "��";
			} else {
				title = "�����́A" + count + "��";
			}
			User1Title = User1Title.replaceFirst(CommonTitleNames[1], CommonTitleNames[3] + CommonTitleNames[2] + title + CommonTitleNames[1]);
		} else {
			for (int i = 0; i < SELECT_DIGITAL_SIZE; i++) {
				if (UserDigitalCardArray[0][i][0] % 2 == odd) {
					count++;
				} else {
					// �������Ȃ�
				}
			}
			if (odd == ODD) {
				title = "��́A" + count + "��";
			} else {
				title = "�����́A" + count + "��";
			}
			User2Title = User2Title.replaceFirst(CommonTitleNames[1], CommonTitleNames[3] + CommonTitleNames[2] + title + CommonTitleNames[1]);
		}
	}

	public static void CenterCompar() {
		String title1 = "";
		String title2 = "";
		if (UserDigitalCardArray[0][CENTER][0] >= 5) {
			title2 = "�����̐����^�C���́A5�ȏ�";
		} else {
			title2 = "�����̐����^�C���́A4�ȉ�";
		}
		if (UserDigitalCardArray[1][CENTER][0] >= 5) {
			title1 = "�����̐����^�C���́A5�ȏ�";
		} else {
			title1 = "�����̐����^�C���́A4�ȉ�";
		}
		User1Title = User1Title.replaceFirst(CommonTitleNames[1], CommonTitleNames[3] + CommonTitleNames[2] + title1 + CommonTitleNames[1]);
		User2Title = User2Title.replaceFirst(CommonTitleNames[1], CommonTitleNames[3] + CommonTitleNames[2] + title2 + CommonTitleNames[1]);
	}

	public static void MaxGap() {
		String title1 = "";
		String title2 = "";
		int sum1 = 0;
		int sum2 = 0;

		sum1 = UserDigitalCardArray[0][4][0] - UserDigitalCardArray[0][0][0];
		sum2 += UserDigitalCardArray[1][4][0] - UserDigitalCardArray[1][0][0];

		title2 = "�����^�C���̍ő�̐�����ŏ��̐�������������" + sum1;
		title1 = "�����^�C���̍ő�̐�����ŏ��̐�������������" + sum2;
		User1Title = User1Title.replaceFirst(CommonTitleNames[1], CommonTitleNames[3] + CommonTitleNames[2] + title1 + CommonTitleNames[1]);
		User2Title = User2Title.replaceFirst(CommonTitleNames[1], CommonTitleNames[3] + CommonTitleNames[2] + title2 + CommonTitleNames[1]);
	}

	public static void Sum5Digital() {
		String title1 = "";
		String title2 = "";
		int sum1 = 0;
		int sum2 = 0;
		for (int i = 0; i < SELECT_DIGITAL_SIZE; i++) {
			sum1 += UserDigitalCardArray[0][i][0];
			sum2 += UserDigitalCardArray[1][i][0];
		}
		title2 = "5���̃^�C�����ׂĂ̍��v���́A" + sum1;
		title1 = "5���̃^�C�����ׂĂ̍��v���́A" + sum2;
		User1Title = User1Title.replaceFirst(CommonTitleNames[1], CommonTitleNames[3] + CommonTitleNames[2] + title1 + CommonTitleNames[1]);
		User2Title = User2Title.replaceFirst(CommonTitleNames[1], CommonTitleNames[3] + CommonTitleNames[2] + title2 + CommonTitleNames[1]);
	}

	public static void Sum3Digital(int index) {
		String title = "";
		int sum = 0;
		if (Number == USER1_DECISION) {
			for (int i = index; i < index + 3; i++) {
				sum += UserDigitalCardArray[1][i][0];
			}
			if (index == SMALL) {
				title = "�������ق�����3���̍��v���́A" + sum;
			} else if (index == CENTER) {
				title = "������3���̍��v���́A" + sum;
			} else {
				title = "�傫���ق�����3���̍��v���́A" + sum;
			}
			User1Title = User1Title.replaceFirst(CommonTitleNames[1], CommonTitleNames[3] + CommonTitleNames[2] + title + CommonTitleNames[1]);

		} else {
			for (int i = index; i < index + 3; i++) {
				sum += UserDigitalCardArray[0][i][0];
			}
			if (index == SMALL) {
				title = "�������ق�����3���̍��v���́A" + sum;
			} else if (index == CENTER) {
				title = "������3���̍��v���́A" + sum;
			} else {
				title = "�傫���ق�����3���̍��v���́A" + sum;
			}
			User2Title = User2Title.replaceFirst(CommonTitleNames[1], CommonTitleNames[3] + CommonTitleNames[2] + title + CommonTitleNames[1]);
		}
	}

	public static void SumColor(int color) {
		String title = "";
		int sum = 0;
		if (Number == USER1_DECISION) {
			for (int i = 0; i < SELECT_DIGITAL_SIZE; i++) {
				if (UserDigitalCardArray[1][i][1] == color) {
					sum += UserDigitalCardArray[1][i][0];
				} else {
					// �������Ȃ�
				}
			}
			if (color == RED) {
				title = "�Ԃ̐��̍��v���́A" + sum;
			} else {
				title = "�̐��̍��v���́A" + sum;
			}
			User1Title = User1Title.replaceFirst(CommonTitleNames[1], CommonTitleNames[3] + CommonTitleNames[2] + title + CommonTitleNames[1]);

		} else {
			for (int i = 0; i < SELECT_DIGITAL_SIZE; i++) {
				if (UserDigitalCardArray[0][i][1] == color) {
					sum += UserDigitalCardArray[0][i][0];
				} else {
					// �������Ȃ�
				}
			}
			if (color == RED) {
				title = "�Ԃ̐��̍��v���́A" + sum;
			} else {
				title = "�̐��̍��v���́A" + sum;
			}
			User2Title = User2Title.replaceFirst(CommonTitleNames[1], CommonTitleNames[3] + CommonTitleNames[2] + title + CommonTitleNames[1]);
		}
	}

	public static void HowManyColor(int color) {
		String title = "";
		int count = 0;
		if (Number == USER1_DECISION) {
			for (int i = 0; i < SELECT_DIGITAL_SIZE; i++) {
				if (UserDigitalCardArray[1][i][1] == color) {
					count++;
				} else {
					// �������Ȃ�
				}
			}
			if (color == RED) {
				title = "�Ԃ̐����^�C���́A" + count + "��";
			} else {
				title = "�̐����^�C���́A" + count + "��";
			}
			User1Title = User1Title.replaceFirst(CommonTitleNames[1], CommonTitleNames[3] + CommonTitleNames[2] + title + CommonTitleNames[1]);

		} else {
			for (int i = 0; i < SELECT_DIGITAL_SIZE; i++) {
				if (UserDigitalCardArray[0][i][1] == color) {
					count++;
				} else {
					// �������Ȃ�
				}
			}
			if (color == RED) {
				title = "�Ԃ̐����^�C���́A" + count + "��";
			} else {
				title = "�̐����^�C���́A" + count + "��";
			}
			User2Title = User2Title.replaceFirst(CommonTitleNames[1], CommonTitleNames[3] + CommonTitleNames[2] + title + CommonTitleNames[1]);
		}
	}

	public static void WhereDigital(int digital) {
		String title = "";
		if (Number == USER1_DECISION) {
			for (int i = 0; i < SELECT_DIGITAL_SIZE; i++) {
				if (UserDigitalCardArray[1][i][0] < digital) {
					continue;
				} else if (UserDigitalCardArray[1][i][0] > digital) {
					break;
				} else {
					if (title == "") {
						title = digital + "�́A������" + (i + 1) + "�Ԗ�";
					} else {
						title += "�ƍ�����" + (i + 1) + "�Ԗ�";
					}
				}
			}
			if (title == "") {
				title = digital + "�́A���݂��܂���B";
			} else {
				// �������Ȃ�
			}
			User1Title = User1Title.replaceFirst(CommonTitleNames[1], CommonTitleNames[3] + CommonTitleNames[2] + title + CommonTitleNames[1]);
		} else {
			for (int i = 0; i < SELECT_DIGITAL_SIZE; i++) {
				if (UserDigitalCardArray[0][i][0] < digital) {
					continue;
				} else if (UserDigitalCardArray[0][i][0] > digital) {
					break;
				} else {
					if (title == "") {
						title = digital + "�́A������" + (i + 1) + "�Ԗ�";
					} else {
						title += "�ƍ�����" + (i + 1) + "�Ԗ�";
					}
				}
			}
			if (title == "") {
				title = digital + "�́A���݂��܂���";
			} else {
				// �������Ȃ�
			}
			User2Title = User2Title.replaceFirst(CommonTitleNames[1], CommonTitleNames[3] + CommonTitleNames[2] + title + CommonTitleNames[1]);
		}
	}
}
