//using CommonLib.Interface;

namespace HashTool.Base
{
    class HashFileBase //: IDataStringIO
    {
        private string file_name;

        public string GetString ( )
        {
            return file_name;
        }

        public void SetString (string s)
        {
            this.file_name = s;
        }
    }
}
