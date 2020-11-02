using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
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
        public static IEnumerable<object[]> BufferNullTestData()
        {
            List<object[]> _testData = new List<object[]>();

            _testData.Add(new object[] { GetTestName(_testData.Count) });
            return _testData;
        }
        public static IEnumerable<object[]> TestData()
        {
            List<object[]> _testData = new List<object[]>();

            _testData.Add(new object[] { GetTestName(_testData.Count), 10 * KB_SIZE, true });
            _testData.Add(new object[] { GetTestName(_testData.Count), 90 * KB_SIZE, false });
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class Flush
    {
        private TestInfo TestInfo = new TestInfo(0);

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.BufferNullTestData), MemberType = typeof(TestDataClass))]
        public void FlushBufferNullTest(string name)
        {
            Console.WriteLine(name);
            // Arrange
            ConfigFactory.Config = new Config();
            ConfigFactory.InitFlag = true;
            ConfigFactory.Config.LogFilePath = @"C:\Log\Test";

            var logCtrl = new LogCtrl();
            if (!Directory.Exists(logCtrl.FileFolder))
                Directory.CreateDirectory(logCtrl.FileFolder);
            if (File.Exists(logCtrl.FullPath))
                File.Delete(logCtrl.FullPath);
            File.WriteAllLines(logCtrl.FullPath, new string[100]);

            // Act
            logCtrl.Flush();

            // Assert
            Assert.Equal(100, logCtrl.FileSize);
 
            // 初期化
            ConfigFactory.Config = new Config();
            ConfigFactory.InitFlag = false;
        }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void InitDirectoryNoExistTest(string name, long expected, bool IsAppend)
        {
            Console.WriteLine(name);
            // Arrange
            ConfigFactory.Config = new Config();
            ConfigFactory.InitFlag = true;
            ConfigFactory.Config.LogFilePath = @"C:\Log\Test";
            ConfigFactory.Config.IsAppend = IsAppend;

            var logCtrl = new LogCtrl();
            if (Directory.Exists(logCtrl.FileFolder))
            {
                DirectoryInfo di = new DirectoryInfo(logCtrl.FileFolder);
                di.Delete(true);
            }

            // Act
            logCtrl.Init();

            // Assert
            Assert.Equal(expected, logCtrl.BufferSize);
            Assert.Equal(0, logCtrl.FileSize);
            Assert.True(Directory.Exists(logCtrl.FileFolder));

            // 初期化
            ConfigFactory.Config = new Config();
            ConfigFactory.InitFlag = false;
        }

        private void CreatFileListName(int period)
        {
            TestInfo = new TestInfo(0);

            DateTime CurrentTime = DateTime.Now;
            TestInfo.FileName.Add("Test_" + CurrentTime.ToString("yyyyMMdd") + ".log", true);
            TestInfo.FileName.Add("Test_" + CurrentTime.ToString("yyyyMMdd") + ".log.bk1", true);
            TestInfo.FileName.Add("Test_" + CurrentTime.AddDays(-period).ToString("yyyyMMdd") + ".log", true);            
            TestInfo.FileName.Add("Test_" + CurrentTime.AddDays(-period).ToString("yyyyMMdd") + ".log.bk1", true);
            TestInfo.FileName.Add("Test_" + CurrentTime.AddDays(-(period + 1)).ToString("yyyyMMdd") + ".log", false);
            TestInfo.FileName.Add("Test_" + CurrentTime.AddDays(-(period + 1)).ToString("yyyyMMdd") + ".log.bk1", false);

            if (period != 1)
            {
                TestInfo.FileName.Add("Test_" + CurrentTime.AddDays(-1).ToString("yyyyMMdd") + ".log", true);
                TestInfo.FileName.Add("Test_" + CurrentTime.AddDays(-1).ToString("yyyyMMdd") + ".log.bk1", true);
            }

            TestInfo.FileName.Add("Test.log", false);
            TestInfo.FileName.Add("Test_202011011.log", false);

            foreach(var item in TestInfo.FileName)
            {
                if (item.Value) TestInfo.Num++;
            }
        }
    }
}
