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

	public static ArrayList<ArrayList<ArrayList<ArrayList<Integer>>>> MainList = new ArrayList<ArrayList<ArrayList<ArrayList<Integer>>>>();
	public static ArrayList<ArrayList<ArrayList<Integer>>> MainItemList = new ArrayList<ArrayList<ArrayList<Integer>>>();
	public static ArrayList<ArrayList<Integer>> MainItemItemList = new ArrayList<ArrayList<Integer>>();
	public static ArrayList<Integer> MainItemItemItemList = new ArrayList<Integer>();
	public static boolean check = true;

	static Data Data = new Data();

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		DefalutList();
		read();
		for (int a = 1; a < 20; a++) {
			System.out.println(a + "ループ");
			statistics();
			check();
			for (int j = 0; j < ResultList.size(); j++) {
				int X = ResultList.get(j).get(0);
				int Y = ResultList.get(j).get(1);
				if (a == 10) {
					System.out.println(MainList.get(X).get(Y).get(5));
				}
			}
			ResultList = new ArrayList<ArrayList<Integer>>(NextList);
		}
	}

	public static void read() {
		File ReadCSV = new File(ReadFile);
		MainItemItemItemList = new ArrayList<Integer>();
		MainItemItemItemList.add(0);
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
				MainItemList = new ArrayList<ArrayList<ArrayList<Integer>>>();
				for (int i = 0; i < PointData.length; i++) {
					if (PointData[i].equals("-")) {
						MainItemItemList = new ArrayList<ArrayList<Integer>>();

						MainItemItemItemList = new ArrayList<Integer>();
						MainItemItemItemList.add(-1);
						MainItemItemList.add(MainItemItemItemList);

						MainItemItemItemList = new ArrayList<Integer>();
						MainItemItemList.add(MainItemItemItemList);

						MainItemItemItemList = new ArrayList<Integer>();
						MainItemItemList.add(MainItemItemItemList);

						MainItemItemItemList = new ArrayList<Integer>();
						MainItemItemList.add(MainItemItemItemList);

						MainItemItemItemList = new ArrayList<Integer>();
						MainItemItemList.add(MainItemItemItemList);

						MainItemItemItemList = new ArrayList<Integer>();
						MainItemItemList.add(MainItemItemItemList);

						MainItemItemItemList = new ArrayList<Integer>();
						MainItemItemList.add(MainItemItemItemList);

						MainItemItemItemList = new ArrayList<Integer>();
						MainItemItemList.add(MainItemItemItemList);

						MainItemList.add(MainItemItemList);
						continue;
					} else if (PointData[i].equals("0")) {
						MainItemItemList = new ArrayList<ArrayList<Integer>>();

						MainItemItemItemList = new ArrayList<Integer>();
						MainItemItemItemList.add(1);
						MainItemItemList.add(MainItemItemItemList);

						MainItemItemItemList = new ArrayList<Integer>();
						MainItemItemItemList.add(0);
						MainItemItemList.add(MainItemItemItemList);

						MainItemItemItemList = new ArrayList<Integer>();
						MainItemItemItemList.add(0);
						MainItemItemList.add(MainItemItemItemList);

						MainItemItemItemList = new ArrayList<Integer>();
						MainItemItemItemList.add(0);
						MainItemItemList.add(MainItemItemItemList);

						MainItemItemItemList = new ArrayList<Integer>();
						MainItemItemItemList.add(0);
						MainItemItemList.add(MainItemItemItemList);

						MainItemItemItemList = new ArrayList<Integer>(Def);
						MainItemItemList.add(MainItemItemItemList);

						MainItemItemItemList = new ArrayList<Integer>(Def);
						MainItemItemList.add(MainItemItemItemList);

						MainItemItemItemList = new ArrayList<Integer>(Def);
						MainItemItemList.add(MainItemItemItemList);

						MainItemList.add(MainItemItemList);

						MainItemItemItemList = new ArrayList<Integer>();
						MainItemItemItemList.add(LineCount);
						MainItemItemItemList.add(i);
						ResultList.add(MainItemItemItemList);
						continue;
					} else {
						int Hor = Integer.parseInt(PointData[i].substring(2, 4));
						int Long = Integer.parseInt(PointData[i].substring(0, 2));

						MainItemItemList = new ArrayList<ArrayList<Integer>>();

						MainItemItemItemList = new ArrayList<Integer>();
						MainItemItemItemList.add(0);
						MainItemItemList.add(MainItemItemItemList);

						MainItemItemItemList = new ArrayList<Integer>();
						MainItemItemItemList.add(Hor);
						MainItemItemList.add(MainItemItemItemList);

						MainItemItemItemList = new ArrayList<Integer>();
						MainItemItemItemList.add(Long);
						MainItemItemList.add(MainItemItemItemList);

						MainItemItemItemList = new ArrayList<Integer>();
						MainItemItemItemList.add(0);
						MainItemItemList.add(MainItemItemItemList);

						MainItemItemItemList = new ArrayList<Integer>();
						MainItemItemItemList.add(0);
						MainItemItemList.add(MainItemItemItemList);

						MainItemItemItemList = new ArrayList<Integer>();
						if (Hor == 0) {
							MainItemItemItemList.add(1);
						}
						if (Long == 0) {
							MainItemItemItemList.add(2);
						}
						MainItemItemList.add(MainItemItemItemList);

						MainItemItemItemList = new ArrayList<Integer>();
						MainItemItemList.add(MainItemItemItemList);

						MainItemItemItemList = new ArrayList<Integer>();
						MainItemItemList.add(MainItemItemItemList);

						MainItemList.add(MainItemItemList);

						MainItemItemItemList = new ArrayList<Integer>();
						MainItemItemItemList.add(LineCount);
						MainItemItemItemList.add(i);
						ConditionList.add(MainItemItemItemList);
					}
				}
				MainList.add(MainItemList);
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
			if (MainList.get(X).get(Y).get(5).indexOf(1) == -1) {
				// 横向计数
				if (MainList.get(X).get(Y).get(3).get(0) == 0) {
					int HorizontalCount = 0;
					for (int k = 1; k < MainList.get(X).size() - Y; k++) {
						if (MainList.get(X).get(Y + k).get(0).get(0) != 1) {
							break;
						}
						MainList.get(X).get(Y + k).get(1).set(0, X);
						MainList.get(X).get(Y + k).get(3).set(0, Y);
						HorizontalCount++;
					}
					MainList.get(X).get(Y).get(3).set(0, HorizontalCount);
				}
				int Total = MainList.get(X).get(Y).get(1).get(0);
				int Num = MainList.get(X).get(Y).get(3).get(0);
				if (MainList.get(X).get(Y).get(6).size() != 0) {
					Num -= MainList.get(X).get(Y).get(6).size();
					for (int value : MainList.get(X).get(Y).get(6)) {
						Total -= value;
					}
				}

				if (Num == 1) {
					if (MainList.get(X).get(Y).get(6).indexOf(Total) == -1) {
						TmpItem = new ArrayList<Integer>();
						TmpItem.add(Total);
					} else {
						System.out.println(X + "," + Y + "でエラーが発生しました");
					}
				} else {
					TmpItem = Data.SubCutProcess(Total, Num, MainList.get(X).get(Y).get(6));
				}
				for (int k = 1; k <= MainList.get(X).get(Y).get(3).get(0); k++) {
					if (MainList.get(X).get(Y + k).get(5).size() != 1) {
						MainList.get(X).get(Y + k).set(6,
								Data.DataIntersection(TmpItem, MainList.get(X).get(Y + k).get(6)));
					}
				}
			}
			// 纵向处理
			if (MainList.get(X).get(Y).get(5).indexOf(2) == -1) {
				// 纵向计数
				if (MainList.get(X).get(Y).get(4).get(0) == 0) {
					int LongitudinalCount = 0;
					for (int k = 1; k < MainList.size() - X; k++) {
						if (MainList.get(X + k).get(Y).get(0).get(0) != 1) {
							break;
						}

						MainList.get(X + k).get(Y).get(2).set(0, X);
						MainList.get(X + k).get(Y).get(4).set(0, Y);
						LongitudinalCount++;
					}
					MainList.get(X).get(Y).get(4).set(0, LongitudinalCount);
				}
				int Total = MainList.get(X).get(Y).get(2).get(0);
				int Num = MainList.get(X).get(Y).get(4).get(0);
				if (MainList.get(X).get(Y).get(7).size() != 0) {
					Num -= MainList.get(X).get(Y).get(7).size();
					for (int value : MainList.get(X).get(Y).get(7)) {
						Total -= value;
					}
				}
				if (Num == 1) {
					if (MainList.get(X).get(Y).get(7).indexOf(Total) == -1) {
						TmpItem = new ArrayList<Integer>();
						TmpItem.add(Total);
					} else {
						System.out.println(X + "," + Y + "でエラーが発生しました");
					}
				} else {
					TmpItem = Data.SubCutProcess(Total, Num, MainList.get(X).get(Y).get(7));
				}
				for (int k = 1; k <= MainList.get(X).get(Y).get(4).get(0); k++) {
					if (MainList.get(X + k).get(Y).get(5).size() != 1) {
						MainList.get(X + k).get(Y).set(7,
								Data.DataIntersection(TmpItem, MainList.get(X + k).get(Y).get(7)));
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
			MainList.get(X).get(Y).set(5,
					Data.DataIntersection(MainList.get(X).get(Y).get(6), MainList.get(X).get(Y).get(7)));
			MainList.get(X).get(Y).set(6, MainList.get(X).get(Y).get(5));
			MainList.get(X).get(Y).set(7, MainList.get(X).get(Y).get(5));

			if (MainList.get(X).get(Y).get(5).size() == 1) {
				int value = MainList.get(X).get(Y).get(5).get(0);
				int HorizontalX = MainList.get(X).get(Y).get(1).get(0);
				int HorizontalY = MainList.get(X).get(Y).get(3).get(0);
				int LongitudinalX = MainList.get(X).get(Y).get(2).get(0);
				int LongitudinalY = MainList.get(X).get(Y).get(4).get(0);

				MainList.get(HorizontalX).get(HorizontalY).get(6).add(value);
				if (MainList.get(HorizontalX).get(HorizontalY).get(6).size() == MainList.get(HorizontalX)
						.get(HorizontalY).get(3).get(0)) {
					MainList.get(HorizontalX).get(HorizontalY).get(5).add(1);
				}

				MainList.get(LongitudinalX).get(LongitudinalY).get(7).add(value);
				if (MainList.get(LongitudinalX).get(LongitudinalY).get(7).size() == MainList.get(LongitudinalX)
						.get(LongitudinalY).get(4).get(0)) {
					MainList.get(LongitudinalX).get(LongitudinalY).get(5).add(2);
				}
			} else {
				TmpItem = new ArrayList<Integer>();
				TmpItem.add(X);
				TmpItem.add(Y);
				NextList.add(TmpItem);
			}
		}
		if (NextList.size() == ResultList.size()) {
			check2();
		}
	}

	public static void check2() {
		int count = 0;
		for (int i = 0; i < ResultList.size(); i++) {
			int X = ResultList.get(i).get(0);
			int Y = ResultList.get(i).get(1);
			int HorizontalX = MainList.get(X).get(Y).get(1).get(0);
			int HorizontalY = MainList.get(X).get(Y).get(3).get(0);
			int LongitudinalX = MainList.get(X).get(Y).get(2).get(0);
			int LongitudinalY = MainList.get(X).get(Y).get(4).get(0);

			if (MainList.get(HorizontalX).get(HorizontalY).get(3).get(0)
					- MainList.get(HorizontalX).get(HorizontalY).get(6).size() == 2) {
				int Total = MainList.get(HorizontalX).get(HorizontalY).get(1).get(0);
				for (int HorizontalValue : MainList.get(HorizontalX).get(HorizontalY).get(6)) {
					Total -= HorizontalValue;
				}

				for (int k = 1; k <= MainList.get(HorizontalX).get(HorizontalY).get(3).get(0) ; k++) {
					if (MainList.get(HorizontalX).get(HorizontalY + k).get(5).size() == 1) {
						continue;
					}
					if (HorizontalY + k == Y) {
						continue;
					}
					for (int j = MainList.get(X).get(Y).get(5).size() - 1; j >= 0; j--) {
						int value = MainList.get(X).get(Y).get(5).get(j);
						if (MainList.get(HorizontalX).get(HorizontalY + k).get(5).indexOf(Total - value) == -1) {
							MainList.get(X).get(Y).get(5).remove(j);
						}
					}
				}
				MainList.get(X).get(Y).set(6, MainList.get(X).get(Y).get(5));
				MainList.get(X).get(Y).set(7, MainList.get(X).get(Y).get(5));
				if (MainList.get(X).get(Y).get(5).size() == 1) {
					MainList.get(HorizontalX).get(HorizontalY).get(6).add(MainList.get(X).get(Y).get(5).get(0));
					MainList.get(LongitudinalX).get(LongitudinalY).get(7).add(MainList.get(X).get(Y).get(5).get(0));
					NextList.remove(i);
					return;
				}
			}

			if (MainList.get(LongitudinalX).get(LongitudinalY).get(4).get(0)
					- MainList.get(LongitudinalX).get(LongitudinalY).get(7).size() == 2) {
				int Total = MainList.get(LongitudinalX).get(LongitudinalY).get(2).get(0);
				for (int LongitudinalValue : MainList.get(LongitudinalX).get(LongitudinalY).get(7)) {
					Total -= LongitudinalValue;
				}

				for (int k = 1; k <= MainList.get(LongitudinalX).get(LongitudinalY).get(4).get(0); k++) {
					if (MainList.get(LongitudinalX + k).get(LongitudinalY).get(5).size() == 1) {
						continue;
					}
					if (LongitudinalX + k == X) {
						continue;
					}
					for (int j = MainList.get(X).get(Y).get(5).size() - 1; j >= 0; j--) {
						int value = MainList.get(X).get(Y).get(5).get(j);
						if (MainList.get(LongitudinalX + k).get(LongitudinalY).get(5).indexOf(Total - value) == -1) {
							MainList.get(X).get(Y).get(5).remove(j);
						}
					}
				}
				MainList.get(X).get(Y).set(6, MainList.get(X).get(Y).get(5));
				MainList.get(X).get(Y).set(7, MainList.get(X).get(Y).get(5));
				if (MainList.get(X).get(Y).get(5).size() == 1) {
					MainList.get(HorizontalX).get(HorizontalY).get(6).add(MainList.get(X).get(Y).get(5).get(0));
					MainList.get(LongitudinalX).get(LongitudinalY).get(7).add(MainList.get(X).get(Y).get(5).get(0));
					NextList.remove(i);
					return;
				}
			}
		}

	}

	public static void DefalutList() {
		for (int i = 0; i < 9; i++) {
			Def.add(i + 1);
		}
	}

}
