using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

using static Log.Constant;

namespace Log.Tests.ConfigTest.CreatNodeElement
{
    public class TestDataClass : TestBase
    {
        public static IEnumerable<object[]> TestData()
        {
            List<object[]> _testData = new List<object[]>();
            foreach (var testItem in NodeInfoTestCase)
            {
                var node = testItem.Key;
                var num = NodeInfoTestCase[node].Count;
                var expected = NodeInfoTestCase[node][num - 1].Expected;
                _testData.Add(new object[] { GetTestName(_testData.Count), expected, node });
            }
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class CreatNodeElement : ConfigBase
    {
        public CreatNodeElement() : base("Test.xml") { }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void CreatNodeElementTest(string name, object expected, string node)
        {
            Console.WriteLine(name);
            // Arrange
            CreatTestRootXml();
            var config = ReadTestXmlRoot();

            // Act
            config.CreatNodeElement(node);

            // Assert
            if (node == NODE_LOG_FILE_PATH)
                Assert.Equal((string)expected, config.LogFilePath);
            if (node == NODE_IS_APPEND)
                Assert.Equal((bool)expected, config.IsAppend);
            if (node == NODE_CATEGORY)
                Assert.Equal((string)expected, config.Category);
            if (node == NODE_OUTPUT_LEVEL)
                Assert.Equal((E_TRACE_EVENT_LEVEL)expected, config.OutputLevel);
            if (node == NODE_MAX_FILE_SIZE)
                Assert.Equal((long)expected, config.MaxFileSize);
            if (node == NODE_PERIOD)
                Assert.Equal((int)expected, config.Period);
            if (node == NODE_IS_AUTO_FLUSH)
                Assert.Equal((bool)expected, config.IsAutoFlush);

            // 初期化
            DeleteTestXml();
        }
    }
}
