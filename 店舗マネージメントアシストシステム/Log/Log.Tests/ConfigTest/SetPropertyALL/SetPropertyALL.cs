using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

using static Log.Constant;

namespace Log.Tests.ConfigTest.SetPropertyALL
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
    public class SetPropertyALL : ConfigBase
    {
        public SetPropertyALL() : base("Test.xml") { }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void SetPropertyALLTest(string name, object expected, 
                                       string node, string nodeValue)
        {
            Console.WriteLine(name);
            // Arrange
            var nodeList = DefalutNodeList;
            nodeList[node] = nodeValue;
            CreatTestXml(nodeList);
            var config = ReadTestXmlRoot();

            // Act
            config.SetProperty(node);

            var expectedLogFilePath = DEFAULT_LOG_FILE_PATH;
            var expectedIsAppend = DEFAULT_IS_APPEND;
            var expectedCategory = DEFAULT_CATEGORY;
            var expectedOutputLevel = DEFAULT_OUTPUT_LEVEL;
            var expectedMaxFileSize = DEFAULT_MAX_FILE_SIZE;
            var expectedPeriod = DEFAULT_PERIOD;
            var expectedIsAutoFlush = DEFAULT_IS_AUTO_FLUSH;
            if (node == NODE_LOG_FILE_PATH)
                expectedLogFilePath = (string)expected;
            if (node == NODE_IS_APPEND)
                expectedIsAppend = (bool)expected;
            if (node == NODE_CATEGORY)
                expectedCategory = (string)expected;
            if (node == NODE_OUTPUT_LEVEL)
                expectedOutputLevel = (E_TRACE_EVENT_LEVEL)expected;
            if (node == NODE_MAX_FILE_SIZE)
                expectedMaxFileSize = (long)expected;
            if (node == NODE_PERIOD)
                expectedPeriod = (int)expected;
            if (node == NODE_IS_AUTO_FLUSH)
                expectedIsAutoFlush = (bool)expected;
            
            // Assert
            Assert.Equal(expectedLogFilePath, config.LogFilePath);
            Assert.Equal(expectedIsAppend, config.IsAppend);
            Assert.Equal(expectedCategory, config.Category);
            Assert.Equal(expectedOutputLevel, config.OutputLevel);
            Assert.Equal(expectedMaxFileSize, config.MaxFileSize);
            Assert.Equal(expectedPeriod, config.Period);
            Assert.Equal(expectedIsAutoFlush, config.IsAutoFlush);

            // 初期化
            DelectTestXml();
        }
    }
}
