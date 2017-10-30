import java.util.ArrayList;

public class ShortestPath {
	

	public static void main(String[] args) {
		// TODO 自動生成されたメソッド・スタブ
		Data Data1 = new Data(1,"2",<1,3>[4,5]);
	}

	class Data {
		int num;
		String path;
		ArrayList<Integer> phase;
		int[] motherVertices;

		Data(int num, String path, ArrayList<Integer> phase, int[] motherVertices) {
			this.num = num;
			this.path = path;
			this.phase = phase;
			this.motherVertices = motherVertices;
		}

		void greet() {
			System.out.println(this.num);
			System.out.println(this.path);

			for (int tmp : this.phase) {
				System.out.println(tmp);
			}

			System.out.print(this.motherVertices[0]);
			System.out.print(this.motherVertices[1]);
		}

	}
}
