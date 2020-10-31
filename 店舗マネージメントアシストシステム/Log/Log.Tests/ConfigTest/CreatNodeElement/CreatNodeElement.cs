using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

using static Log.Constant;

namespace Log.Tests.ConfigTest.SetProperty
{
    public class TestDataClass : TestBase
    {
        public static IEnumerable<object[]> TestData()
        {
            List<object[]> _testData = new List<object[]>();
            foreach (var testItem in NodeInfoTestCase)
            {
                var node = testItem.Key;
                foreach(var nodeValueItem in testItem.Value)
                {
                    var expected = nodeValueItem.Expected;
                    var nodeValue = nodeValueItem.NodeValue;
                    _testData.Add(new object[] { GetTestName(_testData.Count),
                    expected, node, nodeValue });
                }                
            }
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class SetProperty : ConfigBase
    {
        public SetProperty() : base("Test.xml") { }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void SetPropertyTest(string name, object expected, string node, string nodeValue)
        {
            Console.WriteLine(name);
            // Arrange
            var nodeList = new Dictionary<string, string>() { { node, nodeValue } };
            CreatTestXml(nodeList);
            var config = ReadTestXmlRoot();

            // Act
            config.SetProperty(node);

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
            DelectTestXml();
        }
    }
}
