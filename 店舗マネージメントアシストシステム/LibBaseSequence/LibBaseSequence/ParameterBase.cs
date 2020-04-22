using LibBaseSequence.Interface;

namespace LibBaseSequence
{
    public abstract class ParameterBase :IParameter
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ParameterBase ( ) { }

        public void SetParam ( )
        {
            SetParamCore( );
        }

        protected abstract void SetParamCore ( );
    }
}
