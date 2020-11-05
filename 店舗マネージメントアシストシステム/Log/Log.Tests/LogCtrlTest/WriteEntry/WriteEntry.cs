using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

using static CommonLib.Common.Common;
using static Log.Constant;

namespace Log.Tests.LogCtrlTest.WriteEntry
{
    public class TestDataClass : TestBase
    {
        public static string[] WordTest = new string[5] { "123", "abc", "テスト", " ", "@#$%!" };
        public static string[] Category = new string[] { TRACE_CAT_DEBUG, TRACE_CAT_INFO, TRACE_CAT_WARN, TRACE_CAT_ERROR, TRACE_CAT_CRITI };

        public static IEnumerable<object[]> TestData()
        {
            List<object[]> _testData = new List<object[]>();

            foreach(var word in WordTest)
            {
                foreach(var category in Category)
                {
                    var currentTime = DateTime.Now;
                    var expetced = currentTime.ToString("yyyy/MM/dd HH:mm:ss.fff ") + "[" + category + "]" + "\t";
                    if (category == Category[3])
                        expetced += "\t";
                    expetced += word + "\r\n";
                    _testData.Add(new object[] { GetTestName(_testData.Count), 
                        expetced, currentTime, word, category });
                }
            }

            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class WriteEntry
    {
        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void WriteEntryTest(string name, string expected, DateTime currentTime, string word, string category)
        {
            Console.WriteLine(name);
            // Arrange
            ConfigFactory.InitFlag = true;
            ConfigFactory.Config = new Config
            {
                LogFilePath = @"C:\Log\Test",
            };

            var logCtrl = new LogCtrl_Stub()
            {
                CurrentTime = currentTime,
            };

            // Act
            logCtrl.WriteEntry(word, category);

            // Assert
            Assert.Equal(expected, logCtrl.Buffer.ToString());

            // 初期化
            ConfigFactory.Config = new Config();
            ConfigFactory.InitFlag = false;
        }

        public class LogCtrl_Stub : LogCtrl
        {
            public DateTime CurrentTime { get; set;}

            public override void WriteEntry(string message, string category)
            {
                // 出力メッセージ作成
                StringBuilder outmessage = new StringBuilder();
                outmessage.Append(CurrentTime.ToString("yyyy/MM/dd HH:mm:ss.fff "));
                outmessage.Append("[" + category + "]");
                outmessage.Append("\t");

                // メッセージ部分を揃えるため
                if (TRACE_CAT_ERROR == category)
                    outmessage.Append("\t");

                outmessage.Append(message);

                // バッファに追加
                Buffer.AppendLine(outmessage.ToString());
            }
        }
    }
}
