using HashTool.Condition;
using HashTool.Tests.MeasureBaseTest;
using System;
using System.Collections.Generic;
using Xunit;

namespace HashTool.Tests.SequenceTest.PostProcess
{
    public class TestDataClass : TestBase
    {
        public static IEnumerable<object[]> PostProcessTestData ( )
        {
            List<object[]> _testData = new List<object[]>( );
            List<int> condition = new List<int>();
            condition.Add(0);
            SetLeftTest(int.MinValue, 0, ref condition);
            SetRightTest(int.MaxValue, 0, ref condition);
            foreach(var con in condition)
            {
                _testData.Add( new object[] { GetTestName(_testData.Count), con, con});
            }
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class PostProcess
    {
        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.PostProcessTestData), MemberType = typeof(TestDataClass))]
        public void PostProcessTest (string name, int con, int expected)
        {
            Console.WriteLine(name);
            // Arrange
            var seq = new Sequence("");
            Conditions.Condition = con;
            
            // Act
            seq.PostProcess();

            // Assert
            Assert.Equal(expected, Result.Condition);
        }
    }
}