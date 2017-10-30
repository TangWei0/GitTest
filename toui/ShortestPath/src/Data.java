import java.util.ArrayList;

public class Data {

	int num;
	String path;
	ArrayList<Integer> phase;
	int[] motherVertices;
	
	Data(int num, String path, ArrayList<Integer> phase, int[] motherVertices)
	{
		this.num = num;
		this.path = path;
		this.phase = phase;
		this.motherVertices = motherVertices;
	}
	
	void greet ()
	{
		System.out.println(this.num);
		System.out.println(this.path);
		
		for (int tmp : this.phase) {
			System.out.println(tmp);
		}
		
		System.out.print(this.motherVertices[0]);
		System.out.print(this.motherVertices[1]);
	}
	
}
