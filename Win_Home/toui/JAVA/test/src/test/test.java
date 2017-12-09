package test;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;

public class test {

	public static ArrayList<ArrayList<Integer>> Candidate = new ArrayList<ArrayList<Integer>>();
	public static ArrayList<ArrayList<Integer>> CurrentObject = new ArrayList<ArrayList<Integer>>();
	public static ArrayList<ArrayList<Integer>> NextObject = new ArrayList<ArrayList<Integer>>();

	public static ArrayList<Integer> Item = new ArrayList<Integer>();
	public static ArrayList<Integer> def = new ArrayList<Integer>();

	public static int WIDTH_SIZE = 800;
	public static int HEIGHT_SIZE = 800;
	public static int NUM_SIZE = 9;
	public static int OBJECT_SIZE = 3;
	public static int BOTTOM_SIZE = 11;
	public static int BUTTON_SIZE = 49;
	public static int SPACING = 50;
	public static int SelectValue = 0;

	public static int IMPOSSIBLE_SIZE = 20;
	public static int POSSIBLE_SIZE = 24;

	public static int[][] SudokuNum = new int[NUM_SIZE][NUM_SIZE];

	public static boolean SudokuButtonCheck = false;
	public static boolean NumButtonCheck = false;

	public static int[] Impossible = new int[IMPOSSIBLE_SIZE];

	public static void main(String[] args) {
		for (int i = 0; i < 9; i++) {
			def.add(i + 1);
		}
		read();
		Investigation();
		System.out.println(Candidate);
		// display();
		// Calculate();

	}

	public static void read() {
		File ReadCSV = new File("Input/Lev13.csv");
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
				if (CompareFindIndex == -1 )
				{
					continue;
				}
				Item.remove(CompareFindIndex);
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
		int partInitX = X - X % 3;
		int partInitY = Y - Y % 3;

		for (int j = 0; j < NUM_SIZE; j++) {
			int partIndexX = partInitX + j / 3;
			int partIndexY = partInitY + j % 3;
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
	/*
	 * public static void Calculate() { for (int i = 0; i < CurrentObject.size();
	 * i++) { CurrentIndexX = CurrentObject.get(i).get(0); CurrentIndexY =
	 * CurrentObject.get(i).get(1); CurrentValue = CurrentObject.get(i).get(2);
	 * 
	 * RangeCheck(); ImpossibleElementAdd(); PossibleElementAdd(); }
	 * 
	 * CalculateCheck();
	 * 
	 * CurrentObject = new ArrayList<ArrayList<Integer>>(NextObject); NextObject =
	 * new ArrayList<ArrayList<Integer>>();
	 * 
	 * }
	 * 
	 * public static void CalculateCheck() { for (int i = 0; i < 9; i++) { for (int
	 * j = 0; j < 9; j++) { if (SudokuNum[i][j] != 0) { continue; } Item = new
	 * ArrayList<Integer>(); Item = Candidate.get(XYToIndex(i, j)); outside: for
	 * (int k = 0; k < Item.size(); k++) { if (Item.get(k) < 0) { continue; } for
	 * (int l = 0; l < 3; l++) { ComparListCreat(i, j, l); int count = 0; for (int m
	 * = 0; m < 9; m++) { if (Compare[m] == -1) { continue; } else { if
	 * (Candidate.get(Compare[m]).indexOf(-(Item.get(k))) != -1) { count++; } if
	 * ((Candidate.get(Compare[m]).size() == 1) &&
	 * (Candidate.get(Compare[m])).get(0) == 0) { count++; } if (count == 8) {
	 * SudokuNum[i][j] = Item.get(k); SolveCount++;
	 * 
	 * Item = new ArrayList<Integer>(); Item.add(0); Candidate.set(XYToIndex(i, j),
	 * Item);
	 * 
	 * Item = new ArrayList<Integer>(); Item.add(i); Item.add(j);
	 * Item.add(SudokuNum[i][j]); NextObject.add(Item);
	 * 
	 * break outside; } } } } } } } }
	 * 
	 * public static void ComparListCreat(int i, int j, int l) { switch (l) { case
	 * 0: for (int m = 0; m < 9; m++) { if (m == j) { Compare[m] = -1; } else {
	 * Compare[m] = XYToIndex(i, m); } } break; case 1: for (int m = 0; m < 9; m++)
	 * { if (m == i) { Compare[m] = -1; } else { Compare[m] = XYToIndex(m, j); } }
	 * break; case 2: int BlockX = i % 3; int BlockY = j % 3; for (int m = 0; m < 9;
	 * m++) { int TrackX = m / 3; int TrackY = m % 3; if ((TrackX == BlockX) &&
	 * (TrackY == BlockY)) { Compare[m] = -1; } else { Compare[m] = XYToIndex(i -
	 * BlockX + TrackX, j - BlockY + TrackY); } } break; }
	 * 
	 * }
	 * 
	 * public static void PossibleElementAdd() { for (int k = 0; k < POSSIBLE_SIZE;
	 * k++) { Item = new ArrayList<Integer>(); Item = Candidate.get(Possible[k]);
	 * 
	 * if (Item.indexOf(0) != -1) { continue; } if (Item.indexOf(-CurrentValue) !=
	 * -1) { continue; } if (Item.indexOf(CurrentValue) != -1) { continue; }
	 * Item.add(CurrentValue); Candidate.set(Possible[k], Item); } }
	 * 
	 * public static void ImpossibleElementAdd() { for (int k = 0; k <
	 * IMPOSSIBLE_SIZE; k++) { Item = new ArrayList<Integer>(); Item =
	 * Candidate.get(Impossible[k]); if (Item.indexOf(0) != -1) { continue; } if
	 * (Item.indexOf(-CurrentValue) != -1) { continue; } int CurrentValueIndex =
	 * Item.indexOf(CurrentValue); if (CurrentValueIndex != -1) {
	 * Item.set(CurrentValueIndex, -CurrentValue); } else { Item.add(-CurrentValue);
	 * } Candidate.set(Impossible[k], Item); } }
	 * 
	 * public static void RangeCheck() { int ImpossibleCount = 0; int PossibleCount
	 * = 0; for (int x = 0; x < NUM_SIZE; x++) { for (int y = 0; y < NUM_SIZE; y++)
	 * { if (x == CurrentIndexX && y == CurrentIndexY) { continue; } if (x ==
	 * CurrentIndexX || y == CurrentIndexY) { Impossible[ImpossibleCount] =
	 * XYToIndex(x, y); ImpossibleCount++; continue; } if ((x / 3 == CurrentIndexX /
	 * 3) && (y / 3 == CurrentIndexY / 3)) { Impossible[ImpossibleCount] =
	 * XYToIndex(x, y); ImpossibleCount++; continue; } if ((x / 3 == CurrentIndexX /
	 * 3) || (y / 3 == CurrentIndexY / 3)) { Possible[PossibleCount] = XYToIndex(x,
	 * y); PossibleCount++; continue; } if (ImpossibleCount > IMPOSSIBLE_SIZE &&
	 * PossibleCount > POSSIBLE_SIZE) { return; } } } }
	 * 
	 * public static int XYToIndex(int X, int Y) { return X * NUM_SIZE + Y; }
	 * 
	 * public static void display() {
	 * System.out.println("-------------------------------------------");
	 * System.out.println(Candidate);
	 * System.out.println("-------------------------------------------"); }
	 */
}
