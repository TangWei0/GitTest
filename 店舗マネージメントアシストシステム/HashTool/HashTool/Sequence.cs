using HashTool.Condition;
using HashTool.Measurement;
using LibBaseSequence;

namespace HashTool
{
    public sealed class Sequence : SequenceBase<Parameter, Result>
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="word"></param>
        /// <param name="condition"></param>
        public Sequence(string _word, int _condition = 0) : base()
        {
            Parameter.Word = _word;
            Conditions.Condition = _condition;
        }

        /// <summary>
        /// 事前プロセス
        /// </summary>
        public override void PreProcess()
        {
            // パラメータ設定
            Parameter.SetParam();

            // 結果初期化
            Result.Init();
        }

        /// <summary>
        /// 本体処理
        /// </summary>
        public override void BodyProcess()
        {
            // HashTool本体処理
            var measure = MeasurementFactory.Get();
            measure.Exec();
            Result.HashValue = measure.HashValue;
        }

        /// <summary>
        /// 事後プロセス
        /// </summary>
        public override void PostProcess()
        {
            Result.Condition = Conditions.Condition;
        }

        /// <summary>
        /// リトライプロセス
        /// HashToolリトライしないようにする
        /// </summary>
        public override void RetryProcess() { }
    }
}
