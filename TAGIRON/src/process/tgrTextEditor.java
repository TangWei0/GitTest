package Process;

import static Declaration.MathConstants.*;
import static Declaration.Variable.*;

import javax.swing.JOptionPane;

public class tgrTextEditor {

	// BetInfo表示TiTle
	public void tgrBetTitle() {
		switch (ClickCount) {
		case 0:
			BetTitle = CommonTitleNames[0] + CommonTitleNames[2] + BetTitleNames[0] + input0 + BetTitleNames[5] + CommonTitleNames[3]
					+ CommonTitleNames[2] + BetTitleNames[1] + CommonTitleNames[4] + BetTitleNames[3] + CommonTitleNames[5] + CommonTitleNames[1];
			break;
		case 1:
		case 3:
			BetTitle = BetTitle.replaceFirst(BetTitleNames[3], BetTitleNames[4]);
			break;
		case 2:
			BetTitle = BetTitle.replaceFirst(CommonTitleNames[4] + BetTitleNames[4] + CommonTitleNames[5] + CommonTitleNames[1],
					input1 + BetTitleNames[5] + CommonTitleNames[3] + CommonTitleNames[2] + BetTitleNames[2] + CommonTitleNames[4] + BetTitleNames[3]
							+ CommonTitleNames[5] + CommonTitleNames[1]);
			break;
		case 4:
			BetTitle = BetTitle.replaceFirst(CommonTitleNames[4] + BetTitleNames[4] + CommonTitleNames[5] + CommonTitleNames[1],
					input2 + BetTitleNames[5] + CommonTitleNames[3] + CommonTitleNames[2] + CommonTitleNames[4] + checkResult + CommonTitleNames[5]
							+ CommonTitleNames[3] + CommonTitleNames[2] + BetTitleNames[8] + CommonTitleNames[1]);
			break;
		default:
			ErrorCode = CLICK_FAULT;
			JOptionPane.showMessageDialog(null, Error[ErrorCode]);
			break;
		}
	}

	// 問題カード表示Title
	public void tgrQuestionTitle(int QusetionIndex) {
		QuestionTitle = "";
		QuestionTitle = CommonTitleNames[0] + QuestionNames[UsingQuestionCardArray[QusetionIndex]] + CommonTitleNames[1];
	}

	public void tgrUserTitle(int QusetionIndex) {
		tgrQuestionTitle(QusetionIndex);
		switch (UsingQuestionCardArray[QusetionIndex]) {
		case 0:
			if (SelectQuestion == 0) {
				tgrAnswerQuestion.WhereDigital(8);
			} else {
				tgrAnswerQuestion.WhereDigital(9);
			}
			break;
		case 1:
			if (SelectQuestion == 0) {
				tgrAnswerQuestion.WhereDigital(1);
			} else {
				tgrAnswerQuestion.WhereDigital(2);
			}
			break;
		case 2:
			tgrAnswerQuestion.WhereConsistentDigital();
			break;
		case 3:	
			tgrAnswerQuestion.HowManyColor(BLUE);
			break;
		case 4:	
			tgrAnswerQuestion.HowManyOdd(EVEN);
			break;
		case 5:	
			tgrAnswerQuestion.HowManyColor(RED);
			break;
		case 6:	
			tgrAnswerQuestion.SumColor(RED);
			break;
		case 7:	
			tgrAnswerQuestion.SumColor(BLUE);
			break;
		case 8:	
			tgrAnswerQuestion.Sum5Digital();
			break;
		case 9:
			if (SelectQuestion == 0) {
				tgrAnswerQuestion.WhereDigital(3);
			} else {
				tgrAnswerQuestion.WhereDigital(4);
			}
			break;
		case 10:
			tgrAnswerQuestion.HowManyPar();
			break;
		case 11:	
			tgrAnswerQuestion.CenterCompar();
			break;	
		case 12:	
			tgrAnswerQuestion.HowManyOdd(ODD);
			break;
		case 13:
			tgrAnswerQuestion.WhereDigital(0);
			break;
		case 14:	
			tgrAnswerQuestion.MaxGap();
			break;	
		case 15:
			tgrAnswerQuestion.WhereConsistentColor();
			break;
		case 16:
			tgrAnswerQuestion.Sum3Digital(SMALL);
			break;
		case 17:
			if (SelectQuestion == 0) {
				tgrAnswerQuestion.WhereDigital(6);
			} else {
				tgrAnswerQuestion.WhereDigital(7);
			}
			break;
		case 18:
			tgrAnswerQuestion.Sum3Digital(CENTER);
			break;
		case 19:
			tgrAnswerQuestion.WhereDigital(5);
			break;
		case 20:
			tgrAnswerQuestion.Sum3Digital(BIG);
			break;
		}
	}
}
