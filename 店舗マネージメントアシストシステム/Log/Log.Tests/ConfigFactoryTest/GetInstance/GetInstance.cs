using System;
using System.Collections.Generic;
using Xunit;

namespace Log.Tests.ConfigFactoryTest.GetInstance
{
    public class TestDataClass : TestBase
    {
        public static IEnumerable<object[]> GetInstanceNewObjectTestData()
        {
            List<object[]> _testData = new List<object[]>();
            _testData.Add(new object[] { GetTestName(_testData.Count) });
            return _testData;
        }

        public static IEnumerable<object[]> GetInstanceOldObjectTestData()
        {
            List<object[]> _testData = new List<object[]>();
            _testData.Add(new object[] { GetTestName(_testData.Count), new Config() });
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class GetInstance
    {
        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.GetInstanceNewObjectTestData), MemberType = typeof(TestDataClass))]
        public void GetInstanceNewObjectTest(string name)
        {
            Console.WriteLine(name);
            // Arrange
            ConfigFactory.config = null;

            // Act
            ConfigFactory.GetInstance();

            // Assert
            Assert.IsType<Config>(ConfigFactory.config);
        }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.GetInstanceOldObjectTestData), MemberType = typeof(TestDataClass))]
        public void GetInstanceOldObjectTest(string name, Config con)
        {
            Console.WriteLine(name);
            // Arrange
            ConfigFactory.config = con;

            // Act
            ConfigFactory.GetInstance();

            // Assert
            Assert.Equal(con.Category, ConfigFactory.config.Category);
            Assert.Equal(con.IsAppend, ConfigFactory.config.IsAppend);
            Assert.Equal(con.IsAutoFlush, ConfigFactory.config.IsAutoFlush);
            Assert.Equal(con.LogFilePath, ConfigFactory.config.LogFilePath);
            Assert.Equal(con.MaxFileSize, ConfigFactory.config.MaxFileSize);
            Assert.Equal(con.OutputLevel, ConfigFactory.config.OutputLevel);
            Assert.Equal(con.Period, ConfigFactory.config.Period);
        }
    }
}
