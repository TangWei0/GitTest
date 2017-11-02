import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;

public class CSVReadWrite {

	public void CSVRead(ArrayList<String> PointList, ArrayList<ArrayList<String>> EdgeList,
			ArrayList<String> ImagePathList) {

		try {
			File f = new File("AdjacentPoints.csv");
			BufferedReader br = new BufferedReader(new FileReader(f));
			String line;
			ArrayList<String> EdgeListItem = new ArrayList<String>();
			while ((line = br.readLine()) != null) {
				String[] data = line.split(",", 0);

				for (int i = 0; i < data.length; i++) {
					if (i == 0) {
						PointList.add(data[i]);
					} else if (i == data.length - 1) {
						ImagePathList.add(data[i]);
					} else {
						EdgeListItem.add(data[i]);
					}
				}

				EdgeList.add(EdgeListItem);
				EdgeListItem = new ArrayList<String>();
			}
			br.close();

		} catch (IOException e) {
			System.out.println(e);
		}
	}

}
