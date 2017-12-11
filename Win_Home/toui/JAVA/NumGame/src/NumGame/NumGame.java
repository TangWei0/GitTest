package NumGame;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;

public class NumGame {

	public static String ReadFile = "Input/Lev15.csv";
	public static String WirteFile = "Output/Lev15.csv";
	public static ArrayList<ArrayList<Integer>> Candidate = new ArrayList<ArrayList<Integer>>();

	public static ArrayList<Integer> TmpItem = new ArrayList<Integer>();
	public static ArrayList<Integer> Def = new ArrayList<Integer>();
	public static ArrayList<Integer> Object = new ArrayList<Integer>();

	public static int NUM_SIZE = 9;
	public static int OBJECT_SIZE = 3;
	public static int IMPOSSIBLE_SIZE = 20;

	public static int a = 0;
	public static int[] Impossible = new int[IMPOSSIBLE_SIZE];

	public static void main(String[] args) {
		for (int i = 0; i < NUM_SIZE; i++) {
			Def.add(i + 1);
		}
		sudoku();
	}
	
	public static void sudoku()
	{
		read();
		while (Object.size() > 0) {
			Investigation();
		}
		Write();
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
		String PointValue;
		try {
			while ((PointLine = br.readLine()) != null) {
				for (int i = 0; i < PointLine.length(); i++) {
					if (i != PointLine.length() - 1) {
						PointValue = PointLine.substring(i, i + 1);
					} else {
						PointValue = PointLine.substring(i);
					}
					int value = Integer.parseInt(PointValue);
					if (value == 0) {
						TmpItem = new ArrayList<Integer>(Def);
						Candidate.add(TmpItem);
						Object.add(Candidate.size() - 1);
					} else {
						TmpItem = new ArrayList<Integer>();
						TmpItem.add(value);
						Candidate.add(TmpItem);
					}
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

	public static void Write() {
		File file = new File(WirteFile);
		try {
			// 出力先を作成する
			FileWriter fw = new FileWriter(file, false);
			PrintWriter pw = new PrintWriter(new BufferedWriter(fw));
			// 内容を指定する
			for (int i = 0; i < NUM_SIZE * NUM_SIZE; i++) {
				if (i != 0 && i % NUM_SIZE == 0) {
					pw.println();
				}
				pw.print(Candidate.get(i).get(0));
			}
			// ファイルに書き出す
			pw.close();
			// 終了メッセージを画面に出力する
			System.out.println("出力が完了しました。");
		} catch (IOException ex) {
			// 例外時処理
			ex.printStackTrace();
		}
	}

	public static void Investigation() {
		for (int i = 0; i < Object.size(); i++) {
			int Index = Object.get(i);
			TmpItem = new ArrayList<Integer>();
			TmpItem = Candidate.get(Index);
			RangeCheck(Index);
			for (int CompareIndex : Impossible) {
				if (Candidate.get(CompareIndex).size() != 1) {
					continue;
				}
				int CompareFindIndex = TmpItem.indexOf(Candidate.get(CompareIndex).get(0));
				if (CompareFindIndex == -1) {
					continue;
				}
				TmpItem.remove(CompareFindIndex);
				if (TmpItem.size() == 1) {
					Object.remove(Object.indexOf(Index));
				}
			}
			Candidate.set(Index, TmpItem);
		}
	}

	public static void RangeCheck(int i) {
		int X = i / NUM_SIZE;
		int Y = i % NUM_SIZE;
		int ImpossibleCount = 0;
		// 横轴对象
		for (int j = 0; j < NUM_SIZE; j++) {
			if (j == Y) {
				continue;
			}
			Impossible[ImpossibleCount] = XYToIndex(X, j);
			ImpossibleCount++;
		}
		// 纵轴对象
		for (int j = 0; j < NUM_SIZE; j++) {
			if (j == X) {
				continue;
			}
			Impossible[ImpossibleCount] = XYToIndex(j, Y);
			ImpossibleCount++;
		}
		// 局部对象
		int partInitX = X - X % OBJECT_SIZE;
		int partInitY = Y - Y % OBJECT_SIZE;
		for (int j = 0; j < NUM_SIZE; j++) {
			int partIndexX = partInitX + j / OBJECT_SIZE;
			int partIndexY = partInitY + j % OBJECT_SIZE;
			if (partIndexX == X || partIndexY == Y) {
				continue;
			}
			Impossible[ImpossibleCount] = XYToIndex(partIndexX, partIndexY);
			ImpossibleCount++;
		}
	}

	public static int XYToIndex(int X, int Y) {
		return X * NUM_SIZE + Y;
	}
}
