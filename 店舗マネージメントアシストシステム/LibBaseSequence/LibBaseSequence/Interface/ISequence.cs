namespace LibBaseSequence.Interface
{
    internal interface ISequence
    {
        /// <summary>
        /// ライブラリ処理
        /// </summary>
        void Exec ( );

        /// <summary>
        /// 通常シーケンス
        /// </summary>
        void NormalSequence ( );

        /// <summary>
        /// エラーシーケンス
        /// </summary>
        bool ErrorSequence ( );

        /// <summary>
        /// 事前プロセス
        /// </summary>
        void PreProcess ( );

        /// <summary>
        /// 本体プロセス
        /// </summary>
        void BodyProcess ( );

        /// <summary>
        /// 事後プロセス
        /// </summary>
        void PostProcess ( );

        /// <summary>
        /// リトライプロセス
        /// </summary>
        void RetryProcess ( );
    }
}
