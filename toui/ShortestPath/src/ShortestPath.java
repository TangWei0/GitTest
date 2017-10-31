import java.util.ArrayList;

public class ShortestPath {

	static CSVReadWrite csv = new CSVReadWrite();
	static ArrayList<ArrayList<Integer>> list = new ArrayList<ArrayList<Integer>>();
	
	public static void main(String[] args) {
		list = csv.CSVRead();
		for (int i= 0;i<list.size();i++)
		{
			for (int j = 0;j<list.get(i).size();j++)
			{
				System.out.print(list.get(i).get(j));
				
				if (j < list.get(i).size()-1)
				{
				    System.out.print(",");
				}
			}
			System.out.println();
		}
	}
}
