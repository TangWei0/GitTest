namespace LibBaseSequence.Interface
{
    internal interface ISequence
    {
        /// <summary>
        /// 通常シーケンス
        /// </summary>
        void NormalSequence ( );

        /// <summary>
        /// エラーシーケンス
        /// </summary>
        bool ErrorSequence (ProcessException ex);

        /// <summary>
        /// 事前プロセス
        /// </summary>
        void PreProcess ( );

        /// <summary>
        /// 本体処理
        /// </summary>
        void Exec ( );

        /// <summary>
        /// 事後処理
        /// </summary>
        void PostProcess ( );
    }
}
