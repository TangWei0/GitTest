
package Com.OrderFood.Screen;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Container;
import java.awt.GridBagConstraints;
import java.awt.GridBagLayout;
import java.awt.GridLayout;
import java.awt.Insets;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.sql.SQLException;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JPasswordField;
import javax.swing.JTextField;

import Com.OrderFood.Access.Access;
import Com.OrderFood.Access.LoginDao;
import Com.OrderFood.Data.Enum;
import Com.OrderFood.Data.Variable;

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
        setSize ( 582, 460 );
        setResizable ( false );
        setDefaultCloseOperation ( JFrame.EXIT_ON_CLOSE );
        Insets insets = this.getInsets ();

        JPanel p1 = new JPanel ();
        // p1.setBackground ( Color.BLUE );

        Variable.StatusBarPanel.setBackground ( Color.ORANGE );
        int weight = Variable.FrameWidth - insets.left - insets.right;
        int height = Variable.FrameHeight - insets.top - insets.bottom;
        Variable.StatusBar.setSize ( weight, height / 20 );
        Variable.StatusBarPanel.add ( Variable.StatusBar );
        Variable.StatusBarPanel.setVisible ( Enum.FALSE );

        Container contentPane = getContentPane ();
        contentPane.add ( p1, BorderLayout.CENTER );
        contentPane.add ( Variable.StatusBarPanel, BorderLayout.SOUTH );
        GridBagConstraints gbc = new GridBagConstraints ();
        gbc.fill = GridBagConstraints.BOTH;

        gbc.gridx = 0;
        gbc.gridy = 0;
        gbc.gridwidth = 3;

        gbc.gridy = 1;
        gbc.gridwidth = 1;

        gbc.gridx = 1;
        gbc.gridy = 1;
        gbc.gridwidth = 2;

        gbc.gridx = 0;
        gbc.gridy = 2;
        gbc.gridwidth = 1;

        gbc.gridx = 1;
        gbc.gridy = 2;
        gbc.gridwidth = 2;

        gbc.gridx = 0;
        gbc.gridy = 3;
        gbc.gridwidth = 1;

        gbc.gridx = 1;
        gbc.gridy = 3;
        gbc.gridwidth = 1;
        GridBagLayout gbl_p1 = new GridBagLayout();
        gbl_p1.columnWidths = new int[]{153, 58, 17, 0, 6, 53, 6, 67, 63, 0, 0};
        gbl_p1.rowHeights = new int[]{0, 0, 49, 21, 0, 0, 0};
        gbl_p1.columnWeights = new double[]{0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, Double.MIN_VALUE};
        gbl_p1.rowWeights = new double[]{0.0, 0.0, 0.0, 0.0, 0.0, 0.0, Double.MIN_VALUE};
        p1.setLayout(gbl_p1);
        
                GridBagConstraints gbc_Title_lbl = new GridBagConstraints();
                gbc_Title_lbl.fill = GridBagConstraints.BOTH;
                gbc_Title_lbl.gridwidth = 18;
                gbc_Title_lbl.insets = new Insets(0, 0, 5, 0);
                gbc_Title_lbl.gridx = 0;
                gbc_Title_lbl.gridy = 2;
                p1.add ( Title_lbl, gbc_Title_lbl );
        GridBagConstraints gbc_ID_lbl = new GridBagConstraints();
        gbc_ID_lbl.insets = new Insets(0, 0, 5, 5);
        gbc_ID_lbl.gridx = 1;
        gbc_ID_lbl.gridy = 3;
        p1.add ( ID_lbl, gbc_ID_lbl );
        GridBagConstraints gbc_ID_fld = new GridBagConstraints();
        gbc_ID_fld.fill = GridBagConstraints.HORIZONTAL;
        gbc_ID_fld.gridwidth = 5;
        gbc_ID_fld.insets = new Insets(0, 0, 5, 5);
        gbc_ID_fld.gridx = 3;
        gbc_ID_fld.gridy = 3;
        p1.add ( ID_fld, gbc_ID_fld );
        GridBagConstraints gbc_Password_lbl = new GridBagConstraints();
        gbc_Password_lbl.insets = new Insets(0, 0, 5, 5);
        gbc_Password_lbl.gridx = 1;
        gbc_Password_lbl.gridy = 4;
        p1.add ( Password_lbl, gbc_Password_lbl );
        GridBagConstraints gbc_Password_fld = new GridBagConstraints();
        gbc_Password_fld.fill = GridBagConstraints.HORIZONTAL;
        gbc_Password_fld.gridwidth = 5;
        gbc_Password_fld.insets = new Insets(0, 0, 5, 5);
        gbc_Password_fld.gridx = 3;
        gbc_Password_fld.gridy = 4;
        p1.add ( Password_fld, gbc_Password_fld );
        GridBagConstraints gbc_Login_btn = new GridBagConstraints();
        gbc_Login_btn.gridwidth = 2;
        gbc_Login_btn.insets = new Insets(0, 0, 0, 5);
        gbc_Login_btn.gridx = 1;
        gbc_Login_btn.gridy = 5;
        p1.add ( Login_btn, gbc_Login_btn );
        GridBagConstraints gbc_Reset_btn = new GridBagConstraints();
        gbc_Reset_btn.gridwidth = 2;
        gbc_Reset_btn.insets = new Insets(0, 0, 0, 5);
        gbc_Reset_btn.gridx = 4;
        gbc_Reset_btn.gridy = 5;
        p1.add ( Reset_btn, gbc_Reset_btn );
    }

    /*
     * FrameInit ();
     *
     * // BorderLayout = new BorderLayout ( 10, 5 ); Container contentPane =
     * getContentPane (); JPanel p2 = new JPanel (); p2.setBackground (
     * Color.ORANGE ); p2.add ( statusBar ); contentPane.add ( p2,
     * BorderLayout.SOUTH ); // LoginFrame.addMouseListener ( new
     * AddMouseListener () ); // LoginFrame.addWindowListener ( new
     * AddWindowListener () ); // Login_btn.addActionListener ( new
     * ButtonActionListener () ); // Reset_btn.addActionListener ( new
     * ButtonActionListener () ); }
     *
     * private void FrameInit () {
     *
     * int dx; int dy;
     *
     * LoginFrame.getContentPane ().setLayout ( new BorderLayout ( 10, 5 ) );
     * LoginFrame.setSize ( Variable.FrameWidth, Variable.FrameHeight );
     * LoginFrame.setDefaultCloseOperation ( JFrame.EXIT_ON_CLOSE );
     * LoginFrame.setVisible ( true ); LoginFrame.setResizable ( false );
     *
     * /* dx = Variable.UnitWidth * 7; dy = Variable.UnitHeight;
     * Title_lbl.setBounds ( dx, dy, Variable.UnitWidth * 6, Variable.UnitHeight
     * );
     *
     * dy = Variable.UnitHeight * 3; ID_lbl.setBounds ( dx, dy,
     * Variable.UnitWidth * 2, Variable.UnitHeight );
     *
     * dx = Variable.UnitWidth * 9; ID_fld.setBounds ( dx, dy,
     * Variable.UnitWidth * 4, Variable.UnitHeight );
     *
     * dx = Variable.UnitWidth * 7; dy = Variable.UnitHeight * 5;
     * Password_lbl.setBounds ( dx, dy, Variable.UnitWidth * 2,
     * Variable.UnitHeight );
     *
     * dx = Variable.UnitWidth * 9; Password_fld.setBounds ( dx, dy,
     * Variable.UnitWidth * 4, Variable.UnitHeight );
     *
     * dx = Variable.UnitWidth * 7; dy = Variable.UnitHeight * 7;
     * Login_btn.setBounds ( dx, dy, Variable.UnitWidth * 2, Variable.UnitHeight
     * );
     *
     * dx = Variable.UnitWidth * 11; Reset_btn.setBounds ( dx, dy,
     * Variable.UnitWidth * 2, Variable.UnitHeight );
     *
     * LoginFrame.getContentPane ().add ( Title_lbl ); LoginFrame.getContentPane
     * ().add ( ID_lbl ); LoginFrame.getContentPane ().add ( ID_fld );
     * LoginFrame.getContentPane ().add ( Password_lbl );
     * LoginFrame.getContentPane ().add ( Password_fld );
     * LoginFrame.getContentPane ().add ( Login_btn ); LoginFrame.getContentPane
     * ().add ( Reset_btn ); LoginFrame.getContentPane ().add ( statusBar );
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
