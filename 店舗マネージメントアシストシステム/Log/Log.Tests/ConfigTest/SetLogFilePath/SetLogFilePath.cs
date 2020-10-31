using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

using static Log.Constant;

namespace Log.Tests.ConfigTest.SetLogFilePath
{
    public class TestDataClass : TestBase
    {
        public static IEnumerable<object[]> TestData()
        {
            List<object[]> _testData = new List<object[]>();
            bool[] IsExists = new bool[] { true, false };
            foreach (var testItem in NodeInfoTestCase[NODE_LOG_FILE_PATH])
            {
                foreach (var exists in IsExists)
                {
                    var expectedPath = testItem.Expected;
                    var nodeValue = testItem.NodeValue;
                    DirectoryTestCase directoryTestCase;
                    if ((string)expectedPath != DEFAULT_LOG_FILE_PATH)
                    {
                        directoryTestCase = exists ? DirectoryTestCase.Exist : DirectoryTestCase.NoExist;
                    }
                    else
                    {
                        if (!exists) continue;
                        directoryTestCase = DirectoryTestCase.CanNotCreat;
                    }

                    _testData.Add(new object[] { GetTestName(_testData.Count),
                        expectedPath, nodeValue, directoryTestCase});

                }
            }
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class SetLogFilePath : ConfigBase
    {
        public SetLogFilePath() : base("Test.xml") { }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void SetLogFilePathTest(string name, string expectedPath,
                                       string nodeValue, DirectoryTestCase directoryTestCase)
        {
            Console.WriteLine(name);
            // Arrange
            if (DirectoryTestCase.NoExist == directoryTestCase)
                Directory.CreateDirectory(nodeValue);

            var nodeList = new Dictionary<string, string>() { { NODE_LOG_FILE_PATH, nodeValue } };
            CreatTestXml(nodeList);            
            var config = ReadTestXmlNode(NODE_LOG_FILE_PATH);

            // Act
            config.SetLogFilePath();

            // Assert
            Assert.Equal(expectedPath, config.LogFilePath);
            Assert.Equal(expectedPath, config.xmlnode.InnerText);

            // 初期化
            DeleteTestXml();
            if (DirectoryTestCase.CanNotCreat != directoryTestCase)
                Directory.Delete(nodeValue);
        }
    }
}
