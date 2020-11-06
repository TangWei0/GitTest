using System;
using System.Collections.Generic;
using Xunit;

namespace Log.Tests.LogCtrlTraceListenerTest.Close
{
    public class TestDataClass : TestBase
    {
        public static IEnumerable<object[]> TestData()
        {
            List<object[]> _testData = new List<object[]>();
            _testData.Add(new object[] { GetTestName(_testData.Count) });
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class Close
    {
        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void CloseTest(string name)
        {
            Console.WriteLine(name);
            // Arrange
            var logCtrlTraceListener = new LogCtrlTraceListener_Stub();
            
            // Act
            logCtrlTraceListener.Close();

            // Assert
            Assert.True(logCtrlTraceListener.IsFlush);
        }
    }

    public class LogCtrlTraceListener_Stub : LogCtrlTraceListener
    {
        public bool IsFlush { get; set; } = false;

        public override void Close()
        {
            IsFlush = true;
        }
    }
}
