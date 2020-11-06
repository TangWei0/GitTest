using System;
using System.Collections.Generic;
using Xunit;

using static CommonLib.Common.Common;
namespace Log.Tests.LogCtrlTraceListenerTest.CategoryToLevel
{
    public class TestDataClass : TestBase
    {
        public static string[] Category = new string[] { "FAIL", TRACE_CAT_DEBUG, TRACE_CAT_INFO, 
                                                          TRACE_CAT_WARN, TRACE_CAT_ERROR, TRACE_CAT_CRITI };
        public static IEnumerable<object[]> TestData()
        {
            List<object[]> _testData = new List<object[]>();
            for(var i = 0; i < Category.Length; i++)
                _testData.Add(new object[] { GetTestName(_testData.Count), i, Category[i]});
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class CategoryToLevel
    {
        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void CloseTest(string name, int expected, string category)
        {
            Console.WriteLine(name);
            // Arrange
            var logCtrlTraceListener = new LogCtrlTraceListener();
            
            // Act
            var rel = logCtrlTraceListener.CategoryToLevel(category);

            // Assert
            Assert.Equal(expected, rel);
        }
    }
}
