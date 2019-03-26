
package Test;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

public class DataManager {

    private List< IDataListen > listenList = new ArrayList<> ();

    public void notifyListen ( Object event, Object msg ) {
        for ( IDataListen dataListen : listenList ) {
            dataListen.update ( null, null );
        }
    }

    public void addListen ( IDataListen dataListen ) {
        listenList.add ( dataListen );
    }

    public void updateData ( Object msg ) {
        this.notifyListen ( null, msg );
    }

    public static void main ( String[] args ) {
        DataManager dataManager = new DataManager ();
        IDataListen dataListen1 = new DataListen ();

        dataManager.addListen ( dataListen1 );
        dataManager.updateData ( "aaa" );

        try {
            Thread.sleep ( 10000 );
        } catch ( InterruptedException e ) {
            // TODO Auto-generated catch block
            e.printStackTrace ();
        }

        dataManager.updateData ( "bbb" );

    }
}
