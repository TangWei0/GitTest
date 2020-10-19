using static CommonLib.Common.Common;

namespace Log
{
    public enum E_TRACE_EVENT_LEVEL
    {
        /// <summary>いずれのイベントも通過させません</summary>
        OFF,

        /// <summary>Critical、Error、Warning、Information、および Debug の各イベントを通過させます</summary>
        Debug,

        /// <summary>Critical、Error、Warning、および Information の各イベントを通過させます</summary>
        Information,

        /// <summary>Critical、Error、および Warning の各イベントを通過させます</summary>
        Warning,

        /// <summary>Critical イベントおよび Error イベントを通過させます</summary>
        Error,

        /// <summary>Critical イベントのみを通過させます</summary>
        Critical,
    }

    public static class Constant
    {
        public const string DEFAULT_LOG_FILE_PATH = @"C:\work\";
        public const bool DEFAULT_IS_APPEND = true;
        public const string DEFAULT_CATEGORY = TRACE_CAT_INFO;
        public const E_TRACE_EVENT_LEVEL DEFAULT_OUTPUT_LEVEL = E_TRACE_EVENT_LEVEL.Warning;
        public const long DEFAULT_MAX_FILE_SIZE = 10485760; // 10MB
        public const int DEFAULT_PERIOD = 30;               // 30日
        public const bool DEFAULT_IS_AUTO_FLUSH = false;
    }
}
