using System;
using System.Collections.Generic;
using Xunit;

namespace Log.Tests.LogCtrlTraceListenerTest.WriteLine
{
    public class TestDataClass : TestBase
    {
        public static IEnumerable<object[]> TestData()
        {
            List<object[]> _testData = new List<object[]>();
            foreach (bool checkLevel in new[] { false, true })
            {
                foreach (bool IsCheckFlush in new[] { false, true })
                {
                    var writeEntry = checkLevel;
                    var flush = checkLevel ? IsCheckFlush : false;
                    _testData.Add(new object[] { GetTestName(_testData.Count),
                        writeEntry, flush, checkLevel, IsCheckFlush });
                }
            }
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class WriteLine
    {
        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void CloseTest(string name, bool expectedWriteEntry, bool expectedFlush, 
            bool checkLevel, bool IsCheckFlush)
        {
            Console.WriteLine(name);
            // Arrange
            var logCtrlTraceListener = new LogCtrlTraceListener_Stub
            {
                checkLevel = checkLevel,
                IsCheckFlush = IsCheckFlush
            };

            // Act
            logCtrlTraceListener.WriteLine();

            // Assert
            Assert.Equal(expectedWriteEntry, logCtrlTraceListener.WriteEntry);
            Assert.Equal(expectedFlush, logCtrlTraceListener.flush);
        }
    }

    public class LogCtrlTraceListener_Stub : LogCtrlTraceListener
    {
        public bool checkLevel { get; set; } = false;
        public bool IsCheckFlush { get; set; } = false;
        public bool WriteEntry { get; set; } = false;
        public bool flush { get; set; } = false;

        public override void WriteLine(string message = "", string category = "")
        {
            // 出力チェック
            if (checkLevel)
            { 
                WriteEntry = true;

                // ログ出力かを判断し、True場合ログ出力する
                if (IsCheckFlush)
                    flush = true;
            }
        }
    }
}
