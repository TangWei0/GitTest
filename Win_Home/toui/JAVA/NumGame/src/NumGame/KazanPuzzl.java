package NumGame;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;

public class KazanPuzzl {
	public static String ReadFile = "Input/Kazan2.csv";

	public static ArrayList<ArrayList<Integer>> ConditionList = new ArrayList<ArrayList<Integer>>();
	public static ArrayList<ArrayList<Integer>> ResultList = new ArrayList<ArrayList<Integer>>();
	public static ArrayList<ArrayList<Integer>> NextList = new ArrayList<ArrayList<Integer>>();

	public static ArrayList<Integer> TmpItem = new ArrayList<Integer>();
	public static ArrayList<Integer> Def = new ArrayList<Integer>();

	public static ArrayList<Integer> UseSwitchItem = new ArrayList<Integer>();
	public static ArrayList<Integer> HorizontalTotalItem = new ArrayList<Integer>();
	public static ArrayList<Integer> LongitudinalTotalItem = new ArrayList<Integer>();
	public static ArrayList<Integer> HorizontalNumItem = new ArrayList<Integer>();
	public static ArrayList<Integer> LongitudinalNumItem = new ArrayList<Integer>();

	public static ArrayList<ArrayList<Integer>> UseSwitch = new ArrayList<ArrayList<Integer>>();
	public static ArrayList<ArrayList<Integer>> HorizontalTotal = new ArrayList<ArrayList<Integer>>();
	public static ArrayList<ArrayList<Integer>> LongitudinalTotal = new ArrayList<ArrayList<Integer>>();
	public static ArrayList<ArrayList<Integer>> HorizontalNum = new ArrayList<ArrayList<Integer>>();
	public static ArrayList<ArrayList<Integer>> LongitudinalNum = new ArrayList<ArrayList<Integer>>();

	public static ArrayList<ArrayList<Integer>> PossibleListItem = new ArrayList<ArrayList<Integer>>();
	public static ArrayList<ArrayList<Integer>> HorizontalListItem = new ArrayList<ArrayList<Integer>>();
	public static ArrayList<ArrayList<Integer>> LongitudinalListItem = new ArrayList<ArrayList<Integer>>();

	public static ArrayList<ArrayList<ArrayList<Integer>>> PossibleList = new ArrayList<ArrayList<ArrayList<Integer>>>();
	public static ArrayList<ArrayList<ArrayList<Integer>>> HorizontalList = new ArrayList<ArrayList<ArrayList<Integer>>>();
	public static ArrayList<ArrayList<ArrayList<Integer>>> LongitudinalList = new ArrayList<ArrayList<ArrayList<Integer>>>();

	public static boolean check = true;

	static Data Data = new Data();

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		DefalutList();
		read();
		statistics();
		check();
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
				for (int i = 0; i < PointData.length; i++) {
					if (PointData[i].equals("-")) {
						UseSwitchItem.add(-1);
						HorizontalTotalItem.add(0);
						LongitudinalTotalItem.add(0);
						HorizontalNumItem.add(0);
						LongitudinalNumItem.add(0);

						TmpItem = new ArrayList<Integer>();
						PossibleListItem.add(TmpItem);
						HorizontalListItem.add(TmpItem);
						LongitudinalListItem.add(TmpItem);
						continue;
					}
					if (PointData[i].equals("0")) {
						UseSwitchItem.add(1);
						HorizontalTotalItem.add(0);
						LongitudinalTotalItem.add(0);
						HorizontalNumItem.add(0);
						LongitudinalNumItem.add(0);

						PossibleListItem.add(Def);
						HorizontalListItem.add(Def);
						LongitudinalListItem.add(Def);

						TmpItem = new ArrayList<Integer>();
						TmpItem.add(LineCount);
						TmpItem.add(i);
						ResultList.add(TmpItem);
						continue;
					}

					int Hor = Integer.parseInt(PointData[i].substring(2, 4));
					int Long = Integer.parseInt(PointData[i].substring(0, 2));

					UseSwitchItem.add(0);
					HorizontalTotalItem.add(Hor);
					LongitudinalTotalItem.add(Long);
					HorizontalNumItem.add(0);
					LongitudinalNumItem.add(0);

					TmpItem = new ArrayList<Integer>();
					if (Hor == 0) {
						TmpItem.add(1);
					}
					if (Long == 0) {
						TmpItem.add(2);
					}
					PossibleListItem.add(TmpItem);

					TmpItem = new ArrayList<Integer>();
					HorizontalListItem.add(TmpItem);
					LongitudinalListItem.add(TmpItem);

					TmpItem.add(LineCount);
					TmpItem.add(i);
					ConditionList.add(TmpItem);
				}
				UseSwitch.add(UseSwitchItem);
				HorizontalTotal.add(HorizontalTotalItem);
				LongitudinalTotal.add(LongitudinalTotalItem);
				HorizontalNum.add(HorizontalNumItem);
				LongitudinalNum.add(LongitudinalNumItem);
				PossibleList.add(PossibleListItem);
				HorizontalList.add(HorizontalListItem);
				LongitudinalList.add(LongitudinalListItem);

