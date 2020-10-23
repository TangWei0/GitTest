using HashTool.Condition;
using HashTool.Constant;
using LibBaseSequence;
using System;
using System.Collections.Generic;
using Xunit;

namespace HashTool.Tests.AnalysisConditionTest.Exec
{
    public class TestDataClass : AnalysisConditionTestBase
    {
        public static IEnumerable<object[]> SuccessTestData()
        {
            List<object[]> _testData = new List<object[]>();
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
                                _testData.Add(new object[] { GetTestName(_testData.Count), condition,
                                    sensitive, order, type, count, start, end });
                            }
                        }
                    }
                }
            }
            return _testData;
        }

        public static IEnumerable<object[]> FaileTestData()
        {
            List<object[]> _testData = new List<object[]>();

            var SensitiveSuccess = GetEnumSuccess(typeof(E_HASH_SENSITIVE));
            var OrderSuccess = GetEnumSuccess(typeof(E_HASH_ORDER));
            var OrderFaile = GetEnumFaile(typeof(E_HASH_ORDER), byte.MinValue, 3);
            var TypeSuccess = GetEnumSuccess(typeof(E_HASH_TYPE));
            var TypeFaile = GetEnumFaile(typeof(E_HASH_TYPE), byte.MinValue, 15);

            // Sensitive異常
            // bit30のみので、Sensitive異常にならないため、テストしないこと

            // Order異常
            foreach (var sensitive in SensitiveSuccess)
            {
                foreach (var order in OrderFaile)
                {
                    foreach (var type in TypeSuccess)
                    {
                        var count = TypeCount[(E_HASH_TYPE)type];
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
                                var key = Tuple.Create((byte)sensitive, order, (byte)type, count, start, end);
                                _testData.Add(new object[] { GetTestName(_testData.Count), SetCondition(key) });
                            }
                        }
                    }
                }
            }

            // Type異常
            foreach (var sensitive in SensitiveSuccess)
            {
                foreach (var order in OrderSuccess)
                {
                    foreach (var type in TypeFaile)
                    {
                        var Count = new List<byte>();
                        SetLeftTest((byte)1, type, ref Count);
                        SetRightTest((byte)127, type, ref Count);
                        foreach (var count in Count)
                        {
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
                                    var key = Tuple.Create((byte)sensitive, (byte)order, type, count, start, end);
                                    _testData.Add(new object[] { GetTestName(_testData.Count), SetCondition(key) });
                                }
                            }
                        }
                    }
                }
            }

            // Count異常
            foreach (var sensitive in SensitiveSuccess)
            {
                foreach (var order in OrderSuccess)
                {
                    foreach (var type in TypeSuccess)
                    {
                        var Count = new List<byte>();
                        SetLeftTest((byte)1, (byte)type, ref Count);
                        SetRightTest((byte)127, (byte)type, ref Count);
                        foreach (var count in Count)
                        {
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
                                    _testData.Add(new object[] { GetTestName(_testData.Count), SetCondition(key) });
                                }
                            }
                        }
                    }
                }
            }

            // Start異常
            foreach (var sensitive in SensitiveSuccess)
            {
                foreach (var order in OrderSuccess)
                {
                    foreach (var type in TypeSuccess)
                    {
                        var count = TypeCount[(E_HASH_TYPE)type];
                        var StartList = new List<byte>();
                        SetRightTest((byte)127, (byte)(count - 1), ref StartList);
                        foreach (var start in StartList)
                        {
                            var end = (byte)(start + count);
                            var key = Tuple.Create((byte)sensitive, (byte)order, (byte)type, count, start, end);
                            _testData.Add(new object[] { GetTestName(_testData.Count), SetCondition(key) });
                        }
                    }
                }
            }

            // End異常
            foreach (var sensitive in SensitiveSuccess)
            {
                foreach (var order in OrderSuccess)
                {
                    foreach (var type in TypeSuccess)
                    {
                        var count = TypeCount[(E_HASH_TYPE)type];
                        var StartList = new List<byte>();
                        SetLeftTest(byte.MinValue, count, ref StartList);
                        foreach (var start in StartList)
                        {
                            List<byte> EndList = new List<byte>();
                            byte endMin = (byte)(start + count);
                            byte endMax = (byte)(2 * count - 1);
                            SetLeftTest(byte.MinValue, endMin, ref EndList);
                            SetRightTest(byte.MaxValue, endMax, ref EndList);
                            foreach (var end in EndList)
                            {
                                var key = Tuple.Create((byte)sensitive, (byte)order, (byte)type, count, start, end);
                                _testData.Add(new object[] { GetTestName(_testData.Count), SetCondition(key) });
                            }
                        }
                    }
                }
            }
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class Exec
    {
        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.SuccessTestData), MemberType = typeof(TestDataClass))]
        public void SuccessTest(string name, int condition,
                                E_HASH_SENSITIVE sensitive,
                                E_HASH_ORDER order,
                                E_HASH_TYPE type,
                                byte maxCount, byte startIndex, byte endIndex)
        {
            Console.WriteLine(name);

            // Arrange
            var analysis = new AnalysisCondition();
            Conditions.Condition = condition;

            // Act
            analysis.Exec();

            // Assert
            Assert.Equal(sensitive, Conditions.Sensitive);
            Assert.Equal(order, Conditions.Order);
            Assert.Equal(type, Conditions.Type);
            Assert.Equal(maxCount, Conditions.ByteMaxCount);
            Assert.Equal(startIndex, Conditions.StartIndex);
            Assert.Equal(endIndex, Conditions.EndIndex);
        }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.FaileTestData), MemberType = typeof(TestDataClass))]
        public void FaileTest(string name, int param)
        {
            Console.WriteLine(name);

            // Arrange
            var analysis = new AnalysisCondition();
            Conditions.Condition = param;

            // Act
            var ex = Assert.Throws<ProcessException>(() => { analysis.Exec(); });
        }
    }
}
