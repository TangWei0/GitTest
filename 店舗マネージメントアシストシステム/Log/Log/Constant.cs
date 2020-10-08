﻿namespace Log
{
    /// <summary>
    /// トレースを発生させたイベントの種類を識別します。
    /// </summary>
    public enum TraceEventType
    {
        /// <summary>情報メッセージ</summary>
        Information = 0,

        /// <summary>重要でない問題</summary>
        Warning = 1,

        /// <summary>回復可能なエラー</summary>
        Error = 2,

        /// <summary>致命的なエラーまたはアプリケーションのクラッシュ</summary>
        Critical = 3
    };

    public class Constant
    {
    }
}
