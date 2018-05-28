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
		QuestionTitle = CommonTitleNames[0] + QuestionNames[QusetionIndex] + CommonTitleNames[1];
	}
	
	
	public void tgrUserTitle(int QusetionIndex) {
		tgrQuestionTitle(QusetionIndex);
		switch (QusetionIndex)
		{
		case 0:
			



			break;
		}
	}
}
