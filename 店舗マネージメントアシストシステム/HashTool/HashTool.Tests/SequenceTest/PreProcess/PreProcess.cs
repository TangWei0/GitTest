using HashTool.Condition;
using HashTool.Constant;
using HashTool.Tests.AnalysisConditionTest;
using HashTool.Tests.MeasureBaseTest;
using System;
using System.Collections.Generic;
using Xunit;

using static CommonLib.Common.Common;

namespace HashTool.Tests.SequenceTest.BodyProcess
{
    public class AnalysisTestDataClass : AnalysisConditionTestBase
    {
        public static IEnumerable<object[]> TestData()
        {
            List<object[]> _testData = new List<object[]>();
            var measure = new Measure();
            var Sensitive = GetEnumSuccess(typeof(E_HASH_SENSITIVE));
            var Order = GetEnumSuccess(typeof(E_HASH_ORDER));
            var Type = GetEnumSuccess(typeof(E_HASH_TYPE));
            foreach (E_HASH_SENSITIVE sensitive in Sensitive)
            {
                foreach (E_HASH_ORDER order in Order)
                {
                    foreach (E_HASH_TYPE type in Type)
                    {
                        var count = TypeCount[type];
                        var StartList = new List<byte>();
                        SetLeftTest(byte.MinValue, count, ref StartList);
                        foreach (var start in StartList)
                        {
                            List<byte> EndList = new List<byte>();
                            byte endMin = (byte)(start + count);
                            byte endMax = (byte)(2 * count);
                            SetLeftTest(endMin, endMax, ref EndList);
                            foreach (var end in EndList)
                            {
                                var key = Tuple.Create((byte)sensitive, (byte)order, (byte)type, count, start, end);
                                int condition = SetCondition(key);
                                foreach (var val in measure.ByteTest)
                                {
                                    _testData.Add(new object[] { GetTestName(_testData.Count), condition,
                                        sensitive, order, type, count, start, end, val.Key });
                                }

                            }
                        }
                    }
                }
            }
            return _testData;
        }
    }

    public class CreatTestDataClass : TestBase
    {
        public static IEnumerable<object[]> TestData()
        {
            List<object[]> _testData = new List<object[]>();
            List<int> condition = new List<int>();
            SetLeftTest(int.MinValue, 0, ref condition);
            SetRightTest(int.MaxValue, 0, ref condition);
            var measure = new Measure();
            foreach (var init in condition)
            {
                foreach (var val in measure.ByteTest)
                {
                    _testData.Add(new object[] { GetTestName(_testData.Count), init, val.Key });
                }
            }
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class PreProcess
    {
        // テストメソッド
        // テストメソッド
        [Theory]
        [MemberData(nameof(AnalysisTestDataClass.TestData), MemberType = typeof(AnalysisTestDataClass))]
        public void AnalysisTest(string name, int condition,
                                  E_HASH_SENSITIVE sensitive,
                                  E_HASH_ORDER order,
                                  E_HASH_TYPE type,
                                  byte maxCount, byte startIndex, byte endIndex, string hash)
        {
            Console.WriteLine(name);

            // Arrange
            var seq = new Sequence("");
            Conditions.Condition = condition;
            Result.Condition = condition;
            Result.HashValue = hash;

            // Act
            seq.PreProcess();

            // Assert
            Assert.Equal(sensitive, Conditions.Sensitive);
            Assert.Equal(order, Conditions.Order);
            Assert.Equal(type, Conditions.Type);
            Assert.Equal(maxCount, Conditions.ByteMaxCount);
            Assert.Equal(startIndex, Conditions.StartIndex);
            Assert.Equal(endIndex, Conditions.EndIndex);

            Assert.Equal(0, Result.Condition);
            Assert.Equal("", Result.HashValue);
        }

        // テストメソッド
        [Theory]
        [MemberData(nameof(CreatTestDataClass.TestData), MemberType = typeof(CreatTestDataClass))]
        public void CraetTest(string name, int init, string hash)
        {
            Console.WriteLine(name);

            // Arrange
            var seq = new Sequence("");
            Conditions.Condition = 0;
            Result.Condition = init;
            Result.HashValue = hash;

            // Act
            seq.PreProcess();

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

            Assert.Equal(0, Result.Condition);
            Assert.Equal("", Result.HashValue);
        }
    }
}
