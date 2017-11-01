import java.util.ArrayList;

public class VertexFinishing {
	static int notConnected = 999999;
	static int standStill = 0;

	CSVReadWrite csv = new CSVReadWrite();

	public ArrayList<ArrayList<Integer>> vertexPathList = new ArrayList<ArrayList<Integer>>();
	public ArrayList<Integer> item = new ArrayList<Integer>();

	public void VertexPathList() {
		csv.CSVRead();

		for (int i = 0; i < csv.list.size(); i++) {
			for (int j = 0; j < csv.list.size(); j++) {
				if (i == j) {
					item.add(standStill);
				} else {
					int k = csv.list.get(i).indexOf(String.valueOf(j+1));
					if (k == -1) {
						item.add(notConnected);
					}else{
						item.add(j+1);
					}
				}
			}
			vertexPathList.add(item);
			item = new ArrayList<Integer>();
		}

	}
}
