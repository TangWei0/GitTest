using static HashTool.Head.HeadEnum;

namespace HashTool.Struct
{
    public struct InputType
    {
        private E_HASH_ORDER order;
        private E_HASH_TYPE type;

        public void SetValue (E_HASH_ORDER _order,
                              E_HASH_TYPE _type)
        {
            order = _order;
            type = _type;
        }
    }
}
