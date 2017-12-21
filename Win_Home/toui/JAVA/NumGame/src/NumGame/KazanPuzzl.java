package NumGame;

import java.io.BufferedReader;

public class KazanPuzzl {
	public static String ReadFile = "Input/Kazan2.csv";
	public static int ObjectCount = 0;

	public static int Total;
	public static int Num;

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
		DefalutList();
		read();
		for (int l = 1; l < 10; l++) {
			System.out.println(l + "ループ");
			statistics();
			check();
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
						MainBodyItem.add(setConstructor(-1, 0, 0, 0, 0,
								TmpItem, TmpItem, TmpItem));
						continue;
					}
					if (PointData[i].equals("0")) {
						MainBodyItem.add(setConstructor(1, 0, 0, 0, 0, Def,
								Def, Def));
						TmpItem = new ArrayList<Integer>();
						TmpItem.add(LineCount);
						TmpItem.add(i);
						ResultList.add(TmpItem);
						continue;
					}
					TmpItem = new ArrayList<Integer>();
					ArrayList<Integer> ObjectCheckList = new ArrayList<Integer>();
					int Horizontal = Integer.parseInt(PointData[i].substring(2,
							4));
					int Longitudinal = Integer.parseInt(PointData[i].substring(
							0, 2));
					if (Horizontal != 0) {
						ObjectCount++;
					} else {
						ObjectCheckList.add(1);
					}
					if (Longitudinal != 0) {
						ObjectCount++;
					} else {
						ObjectCheckList.add(2);
					}
					MainBodyItem.add(setConstructor(0, Horizontal,
							Longitudinal, 0, 0, ObjectCheckList, TmpItem,
							TmpItem));
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
						MainBody.get(X).get(Y + k).HorizontalList = TmpItem;
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
						MainBody.get(X + k).get(Y).LongitudinalList = TmpItem;
					}
				}
			}
		}

	}

	public static void check() {
		for (int i = 0; i < ResultList.size(); i++) {
			int X = ResultList.get(i).get(0);
			int Y = ResultList.get(i).get(1);
			MainBody.get(X).get(Y).PossibleList = Data.DataIntersection(
					MainBody.get(X).get(Y).HorizontalList,
					MainBody.get(X).get(Y).LongitudinalList);

			if (MainBody.get(X).get(Y).PossibleList.size() == 1) {
				int value = MainBody.get(X).get(Y).PossibleList.get(0);
				int HorizontalX = MainBody.get(X).get(Y).HorizontalTotal;
				int HorizontalY = MainBody.get(X).get(Y).HorizontalNum;
				int LongitudinalX = MainBody.get(X).get(Y).LongitudinalTotal;
				int LongitudinalY = MainBody.get(X).get(Y).LongitudinalNum;
				
				TmpItem = new ArrayList<Integer>(MainBody.get(HorizontalX).get(
						HorizontalY).HorizontalList);
				TmpItem.add(value);
				MainBody.get(HorizontalX).get(HorizontalY).HorizontalList = TmpItem;
				if (MainBody.get(HorizontalX).get(HorizontalY).HorizontalList
						.size() == MainBody.get(HorizontalX).get(HorizontalY).HorizontalNum) {
					TmpItem = new ArrayList<Integer>(MainBody.get(HorizontalX)
							.get(HorizontalY).PossibleList);
					TmpItem.add(1);
					MainBody.get(HorizontalX).get(HorizontalY).PossibleList = TmpItem;
				}

				TmpItem = new ArrayList<Integer>(MainBody.get(HorizontalX).get(
						HorizontalY).LongitudinalList);
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
			}
			System.out.println(MainBody.get(X).get(Y).PossibleList);
		}
	}

	public static void DefalutList() {
		for (int i = 0; i < 9; i++) {
			Def.add(i + 1);
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
