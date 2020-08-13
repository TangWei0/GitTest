using HashTool.Condition;
using System;
using System.Collections.Generic;
using Xunit;

namespace HashTool.Tests.SequenceTest.Constructor
{
    public class TestDataClass : TestBase
    {
        public static IEnumerable<object[]> ConstructorTestData ( )
        {
            List<object[]> _testData = new List<object[]>( );
            List<int> condition = new List<int>();
            condition.Add(0);
            SetLeftTest(int.MinValue, 0, ref condition);
            SetRightTest(int.MaxValue, 0, ref condition);

            var seq = new SequenceBase();
            foreach(var con in condition)
            {
                foreach(var word in seq.WordTest)
                { 
                    _testData.Add( new object[] { GetTestName(_testData.Count), con, word});
                }
            }
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class Constructor
    {
        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.ConstructorTestData), MemberType = typeof(TestDataClass))]
        public void ConstructorTest (string name, int con, string word)
        {
            Console.WriteLine(name);
            // Arrange
            
            // Act
            new Sequence(word, con);

            // Assert
            Assert.Equal(word, Parameter.Word);
            Assert.Equal(con, Conditions.Condition);
        }
    }
}