namespace CommonLib.Common
{
    public enum E_FUNCTION_STATUS
    {
		/// <summary>未処理</summary>
        INIT,
		/// <summary>処理成功</summary>
        SUCCESS,
		/// <summary>処理中止</summary>
        ABORT,
		/// <summary>処理失敗</summary>
        FAILED,
    }

    public class Common
    {
        public const bool SYS_YES = true;
        public const bool SYS_NO = false;

        /// <summary>
        /// シフト定義
        /// </summary>
        public const int SHIFT_8   = 8;
        public const int SHIFT_16  = 16;
        public const int SHIFT_24  = 24;
        public const int SHIFT_28  = 28;
        public const int SHIFT_30  = 30;

        /// <summary>
        /// マスク定義
        /// </summary>
        public const int MASK_BIT_0_7      = 0x000000FF;
        public const int MASK_BIT_8_15     = 0x0000FF00;
        public const int MASK_BIT_16_23    = 0x00FF0000;
        public const int MASK_BIT_24_27    = 0x0F000000;
        public const int MASK_BIT_28_29    = 0x30000000;
        public const int MASK_BIT_30       = 0x40000000;

        /// <summary>
        /// TraceEventCategory
        /// </summary>
        public const string TRACE_CAT_CRITI = "Critical";
        public const string TRACE_CAT_ERROR = "Error";
        public const string TRACE_CAT_WARN = "Warning";
        public const string TRACE_CAT_INFO = "Information";
        public const string TRACE_CAT_DEBUG = "Debug";

    }
}
