using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

using static Log.Constant;

namespace Log.Tests.LogCtrlTest.Init
{
    public class TestDataClass : TestBase
    {
        public static long[] MaxSizeTestCase = new long[] { KB_SIZE, 10 * KB_SIZE, GB_SIZE };
        public static IEnumerable<object[]> TestData()
        {
            List<object[]> _testData = new List<object[]>();

            foreach(var maxSize in MaxSizeTestCase)
            {
                var size = maxSize / 10;
                _testData.Add(new object[] { GetTestName(_testData.Count), size, maxSize, true });
                _testData.Add(new object[] { GetTestName(_testData.Count), size * 9, maxSize, false });
            }

            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class Init
    {
        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void InitDirectoryExistTest(string name, long expected, long maxSize, bool sw)
        {
            Console.WriteLine(name);
            // Arrange
            ConfigFactory.InitFlag = true;
            ConfigFactory.Config = new Config
            {
                LogFilePath = @"C:\Log\Test",
                IsAppend = sw,
                MaxFileSize = maxSize,
            };

            var logCtrl = new LogCtrl_Stub();
            if (!Directory.Exists(logCtrl.FileFolder))
                Directory.CreateDirectory(logCtrl.FileFolder);

            // Act
            logCtrl.Init();

            // Assert
            Assert.Equal(expected, logCtrl.BufferSize);
            Assert.Equal(0, logCtrl.FileSize);
            Assert.False(logCtrl.IsCreatDirectory);
            Assert.True(logCtrl.IsDeleteOldLogFile);

            // 初期化
            ConfigFactory.Config = new Config();
            ConfigFactory.InitFlag = false;
        }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void InitDirectoryNoExistTest(string name, long expected, long maxSize, bool sw)
        {
            Console.WriteLine(name);
            // Arrange
            ConfigFactory.InitFlag = true;
            ConfigFactory.Config = new Config
            {
                LogFilePath = @"C:\Log\Test",
                IsAppend = sw,
                MaxFileSize = maxSize,
            };

            var logCtrl = new LogCtrl_Stub();
            if (Directory.Exists(logCtrl.FileFolder))
                Directory.Delete(logCtrl.FileFolder, true);

            // Act
            logCtrl.Init();

            // Assert
            Assert.Equal(expected, logCtrl.BufferSize);
            Assert.Equal(0, logCtrl.FileSize);
            Assert.True(logCtrl.IsCreatDirectory);
            Assert.False(logCtrl.IsDeleteOldLogFile);

            // 初期化
            ConfigFactory.Config = new Config();
            ConfigFactory.InitFlag = false;
        }

        public class LogCtrl_Stub : LogCtrl
        {
            public bool IsDeleteOldLogFile { get; set; } = false;
            public bool IsCreatDirectory { get; set;} = false;

            public override void Init()
            {
                BufferSize = Config.MaxFileSize / 10;
                if (!Config.IsAppend)
                    BufferSize *= 9;
                FileSize = 0;

                if (!Directory.Exists(FileFolder))
                    IsCreatDirectory = true;
                else
                    IsDeleteOldLogFile = true;
            }
        }
    }
}
