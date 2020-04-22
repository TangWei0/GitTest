namespace HashTool.Struct
{
    public struct Result
    {
        private string hashValue;

        public void SetValue (string _hashValue)
        {
            hashValue = _hashValue;
        }

        public string GetValue ( )
        {
            return hashValue;
        }
    }
}
