using HashTool.Condition;
using HashTool.Constant;
using LibBaseSequence;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HashTool.Tests.AnalysisConditionTest.SetOrder
{
    public class TestDataClass : AnalysisConditionTestBase
    {
        public static IEnumerable<object[]> SuccessTestData()
        {
            List<object[]> _testData = new List<object[]>();
            var Order = GetEnumSuccess(typeof(E_HASH_ORDER));
            for (var param = byte.MinValue; param <= byte.MaxValue; param++)
            {
                foreach(E_HASH_ORDER expected in Order)
                {
                    if (param != (byte)expected) continue;
                    E_HASH_ORDER init = 
                        expected == E_HASH_ORDER.SINGLE ? 
                            E_HASH_ORDER.DOUBLE : E_HASH_ORDER.SINGLE;

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
            var Order = GetEnumFaile(typeof(E_HASH_ORDER));
            for (var param = byte.MinValue; param <= byte.MaxValue; param++)
            {
                if (Order.IndexOf(param) == -1) continue;
                _testData.Add( new object[] { 
                    GetTestName(_testData.Count), param, SetMessage("Enumに変換失敗,", "order", param)});
                if (param == byte.MaxValue) break;
            }
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class SetOrderTest
    {
        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.SuccessTestData),MemberType = typeof(TestDataClass))]
        public void SuccessTest(string name, byte param, E_HASH_ORDER init, E_HASH_ORDER expected )
        {
            Console.WriteLine(name);

            // Arrange
            var analysis = new AnalysisCondition();
            Conditions.Order = init;

            // Act
            analysis.SetOrder(param);

            // Assert
            Assert.Equal(expected, Conditions.Order);
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
            var ex = Assert.Throws<ProcessException>(( ) => { analysis.SetOrder(param); });
            Assert.Equal(errorMessage, ex.Message);
        }
    }
}
