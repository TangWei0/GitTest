using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

using static Log.Constant;

namespace Log.Tests.ConfigFactoryTest.Get
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
    public class Get : ConfigBase
    {
        public Get() : base("Log.xml") { }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void GetInitTrue(string name)
        {
            Console.WriteLine(name);
            // Arrange
            ConfigFactory.InitFlag = true;

            // Act
            var config = ConfigFactory.Get();

            // Assert
            Assert.True(ConfigFactory.InitFlag);

            Assert.Equal(DEFAULT_LOG_FILE_PATH, config.LogFilePath);
            Assert.Equal(DEFAULT_IS_APPEND, config.IsAppend);
            Assert.Equal(DEFAULT_CATEGORY, config.Category);
            Assert.Equal(DEFAULT_OUTPUT_LEVEL, config.OutputLevel);
            Assert.Equal(DEFAULT_MAX_FILE_SIZE, config.MaxFileSize);
            Assert.Equal(DEFAULT_PERIOD, config.Period);
            Assert.Equal(DEFAULT_IS_AUTO_FLUSH, config.IsAutoFlush);

            // 初期化
            ConfigFactory.InitFlag = false;
        }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void GetInitFalse(string name)
        {
            Console.WriteLine(name);
            // Arrange
            ConfigFactory.InitFlag = false;
            var nodeList = DefalutNodeList;

            nodeList[NODE_LOG_FILE_PATH] = TestBase.NodeInfoTestCase[NODE_LOG_FILE_PATH][0].NodeValue;
            nodeList[NODE_IS_APPEND] = TestBase.NodeInfoTestCase[NODE_IS_APPEND][1].NodeValue;
            nodeList[NODE_CATEGORY] = TestBase.NodeInfoTestCase[NODE_CATEGORY][2].NodeValue;
            nodeList[NODE_OUTPUT_LEVEL] = TestBase.NodeInfoTestCase[NODE_OUTPUT_LEVEL][3].NodeValue;
            nodeList[NODE_MAX_FILE_SIZE] = TestBase.NodeInfoTestCase[NODE_MAX_FILE_SIZE][1].NodeValue;
            nodeList[NODE_PERIOD] = TestBase.NodeInfoTestCase[NODE_PERIOD][1].NodeValue;
            nodeList[NODE_IS_AUTO_FLUSH] = TestBase.NodeInfoTestCase[NODE_IS_AUTO_FLUSH][3].NodeValue;
            CreatTestXml(nodeList);

            // Act
            var config = ConfigFactory.Get();

            // Assert
            Assert.True(ConfigFactory.InitFlag);

            Assert.Equal(TestBase.NodeInfoTestCase[NODE_LOG_FILE_PATH][0].Expected, config.LogFilePath);
            Assert.Equal(TestBase.NodeInfoTestCase[NODE_IS_APPEND][1].Expected, config.IsAppend);
            Assert.Equal(TestBase.NodeInfoTestCase[NODE_CATEGORY][2].Expected, config.Category);
            Assert.Equal(TestBase.NodeInfoTestCase[NODE_OUTPUT_LEVEL][3].Expected, config.OutputLevel);
            Assert.Equal(TestBase.NodeInfoTestCase[NODE_MAX_FILE_SIZE][1].Expected, config.MaxFileSize);
            Assert.Equal(TestBase.NodeInfoTestCase[NODE_PERIOD][1].Expected, config.Period);
            Assert.Equal(TestBase.NodeInfoTestCase[NODE_IS_AUTO_FLUSH][3].Expected, config.IsAutoFlush);

            // 初期化
            ConfigFactory.InitFlag = false;
        }
    }
}
