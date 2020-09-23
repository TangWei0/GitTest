using CommonLib.Common;
using LibBaseSequence.Interface;

namespace LibBaseSequence
{
    public abstract class ResultBase : IResult
    {
        protected E_FUNCTION_STATUS status;
        public E_FUNCTION_STATUS GetStatus ( )
        {
            return status;
        }
        public void SetStatus (E_FUNCTION_STATUS _status)
        {
            status = _status;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ResultBase ( )
        {
            status = E_FUNCTION_STATUS.INIT;
        }

        public abstract void Init ( );
    }
}
