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
            Assert.Equal(con, ConfigFactory.config);

            // 初期化
            ConfigFactory.config = null;
        }
    }
}
