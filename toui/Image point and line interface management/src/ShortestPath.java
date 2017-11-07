import java.util.ArrayList;

public class ShortestPath {

	static CSVReadWrite CSVReadWrite = new CSVReadWrite();

	public static ArrayList<ArrayList<String>> CurrentPathList = new ArrayList<ArrayList<String>>();
	public static ArrayList<ArrayList<String>> NextPathList = new ArrayList<ArrayList<String>>();

	public static ArrayList<String> TempItem = new ArrayList<String>();
	public static ArrayList<String> Item = new ArrayList<String>();
	public static ArrayList<String> UsedPointList = new ArrayList<String>();
	public static ArrayList<String> UnusedPointList = new ArrayList<String>();

	public static int ListCount = 0;
	public static int Count = 0;
	public static boolean NextNodeCheck = true;
	public static boolean OutputTypeCheck = false;

	static String WriteData = "";

	public void shortestPath() {
		OutputTypeCheck = false;
		for (int i = 0; i < Main.PointList.size(); i++) {
			Default();
			TempItem.add(Main.PointList.get(i));
			CurrentPathList.add(TempItem);
			TempItem = new ArrayList<String>();

			UsedPointList.add(Main.PointList.get(i));
			UnusedPointList.remove(i);

			Count++;

			while (Count < Main.PointList.size()) {
				if (NextNodeCheck == true) {
					NextNodeCheck = false;
					while (ListCount < CurrentPathList.size()) {
						Item = new ArrayList<String>(CurrentPathList.get(ListCount));
						SearchList();
						ListCount++;
					}
					CurrentPathList = new ArrayList<ArrayList<String>>(NextPathList);
					ListCount = 0;
				} else {
					WriteData = "";
					WriteData = Main.PointList.get(i) + "→" + UnusedPointList.get(0) + ", 安全なルードが存在しません、近くの係員にご連絡ください";

					CSVReadWrite.ShortestPathWrite(OutputTypeCheck);
					if (OutputTypeCheck != true)
					{
						OutputTypeCheck = true;
					}

					UsedPointList.add(UnusedPointList.get(0));
					UnusedPointList.remove(0);
					Count++;
				}
			}
		}
	}

	public static void Default() {
		CurrentPathList = new ArrayList<ArrayList<String>>();
		NextPathList = new ArrayList<ArrayList<String>>();

		TempItem = new ArrayList<String>();
		Item = new ArrayList<String>();
		UsedPointList = new ArrayList<String>();
		UnusedPointList = new ArrayList<String>(Main.PointList);

		ListCount = 0;
		Count = 0;
		NextNodeCheck = true;
	}

	public static void SearchList() {

		int index = Main.PointList.indexOf(CurrentPathList.get(ListCount).get(CurrentPathList.get(ListCount).size() - 1));
		// 寻找下一个点
		for (int j = 0; j < Main.EdgeList.get(index).size(); j++) {
			if (UsedPointList.indexOf(Main.EdgeList.get(index).get(j)) == -1) {
				WriteData = "";
				TempItem = new ArrayList<String>(Item);
				TempItem.add(Main.EdgeList.get(index).get(j));
				NextPathList.add(TempItem);
				Count++;

				if (NextNodeCheck == false) {
					NextNodeCheck = true;
				}

				WriteData = TempItem.get(0) + "→" + TempItem.get(TempItem.size() - 1) + ",";
				for (int k = 0; k < TempItem.size() - 1; k++) {
					WriteData += TempItem.get(k) + "-" + TempItem.get(k + 1) ;
					if (k != TempItem.size() - 2) {
						WriteData +=  ",";
					} 
				}

				UsedPointList.add(Main.EdgeList.get(index).get(j));
				UnusedPointList.remove(Main.EdgeList.get(index).get(j));

				CSVReadWrite.ShortestPathWrite(OutputTypeCheck);
				if (OutputTypeCheck != true)
				{
					OutputTypeCheck = true;
				}
				
			}
		}
	}
}
