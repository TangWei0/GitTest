using HashTool.Condition;
using HashTool.Constant;
using LibBaseSequence;
using System;
using System.Collections.Generic;
using Xunit;

namespace HashTool.Tests.CreatConditionTest.CreatStartIndex
{
    public class TestDataClass : CreatConditionTestBase
    {
        public static IEnumerable<object[]> SuccessTestData()
        {
            List<object[]> _testData = new List<object[]>();
            var TypeList = GetEnum<E_HASH_TYPE>();
            foreach (var type in TypeList)
            {
                var count = TypeCount[type];
                for (var i = 0; i < 20; i++) _testData.Add(new object[] { GetTestName(_testData.Count), count });
            }
            return _testData;
        }

        public static IEnumerable<object[]> FaileTestData()
        {
            List<object[]> _testData = new List<object[]>();
            _testData.Add(new object[] { GetTestName(_testData.Count), SetMessage("StartIndex") });
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class CreatStartIndex : CreatConditionTestBase
    {
        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.SuccessTestData), MemberType = typeof(TestDataClass))]
        public void SuccessTest(string name, byte count)
        {
            Console.WriteLine(name);
            // Arrange
            var creat = new CreatCondition();
            Conditions.ByteMaxCount = count;

            // Act
            creat.CreatStartIndex();

            // Assert
            Assert.True(IsContain(Conditions.StartIndex, Conditions.ByteMaxCount));
        }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.FaileTestData), MemberType = typeof(TestDataClass))]
        public void FaileTest(string name, string errorMessage)
        {
            Console.WriteLine(name);

            // Arrange
            // Act
            var ex = Assert.Throws<ProcessException>(() => { CreatStartIndexStub(); });
            Assert.Equal(errorMessage, ex.Message);
        }
    }
}