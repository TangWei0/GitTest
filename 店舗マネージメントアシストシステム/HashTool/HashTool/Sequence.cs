using HashTool.Struct;
using LibBaseSequence;

namespace HashTool
{
    public class Sequence :SequenceBase
    {
        /// <summary>
        /// パラメータ
        /// </summary>
        public Parameter Parameter { get; set; } = new Parameter( );

        /// <summary>
        /// 結果
        /// </summary>
        public Result Result { get; set; } = new Result( );

        protected override void ExecCore ( )
        {

        }
    }
}
