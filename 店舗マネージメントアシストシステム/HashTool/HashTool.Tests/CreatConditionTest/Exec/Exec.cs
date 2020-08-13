using HashTool.Condition;
using HashTool.Constant;
using LibBaseSequence;
using System;
using System.Collections.Generic;
using Xunit;

using static CommonLib.Constant.ManagerAssist.Common;

namespace HashTool.Tests.CreatConditionTest.Exec
{
    public class TestDataClass : CreatConditionTestBase
    {
        public static IEnumerable<object[]> SuccessTestData()
        {
            List<object[]> _testData = new List<object[]>();
            for (var i = 0; i < 20; i++) 
                _testData.Add( new object[] { GetTestName(_testData.Count) });
            return _testData;
        }

        public static IEnumerable<object[]> FaileTestData ( )
        {
            List<object[]> _testData = new List<object[]>( );
            for (var step = 0; step < 6; step++)
            {
                _testData.Add( new object[] { GetTestName(_testData.Count), step });
            }
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class Exec : CreatConditionTestBase
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
            creat.Exec();

            // Assert
            byte tmp;
            tmp = (byte)((Conditions.Condition & MASK_BIT_30) >> SHIFT_30);
            Assert.True((byte)Conditions.Sensitive == tmp);

            tmp = (byte)((Conditions.Condition & MASK_BIT_28_29) >> SHIFT_28);
            Assert.True((byte)Conditions.Order == tmp);

            tmp = (byte)((Conditions.Condition & MASK_BIT_24_27) >> SHIFT_24);
            Assert.True((byte)Conditions.Type == tmp);

            tmp = (byte)((Conditions.Condition & MASK_BIT_16_23) >> SHIFT_16);
            Assert.True(Conditions.ByteMaxCount == tmp);

            tmp = (byte)((Conditions.Condition & MASK_BIT_8_15) >> SHIFT_8);
            Assert.True(Conditions.StartIndex == tmp);

            tmp = (byte)(Conditions.Condition & MASK_BIT_0_7);
            Assert.True(Conditions.EndIndex == tmp);
        }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.FaileTestData), MemberType = typeof(TestDataClass))]
        public void FaileTest (string name, int step)
        {
            Console.WriteLine(name);

            // Arrange
            // Act
            var ex = Assert.Throws<ProcessException>(( ) => { ExecStub(step); });
        }
    }
}
