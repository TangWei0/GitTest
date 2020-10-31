using System;
using System.Collections.Generic;
using Xunit;

using static Log.Constant;

namespace Log.Tests.ConfigTest.SetPeriod
{
    public class TestDataClass : TestBase
    {
        public static IEnumerable<object[]> TestData()
        {
            List<object[]> _testData = new List<object[]>();

            foreach (var testItem in NodeInfoTestCase[NODE_PERIOD])
            {
                var expectedPeriod = testItem.Expected;
                var nodeValue = testItem.NodeValue;
                _testData.Add(new object[] { GetTestName(_testData.Count),
                    expectedPeriod, nodeValue });
            }
           
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class SetPeriod : ConfigBase
    {
        public SetPeriod() : base("Test.xml") { }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void SetPeriodTest(string name, int expectedPeriod, string nodeValue)
        {
            Console.WriteLine(name);
            // Arrange
            var nodeList = new Dictionary<string, string>() { { NODE_PERIOD, nodeValue } };
            CreatTestXml(nodeList);
            var config = ReadTestXmlNode(NODE_PERIOD);

            // Act
            config.SetPeriod();

            // Assert
            Assert.Equal(expectedPeriod, config.Period);
            Assert.Equal(expectedPeriod.ToString(), config.xmlnode.InnerText);

            // 初期化
            DeleteTestXml();
        }
    }
}
