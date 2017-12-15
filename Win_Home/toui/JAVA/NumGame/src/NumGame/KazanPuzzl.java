package NumGame;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;

public class KazanPuzzl {
	public static String ReadFile = "Input/Kazan2.csv";
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
		double a = 17.15;
		int b = (int) a;
		double e = a-b;
		int c = (int) (a*100);
		int d = c%100;
		
		// TODO Auto-generated method stub
		/*
		DefalutList();
		read();
		statistics();
		for (int i = 0; i < ConditionList.size(); i++) {
			System.out.println(
					MainBody.get(ConditionList.get(i).get(0)).get(ConditionList.get(i).get(1)).HorizontalTotal);
			System.out
					.println(MainBody.get(ConditionList.get(i).get(0)).get(ConditionList.get(i).get(1)).HorizontalNum);
			System.out.println(
					MainBody.get(ConditionList.get(i).get(0)).get(ConditionList.get(i).get(1)).LongitudinalTotal);
			System.out.println(
					MainBody.get(ConditionList.get(i).get(0)).get(ConditionList.get(i).get(1)).LongitudinalNum);

			System.out.println("--------------------------------");
		}

		SubCut(Total, Num);
		System.out.println(AnalysisList);
		*/
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
						continue;
					}
					Data.DataConversion(PointData[i]);
					TmpItem = new ArrayList<Integer>();
					MainBodyItem.add(setConstructor(0, Data.HorizontalTotal, Data.LongitudinalTotal, 0, 0, TmpItem,
							TmpItem, TmpItem));
				}
				MainBody.add(MainBodyItem);
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
		for (int i = 0; i < MainBody.size(); i++) {
			for (int j = 0; j < MainBody.get(i).size(); j++) {
				if (MainBody.get(i).get(j).UseSwitch == -1) {
					continue;
				}
				if (MainBody.get(i).get(j).UseSwitch == 0) {
					TmpItem = new ArrayList<Integer>();
					TmpItem.add(i);
					TmpItem.add(j);
					ConditionList.add(TmpItem);
					if (MainBody.get(i).get(j).HorizontalTotal != 0) {
						int count = 0;
						for (int k = j + 1; k < MainBody.get(i).size(); k++)
						{
							if (MainBody.get(i).get(k).UseSwitch != 1)
							{
								break;
							}
							count++;
						}

						MainBody.get(i).get(j).HorizontalNum = count;
					}
					if (MainBody.get(i).get(j).LongitudinalTotal != 0) {
						int count = 0;
						for (int k = i + 1; k < MainBody.size(); k++)
						{
							if (MainBody.get(k).get(j).UseSwitch != 1)
							{
								break;
							}
							count++;
						}

						MainBody.get(i).get(j).LongitudinalNum = count;
					}
				}
				if (MainBody.get(i).get(j).UseSwitch == 1) {
					TmpItem = new ArrayList<Integer>();
					TmpItem.add(i);
					TmpItem.add(j);
					ResultList.add(TmpItem);
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
					current = 10;
					total += TmpItem.get(TmpItem.size() - 1);
					TmpItem.remove(TmpItem.size() - 1);
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
