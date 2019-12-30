namespace ClassLibrary
{
    public class Enum
    {
        // 出力ハッシュ値用パラメータ(大文字か小文字を指定)
        public enum E_HASH_PARAMETER
        {
            UPPER,  /* 大文字 */
            LOWER   /* 小文字 */
        };

        // 呼び出す関数戻り値
        public enum E_FUNCTION_RESULT
        {
            SUCCESS,/* 処理成功 */
            FAILE   /* 処理失敗 */
        };
    }
}
