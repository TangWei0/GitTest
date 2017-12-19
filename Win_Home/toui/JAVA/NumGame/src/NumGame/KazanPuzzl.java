package NumGame;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;

public class KazanPuzzl {
	public static String ReadFile = "Input/Kazan2.csv";
	public static int ObjectCount = 0;
	
	public static int Total = 26;
	public static int Num = 4;

	public static ArrayList<ArrayList<Integer>> AnalysisList = new ArrayList<ArrayList<Integer>>();
	public static ArrayList<ArrayList<Integer>> ConditionList = new ArrayList<ArrayList<Integer>>();
	public static ArrayList<ArrayList<Integer>> ResultList = new ArrayList<ArrayList<Integer>>();

	public static ArrayList<Integer> TmpItem = new ArrayList<Integer>();
	public static ArrayList<Integer> Def = new ArrayList<Integer>();

	public static ArrayList<ArrayList<Kazan>> MainBody = new ArrayList<ArrayList<Kazan>>();
	public static ArrayList<Kazan> MainBodyItem = new ArrayList<Kazan>();

	static Data Data = new Data();

	public static Kazan setConstructor(int UseSwitch, int HorizontalTotal,
			int LongitudinalTotal, int HorizontalNum, int LongitudinalNum,
			ArrayList<Integer> PossibleList, ArrayList<Integer> HorizontalList,
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

		Def.add(8);
		SubCut(Total, Num/*, Def*/);
		System.out.println(AnalysisList);
		/*
		DefalutList();
		read();
		statistics();
		System.out.println(ObjectCount);

		for (int i = 0; i < ResultList.size(); i++) {
			int x = ResultList.get(i).get(0);
			int y = ResultList.get(i).get(1);
			System.out.println(MainBody.get(x).get(y).PossibleList);

		}
		*/
	}

	public static void read() {

	public static void statistics() {
		for (int i = 0; i < ConditionList.size(); i++) {
			int X = ConditionList.get(i).get(0);
			int Y = ConditionList.get(i).get(1);
			ArrayList<Integer> ExistList = new ArrayList<Integer>();
			if (MainBody.get(X).get(Y).PossibleList.indexOf(1) == -1) {
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

				int Total = MainBody.get(X).get(Y).HorizontalTotal;
				int Num = MainBody.get(X).get(Y).HorizontalNum;
				
				if (MainBody.get(X).get(Y).HorizontalList.size() != 0)
				{
					for (int index : MainBody.get(X).get(Y).HorizontalList)
					{
						int value = MainBody.get(X).get(Y + index).PossibleList.get(0);
						ExistList.add(value);
						Total -= value;
						Num--;
					}
				}
				
				//SubCut(Total, Num, ExistList);
				TmpItem = Data.DataUnion(AnalysisList);
				for (int k = 1; k <= MainBody.get(X).get(Y).HorizontalNum; k++) {
					if (MainBody.get(X).get(Y + k).LongitudinalList.size() != 0) {
						MainBody.get(X).get(Y + k).PossibleList = Data
								.DataIntersection(
										TmpItem,
										MainBody.get(X).get(Y + k).LongitudinalList);
						if (MainBody.get(X).get(Y + k).PossibleList.size() == 1) {
							MainBody.get(X).get(Y).HorizontalList.add(k);
						}
						MainBody.get(X).get(Y + k).HorizontalList = MainBody
								.get(X).get(Y + k).PossibleList;
						MainBody.get(X).get(Y + k).LongitudinalList = MainBody
								.get(X).get(Y + k).PossibleList;
					} else {
						MainBody.get(X).get(Y + k).HorizontalList = TmpItem;
					}
				}
			}

			if (MainBody.get(X).get(Y).PossibleList.indexOf(2) == -1) {
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

				//SubCut(MainBody.get(X).get(Y).LongitudinalTotal, MainBody
						//.get(X).get(Y).LongitudinalNum,ExistList);
				TmpItem = Data.DataUnion(AnalysisList);
				for (int k = 1; k <= MainBody.get(X).get(Y).LongitudinalNum; k++) {
					if (MainBody.get(X + k).get(Y).HorizontalList.size() != 0) {
						MainBody.get(X + k).get(Y).PossibleList = Data
								.DataIntersection(TmpItem, MainBody.get(X + k)
										.get(Y).HorizontalList);
						if (MainBody.get(X + k).get(Y).PossibleList.size() == 1) {
							MainBody.get(X).get(Y).LongitudinalList.add(k);
						}
						MainBody.get(X + k).get(Y).HorizontalList = MainBody
								.get(X + k).get(Y).PossibleList;
						MainBody.get(X + k).get(Y).LongitudinalList = MainBody
								.get(X + k).get(Y).PossibleList;
					} else {
						MainBody.get(X + k).get(Y).LongitudinalList = TmpItem;
					}
					MainBody.get(X + k).get(Y).LongitudinalList = TmpItem;
				}
			}
		}

	}

	public static void DefalutList() {

	public static void SubCut(int total, int num/*, ArrayList<Integer> ExistList*/) {
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
			/*if (ExistList.indexOf(current) != -1)
			{
				current++;
				total--;
				TmpItem.set(TmpItem.size() - 1, current);
				continue;
			}*/
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
				SubCut(total, num/*, ExistList*/);
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
					TmpItem = new ArrayList<Integer>(
							AnalysisList.get(AnalysisList.size() - 1));
					TmpItem.remove(TmpItem.size() - 1);
					current++;
					total--;
					TmpItem.set(TmpItem.size() - 1, current);
					continue;
				}
			}
			
		}
		if (current == 10)
		{
			TmpItem.remove(TmpItem.size()-1);
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
