using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

using static Log.Constant;

namespace Log.Tests.ConfigTest.Init
{
    public enum Test_SWITCH
    {
        ROOT_NULL,
        ALL_NODE_NULL,
        ALL_NODE,
    }

    public class TestDataClass : TestBase
    {
        public static IEnumerable<object[]> NoFileTestData()
        {
            List<object[]> _testData = new List<object[]>();
            _testData.Add(new object[] { GetTestName(_testData.Count) });
            return _testData;
        }

        public static IEnumerable<object[]> TestData()
        {
            List<object[]> _testData = new List<object[]>();

            foreach(Test_SWITCH sw in Enum.GetValues(typeof(Test_SWITCH)))
            {
                _testData.Add(new object[] { GetTestName(_testData.Count), sw });
            }
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class Init : ConfigBase
    {
        public Init() : base("Log.xml") { }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.NoFileTestData), MemberType = typeof(TestDataClass))]
        public void InitNoFileTest(string name)
        {
            Console.WriteLine(name);
            // Arrange
            DeleteTestXml();
            var config = new Config();

            // Act
            config.Init();

            // Assert
            Assert.Equal(DEFAULT_LOG_FILE_PATH, config.LogFilePath);
            Assert.Equal(DEFAULT_IS_APPEND, config.IsAppend);
            Assert.Equal(DEFAULT_CATEGORY, config.Category);
            Assert.Equal(DEFAULT_OUTPUT_LEVEL, config.OutputLevel);
            Assert.Equal(DEFAULT_MAX_FILE_SIZE, config.MaxFileSize);
            Assert.Equal(DEFAULT_PERIOD, config.Period);
            Assert.Equal(DEFAULT_IS_AUTO_FLUSH, config.IsAutoFlush);

            // 初期化
            DeleteTestXml();
        }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void InitFileTest(string name, Test_SWITCH sw)
        {
            Console.WriteLine(name);
            // Arrange
            if (sw == Test_SWITCH.ROOT_NULL)
                CreatTestXml();
            else if (sw == Test_SWITCH.ALL_NODE_NULL)
                CreatTestRootXml();
            else
                CreatTestXml(ConfigBase.DefalutNodeList);
            
            var config = new Config();

            // Act
            config.Init();

            // Assert
            if (sw != Test_SWITCH.ALL_NODE)
            { 
                Assert.Equal(DEFAULT_LOG_FILE_PATH, config.LogFilePath);
                Assert.Equal(DEFAULT_IS_APPEND, config.IsAppend);
                Assert.Equal(DEFAULT_CATEGORY, config.Category);
                Assert.Equal(DEFAULT_OUTPUT_LEVEL, config.OutputLevel);
                Assert.Equal(DEFAULT_MAX_FILE_SIZE, config.MaxFileSize);
                Assert.Equal(DEFAULT_PERIOD, config.Period);
                Assert.Equal(DEFAULT_IS_AUTO_FLUSH, config.IsAutoFlush);
            }
            else
            {
                Assert.Equal(expectedLogFilePath, config.LogFilePath);
                Assert.Equal(expectedIsAppend, config.IsAppend);
                Assert.Equal(expectedCategory, config.Category);
                Assert.Equal(expectedOutputLevel, config.OutputLevel);
                Assert.Equal(expectedMaxFileSize, config.MaxFileSize);
                Assert.Equal(expectedPeriod, config.Period);
                Assert.Equal(expectedIsAutoFlush, config.IsAutoFlush);
            }

            // 初期化
            DeleteTestXml();
        }
    }
}
