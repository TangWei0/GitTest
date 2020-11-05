using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

using static Log.Constant;

namespace Log.Tests.LogCtrlFactoryTest.Get
{
    public class TestDataClass : TestBase
    {
        public static IEnumerable<object[]> TestData()
        {
            List<object[]> _testData = new List<object[]>();
            foreach (bool init in new[] { false, true })
            {
                var expected = init ? 0 : 90 * KB_SIZE;
                _testData.Add(new object[] { GetTestName(_testData.Count), expected, init });
            }
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class Get
    {
        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.TestData), MemberType = typeof(TestDataClass))]
        public void GetInitTrue(string name, long expected, bool init)
        {
            Console.WriteLine(name);
            // Arrange
            ConfigFactory.Config = new Config();
            ConfigFactory.InitFlag = true;
            LogCtrlFactory.LogCtrl = new LogCtrl();
            LogCtrlFactory.InitFlag = init;

            // Act
            var logCtrl = LogCtrlFactory.Get();

            // Assert
            Assert.True(LogCtrlFactory.InitFlag);
            Assert.Equal(expected, logCtrl.BufferSize);
            Assert.Equal(0, logCtrl.FileSize);

            // 初期化
            LogCtrlFactory.InitFlag = false;
            LogCtrlFactory.LogCtrl = new LogCtrl();
            ConfigFactory.InitFlag = false;
            ConfigFactory.Config = new Config();
        }
    }
}
