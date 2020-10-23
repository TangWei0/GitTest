using HashTool.Condition;
using HashTool.Constant;
using LibBaseSequence;
using System;
using System.Collections.Generic;
using Xunit;

namespace HashTool.Tests.CreatConditionTest.CreatEndIndex
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
                List<byte> StartList = new List<byte>();
                SetLeftTest(byte.MinValue, count, ref StartList);
                foreach (var start in StartList)
                {
                    for (var i = 0; i < 20; i++)
                        _testData.Add(new object[] { GetTestName(_testData.Count), count, start });
                }
            }
            return _testData;
        }

        public static IEnumerable<object[]> FaileTestData()
        {
            List<object[]> _testData = new List<object[]>();
            _testData.Add(new object[] { GetTestName(_testData.Count), SetMessage("EndIndex") });
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class CreatEndIndex : CreatConditionTestBase
    {
        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.SuccessTestData), MemberType = typeof(TestDataClass))]
        public void SuccessTest(string name, byte count, byte start)
        {
            Console.WriteLine(name);
            // Arrange
            var creat = new CreatCondition();
            Conditions.EndIndex = 0;
            Conditions.ByteMaxCount = count;
            Conditions.StartIndex = start;

            // Act
            creat.CreatEndIndex();

            // Assert
            Assert.True(IsContain(Conditions.EndIndex,
                                  (byte)(2 * Conditions.ByteMaxCount),
                                  (byte)(Conditions.ByteMaxCount + Conditions.StartIndex)));
        }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.FaileTestData), MemberType = typeof(TestDataClass))]
        public void FaileTest(string name, string errorMessage)
        {
            Console.WriteLine(name);

            // Arrange
            // Act
            var ex = Assert.Throws<ProcessException>(() => { CreatEndIndexStub(); });
            Assert.Equal(errorMessage, ex.Message);
        }
    }
}