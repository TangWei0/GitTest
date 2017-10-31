import java.io.File;
import java.io.FileReader;
import java.io.BufferedReader;
import java.io.IOException;
import java.util.ArrayList;

public class CSVReadWrite {
	public ArrayList<ArrayList<String>> list = new ArrayList<ArrayList<String>>();
	public ArrayList<String> item = new ArrayList<String>();
	
	public void CSVRead() {
	
		try {
			File f = new File("AdjacentPoints.csv");
			BufferedReader br = new BufferedReader(new FileReader(f));
			String line;
			// 1行ずつCSVファイルを読み込む
			while ((line = br.readLine()) != null) {
				String[] data = line.split(",", 0);// 行をカンマ区切りで配列に変換

				for (int i = 0; i < data.length; i++) {
					item.add(data[i]);
				}

				list.add(item);
				item = new ArrayList<String>();
			}
			br.close();

		} catch (IOException e) {
			System.out.println(e);
		}

		//eturn list;
	}

}
