import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.OutputStreamWriter;
import java.util.ArrayList;

public class CSVReadWrite {

	public void CSVRead(ArrayList<String> PointList, ArrayList<ArrayList<String>> EdgeList, ArrayList<String> ImagePathList) {
		try {
			File ReadCSV = new File("AdjacentPoints.csv");
			BufferedReader br = new BufferedReader(new FileReader(ReadCSV));
			String line;
			
			while ((line = br.readLine()) != null) {
				ArrayList<String> EdgeListItem = new ArrayList<String>();
				String[] data = line.split(",", 0);

				for (int i = 0; i < data.length; i++) {
					if (i == 0) {
						PointList.add(data[i]);
					} else {
						EdgeListItem.add(data[i]);
					}
				}

				EdgeList.add(EdgeListItem);
				
			}
			br.close();

		} catch (IOException e) {
			System.out.println(e);
		}
	}

	public void CSVWrite(String WriteName) {
	    try {
	        File f = new File(WriteName);
	        BufferedWriter bw = new BufferedWriter(new FileWriter(f,true));

	        bw.write(ShortestPath.WriteData);
	        bw.newLine();

	        bw.close();
	      } catch (IOException e) {
	        System.out.println(e);
	      }
	}
}
