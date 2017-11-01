import java.util.ArrayList;

public class ShortestPath {

	static VertexFinishing VertexFinishing = new VertexFinishing();
	static CSVReadWrite CSVReadWrite = new CSVReadWrite();
	// static ArrayList<ArrayList<Integer>> list = new
	// ArrayList<ArrayList<Integer>>();

	public static ArrayList<ArrayList<String>> PointList = new ArrayList<ArrayList<String>>();
	public static ArrayList<ArrayList<String>> EdgeList = new ArrayList<ArrayList<String>>();
	public static ArrayList<ArrayList<Integer>> VertexEdgeList = new ArrayList<ArrayList<Integer>>();

	public static void main(String[] args) {
		long start = System.currentTimeMillis();

		CSVReadWrite.CSVRead(PointList, EdgeList);
		VertexEdgeList = VertexFinishing.VertexEdgeList(PointList, EdgeList);

		
		for (int i = 0; i < VertexEdgeList.size(); i++) {
			ArrayList<String> UsedPointList = new ArrayList<String>();
			UsedPointList.add(PointList.get(i).get(0));
			int floor = 0;
			
			for (int j = 0; j < VertexEdgeList.size(); j++) {
				if (i!=j)
				{
					if (VertexEdgeList.get(i).get(j) == 1)
					{
						//TODO输出最短路径
						System.out.println(PointList.get(i).get(0) + PointList.get(j).get(0));
						UsedPointList.add(PointList.get(j).get(0));
					}
					else
					{
						
					}
				}
			}
			System.out.println();
		}

		long end = System.currentTimeMillis();
		System.out.println((end - start) + "ms");
	}
}
