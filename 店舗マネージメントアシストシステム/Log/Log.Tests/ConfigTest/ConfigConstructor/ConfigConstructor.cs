using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Log.Tests.ConfigTest.ConfigConstructor
{
    public class TestDataClass : TestBase
    {
        public static IEnumerable<object[]> TestData()
        {
            List<object[]> _testData = new List<object[]>();
            _testData.Add(new object[] { GetTestName(_testData.Count)});
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class ConfigConstructor : ConfigBase
    {
        public ConfigConstructor() : base("Log.xml") { }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void ConfigConstructorTest(string name)
        {
            Console.WriteLine(name);
            // Arrange
            // Act
            var config = new Config();

            // Assert
            Assert.Equal(expectedLogFilePath, config.LogFilePath);
            Assert.Equal(expectedIsAppend, config.IsAppend);
            Assert.Equal(expectedCategory, config.Category);
            Assert.Equal(expectedOutputLevel, config.OutputLevel);
            Assert.Equal(expectedMaxFileSize, config.MaxFileSize);
            Assert.Equal(expectedPeriod, config.Period);
            Assert.Equal(expectedIsAutoFlush, config.IsAutoFlush);

            // 初期化
            ConfigFactory.InitFlag = false;
        }
    }
}
