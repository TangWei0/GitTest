using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Text;
using Xunit;

using static Log.Constant;

namespace Log.Tests.LogCtrlTest.Flush
{
    public struct TestInfo
    {
        public int Num;
        public Dictionary<string, bool> FileName;

        public TestInfo(int num = 0)
        {
            Num = num;
            FileName = new Dictionary<string, bool>();
        }
    }

    public class TestDataClass : TestBase
    {
        public static string[] WordTest = new string[5] { "123", "abc", "テスト", " ", "@#$%!" };
        public static IEnumerable<object[]> BufferNullTestData()
        {
            List<object[]> _testData = new List<object[]>();

            foreach(var word in WordTest)
                _testData.Add(new object[] { GetTestName(_testData.Count), word });
            return _testData;
        }

        public static IEnumerable<object[]> TestData()
        {
            List<object[]> _testData = new List<object[]>();

            foreach(bool sw in new[] { false, true })
            {
                foreach (var word in WordTest)
                    _testData.Add(new object[] { GetTestName(_testData.Count), sw, word });
            }
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class Flush
    {
        private TestInfo TestInfo = new TestInfo(0);
        private static int count = 0;
        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.BufferNullTestData), MemberType = typeof(TestDataClass))]
        public void FlushBufferNullTest(string name, string word)
        {
            Console.WriteLine(name);
            // Arrange
            ConfigFactory.Config = new Config();
            ConfigFactory.InitFlag = true;
            ConfigFactory.Config.LogFilePath = @"C:\Log\Test" + (count % 2).ToString();
            count++;
            var logCtrl = new LogCtrl();
            if (!Directory.Exists(logCtrl.FileFolder))
                Directory.CreateDirectory(logCtrl.FileFolder);
            if (File.Exists(logCtrl.FullPath))
                File.Delete(logCtrl.FullPath);
            using (StreamWriter writer = new StreamWriter(logCtrl.FullPath, false))
            {
                writer.WriteLine(word);
                writer.Dispose();
            }
            
            var expectedFileSize = word.Length + 2;
            logCtrl.FileSize = expectedFileSize;
            logCtrl.Buffer = new StringBuilder();

            // Act
            logCtrl.Flush();

            // Assert
            Assert.Equal(expectedFileSize, logCtrl.FileSize);
 
            // 初期化
            ConfigFactory.Config = new Config();
            ConfigFactory.InitFlag = false;
        }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void FlushBufferTest(string name, bool IsAppend, string word)
        {
            Console.WriteLine(name);
            // Arrange
            ConfigFactory.Config = new Config();
            ConfigFactory.InitFlag = true;
            ConfigFactory.Config.LogFilePath = @"C:\Log\Test" + (count % 2).ToString();
            count++;
            ConfigFactory.Config.IsAppend = IsAppend;

            var logCtrl = new LogCtrl();
            if (!Directory.Exists(logCtrl.FileFolder))
                Directory.CreateDirectory(logCtrl.FileFolder);
            using (StreamWriter writer = new StreamWriter(logCtrl.FullPath, false))
            {
                writer.WriteLine(word);
                writer.Dispose();
            }
            
            logCtrl.FileSize = word.Length + 2;
            logCtrl.Buffer = new StringBuilder();
            
            // 出力メッセージ作成
            StringBuilder outmessage = new StringBuilder();
            outmessage.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff "));
            outmessage.Append("\t");
            outmessage.Append("Test");
            // バッファに追加
            logCtrl.Buffer.AppendLine(outmessage.ToString());

            long expectedFileSize = outmessage.Length + 2; // AppendLine改行したので、2Byteを加算する
            if (IsAppend)
                expectedFileSize += logCtrl.FileSize;

            // Act
            logCtrl.Flush();

            // Assert
            Assert.Equal(0, logCtrl.BufferSize);
            Assert.Equal(expectedFileSize, logCtrl.FileSize);
            
            // 初期化
            ConfigFactory.Config = new Config();
            ConfigFactory.InitFlag = false;
        }
    }
}
