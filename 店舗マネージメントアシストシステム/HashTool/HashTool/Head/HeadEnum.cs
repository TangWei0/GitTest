namespace HashTool.Head
{
    public class HeadEnum
    {
        public enum E_HASH_SENSITIVE
        {
            UPPER,      /* 大文字  */
            LOWER       /* 小文字  */
        }

        public enum E_HASH_TYPE
        {
            MD5 = 32,       /* MD5ハッシュ     */
            SHA1 = 40,      /* SHA-1ハッシュ   */
            SHA256 = 64,    /* SHA-256ハッシュ */
            SHA384 = 96,    /* SHA-384ハッシュ */
            SHA512 = 128    /* SHA-512ハッシュ */
        }

        public enum E_HASH_ORDER
        {
            SINGLE = 1,    /* 1次ハッシュ */
            DOUBLE = 2     /* 2次ハッシュ */
        }
    }
}
