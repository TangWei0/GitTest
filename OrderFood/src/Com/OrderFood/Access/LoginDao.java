
package Com.OrderFood.Access;

import Com.OrderFood.Data.*;
import Com.OrderFood.Data.Variable;
import Com.OrderFood.Data.StaticVariable;
import Com.OrderFood.Access.Access;
import Com.OrderFood.Screen.App;

public class LoginDao {

    public static boolean getData () {
        boolean Ret = StaticVariable.LOG_JOB_OK;
        String[] tmp;

        Variable.DataClear ();
        Variable.Command = "SELECT u.names, u.depart_id, a.password, s.login, s.exit "
                + "FROM user u "
                + "LEFT JOIN account a ON u.id = a.id "
                + "LEFT JOIN status s ON u.id = s.id "
                + "WHERE a.id = ? ";
        Variable.SQLType = StaticVariable.SQLTYPE_SEARCH;
        tmp = new String[] {
                    Variable.ID, "string"
        };
        Variable.ParameterData.add ( tmp );

        Ret = Access.RunSQLCommand ();
        if ( Ret ) {
            App.Log.WriteLogger ( "FINER", App.Log.getFileMethod () + " SQLSearch処理結果チェック：TRUE" );

            Variable.Status = new Status ();
            Variable.User = new User ();
            Variable.Account = new Account ();

            Variable.ResultData.forEach ( item -> {
                Variable.User.setNames ( item.get ( "names" ) );
                Variable.User.setDepartID ( Integer.valueOf ( item.get ( "depart_id" ) ) );
                Variable.Account.setPassword ( item.get ( "password" ) );
                Variable.Status.setLoginStatus ( Boolean.valueOf ( item.get ( "login" ) ) );
                Variable.Status.setExitStatus ( Boolean.valueOf ( item.get ( "exit" ) ) );
            } );
        } else {
            App.Log.WriteLogger ( "SERVER", App.Log.getFileMethod () + " SQLSearch処理結果チェック：FALSE" );
        }
        return Ret;
    }

}
