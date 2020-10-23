using HashTool.Condition;
using LibBaseSequence;

namespace HashTool
{
    public sealed class Parameter : ParameterBase
    {
        public static string Word { get; set; }

        /// <summary>
        /// パラメータ設定
        /// </summary>
        public override void SetParam()
        {
            var con = ConditionFactory.Get();
            con.Exec();
        }
    }
}
