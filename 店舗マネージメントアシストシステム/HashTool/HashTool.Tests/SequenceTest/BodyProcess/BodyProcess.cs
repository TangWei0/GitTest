using HashTool.Condition;
using HashTool.Constant;
using HashTool.Tests.MeasureBaseTest;
using LibBaseSequence;
using System;
using System.Collections.Generic;
using Xunit;

namespace HashTool.Tests.SequenceTest.BodyProcess
{
    public class TestDataClass : TestBase
    {
        public static IEnumerable<object[]> SuccessTestData()
        {
            List<object[]> _testData = new List<object[]>();
            var measure = new Measure();
            foreach (var val in measure.Hash1_2Time)
            {
                var type = val.Key.Item1;
                var sen = val.Key.Item2;
                var order = val.Key.Item3;
                var start = val.Key.Item4;
                var end = val.Key.Item5;
                var word = val.Key.Item6;
                string expected = val.Value;
                _testData.Add(new object[] {
                    GetTestName(_testData.Count), word, type, sen, order, TypeCount[type], start, end, expected});
            }
            return _testData;
        }

        public static IEnumerable<object[]> FaileTestData()
        {
            List<object[]> _testData = new List<object[]>();
            var Type = GetEnumSuccess(typeof(E_HASH_TYPE));
            var Order = GetEnumSuccess(typeof(E_HASH_ORDER));
            var val = "123";
            E_HASH_SENSITIVE sen = E_HASH_SENSITIVE.LOWER;

            foreach (E_HASH_TYPE type in Type)
            {
                var count = TypeCount[type];
                _testData.Add(new object[] { GetTestName(_testData.Count),
                    val, type, sen, (byte)0, count, (byte)0, (byte)(2 * count - 1)});
                foreach (E_HASH_ORDER order in Order)
                {
                    List<byte> StartList = new List<byte>();
                    SetLeftTest(byte.MinValue, count, ref StartList);
                    foreach (var start in StartList)
                    {
                        List<byte> EndList = new List<byte>();
                        if (start > 1)
                        {
                            byte endMin = (byte)(start - 1);
                            SetLeftTest(byte.MinValue, endMin, ref EndList);
                        }
                        byte endMax = (byte)(2 * count - 1);
                        SetRightTest(byte.MaxValue, endMax, ref EndList);
                        foreach (var end in EndList)
                        {
                            _testData.Add(new object[] { GetTestName(_testData.Count),
                                    val, type, sen, order, count, start, end});
                        }
                    }
                }
            }
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class BodyProcess
    {
        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.SuccessTestData), MemberType = typeof(TestDataClass))]
        public void SuccessTest(string name, string word,
                                 E_HASH_TYPE type, E_HASH_SENSITIVE sen, E_HASH_ORDER order,
                                 byte count, byte start, byte end, string expected)
        {
            Console.WriteLine(name);

            // Arrange
            var seq = new Sequence(word);
            Conditions.Type = type;
            Conditions.Sensitive = sen;
            Conditions.Order = order;
            Conditions.ByteMaxCount = count;
            Conditions.StartIndex = start;
            Conditions.EndIndex = end;

            // Act
            seq.BodyProcess();

            // Assert
            Assert.Equal(expected, Result.HashValue);
        }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.FaileTestData), MemberType = typeof(TestDataClass))]
        public void FaileTest(string name, string word,
                               E_HASH_TYPE type, E_HASH_SENSITIVE sen, E_HASH_ORDER order,
                               byte count, byte start, byte end)
        {
            Console.WriteLine(name);

            // Arrange
            var seq = new Sequence(word);
            Conditions.Type = type;
            Conditions.Sensitive = sen;
            Conditions.Order = order;
            Conditions.ByteMaxCount = count;
            Conditions.StartIndex = start;
            Conditions.EndIndex = end;

            // Act
            var ex = Assert.Throws<ProcessException>(() => { seq.BodyProcess(); });
        }
    }
}
