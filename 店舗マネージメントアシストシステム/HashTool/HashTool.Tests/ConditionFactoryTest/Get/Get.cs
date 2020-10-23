using HashTool.Condition;
using System;
using System.Collections.Generic;
using Xunit;

namespace HashTool.Tests.ConditionFactoryTest.Get
{
    public class TestDataClass : TestBase
    {
        public static IEnumerable<object[]> CreatConditionTestData()
        {
            List<object[]> _testData = new List<object[]>();
            _testData.Add(new object[] { GetTestName(_testData.Count), 0 });
            return _testData;
        }

        public static IEnumerable<object[]> AnalysisConditionTestData()
        {
            List<object[]> _testData = new List<object[]>();
            List<int> condition = new List<int>();
            SetLeftTest(int.MinValue, 0, ref condition);
            SetRightTest(int.MaxValue, 0, ref condition);
            foreach (var init in condition)
                _testData.Add(new object[] { GetTestName(_testData.Count), init });
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class Get
    {
        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.CreatConditionTestData), MemberType = typeof(TestDataClass))]
        public void CreatConditionTest(string name, int init)
        {
            Console.WriteLine(name);
            // Arrange
            Conditions.Condition = init;

            // Act
            var con = ConditionFactory.Get();

            // Assert
            Assert.IsType<CreatCondition>(con);
        }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.AnalysisConditionTestData), MemberType = typeof(TestDataClass))]
        public void AnalysisConditionTest(string name, int init)
        {
            Console.WriteLine(name);
            // Arrange
            Conditions.Condition = init;

            // Act
            var con = ConditionFactory.Get();

            // Assert
            Assert.IsType<AnalysisCondition>(con);
        }
    }
}