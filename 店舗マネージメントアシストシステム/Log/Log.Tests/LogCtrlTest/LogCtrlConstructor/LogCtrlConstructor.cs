using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

using static Log.Constant;

namespace Log.Tests.LogCtrlTest.LogCtrlConstructor
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
    public class Get : ConfigBase
    {
        public Get() : base("Log.xml") { }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void GetLogCtrlConstructorTrue(string name)
        {
            Console.WriteLine(name);
            // Arrange
            ConfigFactory.InitFlag = true;

            // Act
            var logCtrl = new LogCtrl();

            // Assert
            Assert.Equal(expectedLogFilePath, logCtrl.Config.LogFilePath);
            Assert.Equal(expectedIsAppend, logCtrl.Config.IsAppend);
            Assert.Equal(expectedCategory, logCtrl.Config.Category);
            Assert.Equal(expectedOutputLevel, logCtrl.Config.OutputLevel);
            Assert.Equal(expectedMaxFileSize, logCtrl.Config.MaxFileSize);
            Assert.Equal(expectedPeriod, logCtrl.Config.Period);
            Assert.Equal(expectedIsAutoFlush, logCtrl.Config.IsAutoFlush);

            // 初期化
            ConfigFactory.InitFlag = false;
            ConfigFactory.Config = new Config();
        }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void GetLogCtrlConstructorFalse(string name)
        {
            Console.WriteLine(name);
            // Arrange
            DeleteTestXml();
            ConfigFactory.InitFlag = false;

            // Act
            var logCtrl = new LogCtrl();

            // Assert
            Assert.Equal(DEFAULT_LOG_FILE_PATH, logCtrl.Config.LogFilePath);
            Assert.Equal(DEFAULT_IS_APPEND, logCtrl.Config.IsAppend);
            Assert.Equal(DEFAULT_CATEGORY, logCtrl.Config.Category);
            Assert.Equal(DEFAULT_OUTPUT_LEVEL, logCtrl.Config.OutputLevel);
            Assert.Equal(DEFAULT_MAX_FILE_SIZE, logCtrl.Config.MaxFileSize);
            Assert.Equal(DEFAULT_PERIOD, logCtrl.Config.Period);
            Assert.Equal(DEFAULT_IS_AUTO_FLUSH, logCtrl.Config.IsAutoFlush);

            // 初期化
            ConfigFactory.InitFlag = false;
            ConfigFactory.Config = new Config();
        }
    }
}
