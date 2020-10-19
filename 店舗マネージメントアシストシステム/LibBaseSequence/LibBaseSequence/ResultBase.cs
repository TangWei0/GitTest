using CommonLib.Common;
using LibBaseSequence.Interface;

namespace LibBaseSequence
{
    public abstract class ResultBase : IResult
    {
        public E_FUNCTION_STATUS Status
        {
            get; set;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ResultBase ( ) => Status = E_FUNCTION_STATUS.INIT;

        public abstract void Init ( );
    }
}
