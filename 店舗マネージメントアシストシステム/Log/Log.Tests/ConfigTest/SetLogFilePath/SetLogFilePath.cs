using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Xunit;
using static Log.Constant;

namespace Log.Tests.ConfigTest.SetLogFilePath
{
    public class TestDataClass : TestBase
    {
        public static IEnumerable<object[]> TestData()
        {
            List<object[]> _testData = new List<object[]>();

            string[] Node = new string[2] { "LogFilePath", "FailPath" };
            string[] NodeValue = new string[2] { @"C:\Test\", "*Test" };
            bool[] IsExists = new bool[2] { true, false };
            string expectedPath = "";
            bool expectedRel = false;

            for (var i = 0; i < Node.Length; i++)
            {
                for (var j = 0; j < NodeValue.Length; j++)
                {
                    foreach (var exists in IsExists)
                    {
                        if ((i == 0) && (j == 0))
                        {
                            expectedPath = NodeValue[j];
                            expectedRel = true;
                        }

                        if ((i == 0) && (j == 1))
                        {
                            if (!exists) continue;
                            expectedPath = DEFAULT_LOG_FILE_PATH;
                            expectedRel = false;
                        }
                        
                        if (i == 1)
                        {
                            if ((j == 1) && !exists) continue;
                            expectedPath = DEFAULT_LOG_FILE_PATH;
                            expectedRel = false;
                        }

                        _testData.Add(new object[] { GetTestName(_testData.Count), 
                            expectedPath, expectedRel, Node[i], NodeValue[j], exists});
                    }
                }                    
            }
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class SetLogFilePath
    {
        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void SetLogFilePathTest(string name, string expectedPath, bool expectedRel, 
                                       string node, string nodeValue, bool exists)
        {
            Console.WriteLine(name);
            // Arrange
            string path = "Test.xml";
            XElement root = new XElement("Setting");
            root.SetElementValue(node, nodeValue);
            root.Save(path);

            if (!exists)
                Directory.CreateDirectory(nodeValue);

            Config config = new Config
            {
                xdoc = XDocument.Load(path)
            };

            // Act
            var rel = config.SetLogFilePath();

            // Assert
            Assert.Equal(expectedRel, rel);
            Assert.Equal(expectedPath, config.LogFilePath);

            File.Delete(path);
            if (!exists)
                Directory.Delete(nodeValue);
        }
    }
}
