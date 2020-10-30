using System;
using System.Collections.Generic;
using Xunit.Sdk;

using static CommonLib.Common.Common;
using static Log.Constant;

namespace Log.Tests
{
    public enum DirectoryTestCase
    {
        Exist,          // フォルダ存在する
        NoExist,        // フォルダ存在しない
        CanNotCreat,    // フォルダ作成できない
    }

    public struct NodeInfo
    {
        public string NodeValue;
        public object Expected;
        public NodeInfo(string value, object expected)
        {
            NodeValue = value;
            Expected = expected;
        }
    }


    public class TestBase
    {
        protected static string GetTestName(int count)
        {
            return $"TestCase_{count + 1:D4}";
        }

        public static List<NodeInfo> LOG_FILE_PATH_TestCase = new List<NodeInfo>()
        {
            new NodeInfo(@"C:\Test\", @"C:\Test\"),
            new NodeInfo("*Test", DEFAULT_LOG_FILE_PATH),
            new NodeInfo(" ", DEFAULT_LOG_FILE_PATH),
        };

        public static List<NodeInfo> IS_APPEND_TestCase = new List<NodeInfo>()
        {
            new NodeInfo("true", true),
            new NodeInfo("TRUE", true),
            new NodeInfo("false", false),
            new NodeInfo("False", false),
            new NodeInfo("FAIL", DEFAULT_IS_APPEND),
        };

        public static List<NodeInfo> CATEGORY_TestCase = new List<NodeInfo>()
        {
            new NodeInfo("Debug", TRACE_CAT_DEBUG),
            new NodeInfo("Information", TRACE_CAT_INFO),
            new NodeInfo("Warning", TRACE_CAT_WARN),
            new NodeInfo("Error", TRACE_CAT_ERROR),
            new NodeInfo("Critical", TRACE_CAT_CRITI),
            new NodeInfo("FAIL", DEFAULT_CATEGORY),
        };

        public static List<NodeInfo> OUTPUT_LEVEL_TestCase = new List<NodeInfo>()
        {
            new NodeInfo("0", E_TRACE_EVENT_LEVEL.OFF),
            new NodeInfo("1", E_TRACE_EVENT_LEVEL.Debug),
            new NodeInfo("2", E_TRACE_EVENT_LEVEL.Information),
            new NodeInfo("3", E_TRACE_EVENT_LEVEL.Warning),
            new NodeInfo("4", E_TRACE_EVENT_LEVEL.Error),
            new NodeInfo("5", E_TRACE_EVENT_LEVEL.Critical),
            new NodeInfo("-1", DEFAULT_OUTPUT_LEVEL),
            new NodeInfo("6", DEFAULT_OUTPUT_LEVEL),
            new NodeInfo("1.0", DEFAULT_OUTPUT_LEVEL),
            new NodeInfo("fail", DEFAULT_OUTPUT_LEVEL),
        };

        public static List<NodeInfo> MAX_FILE_SIZE_TestCase = new List<NodeInfo>()
        {
            new NodeInfo("1", KB_SIZE),
            new NodeInfo("10", KB_SIZE * 10),
            new NodeInfo("1048576", GB_SIZE),
            new NodeInfo("1048577", DEFAULT_MAX_FILE_SIZE),
            new NodeInfo("9223372036854775807", DEFAULT_MAX_FILE_SIZE),
            new NodeInfo("0", DEFAULT_MAX_FILE_SIZE),
            new NodeInfo("-9223372036854775808", DEFAULT_MAX_FILE_SIZE),
            new NodeInfo("1.0", DEFAULT_MAX_FILE_SIZE),
            new NodeInfo("fail", DEFAULT_MAX_FILE_SIZE),
        };

        public static List<NodeInfo> PERIOD_TestCase = new List<NodeInfo>()
        {
            new NodeInfo("1", PERIOD_MIN),
            new NodeInfo("10", 10),
            new NodeInfo("365", PERIOD_MAX),
            new NodeInfo("366", DEFAULT_PERIOD),
            new NodeInfo("2147483647", DEFAULT_PERIOD),
            new NodeInfo("0", DEFAULT_PERIOD),
            new NodeInfo("-2147483648", DEFAULT_PERIOD),
            new NodeInfo("1.0", DEFAULT_PERIOD),
            new NodeInfo("fail", DEFAULT_PERIOD),
        };

        public static List<NodeInfo> IS_AUTO_FLUSH_TestCase = new List<NodeInfo>()
        {
            new NodeInfo("true", true),
            new NodeInfo("TRUE", true),
            new NodeInfo("false", false),
            new NodeInfo("False", false),
            new NodeInfo("FAIL", DEFAULT_IS_AUTO_FLUSH),
        };

        public static Dictionary<string, List<NodeInfo>> NodeInfoTestCase = new Dictionary<string, List<NodeInfo>>()
        {
            { NODE_LOG_FILE_PATH, LOG_FILE_PATH_TestCase },
            { NODE_IS_APPEND, IS_APPEND_TestCase },
            { NODE_CATEGORY, CATEGORY_TestCase },
            { NODE_OUTPUT_LEVEL, OUTPUT_LEVEL_TestCase },
            { NODE_MAX_FILE_SIZE, MAX_FILE_SIZE_TestCase },
            { NODE_PERIOD, PERIOD_TestCase },
            { NODE_IS_AUTO_FLUSH, IS_AUTO_FLUSH_TestCase }
        };
    }
}
