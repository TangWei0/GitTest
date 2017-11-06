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
	public static boolean Check = true;

	static String RootPath = "http://192.168.100.107/output/";
	static String WriteData = "";
	static String WriteName = "";

	public void shortestPath() {
		for (int i = 0; i < Main.PointList.size(); i++) {
			Default();
			TempItem.add(Main.PointList.get(i));
			CurrentPathList.add(TempItem);
			TempItem = new ArrayList<String>();

			UsedPointList.add(Main.PointList.get(i));
			UnusedPointList.remove(i);

			Count++;

			while (Count < Main.PointList.size()) {
				if (Check == true) {
					Check = false;
					while (ListCount < CurrentPathList.size()) {
						Item = new ArrayList<String>(CurrentPathList.get(ListCount));
						SearchList();
						ListCount++;
					}
					CurrentPathList = new ArrayList<ArrayList<String>>(NextPathList);
					ListCount = 0;
				} else {
					WriteData = "";
					System.out.println(Main.PointList.get(i) + "→" + UnusedPointList.get(0) + ": ルートが存在しません。");
					WriteData = Main.PointList.get(i) + "→" + UnusedPointList.get(0) + ": ルートが存在しません。";

					CSVReadWrite.CSVWrite(WriteName);

					UsedPointList.add(UnusedPointList.get(0));
					UnusedPointList.remove(0);
					Count++;
				}
			}

			System.out.println();
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
		Check = true;
	}

	public static void SearchList() {

		int index = Main.PointList
				.indexOf(CurrentPathList.get(ListCount).get(CurrentPathList.get(ListCount).size() - 1));
		// 寻找下一个点
		for (int j = 0; j < Main.EdgeList.get(index).size(); j++) {
			if (UsedPointList.indexOf(Main.EdgeList.get(index).get(j)) == -1) {
				WriteData = "";
				TempItem = new ArrayList<String>(Item);
				TempItem.add(Main.EdgeList.get(index).get(j));
				NextPathList.add(TempItem);
				Count++;

				if (Check == false) {
					Check = true;
				}

				System.out.print(TempItem.get(0) + "→" + TempItem.get(TempItem.size() - 1) + ":");
				WriteName = TempItem.get(0) + "_" + TempItem.get(TempItem.size() - 1) + ".txt";
				for (int k = 0; k < TempItem.size() - 1; k++) {
					if (k != TempItem.size() - 2) {
						System.out.print(RootPath + TempItem.get(k) + "-" + TempItem.get(k + 1) + ".html" + ",");
						WriteData += RootPath + TempItem.get(k) + "-" + TempItem.get(k + 1) + ".html" + ",";
					} else {
						System.out.println(RootPath + TempItem.get(k) + "-" + TempItem.get(k + 1) + ".html");
						WriteData += RootPath + TempItem.get(k) + "-" + TempItem.get(k + 1) + ".html";
					}
				}

				UsedPointList.add(Main.EdgeList.get(index).get(j));
				UnusedPointList.remove(Main.EdgeList.get(index).get(j));

				CSVReadWrite.CSVWrite(WriteName);
			}
		}
	}
}
