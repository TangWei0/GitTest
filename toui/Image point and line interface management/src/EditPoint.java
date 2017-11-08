
public class EditPoint {

	public void EditPointDelectEdge(String SelectPoint) {
		for (int i = 0; i < Main.EdgeList.size(); i++) {
			if (i != Main.PointList.indexOf(SelectPoint)) {
				int index = Main.EdgeList.get(i).indexOf(SelectPoint);
				if (index != -1) {
					Main.EdgeList.get(i).remove(index);
				}
			}
		}
	}
}
