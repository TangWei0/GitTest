package NumGame;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Collections;

public class KazanPuzzl {
	public static String ReadFile = "Input/Kazan2.csv";
	public static int Total = 26;
	public static int Num = 4;
	public static int ObjectCount = 0;

	public static ArrayList<ArrayList<Integer>> AnalysisList = new ArrayList<ArrayList<Integer>>();
	public static ArrayList<ArrayList<Integer>> ConditionList = new ArrayList<ArrayList<Integer>>();
	public static ArrayList<ArrayList<Integer>> ResultList = new ArrayList<ArrayList<Integer>>();

	public static ArrayList<Integer> TmpItem = new ArrayList<Integer>();
	public static ArrayList<Integer> Def = new ArrayList<Integer>();

	public static ArrayList<ArrayList<Kazan>> MainBody = new ArrayList<ArrayList<Kazan>>();
	public static ArrayList<Kazan> MainBodyItem = new ArrayList<Kazan>();

	static Data Data = new Data();

	public static Kazan setConstructor(int UseSwitch, int HorizontalTotal, int LongitudinalTotal, int HorizontalNum,
			int LongitudinalNum, ArrayList<Integer> PossibleList, ArrayList<Integer> HorizontalList,
			ArrayList<Integer> LongitudinalList) {
		Kazan Kazan = new Kazan();
		Kazan.UseSwitch = UseSwitch;
		Kazan.HorizontalTotal = HorizontalTotal;
		Kazan.LongitudinalTotal = LongitudinalTotal;
		Kazan.HorizontalNum = HorizontalNum;
		Kazan.LongitudinalNum = LongitudinalNum;
		Kazan.PossibleList = PossibleList;
		Kazan.HorizontalList = HorizontalList;
		Kazan.LongitudinalList = LongitudinalList;
		return Kazan;
	}

	public static void main(String[] args) {
		// TODO Auto-generated method stub

		DefalutList();
		read();
		statistics();
		System.out.println(ObjectCount);

		for (int i = 0; i < ResultList.size(); i++) {
			int x = ResultList.get(i).get(0);
			int y = ResultList.get(i).get(1);
			System.out.println(MainBody.get(x).get(y).PossibleList);

		}

	}

