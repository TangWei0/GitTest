import java.util.ArrayList;

public class ShortestPath {

	static VertexFinishing VertexFinishing = new VertexFinishing();
	//static CSVReadWrite csv = new CSVReadWrite();
	//static ArrayList<ArrayList<Integer>> list = new ArrayList<ArrayList<Integer>>();
	
	public static void main(String[] args) {
		VertexFinishing.VertexPathList();
		for (int i= 0;i<VertexFinishing.vertexPathList.size();i++)
		{
			for (int j = 0;j<VertexFinishing.vertexPathList.get(i).size();j++)
			{
				System.out.print(VertexFinishing.vertexPathList.get(i).get(j));
				
				if (j < VertexFinishing.vertexPathList.get(i).size()-1)
				{
				    System.out.print(",");
				}
			}
			System.out.println();
		}
	}
}
