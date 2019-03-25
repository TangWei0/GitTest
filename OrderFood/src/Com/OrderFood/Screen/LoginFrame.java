
package Com.OrderFood.Screen;

import Com.OrderFood.Listener.*;
import Com.OrderFood.Access.Access;
import Com.OrderFood.Access.LoginDao;
import Com.OrderFood.Data.*;
import Com.OrderFood.Data.Enum;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Container;
import java.awt.Insets;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.sql.SQLException;

import javax.swing.JFrame;
import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JPasswordField;
import javax.swing.JTextField;

public class LoginFrame extends JFrame {
    /**
	 * 
	 */
    private static final long serialVersionUID = 1L;
    JFrame LoginFrame = new JFrame ();
    JPanel Pan = new JPanel ();
    JLabel Title_lbl = new JLabel ( "ログイン処理", JLabel.CENTER );
    JLabel ID_lbl = new JLabel ( "ID：", JLabel.RIGHT );
    JLabel Password_lbl = new JLabel ( "パスワード：", JLabel.RIGHT );
    JTextField ID_fld = new JTextField ();
    JPasswordField Password_fld = new JPasswordField ();
    JButton Login_btn = new JButton ( "ログイン" );
    JButton Reset_btn = new JButton ( "リセット" );

    /**
     * Create the frame.
     * 
     * @return
     * @throws SQLException
     */

    LoginFrame ( String title ) {
        setVisible ( true );
        setTitle ( title );
        setSize ( Variable.FrameWidth, Variable.FrameHeight );
        setDefaultCloseOperation ( JFrame.EXIT_ON_CLOSE );
        Insets insets = this.getInsets ();

        JPanel p1 = new JPanel ();
        p1.setBackground ( Color.BLUE );

        JPanel p2 = new JPanel ();
        p2.setBackground ( Color.ORANGE );
        int weight = Variable.FrameWidth - insets.left - insets.right;
        int height = Variable.FrameHeight - insets.top - insets.bottom;
        Variable.statusBar.setSize ( weight, height / 20 );
        p2.add ( Variable.statusBar );

        Container contentPane = getContentPane ();
        contentPane.add ( p1, BorderLayout.NORTH );
        contentPane.add ( p2, BorderLayout.SOUTH );

        System.out.println ( insets.top + " " + insets.bottom + " " + insets.left + " " + insets.right );

    }

    /*FrameInit ();

    // BorderLayout = new BorderLayout ( 10, 5 );
    Container contentPane = getContentPane ();
    JPanel p2 = new JPanel ();
    p2.setBackground ( Color.ORANGE );
    p2.add ( statusBar );
    contentPane.add ( p2, BorderLayout.SOUTH );
    //        LoginFrame.addMouseListener ( new AddMouseListener () );
    //        LoginFrame.addWindowListener ( new AddWindowListener () );
    //        Login_btn.addActionListener ( new ButtonActionListener () );
    //        Reset_btn.addActionListener ( new ButtonActionListener () );
    }

    private void FrameInit () {

    int dx;
    int dy;

    LoginFrame.getContentPane ().setLayout ( new BorderLayout ( 10, 5 ) );
    LoginFrame.setSize ( Variable.FrameWidth, Variable.FrameHeight );
    LoginFrame.setDefaultCloseOperation ( JFrame.EXIT_ON_CLOSE );
    LoginFrame.setVisible ( true );
    LoginFrame.setResizable ( false );

    /*
    dx = Variable.UnitWidth * 7;
    dy = Variable.UnitHeight;
    Title_lbl.setBounds ( dx, dy, Variable.UnitWidth * 6, Variable.UnitHeight );

    dy = Variable.UnitHeight * 3;
    ID_lbl.setBounds ( dx, dy, Variable.UnitWidth * 2, Variable.UnitHeight );

    dx = Variable.UnitWidth * 9;
    ID_fld.setBounds ( dx, dy, Variable.UnitWidth * 4, Variable.UnitHeight );

    dx = Variable.UnitWidth * 7;
    dy = Variable.UnitHeight * 5;
    Password_lbl.setBounds ( dx, dy, Variable.UnitWidth * 2, Variable.UnitHeight );

    dx = Variable.UnitWidth * 9;
    Password_fld.setBounds ( dx, dy, Variable.UnitWidth * 4, Variable.UnitHeight );

    dx = Variable.UnitWidth * 7;
    dy = Variable.UnitHeight * 7;
    Login_btn.setBounds ( dx, dy, Variable.UnitWidth * 2, Variable.UnitHeight );

    dx = Variable.UnitWidth * 11;
    Reset_btn.setBounds ( dx, dy, Variable.UnitWidth * 2, Variable.UnitHeight );

    LoginFrame.getContentPane ().add ( Title_lbl );
    LoginFrame.getContentPane ().add ( ID_lbl );
    LoginFrame.getContentPane ().add ( ID_fld );
    LoginFrame.getContentPane ().add ( Password_lbl );
    LoginFrame.getContentPane ().add ( Password_fld );
    LoginFrame.getContentPane ().add ( Login_btn );
    LoginFrame.getContentPane ().add ( Reset_btn );
    LoginFrame.getContentPane ().add ( statusBar );
    */

