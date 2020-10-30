using System;
using System.Collections.Generic;
using Xunit;

using static Log.Constant;

namespace Log.Tests.ConfigTest.SetMaxFileSize
{
    public class TestDataClass : TestBase
    {
        public static IEnumerable<object[]> TestData()
        {
            List<object[]> _testData = new List<object[]>();

            foreach (var testItem in NodeInfoTestCase[NODE_MAX_FILE_SIZE])
            {
                var expectedMaxFileSize = testItem.Expected;
                var nodeValue = testItem.NodeValue;
                _testData.Add(new object[] { GetTestName(_testData.Count),
                    expectedMaxFileSize, nodeValue });
            }
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class SetMaxFileSize : ConfigBase
    {
        public SetMaxFileSize() : base("Test.xml") { }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void SetMaxFileSizeTest(string name, long expectedMaxFileSize, string nodeValue)
        {
            Console.WriteLine(name);
            // Arrange
            var nodeList = new Dictionary<string, string>() { { NODE_MAX_FILE_SIZE, nodeValue } };
            CreatTestXml(nodeList);
            var config = ReadTestXmlNode(NODE_MAX_FILE_SIZE);

            // Act
            config.SetMaxFileSize();

            // Assert
            Assert.Equal(expectedMaxFileSize, config.MaxFileSize);
            Assert.Equal(expectedMaxFileSize.ToString(), config.xmlnode.InnerText);

            // 初期化
            DelectTestXml();
        }
    }
}
