import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;
import org.apache.commons.net.ftp.FTPClient;
import org.apache.commons.net.ftp.FTPReply;

public class CUploadFileClient {

	public boolean uploadFile(String url, // FTP服务器hostname
			int port, // FTP服务器端口
			String username, // FTP登录账号
			String password, // FTP登录密码
			String path, // FTP服务器保存目录
			String filename, // 上传到FTP服务器上的文件名
			InputStream input // 输入流
	) {
		boolean success = false;
		FTPClient ftp = new FTPClient();
		ftp.setControlEncoding("utf-8");
		try {
			int reply;
			ftp.connect(url, port);// 连接FTP服务器
			// 如果采用默认端口，可以使用ftp.connect(url)的方式直接连接FTP服务器
			ftp.login(username, password);// 登录
			reply = ftp.getReplyCode();
			if (!FTPReply.isPositiveCompletion(reply)) {
				ftp.disconnect();
				return success;
			}
			ftp.setFileType(FTPClient.BINARY_FILE_TYPE);
			ftp.makeDirectory(path);
			ftp.changeWorkingDirectory(path);
			ftp.storeFile(filename, input);
			input.close();
			ftp.logout();
			success = true;
		} catch (IOException e) {
			e.printStackTrace();
		} finally {
			if (ftp.isConnected()) {
				try {
					ftp.disconnect();
				} catch (IOException ioe) {
				}
			}
		}
		return success;
	}

	/**
	 * 将本地文件上传到FTP服务器上 *
	 */
	public void upLoadFromProduction() {
		String url = "192.168.3.10"; // FTP服务器hostname
		int port = 11111;// FTP服务器端口
		String username = "toui"; // FTP登录账号
		String password = "tang0722"; // FTP登录密码
		String path = "test"; // FTP服务器保存目录
		String filename = "test.csv"; // 上传到FTP服务器上的文件名
		String orginfilename = "ShortestPath.csv";// 输入流文件名
		try {
			FileInputStream in = new FileInputStream(new File(orginfilename));
			boolean flag = uploadFile(url, port, username, password, path, filename, in);
			System.out.println(flag);
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}