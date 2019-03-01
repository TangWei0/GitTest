
package Com.OrderFood.Screen;

import Com.OrderFood.Listener.*;
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

public class OrderFoodFrame extends JFrame {
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
    public void LoginFrame () {

        FrameInit ();
        LoginFrame.addMouseListener ( new OrderFoodMouseListener () );
        LoginFrame.addWindowListener ( new OrderFoodWindowListener () );
        Login_btn.addActionListener ( new ButtonActionListener () );
        Reset_btn.addActionListener ( new ButtonActionListener () );
    }

    private void FrameInit () {
        int dx;
        int dy;
        LoginFrame.getContentPane ().setLayout ( null );
        LoginFrame.setSize ( OrderFoodVariable.FrameWidth, OrderFoodVariable.FrameHeight );
        LoginFrame.setDefaultCloseOperation ( JFrame.EXIT_ON_CLOSE );
        LoginFrame.setVisible ( true );
        LoginFrame.setResizable ( false );

        dx = OrderFoodVariable.UnitWidth * 7;
        dy = OrderFoodVariable.UnitHeight;
        Title_lbl.setBounds ( dx, dy, OrderFoodVariable.UnitWidth * 6, OrderFoodVariable.UnitHeight );

        dy = OrderFoodVariable.UnitHeight * 3;
        ID_lbl.setBounds ( dx, dy, OrderFoodVariable.UnitWidth * 2, OrderFoodVariable.UnitHeight );

        dx = OrderFoodVariable.UnitWidth * 9;
        ID_fld.setBounds ( dx, dy, OrderFoodVariable.UnitWidth * 4, OrderFoodVariable.UnitHeight );

        dx = OrderFoodVariable.UnitWidth * 7;
        dy = OrderFoodVariable.UnitHeight * 5;
        Password_lbl.setBounds ( dx, dy, OrderFoodVariable.UnitWidth * 2, OrderFoodVariable.UnitHeight );

        dx = OrderFoodVariable.UnitWidth * 9;
        Password_fld.setBounds ( dx, dy, OrderFoodVariable.UnitWidth * 4, OrderFoodVariable.UnitHeight );

        dx = OrderFoodVariable.UnitWidth * 7;
        dy = OrderFoodVariable.UnitHeight * 7;
        Login_btn.setBounds ( dx, dy, OrderFoodVariable.UnitWidth * 2, OrderFoodVariable.UnitHeight );

        dx = OrderFoodVariable.UnitWidth * 11;
        Reset_btn.setBounds ( dx, dy, OrderFoodVariable.UnitWidth * 2, OrderFoodVariable.UnitHeight );

        LoginFrame.getContentPane ().add ( Title_lbl );
        LoginFrame.getContentPane ().add ( ID_lbl );
        LoginFrame.getContentPane ().add ( ID_fld );
        LoginFrame.getContentPane ().add ( Password_lbl );
        LoginFrame.getContentPane ().add ( Password_fld );
        LoginFrame.getContentPane ().add ( Login_btn );
        LoginFrame.getContentPane ().add ( Reset_btn );
    }

