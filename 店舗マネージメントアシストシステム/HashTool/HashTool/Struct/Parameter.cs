using static HashTool.Head.HeadEnum;

namespace HashTool.Struct
{
    public struct Parameter
    {
        private string word;
        private InputType input;
        private OutputType output;

        public void SetValue (string _word,
                              E_HASH_ORDER _order,
                              E_HASH_TYPE _type,
                              E_HASH_SENSITIVE _sensitive,
                              int _bits)
        {
            word = _word;
            input.SetValue(_order, _type);
            output.SetValue(_sensitive, _bits);
        }
    }
}
