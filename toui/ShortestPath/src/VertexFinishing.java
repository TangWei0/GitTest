import java.util.ArrayList;

public class VertexFinishing {
	static int notConnected = 999999;
	static int standStill = 0;

	public ArrayList<ArrayList<Integer>> VertexEdgeList(ArrayList<ArrayList<String>> PointList,
			ArrayList<ArrayList<String>> EdgeList) {
		ArrayList<ArrayList<Integer>> VertexEdgeList = new ArrayList<ArrayList<Integer>>();
		for (int i = 0; i < PointList.size(); i++) {
			ArrayList<Integer> item = new ArrayList<Integer>();
			for (int j = 0; j < PointList.size(); j++) {
				if (i != j) {
					int k = EdgeList.get(i).indexOf(PointList.get(j).get(0));
					if (k == -1) {
						item.add(notConnected);
					} else {
						item.add(1);
					}
				}
			}
			VertexEdgeList.add(item);
		}

		return VertexEdgeList;
	}
}