	public static void read() {
		File ReadCSV = new File(ReadFile);
		BufferedReader br = null;
		try {
			br = new BufferedReader(new FileReader(ReadCSV));
		} catch (FileNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		int LineCount = 0;
		String PointLine;
		try {
			while ((PointLine = br.readLine()) != null) {
				String[] PointData = PointLine.split(",", 0);
				MainBodyItem = new ArrayList<Kazan>();
				for (int i = 0; i < PointData.length; i++) {
					if (PointData[i].equals("-")) {
						TmpItem = new ArrayList<Integer>();
						MainBodyItem.add(setConstructor(-1, 0, 0, 0, 0, TmpItem, TmpItem, TmpItem));
						continue;
					}
					if (PointData[i].equals("0")) {
						MainBodyItem.add(setConstructor(1, 0, 0, 0, 0, Def, Def, Def));
						TmpItem = new ArrayList<Integer>();
						TmpItem.add(LineCount);
						TmpItem.add(i);
						ResultList.add(TmpItem);
						continue;
					}
					TmpItem = new ArrayList<Integer>();
					int Horizontal = Integer.parseInt(PointData[i].substring(2, 4));
					int Longitudinal = Integer.parseInt(PointData[i].substring(0, 2));
					if (Horizontal != 0) {
						ObjectCount++;
					}
					if (Longitudinal != 0) {
						ObjectCount++;
					}
					MainBodyItem.add(setConstructor(0, Horizontal, Longitudinal, 0, 0, TmpItem, TmpItem, TmpItem));
					TmpItem = new ArrayList<Integer>();
					TmpItem.add(LineCount);
					TmpItem.add(i);
					ConditionList.add(TmpItem);
				}
				MainBody.add(MainBodyItem);
				LineCount++;
			}
		} catch (NumberFormatException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

	public static void statistics() {
		for (int i = 0; i < ConditionList.size(); i++) {
			int X = ConditionList.get(i).get(0);
			int Y = ConditionList.get(i).get(1);
			if (MainBody.get(X).get(Y).HorizontalTotal != 0) {
				if (MainBody.get(X).get(Y).HorizontalNum == 0) {
					for (int k = Y + 1; k < MainBody.get(X).size(); k++) {
						if (MainBody.get(X).get(k).UseSwitch != 1) {
							break;
						}
						MainBody.get(X).get(Y).HorizontalNum++;
					}
				}

				// SubCut函数运行前必须清空下面两个List
				AnalysisList = new ArrayList<ArrayList<Integer>>();
				TmpItem = new ArrayList<Integer>();

				SubCut(MainBody.get(X).get(Y).HorizontalTotal, MainBody.get(X).get(Y).HorizontalNum);
				TmpItem = Data.DataUnion(AnalysisList);
				for (int k = 1; k <= MainBody.get(X).get(Y).HorizontalNum; k++) {
					if (MainBody.get(X).get(Y + k).LongitudinalList.size() != 0) {
						MainBody.get(X).get(Y + k).PossibleList = Data.DataIntersection(TmpItem,
								MainBody.get(X).get(Y + k).LongitudinalList);
						if (MainBody.get(X).get(Y + k).PossibleList.size() == 1) {
							MainBody.get(X).get(Y).HorizontalList.add(k);
						}
						MainBody.get(X).get(Y + k).HorizontalList = MainBody.get(X).get(Y + k).PossibleList;
						MainBody.get(X).get(Y + k).LongitudinalList = MainBody.get(X).get(Y + k).PossibleList;
					} else {
						MainBody.get(X).get(Y + k).HorizontalList = TmpItem;
					}
				}
			}

			if (MainBody.get(X).get(Y).LongitudinalTotal != 0) {
				if (MainBody.get(X).get(Y).LongitudinalNum == 0) {
					for (int k = X + 1; k < MainBody.size(); k++) {
						if (MainBody.get(k).get(Y).UseSwitch != 1) {
							break;
						}
						MainBody.get(X).get(Y).LongitudinalNum++;
					}
				}

				// SubCut函数运行前必须清空下面两个List
				AnalysisList = new ArrayList<ArrayList<Integer>>();
				TmpItem = new ArrayList<Integer>();

				SubCut(MainBody.get(X).get(Y).LongitudinalTotal, MainBody.get(X).get(Y).LongitudinalNum);
				TmpItem = Data.DataUnion(AnalysisList);
				for (int k = 1; k <= MainBody.get(X).get(Y).LongitudinalNum; k++) {
					if (MainBody.get(X + k).get(Y).HorizontalList.size() != 0) {
						MainBody.get(X + k).get(Y).PossibleList = Data.DataIntersection(TmpItem,
								MainBody.get(X + k).get(Y).HorizontalList);
						if (MainBody.get(X + k).get(Y).PossibleList.size() == 1) {
							MainBody.get(X).get(Y).LongitudinalList.add(k);
						}
						MainBody.get(X + k).get(Y).HorizontalList = MainBody.get(X + k).get(Y).PossibleList;
						MainBody.get(X + k).get(Y).LongitudinalList = MainBody.get(X + k).get(Y).PossibleList;
					} else {
						MainBody.get(X + k).get(Y).LongitudinalList = TmpItem;
					}
					MainBody.get(X + k).get(Y).LongitudinalList = TmpItem;
				}
			}
		}

	}

	public static void DefalutList() {
		for (int i = 0; i < 9; i++) {
			Def.add(i + 1);
		}
	}

	public static void SubCut(int total, int num) {
		int current;
		if (TmpItem.size() == 0) {
			current = 1;
		} else {
			current = TmpItem.get(TmpItem.size() - 1) + 1;
			if (current > 9 - num + 1) {
				return;
			}
		}
		total -= current;
		num--;
		TmpItem.add(current);
		while (current < 10) {
			if (num != 1) {
				if (total > ((2 * 9 - num + 1) * num / 2)) {
					current++;
					total--;
					TmpItem.set(TmpItem.size() - 1, current);
					continue;
				}
				if (total < ((2 * current + num + 1) * num / 2)) {
					current = 10;
					total += TmpItem.get(TmpItem.size() - 1);
					TmpItem.remove(TmpItem.size() - 1);
					continue;
				}
				SubCut(total, num);
				current++;
				total--;
				TmpItem.set(TmpItem.size() - 1, current);
				continue;
			} else {
				if (current + 1 > total || total > 9) {
					current++;
					total--;
					TmpItem.set(TmpItem.size() - 1, current);
					continue;
				} else {
					TmpItem.add(total);
					AnalysisList.add(TmpItem);
					TmpItem = new ArrayList<Integer>(AnalysisList.get(AnalysisList.size() - 1));
					TmpItem.remove(TmpItem.size() - 1);
					current++;
					total--;
					TmpItem.set(TmpItem.size() - 1, current);
					continue;
				}
			}
		}
	}

}

class Kazan {
	int UseSwitch;
	int HorizontalTotal;
	int LongitudinalTotal;
	int HorizontalNum;
	int LongitudinalNum;
	ArrayList<Integer> PossibleList;
	ArrayList<Integer> HorizontalList;
	ArrayList<Integer> LongitudinalList;
}
