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
			File ReadCSV = new File("AdjacentPoints.csv");
			BufferedReader br = new BufferedReader(new FileReader(ReadCSV));
			String line;

			while ((line = br.readLine()) != null) {
				ArrayList<String> EdgeListItem = new ArrayList<String>();
				String[] data = line.split(",", 0);

				for (int i = 0; i < data.length; i++) {
					if (i == 0) {
						Main.PointList.add(data[i]);
					} else {
						EdgeListItem.add(data[i]);
					}
				}

				Main.EdgeList.add(EdgeListItem);

			}
			br.close();

		} catch (IOException e) {
			System.out.println(e);
		}

		try {
			File ReadCSV = new File("NoTrespassing.csv");
			BufferedReader br = new BufferedReader(new FileReader(ReadCSV));
			String line;

			while ((line = br.readLine()) != null) {
				String[] data = line.split(",", 0);
				for (int i = 0; i < data.length; i++) {
					Main.NoTrespassingList.add(data[i]);
				}
			}
			br.close();

		} catch (IOException e) {
			System.out.println(e);
		}
	}

	public void PointWrite() {
		File file = new File("AdjacentPoints.csv");
		try {
			PrintWriter p_writer = new PrintWriter(
					new BufferedWriter(new OutputStreamWriter(new FileOutputStream(file), "utf-8")));

			for (int i = 0; i < Main.PointList.size(); i++) {
				if (Main.EdgeList.get(i).size() == 0) {
					p_writer.println(Main.PointList.get(i));
				} else {
					p_writer.print(Main.PointList.get(i) + ",");
					for (int j = 0; j < Main.EdgeList.get(i).size(); j++) {
						if (j != Main.EdgeList.get(i).size() - 1) {
							p_writer.print(Main.EdgeList.get(i).get(j) + ",");
						} else {
							p_writer.println(Main.EdgeList.get(i).get(j));
						}
					}
				}
			}
			p_writer.close();
		} catch (IOException e) {
			System.out.println(e);
		}

		File file1 = new File("NoTrespassing.csv");
		try {
			PrintWriter p_writer = new PrintWriter(
					new BufferedWriter(new OutputStreamWriter(new FileOutputStream(file1), "utf-8")));
			if (Main.NoTrespassingList.size() != 0) {
				for (int i = 0; i < Main.NoTrespassingList.size(); i++) {
					if (i == Main.NoTrespassingList.size() - 1) {
						p_writer.print(Main.NoTrespassingList.get(i));
					} else {
						p_writer.print(Main.NoTrespassingList.get(i) + ",");
					}
				}
			}
			p_writer.close();
		} catch (IOException e) {
			System.out.println(e);
		}
	}

	public void ShortestPathWrite(boolean OutputTypeCheck) {
		File file = new File("ShortestPath.csv");
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
		Path SourcePointPath = Paths.get("DefaultAdjacentPoints.csv");
		Path TargetPointPath = Paths.get("AdjacentPoints.csv");
		Path SourceShortestPath = Paths.get("DefaultShortestPath.csv");
		Path TargetShortestPath = Paths.get("ShortestPath.csv");
		Path SourceNoTrespassingPath = Paths.get("DefaultNoTrespassing.csv");
		Path TargetNoTrespassingPath = Paths.get("NoTrespassing.csv");
		try {
			Files.copy(SourcePointPath, TargetPointPath, StandardCopyOption.REPLACE_EXISTING);
			Files.copy(SourceShortestPath, TargetShortestPath, StandardCopyOption.REPLACE_EXISTING);
			Files.copy(SourceNoTrespassingPath, TargetNoTrespassingPath, StandardCopyOption.REPLACE_EXISTING);

		} catch (IOException e) {
			e.printStackTrace();
		}

	}

}
