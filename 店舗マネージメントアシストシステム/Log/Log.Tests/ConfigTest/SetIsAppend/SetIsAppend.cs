using System;
using System.Collections.Generic;
using Xunit;

using static Log.Constant;

namespace Log.Tests.ConfigTest.SetIsAppend
{
    public class TestDataClass : TestBase
    {
        public static IEnumerable<object[]> TestData()
        {
            List<object[]> _testData = new List<object[]>();

            foreach (var testItem in NodeInfoTestCase[NODE_IS_APPEND])
            {
                var expectedIsAppend = testItem.Expected;
                var nodeValue = testItem.NodeValue;
                _testData.Add(new object[] { GetTestName(_testData.Count),
                    expectedIsAppend, nodeValue });
            }
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class SetIsAppend : ConfigBase
    {
        public SetIsAppend() : base("Test.xml") { }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void SetIsAppendTest(string name, bool expectedIsAppend, string nodeValue)
        {
            Console.WriteLine(name);
            // Arrange
            var nodeList = new Dictionary<string, string>() { { NODE_IS_APPEND, nodeValue } };
            CreatTestXml(nodeList);
            var config = ReadTestXmlNode(NODE_IS_APPEND);

            // Act
            config.SetIsAppend();

            // Assert
            Assert.Equal(expectedIsAppend, config.IsAppend);
            Assert.Equal(expectedIsAppend.ToString().ToUpper(), config.xmlnode.InnerText);

            // 初期化
            DeleteTestXml();
        }
    }
}
