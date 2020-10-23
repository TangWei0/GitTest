using System;
using System.Collections.Generic;
using Xunit;

namespace Log.Tests.LogCtrlFactoryTest.GetInstance
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
            _testData.Add(new object[] { GetTestName(_testData.Count), new LogCtrl() });
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
            LogCtrlFactory.logCtrl = null;

            // Act
            LogCtrlFactory.GetInstance();

            // Assert
            Assert.IsType<LogCtrl>(LogCtrlFactory.logCtrl);
        }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.GetInstanceOldObjectTestData), MemberType = typeof(TestDataClass))]
        public void GetInstanceOldObjectTest(string name, LogCtrl log)
        {
            Console.WriteLine(name);
            // Arrange
            LogCtrlFactory.logCtrl = log;

            // Act
            LogCtrlFactory.GetInstance();

            // Assert
            Assert.Equal(log, LogCtrlFactory.logCtrl);

            // 初期化
            LogCtrlFactory.logCtrl = null;
        }
    }
}
