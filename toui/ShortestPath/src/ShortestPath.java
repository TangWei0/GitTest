import java.util.ArrayList;

public class ShortestPath {

	//static VertexFinishing VertexFinishing = new VertexFinishing();
	static CSVReadWrite CSVReadWrite = new CSVReadWrite();

	public static ArrayList<String> PointList = new ArrayList<String>();
	public static ArrayList<ArrayList<String>> EdgeList = new ArrayList<ArrayList<String>>();
	public static ArrayList<String> ImagePathList = new ArrayList<String>();
	//public static ArrayList<ArrayList<Integer>> VertexEdgeList = new ArrayList<ArrayList<Integer>>();

	public static void path()
	{
		
	}
	
	
	public static void main(String[] args) {
		long start = System.currentTimeMillis();

		CSVReadWrite.CSVRead(PointList, EdgeList, ImagePathList);
		
		ArrayList<ArrayList<String>> PathList = new ArrayList<ArrayList<String>>();
		ArrayList<String> Item = new ArrayList<String>();
		ArrayList<String> UnusedPointList = new ArrayList<String>(PointList);
		
		for (int i=0; i<PointList.size(); i++)
		{
			UnusedPointList.remove(UnusedPointList.indexOf(PointList.get(i)));
			
			for (int j=0; j<EdgeList.get(i).size();j++)
			{
				UnusedPointList.remove(UnusedPointList.indexOf(EdgeList.get(i).get(j)));
				
				Item.add(PointList.get(i));
				Item.add(EdgeList.get(i).get(j));
				
				PointList.get(i);
				Item.add(EdgeList.get(0).get(i));
			}
			System.out.println(UnusedPointList.get(i));
		}
		
		for (int i=0;i<EdgeList.get(0).size();i++)
		{
			Item.add(EdgeList.get(0).get(i));
		}

		long end = System.currentTimeMillis();
		System.out.println((end - start) + "ms");
	}

}
