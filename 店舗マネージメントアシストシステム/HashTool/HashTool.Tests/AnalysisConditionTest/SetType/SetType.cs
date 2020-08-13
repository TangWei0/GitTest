using HashTool.Condition;
using HashTool.Constant;
using LibBaseSequence;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HashTool.Tests.AnalysisConditionTest.SetType
{
    public class TestDataClass : AnalysisConditionTestBase
    {
        public static IEnumerable<object[]> SuccessTestData()
        {
            List<object[]> _testData = new List<object[]>();
            var Type = GetEnumSuccess(typeof(E_HASH_TYPE));
            for (var param = byte.MinValue; param <= byte.MaxValue; param++)
            {
                foreach(E_HASH_TYPE expected in Type)
                {
                    if (param != (byte)expected) continue;
                    E_HASH_TYPE init = 
                        expected == E_HASH_TYPE.MD5 ? E_HASH_TYPE.SHA512 : E_HASH_TYPE.MD5;
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
            var Type = GetEnumFaile(typeof(E_HASH_TYPE));

            for (var param = byte.MinValue; param <= byte.MaxValue; param++)
            {
                if (Type.IndexOf(param) == -1) continue;
                _testData.Add( new object[] { 
                    GetTestName(_testData.Count), param, SetMessage("Enumに変換失敗,", "type", param)});
                if (param == byte.MaxValue) break;
            }
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class SetType
    {
        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.SuccessTestData),MemberType = typeof(TestDataClass))]
        public void SuccessTest(string name, byte param, E_HASH_TYPE init, E_HASH_TYPE expected )
        {
            Console.WriteLine(name);

            // Arrange
            var analysis = new AnalysisCondition();
            Conditions.Type = init;

            // Act
            analysis.SetType(param);

            // Assert
            Assert.Equal(expected, Conditions.Type);
        }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.FaileTestData),MemberType = typeof(TestDataClass))]
        public void FaileTest(string name, byte param, string errorMessage )
        {
            Console.WriteLine(name);

            // Arrange
            var analysis = new AnalysisCondition();

            // Act
            var ex = Assert.Throws<ProcessException>(( ) => { analysis.SetType(param); });
            Assert.Equal(errorMessage, ex.Message);
        }
    }
}
