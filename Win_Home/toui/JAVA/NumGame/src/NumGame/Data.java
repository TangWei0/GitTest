package NumGame;

import java.util.ArrayList;
import java.util.Collections;

public class Data {
	
	public ArrayList<Integer> DataUnion (ArrayList<ArrayList<Integer>> AnalysisList)
	{
		ArrayList<Integer> DataList = new ArrayList<Integer>();
		
		for (int i = 0; i < AnalysisList.size(); i++)
		{
			for (int value : AnalysisList.get(i))
			{
				if (DataList.indexOf(value) != -1)
				{
					continue;
				}
				DataList.add(value);
			}
		}
		Collections.sort(DataList);
		return DataList;
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
}
