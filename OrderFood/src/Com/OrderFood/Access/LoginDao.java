
package Com.OrderFood.Access;

import Com.OrderFood.Data.*;
import Com.OrderFood.Data.Enum;
import Com.OrderFood.Access.Access;
import Com.OrderFood.Screen.App;

public class LoginDao {
    public static boolean getData () {
        boolean Ret = true;

        Variable.DataClear ();
        Variable.Command = "SELECT u.names, u.depart_id, a.password, s.login, s.connect "
                + "FROM user u "
                + "LEFT JOIN account a ON u.id = a.id "
                + "LEFT JOIN status s ON u.id = s.id "
                + "WHERE a.id = ? ";

        Variable.SQLType = Enum.SQLType.SEARCH;
        Variable.ParameterDataType.add ( Enum.ParameterDataType.STRING );
        Variable.ParameterData.add ( Variable.ID );

        Ret = Access.RunSQLCommand ();
        if ( Ret ) {
            App.Log.WriteLogger ( "FINER", App.Log.getFileMethod () + " SQLSearch処理結果チェック：TRUE" );

            Variable.Status = new Status ();
            Variable.User = new User ();
            Variable.Account = new Account ();

            Variable.ResultData.forEach ( item -> {
                Variable.User.setNames ( item.get ( "names" ) );
                Variable.User.setDepartID ( item.get ( "depart_id" ) );
                Variable.Account.setPassword ( item.get ( "password" ) );
                Variable.Status.setLoginStatus ( item.get ( "login" ) );
                Variable.Status.setConnectTime ( item.get ( "connect" ) );
            } );
        } else {
            App.Log.WriteLogger ( "SERVER", App.Log.getFileMethod () + " SQLSearch処理結果チェック：FALSE" );
        }
        return Ret;
    }

}
