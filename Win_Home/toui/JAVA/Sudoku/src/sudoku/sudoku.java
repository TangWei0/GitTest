package sudoku;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;

public class sudoku {

	public static ArrayList<ArrayList<Integer>> Candidate = new ArrayList<ArrayList<Integer>>();

	public static ArrayList<Integer> Item = new ArrayList<Integer>();
	public static ArrayList<Integer> def = new ArrayList<Integer>();

	public static int NUM_SIZE = 9;
	public static int OBJECT_SIZE = 3;
	public static int IMPOSSIBLE_SIZE = 20;

	public static int count = 0;

	public static int[][] SudokuNum = new int[NUM_SIZE][NUM_SIZE];
	public static int[] Impossible = new int[IMPOSSIBLE_SIZE];

	public static void main(String[] args) {
		for (int i = 0; i < NUM_SIZE; i++) {
			def.add(i + 1);
		}
		read();
		while (count < NUM_SIZE * NUM_SIZE) {
			Investigation();
		}
		Write();
	}

	public static void read() {
		File ReadCSV = new File("Input/Lev14.csv");
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
					int value = Integer.parseInt(PointData[i]);
					if (value == 0) {
						Item = new ArrayList<Integer>(def);
						Candidate.add(Item);
					} else {
						Item = new ArrayList<Integer>();
						Item.add(value);
						Candidate.add(Item);
						count++;
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
		File file = new File("Output/Lev14.csv");
		try {
			// 出力先を作成する
			FileWriter fw = new FileWriter(file, false);
			PrintWriter pw = new PrintWriter(new BufferedWriter(fw));

			// 内容を指定する
			for (int i = 0; i < NUM_SIZE * NUM_SIZE; i++) {
				if (i != 0 && i%NUM_SIZE == 0)
				{
					pw.println();
				}
				pw.print(Candidate.get(i).get(0));
				pw.print(",");
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
		for (int i = 0; i < NUM_SIZE * NUM_SIZE; i++) {
			if (Candidate.get(i).size() == 1) {
				continue;
			}
			Item = new ArrayList<Integer>();
			Item = Candidate.get(i);
			RangeCheck(i);
			for (int CompareIndex : Impossible) {
				if (Candidate.get(CompareIndex).size() != 1) {
					continue;
				}
				int CompareFindIndex = Item.indexOf(Candidate.get(CompareIndex).get(0));
				if (CompareFindIndex == -1) {
					continue;
				}
				Item.remove(CompareFindIndex);
				if (Item.size() == 1) {
					count++;
				}
			}
			Candidate.set(i, Item);
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
