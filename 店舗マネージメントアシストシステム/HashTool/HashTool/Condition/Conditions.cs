using HashTool.Constant;

namespace HashTool.Condition
{
    public static class Conditions
    {
        public static int Condition { get; set; }
        public static E_HASH_ORDER Order { get; set; }
        public static E_HASH_SENSITIVE Sensitive{ get; set; }
        public static E_HASH_TYPE Type { get; set; }
        public static byte ByteMaxCount { get; set; }
        public static byte StartIndex { get; set; }
        public static byte EndIndex { get; set; }
    }
}
