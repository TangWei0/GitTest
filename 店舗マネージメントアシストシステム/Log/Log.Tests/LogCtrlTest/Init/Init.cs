using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Xunit;

using static Log.Constant;

namespace Log.Tests.LogCtrlTest.Init
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
        public static IEnumerable<object[]> TestData()
        {
            List<object[]> _testData = new List<object[]>();

            _testData.Add(new object[] { GetTestName(_testData.Count), 10 * KB_SIZE, true });
            _testData.Add(new object[] { GetTestName(_testData.Count), 90 * KB_SIZE, false });
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class Init
    {
        private TestInfo TestInfo = new TestInfo(0);
        private static int count = 0;
        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void InitDirectoryExistTest(string name, long expected, bool sw)
        {
            Console.WriteLine(name);
            // Arrange
            ConfigFactory.InitFlag = true;
            ConfigFactory.Config = new Config
            {
                LogFilePath = @"C:\Log\Test" + (count % 10).ToString(),
                IsAppend = sw,
            };
            count++;

            Assert.Equal(sw, ConfigFactory.Config.IsAppend);
            var logCtrl = new LogCtrl();
            if (!Directory.Exists(logCtrl.FileFolder))
                Directory.CreateDirectory(logCtrl.FileFolder);

            string[] filePathList = Directory.GetFiles(logCtrl.FileFolder);
            foreach (string filePath in filePathList)
                File.Delete(filePath);

            CreatFileListName(ConfigFactory.Config.Period);
            foreach (var item in TestInfo.FileName)
            { 
                var path = Path.Combine(logCtrl.FileFolder, item.Key);
                using StreamWriter writer = new StreamWriter(path, false);
                writer.WriteLine("Test");
                writer.Dispose();
            }

            logCtrl.Config.IsAppend = sw;
            // Act
            logCtrl.Init();

            // Assert
            Assert.Equal(expected, logCtrl.BufferSize);
            Assert.Equal(0, logCtrl.FileSize);

            var DeletedFilePath = Directory.GetFiles(logCtrl.FileFolder);
            Assert.Equal(TestInfo.Num, DeletedFilePath.Length);

            foreach (var item in TestInfo.FileName)
            {
                var path = Path.Combine(logCtrl.FileFolder, item.Key);
                if (item.Value)
                    Assert.True(File.Exists(path));
                else
                    Assert.False(File.Exists(path));
            }
            // 初期化
            ConfigFactory.Config = new Config();
            ConfigFactory.InitFlag = false;

            if (Directory.Exists(logCtrl.FileFolder))
            {
                DirectoryInfo di = new DirectoryInfo(logCtrl.FileFolder);
                di.Delete(true);
            }
        }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void InitDirectoryNoExistTest(string name, long expected, bool sw)
        {
            Console.WriteLine(name);
            // Arrange
            ConfigFactory.InitFlag = true;
            ConfigFactory.Config = new Config
            {
                LogFilePath = @"C:\Log\Test" + (count % 10).ToString(),
                IsAppend = sw,
            };
            count++;

            var logCtrl = new LogCtrl();
            logCtrl.Config.IsAppend = sw;
        
            // Act
            logCtrl.Init();

            // Assert
            Assert.Equal(expected, logCtrl.BufferSize);
            Assert.Equal(0, logCtrl.FileSize);
            Assert.True(Directory.Exists(logCtrl.FileFolder));

            // 初期化
            ConfigFactory.Config = new Config();
            ConfigFactory.InitFlag = false;

            if (Directory.Exists(logCtrl.FileFolder))
            {
                DirectoryInfo di = new DirectoryInfo(logCtrl.FileFolder);
                di.Delete(true);
            }
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
