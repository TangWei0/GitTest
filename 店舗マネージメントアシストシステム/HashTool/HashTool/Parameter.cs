using LibBaseSequence;
using HashTool.Condition;

namespace HashTool
{
    public class Parameter : ParameterBase
    {
        public static string Word { get; set; }        

        /// <summary>
        /// パラメータ設定
        /// </summary>
        public override void SetParam ( )
        {
            var con = ConditionFactory.Get();
            con.Exec( );
        }
    }
}
