using System;
using System.Collections.Generic;
using Xunit;

using static Log.Constant;
using static CommonLib.Common.Common;

namespace Log.Tests.ConfigTest.SetCategory
{
    public class TestDataClass : TestBase
    {
        public static IEnumerable<object[]> TestData()
        {
            List<object[]> _testData = new List<object[]>();

            foreach (var testItem in NodeInfoTestCase[NODE_CATEGORY])
            {
                var expectedCategory = testItem.Expected;
                var nodeValue = testItem.NodeValue;
                _testData.Add(new object[] { GetTestName(_testData.Count),
                    expectedCategory, nodeValue });
            }
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class SetCategory : ConfigBase
    {
        public SetCategory() : base("Test.xml") { }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void SetCategoryTest(string name, string expectedCategory, string nodeValue)
        {
            Console.WriteLine(name);
            // Arrange
            var nodeList = new Dictionary<string, string>() { { NODE_CATEGORY, nodeValue } };
            CreatTestXml(nodeList);
            var config = ReadTestXmlNode(NODE_CATEGORY);

            // Act
            config.SetCategory();

            // Assert
            Assert.Equal(expectedCategory, config.Category);
            Assert.Equal(expectedCategory, config.xmlnode.InnerText);

            // 初期化
            DeleteTestXml();
        }
    }
}
