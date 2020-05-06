using LibBaseSequence;

namespace HashTool
{
    public sealed class Parameter : ParameterBase
    {
        private readonly int condition;
        private readonly string word;
        public string GetWord ( ) { return word; }
        
        private Condition Condition;
        public Condition GetCondition ( ) { return Condition; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Parameter ( ) { }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="_word"></param>
        /// <param name="_condition"></param>
        public Parameter (string _word, int _condition)
        {
            word = _word;
            condition = _condition;
        }

        /// <summary>
        /// パラメータ設定
        /// </summary>
        public override void SetParam ( )
        {
            Condition = new Condition(condition);
            Condition.Exec( );
        }
    }
}
