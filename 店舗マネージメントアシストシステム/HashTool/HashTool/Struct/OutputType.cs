using static HashTool.Head.HeadEnum;

namespace HashTool.Struct
{
    public struct OutputType
    {
        private E_HASH_SENSITIVE sensitive;
        private int bits;

        public void SetValue (E_HASH_SENSITIVE _sensitive,
                              int _bits)
        {
            sensitive = _sensitive;
            bits = _bits;
        }
    }
}
