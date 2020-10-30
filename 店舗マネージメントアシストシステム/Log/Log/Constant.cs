using System.Collections.Generic;

using static CommonLib.Common.Common;

namespace Log
{
    public struct NodeInfo
    {
        public string NodeValue;
        public List<string> NodeComment;

        public NodeInfo(string value, List<string> comment)
        {
            NodeValue = value;
            NodeComment = comment;
        }
    }

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

        public const long KB_SIZE = 1024;
        public const long GB_SIZE = KB_SIZE * KB_SIZE * KB_SIZE;

        public const int PERIOD_MIN = 1;
        public const int PERIOD_MAX = 365;

        public const string ROOT_NAME = "Setting";
        public const string NODE_LOG_FILE_PATH = "LogFilePath";
        public const string NODE_IS_APPEND = "IsAppend";
        public const string NODE_CATEGORY = "Category";
        public const string NODE_OUTPUT_LEVEL = "OutputLevel";
        public const string NODE_MAX_FILE_SIZE = "MaxFileSize";
        public const string NODE_PERIOD = "Period";
        public const string NODE_IS_AUTO_FLUSH = "IsAutoFlush";

        public static List<string> COMMENT_LOG_FILE_PATH = new List<string>() { 
                "ログファイルパス" 
        };
        public static List<string> COMMENT_IS_APPEND = new List<string>() { 
                "ログファイル追記するか。			",
                "True	：追記する。				",
                "False	：追記しない。上書きする。	"
        };
        public static List<string> COMMENT_CATEGORY = new List<string>() {
                "TraceメッセージのCategoryが未設定場合、下記の設定値を使用する。	",
                "値：Critical、Error、Warning、Information、Debuを選択する。		"
        };
        public static List<string> COMMENT_OUTPUT_LEVEL = new List<string>() {
                "	値	メンバ名	説明																							",
                "	0	OFF			すべてのイベントを通過させません。																",
                "	1	Debug		Debugイベントのみ通過させます。																	",
                "	2	Information	DebugイベントおよびInformationイベントを通過させます。											",
                "	3	Warning		Debugイベント、InformationイベントおよびWarningイベントを通過させます。							",
                "	4	Error		Debugイベント、Informationイベント、WarningイベントおよびErrorイベントを通過させます。			",
                "	5	Critical	Debugイベント、Informationイベント、Warningイベント、ErrorイベントおよびCriticalを通過させます。"
        };
        public static List<string> COMMENT_MAX_FILE_SIZE = new List<string>() {
                "ファイルサイズ上限 1GB = 1024 * 1024 KB "
        };
        public static List<string> COMMENT_PERIOD = new List<string>() {
                "最大保管期間　365日"
        };
        public static List<string> COMMENT_IS_AUTO_FLUSH = new List<string>() {
                "自動フラッシュするか			",
                "True	：フラッシュする。		",
                "False	：フラッシュしない。	"
        };

        public static NodeInfo NODE_INFO_LOG_FILE_PATH = new NodeInfo(DEFAULT_LOG_FILE_PATH, COMMENT_LOG_FILE_PATH);
        public static NodeInfo NODE_INFO_IS_APPEND = new NodeInfo(DEFAULT_IS_APPEND.ToString().ToUpper(), COMMENT_IS_APPEND);
        public static NodeInfo NODE_INFO_CATEGORY = new NodeInfo(DEFAULT_CATEGORY, COMMENT_CATEGORY);
        public static NodeInfo NODE_INFO_OUTPUT_LEVEL = new NodeInfo(DEFAULT_OUTPUT_LEVEL.ToString(), COMMENT_OUTPUT_LEVEL);
        public static NodeInfo NODE_INFO_MAX_FILE_SIZE = new NodeInfo(DEFAULT_MAX_FILE_SIZE.ToString(), COMMENT_MAX_FILE_SIZE);
        public static NodeInfo NODE_INFO_PERIOD = new NodeInfo(DEFAULT_PERIOD.ToString(), COMMENT_PERIOD);
        public static NodeInfo NODE_INFO_IS_AUTO_FLUSH = new NodeInfo(DEFAULT_IS_AUTO_FLUSH.ToString().ToUpper(), COMMENT_IS_AUTO_FLUSH);

        public static Dictionary<string, NodeInfo> NODE_INFO = new Dictionary<string, NodeInfo>() {
            { NODE_LOG_FILE_PATH, NODE_INFO_LOG_FILE_PATH },
            { NODE_IS_APPEND, NODE_INFO_IS_APPEND },
            { NODE_CATEGORY, NODE_INFO_CATEGORY },
            { NODE_OUTPUT_LEVEL, NODE_INFO_OUTPUT_LEVEL },
            { NODE_MAX_FILE_SIZE, NODE_INFO_MAX_FILE_SIZE },
            { NODE_PERIOD, NODE_INFO_PERIOD },
            { NODE_IS_AUTO_FLUSH, NODE_INFO_IS_AUTO_FLUSH }
        };
    }
}
