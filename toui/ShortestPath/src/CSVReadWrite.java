import java.io.File;
import java.io.FileReader;
import java.io.BufferedReader;
import java.io.IOException;
import java.util.ArrayList;

public class CSVReadWrite {
	//public ArrayList<ArrayList<String>> PointList = new ArrayList<ArrayList<String>>();
	//public ArrayList<ArrayList<String>> EdgeList = new ArrayList<ArrayList<String>>();

	public void CSVRead(ArrayList<ArrayList<String>> PointList,ArrayList<ArrayList<String>> EdgeList) {

		try {
			File f = new File("AdjacentPoints.csv");
			BufferedReader br = new BufferedReader(new FileReader(f));
			String line;
			ArrayList<String> PointListItem = new ArrayList<String>();
			ArrayList<String> EdgeListItem = new ArrayList<String>();
			while ((line = br.readLine()) != null) {
				String[] data = line.split(",", 0);

				for (int i = 0; i < data.length; i++) {
					if (i == 0 || i == data.length - 1) {
						PointListItem.add(data[i]);
					} else {
						EdgeListItem.add(data[i]);
					}
				}

				PointList.add(PointListItem);
				EdgeList.add(EdgeListItem);
				PointListItem = new ArrayList<String>();
				EdgeListItem = new ArrayList<String>();
			}
			br.close();

		} catch (IOException e) {
			System.out.println(e);
		}
	}

}
