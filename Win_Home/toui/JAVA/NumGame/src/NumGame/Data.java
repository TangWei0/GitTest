package NumGame;

import java.util.ArrayList;
import java.util.Collections;

public class Data {
	
	static ArrayList<ArrayList<Integer>> AnalysisList = new ArrayList<ArrayList<Integer>>();
	static ArrayList<Integer> TmpItem = new ArrayList<Integer>();
	
	public ArrayList<Integer> SubCutProcess(int total, int num, ArrayList<Integer> ConfirmList)
	{
		ArrayList<Integer> CutResultList = new ArrayList<Integer>();
		ClearList();
		SubCut(total,num,ConfirmList);
		DataUnion(CutResultList);
		
		return CutResultList;
	}
	
	public void ClearList()
	{
		AnalysisList = new ArrayList<ArrayList<Integer>>();
		TmpItem = new ArrayList<Integer>();
	}
	
	public void DataUnion (ArrayList<Integer> CutResultList)
	{	
		for (int i = 0; i < AnalysisList.size(); i++)
		{
			for (int value : AnalysisList.get(i))
			{
				if (CutResultList.indexOf(value) != -1)
				{
					continue;
				}
				CutResultList.add(value);
			}
		}
		Collections.sort(CutResultList);
	}
	
	public ArrayList<Integer> DataIntersection(ArrayList<Integer> HorizontalList,
			ArrayList<Integer> LongitudinalList) {
		ArrayList<Integer> DataList = new ArrayList<Integer>();
		for (int value : HorizontalList) {
			if (LongitudinalList.indexOf(value) != -1) {
				DataList.add(value);
			}
		}
		Collections.sort(DataList);
		return DataList;
	}
	
	public void SubCut(int total, int num, ArrayList<Integer> ConfirmList) {
		int current, limit, Max, Min;
		if (TmpItem.size() == 0) {
			current = 1;
		} else {
			current = TmpItem.get(TmpItem.size() - 1) + 1;
		}
		limit = 9 - num + 2;
		Max = (2 * 10 - num) * (num - 1) / 2;
		for (int i = current; i < limit; i++) {
			Min = (2 * (i - 1) + num) * (num - 1) / 2;
			if (ConfirmList.indexOf(i) != -1) {
				continue;
			}
			if (total - i < Min || total - i > Max) {
				continue;
			} else {
				if (num == 2) {
					if (2 * i != total && ConfirmList.indexOf(total - i) == -1) {
						TmpItem.add(i);
						TmpItem.add(total - i);
						AnalysisList.add(TmpItem);
						TmpItem = new ArrayList<Integer>(
								AnalysisList.get(AnalysisList.size() - 1));
						TmpItem.remove(TmpItem.size() - 1);
						TmpItem.remove(TmpItem.size() - 1);
					}
				} else {
					TmpItem.add(i);
					SubCut(total - i, num - 1, ConfirmList);
					TmpItem.remove(TmpItem.size() - 1);
				}
			}
		}
	}
}
