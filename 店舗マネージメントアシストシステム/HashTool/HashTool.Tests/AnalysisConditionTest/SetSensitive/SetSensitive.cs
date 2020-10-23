using HashTool.Condition;
using HashTool.Constant;
using LibBaseSequence;
using System;
using System.Collections.Generic;
using Xunit;

namespace HashTool.Tests.AnalysisConditionTest.SetSensitive
{
    public class TestDataClass : AnalysisConditionTestBase
    {
        public static IEnumerable<object[]> SuccessTestData()
        {
            List<object[]> _testData = new List<object[]>();
            var Sensitive = GetEnumSuccess(typeof(E_HASH_SENSITIVE));
            for (var param = byte.MinValue; param <= byte.MaxValue; param++)
            {
                foreach (E_HASH_SENSITIVE expected in Sensitive)
                {
                    if (param != (byte)expected) continue;
                    E_HASH_SENSITIVE init =
                        expected == E_HASH_SENSITIVE.LOWER ?
                            E_HASH_SENSITIVE.UPPER : E_HASH_SENSITIVE.LOWER;
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
            var Sensitive = GetEnumFaile(typeof(E_HASH_SENSITIVE));
            for (var param = byte.MinValue; param <= byte.MaxValue; param++)
            {
                if (Sensitive.IndexOf(param) == -1) continue;
                _testData.Add(new object[] {
                    GetTestName(_testData.Count), param, SetMessage("Enumに変換失敗,", "sensitive", param)});
                if (param == byte.MaxValue) break;
            }
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class SetSensitiveTest
    {
        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.SuccessTestData), MemberType = typeof(TestDataClass))]
        public void SuccessTest(string name, byte param, E_HASH_SENSITIVE init, E_HASH_SENSITIVE expected)
        {
            Console.WriteLine(name);

            // Arrange
            var analysis = new AnalysisCondition();
            Conditions.Sensitive = init;

            // Act
            analysis.SetSensitive(param);

            // Assert
            Assert.Equal(expected, Conditions.Sensitive);
        }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.FaileTestData), MemberType = typeof(TestDataClass))]
        public void FaileTest(string name, byte param, string errorMessage)
        {
            Console.WriteLine(name);

            // Arrange
            var analysis = new AnalysisCondition();

            // Act
            var ex = Assert.Throws<ProcessException>(() => { analysis.SetSensitive(param); });
            Assert.Equal(errorMessage, ex.Message);
        }
    }
}
