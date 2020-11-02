using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using Xunit;

using static Log.Constant;

namespace Log.Tests.LogCtrlTest.BackupLogFile
{
    public enum FileStatus
    {
        Exist,
        NoExist,
    }

    public struct TestInfo
    {
        public int Num;
        public string expectedFileName;
        public List<string> FileName;

        public TestInfo(int num = 0)
        {
            Num = num;
            expectedFileName = "";
            FileName = new List<string>();
        }
    }

    public class TestDataClass : TestBase
    {
        public static IEnumerable<object[]> TestData()
        {
            List<object[]> _testData = new List<object[]>();

            foreach (FileStatus File1 in Enum.GetValues(typeof(FileStatus)))
            {
                foreach (FileStatus File2 in Enum.GetValues(typeof(FileStatus)))
                {
                    foreach (FileStatus File3 in Enum.GetValues(typeof(FileStatus)))
                    {
                        foreach (FileStatus File4 in Enum.GetValues(typeof(FileStatus)))
                        {
                            _testData.Add(new object[] { GetTestName(_testData.Count), 
                                File1, File2, File3, File4 });
                        }
                    }
                }
            }
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class BackupLogFile
    {
        private TestInfo TestInfo = new TestInfo(0);
        
        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void BackupLogFileTest(string name, FileStatus file1, FileStatus file2, FileStatus file3, FileStatus file4)
        {
            Console.WriteLine(name);
            // Arrange
            ConfigFactory.Config = new Config();
            ConfigFactory.InitFlag = true;
            ConfigFactory.Config.LogFilePath = @"C:\Log\Test";
            var logCtrl = new LogCtrl();
            if (!Directory.Exists(logCtrl.FileFolder))
                Directory.CreateDirectory(logCtrl.FileFolder);

            string[] filePathList = Directory.GetFiles(logCtrl.FileFolder);
            foreach (string filePath in filePathList)
                File.Delete(filePath);
            bool[] IsFileExist = new bool[4];
            IsFileExist[0] = file1 == FileStatus.Exist;
            IsFileExist[1] = file2 == FileStatus.Exist;
            IsFileExist[2] = file3 == FileStatus.Exist;
            IsFileExist[3] = file4 == FileStatus.Exist;

            CreatFileListName(logCtrl.FullPath, IsFileExist);
            foreach (var item in TestInfo.FileName)
                File.WriteAllLines(item, new string[0]);

            // Act
            logCtrl.BackupLogFile();

            // Assert
            var DeletedFilePath = Directory.GetFiles(logCtrl.FileFolder);
            Assert.Equal(TestInfo.Num, DeletedFilePath.Length);
            
            // バックするファイルが存在するか
            Assert.True(File.Exists(TestInfo.expectedFileName));
            for (var i = 0; i < TestInfo.FileName.Count; i++)
            {
                if (i == 0) 
                    Assert.False(File.Exists(TestInfo.FileName[i]));
                else
                    Assert.True(File.Exists(TestInfo.FileName[i]));
            }

            Assert.Equal(0, logCtrl.FileSize);
            
            // 初期化
            ConfigFactory.Config = new Config();
            ConfigFactory.InitFlag = false;

        }

        private void CreatFileListName(string FullPath, bool[] IsFileExist)
        {
            bool ExpectedFlag = false;
            TestInfo = new TestInfo(0);

            TestInfo.FileName.Add(FullPath);
            for(var i = 0; i < IsFileExist.Length; i++)
            {
                var filename = FullPath + ".bk" + (i + 1).ToString();
                if (IsFileExist[i]) 
                    TestInfo.FileName.Add(filename);
                else
                {
                    if (!ExpectedFlag)
                    {
                        TestInfo.expectedFileName = filename;
                        ExpectedFlag = true;
                    }
                }
            }
            if (!ExpectedFlag)
                TestInfo.expectedFileName = FullPath + ".bk" + (5).ToString();

            TestInfo.Num = TestInfo.FileName.Count();
        }
    }
}
