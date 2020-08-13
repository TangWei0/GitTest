using HashTool.Condition;
using HashTool.Constant;
using LibBaseSequence;
using System;
using System.Collections.Generic;
using Xunit;

namespace HashTool.Tests.AnalysisConditionTest.SetByteMaxCount
{
    public class TestDataClass : AnalysisConditionTestBase
    {
        private static readonly Dictionary<E_HASH_TYPE, List<byte>> TypeCountFaile = 
            new Dictionary<E_HASH_TYPE, List<byte>>();

        public static IEnumerable<object[]> SuccessTestData()
        {
            List<object[]> _testData = new List<object[]>();
            for (var param = byte.MinValue; param <= byte.MaxValue; param++)
            {
                foreach(var typeCount in TypeCount)
                {
                    byte expected = typeCount.Value;
                    if (param != expected) continue;
                    E_HASH_TYPE init = typeCount.Key;
                    _testData.Add( 
                        new object[] { GetTestName(_testData.Count), param, init, expected });
                }
                if (param == byte.MaxValue) break;
            }
            return _testData;
        }

        public static IEnumerable<object[]> FaileTestData()
        {
            List<object[]> _testData = new List<object[]>();

            TypeCountFaile.Clear();
            foreach(var typeCount in TypeCount) 
                TypeCountFaile.Add(typeCount.Key, GetCountFaile(typeCount.Value));

            for (var param = byte.MinValue; param <= byte.MaxValue; param++)
            {
                foreach(var typeCount in TypeCountFaile)
                {
                    if (typeCount.Value.IndexOf(param) == -1) continue;
                    E_HASH_TYPE init = typeCount.Key;
                    _testData.Add( new object[] { 
                        GetTestName(_testData.Count), param, init, SetMessage("出力最大Bytes,", "maxNum", param)});
                }
                if (param == byte.MaxValue) break;
            }
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class SetByteMaxCount
    {
        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.SuccessTestData),MemberType = typeof(TestDataClass))]
        public void SuccessTest(string name, byte param, E_HASH_TYPE init, byte expected )
        {
            Console.WriteLine(name);

            // Arrange
            var analysis = new AnalysisCondition();
            Conditions.Type = init;

            // Act
            analysis.SetByteMaxCount(param);

            // Assert
            Assert.Equal(expected, Conditions.ByteMaxCount);
        }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.FaileTestData),MemberType = typeof(TestDataClass))]
        public void FaileTest(string name, byte param, E_HASH_TYPE init, string errorMessage )
        {
            Console.WriteLine(name);

            // Arrange
            var analysis = new AnalysisCondition();
            Conditions.Type = init;

            // Act
            var ex = Assert.Throws<ProcessException>(( ) => { analysis.SetByteMaxCount(param); });
            Assert.Equal(errorMessage, ex.Message);
        }
    }
}
