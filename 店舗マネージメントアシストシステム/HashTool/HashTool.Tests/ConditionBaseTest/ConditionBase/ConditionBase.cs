using HashTool.Condition;
using HashTool.Constant;
using LibBaseSequence;
using System;
using System.Collections.Generic;
using Xunit;

namespace HashTool.Tests.ConditionBaseTest.ConditionBase
{
    public class TestDataClass : ConditionBaseBase
    {
        public static IEnumerable<object[]> SuccessTestData()
        {
            List<object[]> _testData = new List<object[]>();
            var Type = GetEnum<E_HASH_TYPE>();
            foreach (var init in Type)
            {
                var expected = TypeCount[init];
                _testData.Add(new object[] { GetTestName(_testData.Count), init, expected });
            }
            return _testData;
        }

        public static IEnumerable<object[]> FaileTestData()
        {
            List<object[]> _testData = new List<object[]>();
            _testData.Add(new object[] { GetTestName(_testData.Count), SetMessage() });
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class ConditionBase : ConditionBaseBase
    {
        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.SuccessTestData), MemberType = typeof(TestDataClass))]
        public void SuccessTest(string name, E_HASH_TYPE init, byte expected)
        {
            Console.WriteLine(name);
            // Arrange
            Conditions.Type = init;
            // Act
            var count = GetTypeMaxBytesStub();
            // Assert
            Assert.Equal(expected, count);
        }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.FaileTestData), MemberType = typeof(TestDataClass))]
        public void FaileTest(string name, string errorMessage)
        {
            Console.WriteLine(name);

            // Arrange
            // Act
            var ex = Assert.Throws<ProcessException>(() => { GetTypeMaxBytesStub(false); });
            Assert.Equal(errorMessage, ex.Message);
        }
    }
}
