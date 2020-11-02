using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Xunit;

using static Log.Constant;

namespace Log.Tests.LogCtrlTest.DeleteOldLogFile
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
            _testData.Add(new object[] { GetTestName(_testData.Count), PERIOD_MIN });
            _testData.Add(new object[] { GetTestName(_testData.Count), 30 });
            _testData.Add(new object[] { GetTestName(_testData.Count), PERIOD_MAX });
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class DeleteOldLogFile
    {
        private TestInfo TestInfo = new TestInfo(0);

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void DeleteOldLogFileTest(string name, int period)
        {
            Console.WriteLine(name);
            // Arrange
            ConfigFactory.Config = new Config();
            ConfigFactory.InitFlag = true;
            ConfigFactory.Config.LogFilePath = @"C:\Log\Test";
            ConfigFactory.Config.Period = period;
            var logCtrl = new LogCtrl();
            if (!Directory.Exists(logCtrl.FileFolder))
                Directory.CreateDirectory(logCtrl.FileFolder);

            string[] filePathList = Directory.GetFiles(logCtrl.FileFolder);
            foreach (string filePath in filePathList)
                File.Delete(filePath);

            CreatFileListName(period);
            foreach (var item in TestInfo.FileName)
            { 
                var path = Path.Combine(logCtrl.FileFolder, item.Key);
                File.WriteAllLines(path, new string[0]);
            }

            // Act
            logCtrl.DeleteOldLogFile();

            // Assert
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
