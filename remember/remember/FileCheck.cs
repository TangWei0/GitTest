using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace remember
{
    class FileCheck
    {
        public string excelName = "C://Users/itou1/Desktop/Sim/GitTest/remember/LOGGER.xlsx";

        public bool IsFileInUse(string fileName)
        {
            bool inUse = true;

            FileStream fs = null;
            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read,FileShare.None);
                inUse = false;

            }
            catch
            {

            }
            finally
            {
                if (fs != null)

                    fs.Close();
            }
            return inUse;
        }

    }
}
