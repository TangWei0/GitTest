
package Com.OrderFood.Screen;

import Com.OrderFood.Listener.*;
import Com.OrderFood.Access.LoginDao;
import Com.OrderFood.Data.*;

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
    public void FrameStart () {
        FrameInit ();
        LoginFrame.addMouseListener ( new AddMouseListener () );
        LoginFrame.addWindowListener ( new AddWindowListener () );
        Login_btn.addActionListener ( new ButtonActionListener () );
        Reset_btn.addActionListener ( new ButtonActionListener () );
    }

    private void FrameInit () {
        int dx;
        int dy;
        LoginFrame.getContentPane ().setLayout ( null );
        LoginFrame.setSize ( Variable.FrameWidth, Variable.FrameHeight );
        LoginFrame.setDefaultCloseOperation ( JFrame.EXIT_ON_CLOSE );
        LoginFrame.setVisible ( true );
        LoginFrame.setResizable ( false );

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
    }

    private boolean Login () {
        boolean Ret = StaticVariable.LOG_JOB_OK;

        Ret = LoginDao.getData ();
        if ( Ret ) {
            App.Log.WriteLogger ( "FINER", App.Log.getFileMethod () + " LoginDaoのデータ取得処理結果チェック：TRUE" );

            if ( Variable.User.getNames () != null ) {
                App.Log.WriteLogger ( "FINER", App.Log.getFileMethod () + " 入力したIDチェック：TRUE" );

                if ( Variable.Account.getPassword ().equals ( Variable.Password ) ) {
                    App.Log.WriteLogger ( "FINER", App.Log.getFileMethod () + " 入力したパスワードチェック：TRUE" );

                    if ( ( Variable.Status.getLoginStatus () ) && ( Variable.Status.getExitStatus () ) ) {
                        App.Log.WriteLogger ( "WARNING", App.Log.getFileMethod () + " 重複ログインチェック：FALSE" );

                        JOptionPane.showMessageDialog ( null, "既にログインしました。" );
                        Reset_btn.doClick ();
                    } else {
                        System.out.println ( "ログイン成功" );
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
        /*
                Ret = Status.getDBLoginStatus ();
                if ( Ret ) {
                    App.Log.WriteLogger ( "FINER", App.Log.getFileMethod ()
                            + " DBのLoginStatus取得処理結果チェック：TRUE" );

                    if ( Variable.Status.getLoginStatusSize () == 1 ) {
                        App.Log.WriteLogger ( "FINER", App.Log.getFileMethod ()
                                + " DBのLoginStatus取得結果数チェック：1個" );

                        if ( !Variable.Status.getLoginStatus ( 0 ) ) {
                            App.Log.WriteLogger ( "FINER", App.Log.getFileMethod ()
                                    + " DBのLoginStatus取得結果チェック：OK" );
                        } else {
                            App.Log.WriteLogger ( "WARNING", App.Log.getFileMethod ()
                                    + " DBのLoginStatus取得結果チェック：NG" );

                            JOptionPane.showMessageDialog ( null, "既にログインしました。" );
                            Reset_btn.doClick ();
                        }
                    } else {
                        App.Log.WriteLogger ( "WARNING", App.Log.getFileMethod ()
                                + " DBのLoginStatus取得結果数チェック：1個ではない" );

                        JOptionPane.showMessageDialog ( null, "入力したIDが間違っています。" );
                        Reset_btn.doClick ();
                    }
                } else {
                    App.Log.WriteLogger ( "SERVER", App.Log.getFileMethod ()
                            + " DBのLoginStatus取得処理結果チェック：FALSE" );
                    return Ret;
                }
        /*
                Ret = Account.getDBPassword ();
                if ( Ret ) {
                    App.Log.WriteLogger ( "FINER", App.Log.getFileMethod ()
                            + " DBのPassword取得処理結果チェック：TRUE" );

                    if ( Variable.Account.getPasswordSize () == 1 ) {
                        App.Log.WriteLogger ( "FINER", App.Log.getFileMethod ()
                                + " DBのPassword取得結果数チェック：1個" );

                        if ( Variable.Account.getPassword ( 0 ).equals ( Variable.Password ) ) {
                            App.Log.WriteLogger ( "FINER", App.Log.getFileMethod ()
                                    + " DBのPassword取得結果チェック：TRUE" );
                        } else {
                            App.Log.WriteLogger ( "WARNING", App.Log.getFileMethod ()
                                    + " DBのPassword取得結果チェック：FALSE" );

                            JOptionPane.showMessageDialog ( null, "入力したパスワードが間違っています。" );
                            Reset_btn.doClick ();
                        }
                    } else {
                        App.Log.WriteLogger ( "WARNING", App.Log.getFileMethod ()
                                + " DBのPassword取得結果数チェック：1個ではない" );

                        JOptionPane.showMessageDialog ( null, "入力したIDが間違っています。" );
                        Reset_btn.doClick ();
                    }
                } else {
                    App.Log.WriteLogger ( "SERVER", App.Log.getFileMethod ()
                            + " DBのPassword取得処理結果チェック：FALSE" );
                    return Ret;
                }
        */
        return Ret;
    }

    private class ButtonActionListener implements ActionListener {
        public void actionPerformed ( ActionEvent e ) {
            if ( e.getSource () == Login_btn ) {
                boolean Ret = StaticVariable.LOG_JOB_OK;

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
            }
        }
    }

}
