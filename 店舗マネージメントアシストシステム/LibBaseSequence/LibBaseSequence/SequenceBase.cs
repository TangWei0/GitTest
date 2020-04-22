using System;
using CommonLib.Constant.ManagerAssist;
using LibBaseSequence.Interface;

namespace LibBaseSequence
{
    public abstract class SequenceBase :ISequence
    {
        /// <summary>
        /// 残りの行動数
        /// </summary>
        private int remainAction;

        /// <summary>
        /// リトライ
        /// </summary>
        private bool retryEnable;

        /// <summary>
        /// コンストラクタ(リトライ付き)
        /// </summary>
        public SequenceBase (int retryMax = 0)
        {
            retryEnable = retryMax == 0 ? Constant.MAS_No : Constant.MAS_Yes;
            remainAction = retryMax;
        }

        public void NormalSequence ( )
        {
            bool retry = Constant.MAS_No;

            do
            {
                try
                {
                    PreProcess( );
                    Exec( );
                    PostProcess( );
                }
                catch(ProcessException ex)
                {
                    retry = ErrorSequence(ex);

                    // 異常終了
                    return;
                }
            } while(retry == Constant.MAS_Yes);
        }

        /// <summary>
        /// 事前プロセス
        /// </summary>
        public void PreProcess ( )
        {
            PreProcessCore( );
        }

        protected abstract void PreProcessCore ( );
        
        /// <summary>
        /// 本体処理
        /// </summary>
        public void Exec ( )
        {
            ExecCore( );
        }

        protected abstract void ExecCore ( );

        /// <summary>
        /// 事後プロセス
        /// </summary>
        public void PostProcess ( )
        {
            PostProcessCore( );
        }

        protected abstract void PostProcessCore ( );

        public bool ErrorSequence (ProcessException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);

            if(retryEnable && (remainAction > 0))
            {
                remainAction--;
                return Constant.MAS_Yes;
            }
            else
            {
                ErrorSequenceCore( );
                return Constant.MAS_No;
            }
        }

        protected abstract bool ErrorSequenceCore ( );
    }
}
