package NumGame;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;

public class KazanPuzzl {

	public static String ReadFile = "Input/Kazan1.csv";
	public static int Total = 26;
	public static int Num = 4;

	public static ArrayList<ArrayList<Integer>> Group = new ArrayList<ArrayList<Integer>>();
	public static ArrayList<Integer> TmpItem = new ArrayList<Integer>();
	public static ArrayList<Integer> Def = new ArrayList<Integer>();

	public static ArrayList<Kazan> MainBody = new ArrayList<Kazan>();

	public static Kazan setConstructor(boolean use, int HorizontalTotal, int LongitudinalTotal,
			ArrayList<Integer> HorizontalNum, ArrayList<Integer> LongitudinalNum) {
		Kazan Kazan = new Kazan();
		Kazan.use = use;
		Kazan.HorizontalTotal = HorizontalTotal;
		Kazan.LongitudinalTotal = LongitudinalTotal;
		Kazan.HorizontalNum = HorizontalNum;
		Kazan.LongitudinalNum = LongitudinalNum;
		return Kazan;
	}

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		DefalutList();
		read();
		SubCut(Total, Num);
		System.out.println(Group);
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
				for (int i = 0; i < PointData.length; i++) {
					if (PointData[i].equals("-")) {
						TmpItem = new ArrayList<Integer>();
						MainBody.add(setConstructor(false, 0, 0, TmpItem, TmpItem));
						continue;
					}
					if (PointData[i].equals("")) {
						MainBody.add(setConstructor(true, 0, 0, Def, Def));
						continue;
					}

					double subData = Double.valueOf(PointData[i]);
					int LongitudinalTotal = (int) Math.floor(subData);
					
					int HorizontalTotal = DecimalPoint(subData);;
					TmpItem = new ArrayList<Integer>();
					MainBody.add(setConstructor(true, HorizontalTotal, LongitudinalTotal, TmpItem, TmpItem));
				}
			}
		} catch (NumberFormatException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

	public static int DecimalPoint(double s)
	{
		int a = (int)(s*100);
		int b = (int) s*100;
		return a-b;
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
		}
		total -= current;
		TmpItem.add(current);
		num--;
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
					Group.add(TmpItem);
					TmpItem = new ArrayList<Integer>(Group.get(Group.size() - 1));
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
	boolean use;
	int HorizontalTotal;
	int LongitudinalTotal;
	ArrayList<Integer> HorizontalNum;
	ArrayList<Integer> LongitudinalNum;
}
