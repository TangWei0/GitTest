using LibBaseSequence;
using HashTool.Measurement;

namespace HashTool
{
    public sealed class Sequence : SequenceBase<Parameter, Result>
    {
        private readonly string word;
        private readonly int condition;


        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="word"></param>
        /// <param name="condition"></param>
        public Sequence (string _word, int _condition = 0) : base()
        {
            word = _word;
            condition = _condition;
        }

        /// <summary>
        /// 事前プロセス
        /// </summary>
        public override void PreProcess ( )
        {
            // パラメータ設定
            Parameter = new Parameter(word, condition);
            Parameter.SetParam( );

            // 結果初期化
            Result.Init( );
        }

        /// <summary>
        /// 本体処理
        /// </summary>
        public override void BodyProcess ( )
        {
            // HashTool本体処理
            var measure = MeasurementFactory.Get(Parameter);
            measure.Exec( );
            Result.SetHashValue(measure.GetHashValue( ));
        }

        /// <summary>
        /// 事後プロセス
        /// HashToolは、事後プロセスしないようにする
        /// </summary>
        public override void PostProcess ( ) { }

        /// <summary>
        /// リトライプロセス
        /// HashToolリトライしないようにする
        /// </summary>
        public override void RetryProcess ( ) { }
    }
}
