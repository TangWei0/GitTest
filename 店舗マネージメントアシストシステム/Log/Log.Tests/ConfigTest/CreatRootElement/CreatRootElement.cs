using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

using static Log.Constant;

namespace Log.Tests.ConfigTest.CreatRootElement
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
    public class CreatRootElement : ConfigBase
    {
        public CreatRootElement() : base("Log.xml") { }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void CreatRootElementTest(string name)
        {
            Console.WriteLine(name);
            // Arrange
            CreatTestXml("Test");
            var config = ReadTestXmlTitle();

            // Act
            config.CreatRootElement();

            // Assert
            Assert.Equal(DEFAULT_LOG_FILE_PATH, config.LogFilePath);
            Assert.Equal(DEFAULT_IS_APPEND, config.IsAppend);
            Assert.Equal(DEFAULT_CATEGORY, config.Category);
            Assert.Equal(DEFAULT_OUTPUT_LEVEL, config.OutputLevel);
            Assert.Equal(DEFAULT_MAX_FILE_SIZE, config.MaxFileSize);
            Assert.Equal(DEFAULT_PERIOD, config.Period);
            Assert.Equal(DEFAULT_IS_AUTO_FLUSH, config.IsAutoFlush);

            // 初期化
            DelectTestXml();
        }
    }
}
