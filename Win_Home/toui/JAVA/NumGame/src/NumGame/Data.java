package NumGame;

import java.util.ArrayList;
import java.util.Collections;


public class Data {
	public int HorizontalTotal;
	public int LongitudinalTotal;

	public void DataConversion (String ReadData) {
		double subData = Double.valueOf(ReadData);
		LongitudinalTotal = (int) subData;
		HorizontalTotal = (int) ((subData * 100) % 100);
	}
	
	public ArrayList<Integer> DataUnion (ArrayList<ArrayList<Integer>> Group)
	{
		ArrayList<Integer> DataList = new ArrayList<Integer>();
		
		for (int i = 0; i < Group.size(); i++)
		{
			for (int value : Group.get(i))
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
	
	public ArrayList<Integer> DataIntersection (ArrayList<Integer> HorizontalNum, ArrayList<Integer> LongitudinalNum)
	{
		ArrayList<Integer> DataList = new ArrayList<Integer>();
		for (int value : HorizontalNum)
		{
			if (LongitudinalNum.indexOf(value) != -1)
			{
				DataList.add(value);
			}
		}
		Collections.sort(DataList);
		return DataList;
	}
}
