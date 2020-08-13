using LibBaseSequence;

namespace HashTool
{
    public sealed class Result : ResultBase
    {
        /// <summary>
        /// Hash値
        /// </summary>
        public static string HashValue { get; set; }

        /// <summary>
        /// Hash条件
        /// </summary>
        public static int Condition { get; set; }

        /// <summary>
        /// Result初期化
        /// </summary>
        public override void Init ( )
        {
            // 前回処理結果を初期化
            HashValue = "";
            Condition = 0;
        }
    }
}
