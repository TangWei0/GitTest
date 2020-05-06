using LibBaseSequence.Interface;

namespace LibBaseSequence
{
    public abstract class ParameterBase : IParameter
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ParameterBase ( ) { }

        public abstract void SetParam ( );
    }
}
