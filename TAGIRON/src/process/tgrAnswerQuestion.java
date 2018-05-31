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
								title = "連続してとなり合っている色は、左から" + startIndex + "番目から" + endIndex + "番目まで";
							} else {
								title += "と左から" + startIndex + "番目から" + endIndex + "番目まで";
							}
						} else {
							// 何もしない
						}
					} else {
						if (!recodeSwitch) {
							recodeSwitch = true;
							startIndex = i + 1;
						} else {
							// 何もしない
						}
					}
				} else {
					if (recodeSwitch) {
						recodeSwitch = false;
						endIndex = i + 1;
						if (title == "") {
							title = "連続してとなり合っている色は、左から" + startIndex + "番目から" + endIndex + "番目まで";
						} else {
							title += "と左から" + startIndex + "番目から" + endIndex + "番目まで";
						}
					} else {
						// 何もしない
					}
				}
			}
			if (title == "") {
				title = "連続してとなり合っている色は、なし";
			} else {
				// 何もしない
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
								title = "連続してとなり合っている色は、左から" + startIndex + "番目から" + endIndex + "番目まで";
							} else {
								title += "と左から" + startIndex + "番目から" + endIndex + "番目まで";
							}
						} else {
							// 何もしない
						}
					} else {
						if (!recodeSwitch) {
							recodeSwitch = true;
							startIndex = i + 1;
						} else {
							// 何もしない
						}
					}
				} else {
					if (recodeSwitch) {
						recodeSwitch = false;
						endIndex = i + 1;
						if (title == "") {
							title = "連続してとなり合っている色は、左から" + startIndex + "番目から" + endIndex + "番目まで";
						} else {
							title += "と左から" + startIndex + "番目から" + endIndex + "番目まで";
						}
					} else {
						// 何もしない
					}
				}
			}
			if (title == "") {
				title = "連続してとなり合っている色は、なし";
			} else {
				// 何もしない
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
								title = "連番になっているタイルは、左から" + startIndex + "番目から" + endIndex + "番目まで";
							} else {
								title += "と左から" + startIndex + "番目から" + endIndex + "番目まで";
							}
						} else {
							// 何もしない
						}
					} else {
						if (!recodeSwitch) {
							recodeSwitch = true;
							startIndex = i + 1;
						} else {
							// 何もしない
						}
					}
				} else {
					if (recodeSwitch) {
						recodeSwitch = false;
						endIndex = i + 1;
						if (title == "") {
							title = "連番になっているタイルは、左から" + startIndex + "番目から" + endIndex + "番目まで";
						} else {
							title += "と左から" + startIndex + "番目から" + endIndex + "番目まで";
						}
					} else {
						// 何もしない
					}
				}
			}
			if (title == "") {
				title = "連番になっているタイルは、なし";
			} else {
				// 何もしない
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
								title = "連番になっているタイルは、左から" + startIndex + "番目から" + endIndex + "番目まで";
							} else {
								title += "と左から" + startIndex + "番目から" + endIndex + "番目まで";
							}
						} else {
							// 何もしない
						}
					} else {
						if (!recodeSwitch) {
							recodeSwitch = true;
							startIndex = i + 1;
						} else {
							// 何もしない
						}
					}
				} else {
					if (recodeSwitch) {
						recodeSwitch = false;
						endIndex = i + 1;
						if (title == "") {
							title = "連番になっているタイルは、左から" + startIndex + "番目から" + endIndex + "番目まで";
						} else {
							title += "と左から" + startIndex + "番目から" + endIndex + "番目まで";
						}
					} else {
						// 何もしない
					}
				}
			}
			if (title == "") {
				title = "連番になっているタイルは、なし";
			} else {
				// 何もしない
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
					// 何もしない
				}
			}
			title = "同じ数字タイルのペアは" + count + "組ある";
			User1Title = User1Title.replaceFirst(CommonTitleNames[1], CommonTitleNames[3] + CommonTitleNames[2] + title + CommonTitleNames[1]);
		} else {
			for (int i = 0; i < SELECT_DIGITAL_SIZE - 1; i++) {
				if (UserDigitalCardArray[0][i][0] == UserDigitalCardArray[0][i + 1][0]) {
					count++;
					i++;
				} else {
					// 何もしない
				}
			}
			title = "同じ数字タイルのペアは" + count + "組ある";
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
					// 何もしない
				}
			}
			if (odd == ODD) {
				title = "奇数は、" + count + "枚";
			} else {
				title = "偶数は、" + count + "枚";
			}
			User1Title = User1Title.replaceFirst(CommonTitleNames[1], CommonTitleNames[3] + CommonTitleNames[2] + title + CommonTitleNames[1]);
		} else {
			for (int i = 0; i < SELECT_DIGITAL_SIZE; i++) {
				if (UserDigitalCardArray[0][i][0] % 2 == odd) {
					count++;
				} else {
					// 何もしない
				}
			}
			if (odd == ODD) {
				title = "奇数は、" + count + "枚";
			} else {
				title = "偶数は、" + count + "枚";
			}
			User2Title = User2Title.replaceFirst(CommonTitleNames[1], CommonTitleNames[3] + CommonTitleNames[2] + title + CommonTitleNames[1]);
		}
	}

	public static void CenterCompar() {
		String title1 = "";
		String title2 = "";
		if (UserDigitalCardArray[0][CENTER][0] >= 5) {
			title2 = "中央の数字タイルは、5以上";
		} else {
			title2 = "中央の数字タイルは、4以下";
		}
		if (UserDigitalCardArray[1][CENTER][0] >= 5) {
			title1 = "中央の数字タイルは、5以上";
		} else {
			title1 = "中央の数字タイルは、4以下";
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

		title2 = "数字タイルの最大の数から最小の数を引いた数は" + sum1;
		title1 = "数字タイルの最大の数から最小の数を引いた数は" + sum2;
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
		title2 = "5枚のタイルすべての合計数は、" + sum1;
		title1 = "5枚のタイルすべての合計数は、" + sum2;
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
				title = "小さいほうから3枚の合計数は、" + sum;
			} else if (index == CENTER) {
				title = "中央の3枚の合計数は、" + sum;
			} else {
				title = "大きいほうから3枚の合計数は、" + sum;
			}
			User1Title = User1Title.replaceFirst(CommonTitleNames[1], CommonTitleNames[3] + CommonTitleNames[2] + title + CommonTitleNames[1]);

		} else {
			for (int i = index; i < index + 3; i++) {
				sum += UserDigitalCardArray[0][i][0];
			}
			if (index == SMALL) {
				title = "小さいほうから3枚の合計数は、" + sum;
			} else if (index == CENTER) {
				title = "中央の3枚の合計数は、" + sum;
			} else {
				title = "大きいほうから3枚の合計数は、" + sum;
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
					// 何もしない
				}
			}
			if (color == RED) {
				title = "赤の数の合計数は、" + sum;
			} else {
				title = "青の数の合計数は、" + sum;
			}
			User1Title = User1Title.replaceFirst(CommonTitleNames[1], CommonTitleNames[3] + CommonTitleNames[2] + title + CommonTitleNames[1]);

		} else {
			for (int i = 0; i < SELECT_DIGITAL_SIZE; i++) {
				if (UserDigitalCardArray[0][i][1] == color) {
					sum += UserDigitalCardArray[0][i][0];
				} else {
					// 何もしない
				}
			}
			if (color == RED) {
				title = "赤の数の合計数は、" + sum;
			} else {
				title = "青の数の合計数は、" + sum;
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
					// 何もしない
				}
			}
			if (color == RED) {
				title = "赤の数字タイルは、" + count + "枚";
			} else {
				title = "青の数字タイルは、" + count + "枚";
			}
			User1Title = User1Title.replaceFirst(CommonTitleNames[1], CommonTitleNames[3] + CommonTitleNames[2] + title + CommonTitleNames[1]);

		} else {
			for (int i = 0; i < SELECT_DIGITAL_SIZE; i++) {
				if (UserDigitalCardArray[0][i][1] == color) {
					count++;
				} else {
					// 何もしない
				}
			}
			if (color == RED) {
				title = "赤の数字タイルは、" + count + "枚";
			} else {
				title = "青の数字タイルは、" + count + "枚";
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
						title = digital + "は、左から" + (i + 1) + "番目";
					} else {
						title += "と左から" + (i + 1) + "番目";
					}
				}
			}
			if (title == "") {
				title = digital + "は、存在しません。";
			} else {
				// 何もしない
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
						title = digital + "は、左から" + (i + 1) + "番目";
					} else {
						title += "と左から" + (i + 1) + "番目";
					}
				}
			}
			if (title == "") {
				title = digital + "は、存在しません";
			} else {
				// 何もしない
			}
			User2Title = User2Title.replaceFirst(CommonTitleNames[1], CommonTitleNames[3] + CommonTitleNames[2] + title + CommonTitleNames[1]);
		}
	}
}
