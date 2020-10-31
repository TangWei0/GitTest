using System;
using System.Collections.Generic;
using Xunit;

using static Log.Constant;

namespace Log.Tests.ConfigTest.SetIsAutoFlush
{
    public class TestDataClass : TestBase
    {
        public static IEnumerable<object[]> TestData()
        {
            List<object[]> _testData = new List<object[]>();

            foreach (var testItem in NodeInfoTestCase[NODE_IS_AUTO_FLUSH])
            {
                var expectedIsAutoFlush = testItem.Expected;
                var nodeValue = testItem.NodeValue;
                _testData.Add(new object[] { GetTestName(_testData.Count),
                    expectedIsAutoFlush, nodeValue });
            }
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class SetIsAutoFlush : ConfigBase
    {
        public SetIsAutoFlush() : base("Test.xml") { }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void SetIsAutoFlushTest(string name, bool expectedIsAutoFlush, string nodeValue)
        {
            Console.WriteLine(name);
            // Arrange
            var nodeList = new Dictionary<string, string>() { { NODE_IS_AUTO_FLUSH, nodeValue } };
            CreatTestXml(nodeList);
            var config = ReadTestXmlNode(NODE_IS_AUTO_FLUSH);

            // Act
            config.SetIsAutoFlush();

            // Assert
            Assert.Equal(expectedIsAutoFlush, config.IsAutoFlush);
            Assert.Equal(expectedIsAutoFlush.ToString().ToUpper(), config.xmlnode.InnerText);

            // 初期化
            DeleteTestXml();
        }
    }
}
