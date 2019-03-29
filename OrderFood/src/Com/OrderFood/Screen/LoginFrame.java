
package Com.OrderFood.Screen;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.FlowLayout;
import java.awt.GridBagConstraints;
import java.awt.GridBagLayout;
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
import javax.swing.SwingConstants;
import javax.swing.border.LineBorder;

import Com.OrderFood.Access.Access;
import Com.OrderFood.Access.LoginDao;
import Com.OrderFood.Data.Enum;
import Com.OrderFood.Data.Variable;
import Com.OrderFood.Listener.StatusButtonActionListener;

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
        setResizable ( false );
        setDefaultCloseOperation ( JFrame.EXIT_ON_CLOSE );

        FrameInit ();

    }

    /* BorderLayout = new BorderLayout ( 10, 5 ); Container contentPane =
    getContentPane (); JPanel p2 = new JPanel (); p2.setBackground (
    Color.ORANGE ); p2.add ( statusBar ); contentPane.add ( p2,
    BorderLayout.SOUTH ); // LoginFrame.addMouseListener ( new
    AddMouseListener () ); // LoginFrame.addWindowListener ( new
    AddWindowListener () ); // Login_btn.addActionListener ( new
    ButtonActionListener () ); // Reset_btn.addActionListener ( new
    ButtonActionListener () ); }
    */
    private void FrameInit () {
        JPanel p1 = new JPanel ();
        GridBagLayout gblayout = new GridBagLayout ();
        p1.setLayout ( gblayout );

        JLabel l1 = new JLabel ( "label1" );
        l1.setHorizontalAlignment ( JLabel.HORIZONTAL );
        l1.setVerticalAlignment ( JLabel.BOTTOM );

        JLabel l2 = new JLabel ( "label2", SwingConstants.CENTER );
        JLabel l3 = new JLabel ( "label3", SwingConstants.CENTER );
        JLabel l4 = new JLabel ( "label4", SwingConstants.CENTER );

        l1.setBorder ( new LineBorder ( Color.BLACK, 2 ) );
        l2.setBorder ( new LineBorder ( Color.BLACK, 2 ) );
        l3.setBorder ( new LineBorder ( Color.BLACK, 2 ) );
        l4.setBorder ( new LineBorder ( Color.BLACK, 2 ) );

        GridBagConstraints gbc = new GridBagConstraints ();
        gbc.fill = GridBagConstraints.BOTH;
        gbc.gridx = 0;
        gbc.gridy = 0;
        gbc.gridwidth = 2;
        gbc.gridheight = 1;
        gbc.insets = new Insets ( 1, 1, 1, 1 );
        gbc.weightx = 1.0;
        gbc.weighty = 5.0;
        gblayout.setConstraints ( l1, gbc );
        p1.add ( l1 );

        gbc.fill = GridBagConstraints.BOTH;
        gbc.gridx = 0;
        gbc.gridy = 1;
        gbc.gridwidth = 1;
        gbc.gridheight = 1;
        gbc.insets = new Insets ( 1, 1, 1, 1 );
        gbc.weightx = 0.5;
        gbc.weighty = 1.0;
        gblayout.setConstraints ( l2, gbc );
        p1.add ( l2 );

        gbc.fill = GridBagConstraints.BOTH;
        gbc.gridx = 1;
        gbc.gridy = 1;
        gbc.gridwidth = 1;
        gbc.gridheight = 1;
        gbc.insets = new Insets ( 1, 1, 1, 1 );
        gbc.weightx = 1.5;
        gbc.weighty = 1.0;
        gblayout.setConstraints ( l3, gbc );
        p1.add ( l3 );

        gbc.fill = GridBagConstraints.BOTH;
        gbc.gridx = 0;
        gbc.gridy = 2;
        gbc.gridwidth = 2;
        gbc.gridheight = 1;
        gbc.insets = new Insets ( 1, 1, 1, 1 );
        gbc.weightx = 1.0;
        gbc.weighty = 1.0;
        gblayout.setConstraints ( l4, gbc );
        p1.add ( l4 );

        JButton button3 = new JButton ( "Button3" );
        JButton button4 = new JButton ( "Button4" );

        JPanel p2 = new JPanel ();
        p2.setLayout ( new FlowLayout ( FlowLayout.LEFT ) );
        p2.add ( button3 );
        p2.add ( button4 );

        Variable.StatusBarPanel.setBackground ( Color.ORANGE );
        Variable.StatusBarPanel.setVisible ( Enum.FALSE );
        gblayout = new GridBagLayout ();
        Variable.StatusBarPanel.setLayout ( gblayout );

        gbc = new GridBagConstraints ();
        gbc.fill = GridBagConstraints.BOTH;
        gbc.gridx = 0;
        gbc.gridy = 0;
        gbc.gridwidth = 1;
        gbc.gridheight = 1;
        gbc.insets = new Insets ( 5, 5, 5, 5 );
        gbc.weightx = 10.0;
        gbc.weighty = 1.0;
        gblayout.setConstraints ( Variable.StatusBarLabel, gbc );
        Variable.StatusBarPanel.add ( Variable.StatusBarLabel );

        gbc.fill = GridBagConstraints.BOTH;
        gbc.gridx = 1;
        gbc.gridy = 0;
        gbc.gridwidth = 1;
        gbc.gridheight = 1;
        gbc.insets = new Insets ( 5, 5, 5, 5 );
        gbc.weightx = 0.5;
        gbc.weighty = 1.0;
        gblayout.setConstraints ( Variable.StatusBarButton, gbc );
        Variable.StatusBarPanel.add ( Variable.StatusBarButton );

        getContentPane ().add ( p1, BorderLayout.CENTER );
        getContentPane ().add ( p2, BorderLayout.PAGE_START );
        getContentPane ().add ( Variable.StatusBarPanel, BorderLayout.PAGE_END );

//        Variable.StatusBarButton.addActionListener ( new StatusButtonActionListener () );
    }

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
