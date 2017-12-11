package NumGame;

import java.util.ArrayList;

public class KazanPuzzl {

	public static int Total = 26;
	public static int Num = 4;

	public static ArrayList<ArrayList<Integer>> Group = new ArrayList<ArrayList<Integer>>();

	public static ArrayList<Integer> TmpItem = new ArrayList<Integer>();

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		SubCut(Total, Num);
		System.out.println(Group);
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
					TmpItem = new ArrayList<Integer>(Group.get(Group.size()-1));
					TmpItem.remove(TmpItem.size()-1);
					current = 10;
					total += TmpItem.get(TmpItem.size() - 1);
					TmpItem.remove(TmpItem.size()-1);
					continue;
				}
			}
		}
	}
}
