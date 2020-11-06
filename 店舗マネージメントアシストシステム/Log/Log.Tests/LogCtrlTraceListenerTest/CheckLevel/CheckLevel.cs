﻿using System;
using System.Collections.Generic;
using Xunit;

using static CommonLib.Common.Common;
namespace Log.Tests.LogCtrlTraceListenerTest.CheckLevel
{
    public class TestDataClass : TestBase
    {
        public static string[] Category = new string[] { "FAIL", TRACE_CAT_DEBUG, TRACE_CAT_INFO, 
                                                          TRACE_CAT_WARN, TRACE_CAT_ERROR, TRACE_CAT_CRITI };
        public static IEnumerable<object[]> TestData()
        {
            List<object[]> _testData = new List<object[]>();
            for(var i = 0; i < Category.Length; i++)
            {
                foreach(E_TRACE_EVENT_LEVEL level in Enum.GetValues(typeof(E_TRACE_EVENT_LEVEL)))
                {
                    var expected = false;
                    if (level != E_TRACE_EVENT_LEVEL.OFF)
                    {
                        if ((int)level <= i) expected = true;
                    }
                    _testData.Add(new object[] { GetTestName(_testData.Count), 
                        expected, level, Category[i] });
                }
            }
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class CheckLevel
    {
        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void CloseTest(string name, bool expected, 
                              E_TRACE_EVENT_LEVEL level, string category)
        {
            Console.WriteLine(name);
            // Arrange
            var logCtrlTraceListener = new LogCtrlTraceListener();
            logCtrlTraceListener.Config.OutputLevel = level;

            // Act
            var rel = logCtrlTraceListener.CheckLevel(category);

            // Assert
            Assert.Equal(expected, rel);
        }
    }
}
