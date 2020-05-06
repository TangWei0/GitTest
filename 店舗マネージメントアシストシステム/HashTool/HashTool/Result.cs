using LibBaseSequence;

namespace HashTool
{
    public sealed class Result : ResultBase
    {
        /// <summary>
        /// Hash値
        /// </summary>
        private string hashValue = "";
        public string GetHashValue ( ) { return hashValue; }
        public void SetHashValue (string value) { hashValue = value; }

        /// <summary>
        /// Result初期化
        /// </summary>
        public override void Init ( )
        {
            // 前回処理結果を初期化
            hashValue = "";
        }
    }
}
