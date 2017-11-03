import java.util.ArrayList;

public class ShortestPath {

	// static VertexFinishing VertexFinishing = new VertexFinishing();
	static CSVReadWrite CSVReadWrite = new CSVReadWrite();

	public static ArrayList<String> PointList = new ArrayList<String>();
	public static ArrayList<ArrayList<String>> EdgeList = new ArrayList<ArrayList<String>>();
	public static ArrayList<String> ImagePathList = new ArrayList<String>();

	public static ArrayList<ArrayList<String>> CurrentPathList = new ArrayList<ArrayList<String>>();
	public static ArrayList<ArrayList<String>> NextPathList = new ArrayList<ArrayList<String>>();

	public static ArrayList<String> TempItem = new ArrayList<String>();
	public static ArrayList<String> Item = new ArrayList<String>();
	public static ArrayList<String> UsedPointList = new ArrayList<String>();
	
	public static int ListCount = 0;
	public static int Count = 0;
	
	public static void main(String[] args) {
		long start = System.currentTimeMillis();
		
		CSVReadWrite.CSVRead(PointList, EdgeList, ImagePathList);

		for (int i = 0; i < PointList.size(); i++) {
			Default();
			TempItem.add(PointList.get(i));
			CurrentPathList.add(TempItem);
			TempItem = new ArrayList<String>();

			UsedPointList.add(PointList.get(i));

			while (Count < PointList.size()-1) {
				while (ListCount < CurrentPathList.size()) {
					Item = new ArrayList<String>(CurrentPathList.get(ListCount));
					SearchList(); 
					ListCount++;
				}

				CurrentPathList = new ArrayList<ArrayList<String>>(NextPathList);
				ListCount = 0;
			}
			
			System.out.println();
		}
		long end = System.currentTimeMillis();
		System.out.println((end - start) + "ms");

	}
	
	public static void Default() {
		CurrentPathList = new ArrayList<ArrayList<String>>();
		NextPathList = new ArrayList<ArrayList<String>>();

		TempItem = new ArrayList<String>();
		Item = new ArrayList<String>();
		UsedPointList = new ArrayList<String>();
		
		ListCount = 0;
		Count = 0;
	}

	public static void SearchList() {

		int index = PointList.indexOf(CurrentPathList.get(ListCount).get(CurrentPathList.get(ListCount).size() - 1));
		// 寻找下一个点
		for (int j = 0; j < EdgeList.get(index).size(); j++) {
			if (UsedPointList.indexOf(EdgeList.get(index).get(j)) == -1) {

				TempItem = new ArrayList<String>(Item);
				TempItem.add(EdgeList.get(index).get(j));
				NextPathList.add(TempItem);
				Count++;

				System.out.print(TempItem.get(0) + "→" + TempItem.get(TempItem.size() - 1) + ":");

				for (int k = 0; k < TempItem.size(); k++) {
					if (k != TempItem.size() - 1) {
						System.out.print(ImagePathList.get(PointList.indexOf(TempItem.get(k))) + ",");
					} else {
						System.out.println(ImagePathList.get(PointList.indexOf(TempItem.get(k))));
					}
				}

				UsedPointList.add(EdgeList.get(index).get(j));
			}
		}
	}

}
