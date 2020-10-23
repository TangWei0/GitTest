using LibBaseSequence.Interface;
using CommonLib.Common;
using System.Diagnostics;

using static CommonLib.Common.Common;

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
            retryEnable = retryMax != 0;
            remainAction = retryMax;
        }

        /// <summary>
        /// ライブラリ処理
        /// </summary>
        public void Exec ( )
        {
            bool rel = SYS_NO;
            bool retry = SYS_NO;

            do
            {
                try
                {
                    // ノーマルシーケンスを実行
                    NormalSequence( );
                    rel = SYS_YES;
                }
                catch(ProcessException ex)
                {
                    // 例外処理
                    Trace.WriteLine(ex, TRACE_CAT_ERROR);

                    // エラーシーケンスを実行
                    retry = ErrorSequence( );
                }
            } while(retry == SYS_YES);

            if(rel)
            {
                // ライブラリ実行結果を設定
                Result.Status = E_FUNCTION_STATUS.SUCCESS;
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
            bool retry = SYS_NO;

            if(retryEnable && (remainAction > 0))
            {
                // リトライ かつ 残り行動数あり
                remainAction--;

                // リトライプロセスを実行
                RetryProcess( );

                // リトライ
                retry = SYS_YES;
            }
            else
            {
                // リトライしない場合、ステータスがFailedに設定
                Result.Status = E_FUNCTION_STATUS.FAILED;
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
