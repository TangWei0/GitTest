using HashTool.Condition;
using LibBaseSequence;
using System;
using System.Collections.Generic;
using Xunit;

namespace HashTool.Tests.CreatConditionTest.CreatSensitive
{
    public class TestDataClass : CreatConditionTestBase
    {
        public static IEnumerable<object[]> SuccessTestData()
        {
            List<object[]> _testData = new List<object[]>();
            for (var i = 0; i < 20; i++) _testData.Add( new object[] { GetTestName(_testData.Count) });
            return _testData;
        }

        public static IEnumerable<object[]> FaileTestData()
        {
            List<object[]> _testData = new List<object[]>();
            _testData.Add( new object[] { GetTestName(_testData.Count), SetMessage("Sensitive") });
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class CreatSensitive : CreatConditionTestBase
    {
        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.SuccessTestData), MemberType = typeof(TestDataClass))]
        public void SuccessTest (string name)
        {
            Console.WriteLine(name);
            // Arrange
            var creat = new CreatCondition();
            
            // Act
            creat.CreatSensitive();

            // Assert
            Assert.True(IsContain(Conditions.Sensitive));
        }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.FaileTestData),MemberType = typeof(TestDataClass))]
        public void FaileTest(string name, string errorMessage )
        {
            Console.WriteLine(name);

            // Arrange
            // Act
            var ex = Assert.Throws<ProcessException>(( ) => { CreatSensitiveStub(); });
            Assert.Equal(errorMessage, ex.Message);
        }
    }
}