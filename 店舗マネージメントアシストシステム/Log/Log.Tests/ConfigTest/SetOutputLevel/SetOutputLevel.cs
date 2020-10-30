using System;
using System.Collections.Generic;
using Xunit;

using static Log.Constant;

namespace Log.Tests.ConfigTest.SetOutputLevel
{
    public class TestDataClass : TestBase
    {
        public static IEnumerable<object[]> TestData()
        {
            List<object[]> _testData = new List<object[]>();

            foreach (var testItem in NodeInfoTestCase[NODE_OUTPUT_LEVEL])
            {
                var expectedOutputLevel = testItem.Expected;
                var nodeValue = testItem.NodeValue;
                _testData.Add(new object[] { GetTestName(_testData.Count),
                    expectedOutputLevel, nodeValue });
            }

            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class SetOutputLevel : ConfigBase
    {
        public SetOutputLevel() : base("Test.xml") { }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void SetOutputLevelTest(string name, E_TRACE_EVENT_LEVEL expectedOutputLevel, string nodeValue)
        {
            Console.WriteLine(name);
            // Arrange
            var nodeList = new Dictionary<string, string>() { { NODE_OUTPUT_LEVEL, nodeValue } };
            CreatTestXml(nodeList);
            var config = ReadTestXmlNode(NODE_OUTPUT_LEVEL);

            // Act
            config.SetOutputLevel();

            // Assert
            Assert.Equal(expectedOutputLevel, config.OutputLevel);
            Assert.Equal(((int)expectedOutputLevel).ToString(), config.xmlnode.InnerText);

            // 初期化
            DelectTestXml();
        }
    }
}