    private boolean Login () {
        boolean Ret = OrderFoodStaticVariable.LOG_JOB_OK;

        OrderFoodApp.Log.WriteLogger ( "INFO", "LoginStatus取得：開始" );
        Ret = OrderFoodStatus.GetDBLoginStatus ();
        if ( Ret ) {
            OrderFoodApp.Log.WriteLogger ( "INFO", "LoginStatus取得：OK" );

            OrderFoodApp.Log.WriteLogger ( "INFO", "LoginStatus取得結果数チェック：開始" );
            if ( OrderFoodVariable.Status.getLoginStatusSize ()  == 1 ) {
                OrderFoodApp.Log.WriteLogger ( "INFO", "LoginStatus取得結果数チェック：OK" );

                OrderFoodApp.Log.WriteLogger ( "INFO", "LoginStatus取得結果チェック：開始" );
                if ( OrderFoodVariable.Status.getLoginStatus ( 0 ) ) {
                    OrderFoodApp.Log.WriteLogger ( "WARNING", "LoginStatus取得結果チェック：NG" );

                    JOptionPane.showMessageDialog ( null, "既にログインしました。" );
                    Reset_btn.doClick ();
                } else {
                    OrderFoodApp.Log.WriteLogger ( "INFO", "LoginStatus取得結果チェック：OK" );
                }
            } else {
                OrderFoodApp.Log.WriteLogger ( "WARNING", "LoginStatus取得結果数チェック：NG" );

                JOptionPane.showMessageDialog ( null, "入力IDが間違っています。" );
                Reset_btn.doClick ();
            }
        } else {
            OrderFoodApp.Log.WriteLogger ( "SERVER", "LoginStatus取得：NG" );
            return Ret;
        }

        OrderFoodApp.Log.WriteLogger ( "INFO", "パスワード取得：開始" );
        Ret = OrderFoodAccount.GetPassword ();
        if ( Ret ) {
            OrderFoodApp.Log.WriteLogger ( "INFO", "パスワード取得：OK" );

            OrderFoodApp.Log.WriteLogger ( "INFO", "パスワード取得結果数チェック：開始" );
            if ( OrderFoodVariable.Account.getPasswordSize () == 1 ) {
                OrderFoodApp.Log.WriteLogger ( "INFO", "パスワード取得結果数チェック：OK" );

                OrderFoodApp.Log.WriteLogger ( "INFO", "パスワード取得結果チェック：開始" );
                if ( OrderFoodVariable.Account.getPassword ( 0 ).equals ( OrderFoodVariable.Password ) ) {
                    OrderFoodApp.Log.WriteLogger ( "INFO", "パスワード取得結果チェック：OK" );

                } else {
                    OrderFoodApp.Log.WriteLogger ( "WARNING", "パスワード取得結果チェック：NG" );

                    JOptionPane.showMessageDialog ( null, "入力IDが間違っています。" );
                    Reset_btn.doClick ();
                }
            } else {
                OrderFoodApp.Log.WriteLogger ( "WARNING", "パスワード取得結果数チェック：NG" );

                JOptionPane.showMessageDialog ( null, "入力IDが間違っています。" );
                Reset_btn.doClick ();
            }
        } else {
            OrderFoodApp.Log.WriteLogger ( "SERVER", "パスワード取得：NG" );
            return Ret;
        }

        Ret = OrderFoodStatus.SetDBLoginStatus ( true );
        if ( Ret ) {
            OrderFoodApp.Log.WriteLogger ( "INFO", "LoginStatus取得：OK" );

            OrderFoodApp.Log.WriteLogger ( "INFO", "LoginStatus取得結果数チェック：開始" );
            if ( OrderFoodVariable.Status.getLoginStatusSize () == 1 ) {
                OrderFoodApp.Log.WriteLogger ( "INFO", "LoginStatus取得結果数チェック：OK" );

                OrderFoodApp.Log.WriteLogger ( "INFO", "LoginStatus取得結果チェック：開始" );
                if ( OrderFoodVariable.Status.getLoginStatus ( 0 ) ) {
                    OrderFoodApp.Log.WriteLogger ( "WARNING", "LoginStatus取得結果チェック：NG" );

                    JOptionPane.showMessageDialog ( null, "既にログインしました。" );
                    Reset_btn.doClick ();
                } else {
                    OrderFoodApp.Log.WriteLogger ( "INFO", "LoginStatus取得結果チェック：OK" );
                }
            } else {
                OrderFoodApp.Log.WriteLogger ( "WARNING", "LoginStatus取得結果数チェック：NG" );

                JOptionPane.showMessageDialog ( null, "入力IDが間違っています。" );
                Reset_btn.doClick ();
            }
        } else {
            OrderFoodApp.Log.WriteLogger ( "SERVER", "LoginStatus取得：NG" );
            return Ret;
        }

        return Ret;
    }

    private class ButtonActionListener implements ActionListener {
        public void actionPerformed ( ActionEvent e ) {
            if ( e.getSource () == Login_btn ) {
                boolean Ret = OrderFoodStaticVariable.LOG_JOB_OK;

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

                OrderFoodVariable.ID = ID_fld.getText ();
                OrderFoodVariable.Password = String.valueOf ( Password_fld.getPassword () );

                Ret = Login ();
                if ( Ret ) {
//                    Ret = UpdateStatus ();
//                    Ret = OrderFoodApp.DownloadSubStatus ();
                } else {
                    OrderFoodApp.Log.WriteLogger ( "SEVERE", "異常が発生しましたので、アプリを終了します。" );
                    System.exit ( 0 );
                }
            } else if ( e.getSource () == Reset_btn ) {
                ID_fld.setText ( "" );
                Password_fld.setText ( "" );
            } else {
                OrderFoodApp.Log.WriteLogger ( "SEVERE", "ボタンが異常発生しましたので、アプリを終了します。" );
                System.exit ( 0 );
            }
        }
    }

}
