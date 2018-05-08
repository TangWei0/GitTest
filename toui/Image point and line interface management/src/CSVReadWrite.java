import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.IOException;
import java.io.OutputStreamWriter;
import java.io.PrintWriter;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardCopyOption;
import java.util.ArrayList;

public class CSVReadWrite {

	public void PointRead() {
		try {
			File ReadCSV = new File("/Library/WebServer/Documents/doutai/AdjacentPoints.csv");
			BufferedReader br = new BufferedReader(new FileReader(ReadCSV));
			String PointLine;

			while ((PointLine = br.readLine()) != null) {
				ArrayList<String> EdgeListItem = new ArrayList<String>();
				String[] PointData = PointLine.split(",", 0);

				for (int i = 0; i < PointData.length; i++) {
					if (i == 0) {
						Main.PointList.add(PointData[i]);
					} else {
						EdgeListItem.add(PointData[i]);
					}
				}

				Main.EdgeList.add(EdgeListItem);

			}
			br.close();

		} catch (IOException e) {
			System.out.println(e);
		}

		try {
			File ReadCSV = new File("/Library/WebServer/Documents/doutai/NoTrespassing.csv");
			BufferedReader br = new BufferedReader(new FileReader(ReadCSV));
			String NoTrespassingLine;

			while ((NoTrespassingLine = br.readLine()) != null) {
				String[] NoTrespassingData = NoTrespassingLine.split(",", 0);
				for (int j = 0; j < NoTrespassingData.length; j++) {
					Main.NoTrespassingList.add(NoTrespassingData[j]);
				}
			}
			br.close();

		} catch (IOException e) {
			System.out.println(e);
		}
	}

	public void PointWrite() {
		File file = new File("/Library/WebServer/Documents/doutai/AdjacentPoints.csv");
		try {
			PrintWriter Point_writer = new PrintWriter(
					new BufferedWriter(new OutputStreamWriter(new FileOutputStream(file), "utf-8")));

			for (int i = 0; i < Main.PointList.size(); i++) {
				if (Main.EdgeList.get(i).size() == 0) {
					Point_writer.println(Main.PointList.get(i));
				} else {
					Point_writer.print(Main.PointList.get(i) + ",");
					for (int j = 0; j < Main.EdgeList.get(i).size(); j++) {
						if (j != Main.EdgeList.get(i).size() - 1) {
							Point_writer.print(Main.EdgeList.get(i).get(j) + ",");
						} else {
							Point_writer.println(Main.EdgeList.get(i).get(j));
						}
					}
				}
			}
			Point_writer.close();
		} catch (IOException e) {
			System.out.println(e);
		}

		File file1 = new File("/Library/WebServer/Documents/doutai/NoTrespassing.csv");
		try {
			PrintWriter NoTrespassing_writer = new PrintWriter(
					new BufferedWriter(new OutputStreamWriter(new FileOutputStream(file1), "utf-8")));
			if (Main.NoTrespassingList.size() != 0) {
				for (int j = 0; j < Main.NoTrespassingList.size(); j++) {
					if (j == Main.NoTrespassingList.size() - 1) {
						NoTrespassing_writer.print(Main.NoTrespassingList.get(j));
					} else {
						NoTrespassing_writer.print(Main.NoTrespassingList.get(j) + ",");
					}
				}
			}
			NoTrespassing_writer.close();
		} catch (IOException e) {
			System.out.println(e);
		}
	}

	public void ShortestPathWrite(boolean OutputTypeCheck) {
		File file = new File("/Library/WebServer/Documents/doutai/ShortestPath.csv");
		PrintWriter p_writer;
		try {

			if (OutputTypeCheck == true) {
				p_writer = new PrintWriter(
						new BufferedWriter(new OutputStreamWriter(new FileOutputStream(file, true), "utf-8")));
			} else {
				p_writer = new PrintWriter(
						new BufferedWriter(new OutputStreamWriter(new FileOutputStream(file), "utf-8")));
			}

			p_writer.println(ShortestPath.WriteData);

			p_writer.close();
		} catch (IOException e) {
			System.out.println(e);
		}
	}

	public void CopyFile() {
		Path SourcePointPath = Paths.get("/Library/WebServer/Documents/doutai/DefaultAdjacentPoints.csv");
		Path TargetPointPath = Paths.get("/Library/WebServer/Documents/doutai/AdjacentPoints.csv");
		Path SourceShortestPath = Paths.get("/Library/WebServer/Documents/doutai/DefaultShortestPath.csv");
		Path TargetShortestPath = Paths.get("/Library/WebServer/Documents/doutai/ShortestPath.csv");
		Path SourceNoTrespassingPath = Paths.get("/Library/WebServer/Documents/doutai/DefaultNoTrespassing.csv");
		Path TargetNoTrespassingPath = Paths.get("/Library/WebServer/Documents/doutai/NoTrespassing.csv");
		try {
			Files.copy(SourcePointPath, TargetPointPath, StandardCopyOption.REPLACE_EXISTING);
			Files.copy(SourceShortestPath, TargetShortestPath, StandardCopyOption.REPLACE_EXISTING);
			Files.copy(SourceNoTrespassingPath, TargetNoTrespassingPath, StandardCopyOption.REPLACE_EXISTING);

		} catch (IOException e) {
			e.printStackTrace();
		}

	}

}
