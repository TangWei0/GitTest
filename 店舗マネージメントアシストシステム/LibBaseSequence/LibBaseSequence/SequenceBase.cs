using System;
using CommonLib.Constant.ManagerAssist;
using LibBaseSequence.Interface;

namespace LibBaseSequence
{
    public abstract class SequenceBase<TParameter, TResult> :ISequence
        where TParameter : ParameterBase, new()
        where TResult : ResultBase, new()
    {
        public TParameter Parameter { get; set; } = new TParameter( );
        public TResult Result { get; set; } = new TResult( );

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
                    // 事前プロセス
                    PreProcess( );

                    // 本体処理
                    Exec( );

                    // 事後プロセス
                    PostProcess( );
                }
                catch(ProcessException ex)
                {
                    // 例外処理
                    ex.View( );

                    // エラーシーケンスを実行
                    retry = ErrorSequence();
                }
            } while(retry == Constant.MAS_Yes);
        }

        /// <summary>
        /// 事前プロセス
        /// </summary>
        public abstract void PreProcess ( );

        /// <summary>
        /// 本体処理
        /// </summary>
        public abstract void Exec ( );

        /// <summary>
        /// 事後プロセス
        /// </summary>
        public abstract void PostProcess ( );

        /// <summary>
        /// エラーシーケンス
        /// </summary>
        /// <returns>リトライするかを返却</returns>
        public bool ErrorSequence ( )
        {
            bool retry = Constant.MAS_No;

            if(retryEnable && (remainAction > 0))
            {
                // リトライ かつ 残り行動数あり
                remainAction--;

                // 各ライブラリのエラーシーケンスを実行
                // 基本的に各ライブラリを初期化する(事前プロセス実行前状態に戻る)
                ErrorSequenceCore( );

                // リトライ
                retry = Constant.MAS_Yes;
            }
            else
            {
                // リトライしない場合、ステータスがFailedに設定
                Result.SetStatus(E_FUNCTION_STATUS.FAILED);
            }

            return retry;
        }

        /// <summary>
        /// 各ライブラリのエラーシーケンスを実行
        /// </summary>
        protected abstract void ErrorSequenceCore ( );
    }
}
