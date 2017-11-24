import java.awt.BasicStroke;
import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Component;
import java.awt.Container;
import java.awt.Dimension;
import java.awt.FlowLayout;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.Toolkit;
import java.awt.image.BufferedImage;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;

public class GomokuGame extends JPanel {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	private static int LineNum = 19;
	private static int LatticeInterval = 25;
	private static int SmallStarSize = 8;

	private static int[][] chesses = new int[19][19];

	public static void main(String[] args) {
		GomokuGame GomokuGame = new GomokuGame();
		GomokuGame.initUI();
	}

	public void initUI() {
		JFrame jf = new JFrame();
		jf.setTitle("五子棋 by toui");
		jf.setSize(750, 600);
		jf.setLocationRelativeTo(null);

		jf.add(this, BorderLayout.CENTER);
		this.setBackground(Color.ORANGE);

		jf.setDefaultCloseOperation(3);
		this.setLayout(new FlowLayout());

		JPanel jp2 = new JPanel();
		jp2.setPreferredSize(new Dimension(150, 0));
		jp2.setBackground(Color.CYAN);

		// JButton jbuStart = new JButton("开始");
		// jbuStart.setPreferredSize(new Dimension(70, 70));

		JButton jbuReg = new JButton("悔棋");
		jbuReg.setPreferredSize(new Dimension(70, 50));

		JButton jbuR = new JButton("重来");
		jbuR.setPreferredSize(new Dimension(70, 50));

		JButton jbup2p = new JButton("双人");
		jbup2p.setPreferredSize(new Dimension(70, 70));

		JButton jbup2c = new JButton("人机");
		jbup2c.setPreferredSize(new Dimension(70, 70));

		JLabel la2 = new JLabel("当前执子：black");

		jp2.add(jbup2p);
		jp2.add(jbup2c);
		jp2.add(jbuReg);
		jp2.add(jbuR);
		// jp2.add(jbuStart);

		jp2.add(la2);

		jf.add(jp2, BorderLayout.EAST);

		jf.setVisible(true);

		// Graphics g = this.getGraphics();

		// ChessListener e = new ChessListener(g,chesses,this);
		// jbup2p.addActionListener(e);
		// jbup2c.addActionListener(e);
		// jbuReg.addActionListener(e);
		// jbuR.addActionListener(e);

	}

	/**
	 * 重写重绘方法
	 */
	public void paint(Graphics g) {
		// 调用父类的重绘窗体
		super.paint(g);
		// 重绘窗体的同时绘制棋盘和棋子
		drawChessTable(g);
		drawChesses(g);
	}

	// 画棋盘
	public void drawChessTable(Graphics g) {
		Graphics2D g2 = (Graphics2D) g;
		int X0 = 50;
		int Y0 = 50;
		g2.setColor(Color.BLACK);
		for (int i = 0; i < LineNum; i++) {
			if (i == 3 || i == 9 || i == 15) {
				g2.setStroke(new BasicStroke(3.0f));
			} else {
				g2.setStroke(new BasicStroke(1.0f));
			}
			g2.drawLine(X0, Y0 + i * LatticeInterval, X0 + (LineNum - 1) * LatticeInterval, Y0 + i * LatticeInterval);
		}
		for (int j = 0; j < LineNum; j++) {
			if (j == 3 || j == 9 || j == 15) {
				g2.setStroke(new BasicStroke(3.0f));
			} else {
				g2.setStroke(new BasicStroke(1.0f));
			}
			g2.drawLine(X0 + j * LatticeInterval, Y0, X0 + j * LatticeInterval, Y0 + (LineNum - 1) * LatticeInterval);
		}
		
		g2.fillOval(X0 + 3*LatticeInterval - (SmallStarSize/2), Y0 + 3*LatticeInterval - (SmallStarSize/2), SmallStarSize, SmallStarSize);
		g2.fillOval(X0 + 3*LatticeInterval - (SmallStarSize/2), Y0 + 9*LatticeInterval - (SmallStarSize/2), SmallStarSize, SmallStarSize);
		g2.fillOval(X0 + 3*LatticeInterval - (SmallStarSize/2), Y0 + 15*LatticeInterval - (SmallStarSize/2), SmallStarSize, SmallStarSize);
		g2.fillOval(X0 + 9*LatticeInterval - (SmallStarSize/2), Y0 + 3*LatticeInterval - (SmallStarSize/2), SmallStarSize, SmallStarSize);
		g2.fillOval(X0 + 9*LatticeInterval - (SmallStarSize/2), Y0 + 9*LatticeInterval - (SmallStarSize/2), SmallStarSize, SmallStarSize);
		g2.fillOval(X0 + 9*LatticeInterval - (SmallStarSize/2), Y0 + 15*LatticeInterval - (SmallStarSize/2), SmallStarSize, SmallStarSize);
		g2.fillOval(X0 + 15*LatticeInterval - (SmallStarSize/2), Y0 + 3*LatticeInterval - (SmallStarSize/2), SmallStarSize, SmallStarSize);
		g2.fillOval(X0 + 15*LatticeInterval - (SmallStarSize/2), Y0 + 9*LatticeInterval - (SmallStarSize/2), SmallStarSize, SmallStarSize);
		g2.fillOval(X0 + 15*LatticeInterval - (SmallStarSize/2), Y0 + 15*LatticeInterval - (SmallStarSize/2), SmallStarSize, SmallStarSize);
	}

	// 画棋子
	public void drawChesses(Graphics g) {
		for (int i = 0; i < chesses.length; i++) {
			for (int j = 0; j < chesses.length; j++) {
				if (chesses[i][j] == 1) {
					g.setColor(Color.BLACK);
					g.fillOval(50 + i * 5 - 5 / 2, 50 + j * 5 - 5 / 2, 5, 5);
				} else if (chesses[i][j] == 2) {
					g.setColor(Color.WHITE);
					g.fillOval(50 + i * 5 - 5 / 2, 50 + j * 5 - 5 / 2, 5, 5);
				}
			}
		}
	}

}
