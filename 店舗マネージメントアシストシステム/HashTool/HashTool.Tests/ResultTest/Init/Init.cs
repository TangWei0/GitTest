using HashTool.Tests.MeasureBaseTest;
using System;
using System.Collections.Generic;
using Xunit;

namespace HashTool.Tests.ResultTest.Init
{
    public class TestDataClass : TestBase
    {
        public static IEnumerable<object[]> InitTestData()
        {
            List<object[]> _testData = new List<object[]>();
            List<int> condition = new List<int>();
            SetLeftTest(int.MinValue, 0, ref condition);
            SetRightTest(int.MaxValue, 0, ref condition);
            var measure = new Measure();
            foreach (var init in condition)
            {
                foreach (var val in measure.ByteTest)
                {
                    _testData.Add(new object[] { GetTestName(_testData.Count), init, val.Key });
                }
            }
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class Init
    {
        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.InitTestData), MemberType = typeof(TestDataClass))]
        public void InitTest(string name, int init, string hash)
        {
            Console.WriteLine(name);
            // Arrange
            var result = new Result();
            Result.HashValue = hash;
            Result.Condition = init;

            // Act
            result.Init();

            // Assert
            Assert.Equal(0, Result.Condition);
            Assert.Equal("", Result.HashValue);
        }
    }
}