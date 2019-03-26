
package Test;

import java.util.Date;

public class DataListen implements IDataListen {

    @Override
    public void update ( Object event, Object arg ) {
        // TODO Auto-generated method stub
        System.out.println ( new Date () + "数据发生了变化" );
    }

}
