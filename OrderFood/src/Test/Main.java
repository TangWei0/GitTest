
package Test;

import java.io.File;

public class Main {
    static String LogPath = new File ( "" ).getAbsolutePath ()
            + "\\Log\\";
    static String OldLogPath = LogPath
            + "Old\\";
    static File[] FileList = null;

    public static void main ( String[] args ) {

        FileList = new File ( LogPath ).listFiles ();

        for ( int i = 0; i < FileList.length; i++ ) {
            if ( FileList[i].isFile () ) {
                File fileOut = new File ( OldLogPath + FileList[i].getName () );

                if ( FileList[i].renameTo ( fileOut ) ) {
                    System.out.println ( "移動しました" );
                } else {
                    System.out.println ( "移動に失敗しました" );
                }

            }
        }
        
        FileList = null;
    }
}