				UseSwitchItem = new ArrayList<Integer>();
				HorizontalTotalItem = new ArrayList<Integer>();
				LongitudinalTotalItem = new ArrayList<Integer>();
				HorizontalNumItem = new ArrayList<Integer>();
				LongitudinalNumItem = new ArrayList<Integer>();
				PossibleListItem = new ArrayList<ArrayList<Integer>>();
				HorizontalListItem = new ArrayList<ArrayList<Integer>>();
				LongitudinalListItem = new ArrayList<ArrayList<Integer>>();
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
			// 横向处理
			if (PossibleList.get(X).get(Y).indexOf(1) == -1) {
				// 横向计数
				if (HorizontalNum.get(X).get(Y) == 0) {
					int HorizontalCount = 0;
					for (int k = 1; k < UseSwitch.get(X).size() - Y; k++) {
						if (UseSwitch.get(X).get(Y + k) != 1) {
							break;
						}
						HorizontalTotal.get(X).set(Y + k, X);
						HorizontalNum.get(X).set(Y + k, Y);
						HorizontalCount++;
					}
					HorizontalNum.get(X).set(Y, HorizontalCount);
				}
				int Total = HorizontalTotal.get(X).get(Y);
				int Num = HorizontalNum.get(X).get(Y);
				if (HorizontalList.get(X).get(Y).size() != 0) {
					Num -= HorizontalList.get(X).get(Y).size();
					for (int value : HorizontalList.get(X).get(Y)) {
						Total -= value;
					}
				}
				if (Num == 1) {
					if (HorizontalList.get(X).get(Y).indexOf(Total) == -1) {
						TmpItem = new ArrayList<Integer>();
						TmpItem.add(Total);
					} else {
						System.out.println("エラーが発生しました");
					}
				} else {
					TmpItem = Data.SubCutProcess(Total, Num, HorizontalList.get(X).get(Y));
				}
				for (int k = 1; k <= HorizontalNum.get(X).get(Y); k++) {
					if (PossibleList.get(X).get(Y + k).size() != 1) {
						HorizontalList.get(X).set(Y + k,
								Data.DataIntersection(TmpItem, HorizontalList.get(X).get(Y + k)));
					}
				}
			}
			// 纵向处理
			if (PossibleList.get(X).get(Y).indexOf(2) == -1) {
				// 纵向计数
				if (LongitudinalNum.get(X).get(Y) == 0) {
					int LongitudinalCount = 0;
					for (int k = 1; k < UseSwitch.size() - X; k++) {
						if (UseSwitch.get(X + k).get(Y) != 1) {
							break;
						}
						LongitudinalTotal.get(X + k).set(Y, X);
						LongitudinalNum.get(X + k).set(Y, Y);
						LongitudinalCount++;
					}
					LongitudinalNum.get(X).set(Y, LongitudinalCount);
				}
				int Total = LongitudinalTotal.get(X).get(Y);
				int Num = LongitudinalNum.get(X).get(Y);
				if (LongitudinalList.get(X).get(Y).size() != 0) {
					Num -= LongitudinalList.get(X).get(Y).size();
					for (int value : LongitudinalList.get(X).get(Y)) {
						Total -= value;
					}
				}
				if (Num == 1) {
					if (LongitudinalList.get(X).get(Y).indexOf(Total) == -1) {
						TmpItem = new ArrayList<Integer>();
						TmpItem.add(Total);
					} else {
						System.out.println("エラーが発生しました");
					}
				} else {
					TmpItem = Data.SubCutProcess(Total, Num, LongitudinalList.get(X).get(Y));
				}
				for (int k = 1; k <= LongitudinalNum.get(X).get(Y); k++) {
					if (PossibleList.get(X + k).get(Y).size() != 1) {
						LongitudinalList.get(X + k).set(Y,
								Data.DataIntersection(TmpItem, LongitudinalList.get(X + k).get(Y)));
					}
				}
			}
		}

	}

	public static void check() {
		NextList = new ArrayList<ArrayList<Integer>>();
		for (int i = 0; i < ResultList.size(); i++) {

			int X = ResultList.get(i).get(0);
			int Y = ResultList.get(i).get(1);
			PossibleList.get(X).set(Y, Data.DataIntersection(HorizontalList.get(X).get(Y), LongitudinalList.get(X).get(Y)));
			HorizontalList.get(X).set(Y, PossibleList.get(X).get(Y));
			LongitudinalList.get(X).set(Y, PossibleList.get(X).get(Y));

			if (PossibleList.get(X).get(Y).size() == 1) {
				int value = PossibleList.get(X).get(Y).get(0);
				int HorizontalX = HorizontalTotal.get(X).get(Y);
				int HorizontalY = HorizontalNum.get(X).get(Y);
				int LongitudinalX = LongitudinalTotal.get(X).get(Y);
				int LongitudinalY = LongitudinalNum.get(X).get(Y);

				TmpItem = new ArrayList<Integer>();
				TmpItem = HorizontalList.get(HorizontalX).get(HorizontalY);
				TmpItem.add(value);
				HorizontalList.get(HorizontalX).set(HorizontalY, TmpItem);
				if (HorizontalList.get(HorizontalX).get(HorizontalY).size() == HorizontalNum.get(HorizontalX).get(HorizontalY)) 
				{
					TmpItem = new ArrayList<Integer>(PossibleList.get(HorizontalX).get(HorizontalY));
					TmpItem.add(1);
					PossibleList.get(HorizontalX).set(HorizontalY, TmpItem);
				}

				TmpItem = new ArrayList<Integer>();
				TmpItem = LongitudinalList.get(LongitudinalX).get(LongitudinalY);
				TmpItem.add(value);
				LongitudinalList.get(LongitudinalX).set(LongitudinalY, TmpItem);
				if (LongitudinalList.get(LongitudinalX).get(LongitudinalY).size() == LongitudinalNum.get(LongitudinalX).get(LongitudinalY)) 
				{
					TmpItem = new ArrayList<Integer>(PossibleList.get(LongitudinalX).get(LongitudinalY));
					TmpItem.add(2);
					PossibleList.get(LongitudinalX).set(LongitudinalY, TmpItem);
				}
			} else {
				TmpItem = new ArrayList<Integer>();
				TmpItem.add(X);
				TmpItem.add(Y);
				NextList.add(TmpItem);
			}

			if (NextList.size() == ResultList.size()) {
				check = false;
			} 
			System.out.print(X + "," + Y + ":"); //
			System.out.println(PossibleList.get(X).get(Y));

		}

	}

	public static void DefalutList() {
		for (int i = 0; i < 9; i++) {
			Def.add(i + 1);
		}
	}

}
