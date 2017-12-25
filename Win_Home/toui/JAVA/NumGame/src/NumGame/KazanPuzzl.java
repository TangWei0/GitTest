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

	public static ArrayList<ArrayList<Integer>>  UseSwitch = new ArrayList<ArrayList<Integer>> ();
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

		for (int i = 0; i < UseSwitch.size(); i++) {
			System.out.println(UseSwitch.get(i));
			//for (int j = 0; j < UseSwitch.get(i).size(); j++) 
			{
				//System.out.print(UseSwitch.get(i).get(j) + ",");
				//System.out.println("-------------------");
				//System.out.println(HorizontalTotal);
				//System.out.println("-------------------");
				//System.out.println(LongitudinalTotal);
				//System.out.println("-------------------");
				//System.out.println(HorizontalNum);
				//System.out.println("-------------------");
				//System.out.println(LongitudinalNum);
				//System.out.println("-------------------");
				//System.out.println(PossibleList);
				//System.out.println("-------------------");
				//System.out.println(HorizontalList);
				//System.out.println("-------------------");
				//System.out.println(LongitudinalList);
				//System.out.println("-------------------");			
			}
			//System.out.println();
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

	/*
	public static void statistics() {
		for (int i = 0; i < ConditionList.size(); i++) {
			int X = ConditionList.get(i).get(0);
			int Y = ConditionList.get(i).get(1);
			// 横向处理
			if (MainBody.get(X).get(Y).PossibleList.indexOf(1) == -1) {
				// 横向计数
				if (MainBody.get(X).get(Y).HorizontalNum == 0) {
					for (int k = 1; k < MainBody.get(X).size() - Y; k++) {
						if (MainBody.get(X).get(Y + k).UseSwitch != 1) {
							break;
						}
						MainBody.get(X).get(Y + k).HorizontalTotal = X;
						MainBody.get(X).get(Y + k).HorizontalNum = Y;
						MainBody.get(X).get(Y).HorizontalNum++;
					}
				}

				int Total = MainBody.get(X).get(Y).HorizontalTotal;
				int Num = MainBody.get(X).get(Y).HorizontalNum;
				if (MainBody.get(X).get(Y).HorizontalList.size() != 0) {
					Num -= MainBody.get(X).get(Y).HorizontalList.size();
					for (int value : MainBody.get(X).get(Y).HorizontalList) {
						Total -= value;
					}
				}

				if (Num == 1) {
					if (MainBody.get(X).get(Y).HorizontalList.indexOf(Total) == -1) {
						TmpItem = new ArrayList<Integer>();
						TmpItem.add(Total);
					} else {
						System.out.println("エラーが発生しました");
					}
				} else {
					TmpItem = Data.SubCutProcess(Total, Num, MainBody.get(X)
							.get(Y).HorizontalList);
				}
				for (int k = 1; k <= MainBody.get(X).get(Y).HorizontalNum; k++) {
					if (MainBody.get(X).get(Y + k).PossibleList.size() != 1) {
						MainBody.get(X).get(Y + k).HorizontalList = Data
								.DataIntersection(
										TmpItem,
										MainBody.get(X).get(Y + k).HorizontalList);
					}
				}
			}
			// 纵向处理
			if (MainBody.get(X).get(Y).PossibleList.indexOf(2) == -1) {

				// 纵向计数
				if (MainBody.get(X).get(Y).LongitudinalNum == 0) {
					for (int k = 1; k < MainBody.size() - X; k++) {
						if (MainBody.get(X + k).get(Y).UseSwitch != 1) {
							break;
						}
						MainBody.get(X + k).get(Y).LongitudinalTotal = X;
						MainBody.get(X + k).get(Y).LongitudinalNum = Y;
						MainBody.get(X).get(Y).LongitudinalNum++;
					}
				}

				int Total = MainBody.get(X).get(Y).LongitudinalTotal;
				int Num = MainBody.get(X).get(Y).LongitudinalNum;

				if (MainBody.get(X).get(Y).LongitudinalList.size() != 0) {
					Num -= MainBody.get(X).get(Y).LongitudinalList.size();
					for (int value : MainBody.get(X).get(Y).LongitudinalList) {
						Total -= value;
					}
				}

				if (Num == 1) {
					if (MainBody.get(X).get(Y).LongitudinalList.indexOf(Total) == -1) {
						TmpItem = new ArrayList<Integer>();
						TmpItem.add(Total);
					} else {
						System.out.println("エラーが発生しました");
					}
				} else {
					TmpItem = Data.SubCutProcess(Total, Num, MainBody.get(X)
							.get(Y).LongitudinalList);
				}
				for (int k = 1; k <= MainBody.get(X).get(Y).LongitudinalNum; k++) {
					if (MainBody.get(X + k).get(Y).PossibleList.size() != 1) {
						MainBody.get(X + k).get(Y).LongitudinalList = Data
								.DataIntersection(TmpItem, MainBody.get(X + k)
										.get(Y).LongitudinalList);
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
			MainBody.get(X).get(Y).PossibleList = Data.DataIntersection(
					MainBody.get(X).get(Y).HorizontalList,
					MainBody.get(X).get(Y).LongitudinalList);
			MainBody.get(X).get(Y).HorizontalList = MainBody.get(X).get(Y).PossibleList;
			MainBody.get(X).get(Y).LongitudinalList = MainBody.get(X).get(Y).PossibleList;

			if (MainBody.get(X).get(Y).PossibleList.size() == 1) {
				int value = MainBody.get(X).get(Y).PossibleList.get(0);
				int HorizontalX = MainBody.get(X).get(Y).HorizontalTotal;
				int HorizontalY = MainBody.get(X).get(Y).HorizontalNum;
				int LongitudinalX = MainBody.get(X).get(Y).LongitudinalTotal;
				int LongitudinalY = MainBody.get(X).get(Y).LongitudinalNum;

				if (X == 9 && Y == 4) {
					System.out.println(MainBody.get(9).get(1).HorizontalList);
					System.out.println(MainBody.get(9).get(1).LongitudinalList);
				}
				TmpItem = new ArrayList<Integer>();
				TmpItem = MainBody.get(HorizontalX).get(HorizontalY).HorizontalList;
				TmpItem.add(value);
				Kazan c = new Kazan();
				c = MainBody.get(HorizontalX).get(HorizontalY);
				c.HorizontalList = TmpItem;
				MainBody.get(HorizontalX).get(HorizontalY).HorizontalList = new ArrayList<Integer>(
						TmpItem);
				if (X == 9 && Y == 4) {
					System.out.println(MainBody.get(9).get(1).HorizontalList);
					System.out.println(MainBody.get(9).get(1).LongitudinalList);
				}
				if (MainBody.get(HorizontalX).get(HorizontalY).HorizontalList
						.size() == MainBody.get(HorizontalX).get(HorizontalY).HorizontalNum) {
					TmpItem = new ArrayList<Integer>(MainBody.get(HorizontalX)
							.get(HorizontalY).PossibleList);
					TmpItem.add(1);
					MainBody.get(HorizontalX).get(HorizontalY).PossibleList = TmpItem;
				}

				TmpItem = new ArrayList<Integer>();
				TmpItem = MainBody.get(LongitudinalX).get(LongitudinalY).LongitudinalList;
				TmpItem.add(value);
				MainBody.get(LongitudinalX).get(LongitudinalY).LongitudinalList = TmpItem;
				if (MainBody.get(LongitudinalX).get(LongitudinalY).LongitudinalList
						.size() == MainBody.get(LongitudinalX).get(
						LongitudinalY).LongitudinalNum) {
					TmpItem = new ArrayList<Integer>(MainBody
							.get(LongitudinalX).get(LongitudinalY).PossibleList);
					TmpItem.add(2);
					MainBody.get(LongitudinalX).get(LongitudinalY).PossibleList = TmpItem;
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
			// System.out.print(X + "," + Y + ":");
			// System.out.println(MainBody.get(X).get(Y).PossibleList);

		}

	}
	*/
	
	public static void DefalutList() {
		for (int i = 0; i < 9; i++) {
			Def.add(i + 1);
		}
	}

}
