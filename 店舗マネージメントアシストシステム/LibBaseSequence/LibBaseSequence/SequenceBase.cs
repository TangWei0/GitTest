using LibBaseSequence.Interface;
using CommonLib.Common;
//using static CommonLib.Common.Common;
//using static CommonLib.Common.E_FUNCTION_STATUS;

namespace LibBaseSequence
{
    public abstract class SequenceBase<TParameter,TResult> : ISequence
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
            retryEnable = retryMax == 0 ? Common.MAS_No : Common.MAS_Yes;
            remainAction = retryMax;
        }

        /// <summary>
        /// ライブラリ処理
        /// </summary>
        public void Exec ( )
        {
            bool rel = Common.MAS_No;
            bool retry = Common.MAS_No;

            do
            {
                try
                {
                    // ノーマルシーケンスを実行
                    NormalSequence( );
                    rel = Common.MAS_Yes;
                }
                catch(ProcessException ex)
                {
                    // 例外処理
                    ex.View( );

                    // エラーシーケンスを実行
                    retry = ErrorSequence( );
                }
            } while(retry == Common.MAS_Yes);

            if(rel)
            {
                // ライブラリ実行結果を設定
                Result.SetStatus(E_FUNCTION_STATUS.SUCCESS);
            }
        }

        /// <summary>
        /// ノーマルシーケンス
        /// </summary>
        public void NormalSequence ( )
        {
            // 事前プロセス
            PreProcess( );

            // 本体プロセス
            BodyProcess( );

            // 事後プロセス
            PostProcess( );
        }

        /// <summary>
        /// エラーシーケンス
        /// リトライ場合、リトライプロセスを実行
        /// リトライしない場合、ステータスがFailedに設定
        /// </summary>
        /// <returns>リトライするかを返却</returns>
        public bool ErrorSequence ( )
        {
            bool retry = Common.MAS_No;

            if(retryEnable && (remainAction > 0))
            {
                // リトライ かつ 残り行動数あり
                remainAction--;

                // リトライプロセスを実行
                RetryProcess( );

                // リトライ
                retry = Common.MAS_Yes;
            }
            else
            {
                // リトライしない場合、ステータスがFailedに設定
                Result.SetStatus(E_FUNCTION_STATUS.FAILED);
            }

            return retry;
        }

        /// <summary>
        /// 事前プロセス
        /// </summary>
        public abstract void PreProcess ( );

        /// <summary>
        /// 本体処理
        /// </summary>
        public abstract void BodyProcess ( );

        /// <summary>
        /// 事後プロセス
        /// </summary>
        public abstract void PostProcess ( );

        /// <summary>
        /// リトライプロセス(ノーマルシーケンス実行前の状態戻る)
        /// </summary>
        public abstract void RetryProcess ( );
    }
}
