//using CommonLib.Interface;

namespace HashTool
{
    // HashContext基底クラス
    public class HashContextBase //: IDataStringIO
    {
        private string context = null;

        public string GetString ( )
        {
            return context;
        }

        public void SetString (string s)
        {
            this.context = s;
        }
    }
}