    private boolean Login () {
        boolean Ret = true;

        Ret = LoginDao.getData ();
        if ( Ret ) {
            App.Log.WriteLogger ( "FINER", App.Log.getFileMethod () + " LoginDaoのデータ取得処理結果チェック：TRUE" );

            if ( Variable.User.getNames () != null ) {
                App.Log.WriteLogger ( "FINER", App.Log.getFileMethod () + " 入力したIDチェック：TRUE" );

                if ( Variable.Account.getPassword ().equals ( Variable.Password ) ) {
                    App.Log.WriteLogger ( "FINER", App.Log.getFileMethod () + " 入力したパスワードチェック：TRUE" );

                    if ( Variable.Status.getLoginStatus () ) {
                        if ( Variable.Status.getConnectTime () + Enum.TimerOut < System.currentTimeMillis () ) {
                            System.out.println ( "異常終了を判断しました。" );
                        } else {
                            System.out.println ( "既にログインしました。" );
                        }
                    } else {
                        App.Log.WriteLogger ( "INFO", App.Log.getFileMethod () + " Login成功" );
                    }
                } else {
                    App.Log.WriteLogger ( "WARNING", App.Log.getFileMethod () + " 入力したパスワードチェック：FALSE" );

                    JOptionPane.showMessageDialog ( null, "入力したパスワードが間違っています。" );
                    Reset_btn.doClick ();
                }
            } else {
                App.Log.WriteLogger ( "WARNING", App.Log.getFileMethod () + " 入力したIDチェック：FALSE" );

                JOptionPane.showMessageDialog ( null, "入力したIDが間違っています。" );
                Reset_btn.doClick ();
            }
        } else {
            App.Log.WriteLogger ( "SERVER", App.Log.getFileMethod () + " LoginDaoのデータ取得処理結果チェック：FALSE" );
            return Ret;
        }

        return Ret;
    }

    private class ButtonActionListener implements ActionListener {
        public void actionPerformed ( ActionEvent e ) {
            if ( Variable.NetworkStateResult.equals ( Enum.NetworkStateResult.DISCOVERED ) ) {
                if ( e.getSource () == Login_btn ) {
                    boolean Ret = true;

                    if ( ID_fld.getText ().length () == 0 ) {
                        JOptionPane.showMessageDialog ( null, "IDが未入力です。" );
                        Reset_btn.doClick ();
                        return;
                    } else {
                        if ( Password_fld.getPassword ().length == 0 ) {
                            JOptionPane.showMessageDialog ( null, "パスワードが未入力です。" );
                            Reset_btn.doClick ();
                            return;
                        } else {
                            // 何もしない。
                        }
                    }

                    Variable.ID = ID_fld.getText ();
                    Variable.Password = String.valueOf ( Password_fld.getPassword () );

                    Ret = Login ();
                    if ( Ret ) {
                        App.Log.WriteLogger ( "FINER", App.Log.getFileMethod () + " Login処理結果チェック：TRUE" );
                    } else {
                        App.Log.WriteLogger ( "SEVERE", App.Log.getFileMethod () + " Login処理結果チェック：NG" );

                        JOptionPane.showMessageDialog ( null, "異常が発生しました、アプリを終了します。" );
                        System.exit ( 0 );
                    }
                } else {
                    Variable.ID = null;
                    Variable.Password = null;
                    ID_fld.setText ( "" );
                    Password_fld.setText ( "" );
                    System.out.println ( "接続開始" );
                    Access.GetConnection ();
                }
            } else {
                // 何もしない
            }
        }
    }

}
