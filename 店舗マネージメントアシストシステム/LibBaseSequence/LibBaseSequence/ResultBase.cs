using CommonLib.Constant.ManagerAssist;
using LibBaseSequence.Interface;

namespace LibBaseSequence
{
    public abstract class ResultBase : IResult
    {
        private E_FUNCTION_RESULT result;
        public E_FUNCTION_RESULT GetResult ( ) { return result; }
        public void SetResult (E_FUNCTION_RESULT rel) { result = rel; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ResultBase ( ) { }

        public void Init ( ) 
        { 
            result = E_FUNCTION_RESULT.ABORT;
            InitCore( );
        }

        protected abstract void InitCore ( );
    }
}
