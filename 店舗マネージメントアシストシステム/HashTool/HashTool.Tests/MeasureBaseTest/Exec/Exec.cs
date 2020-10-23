using HashTool.Condition;
using HashTool.Constant;
using HashTool.Measurement;
using LibBaseSequence;
using System;
using System.Collections.Generic;
using Xunit;

namespace HashTool.Tests.MeasureBaseTest.Exec
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
                    val, type, sen, (byte)0, count, (byte)0, (byte)(2 * count - 1), SetMessage()});
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
                                    val, type, sen, order, count, start, end, SetMessage(start, end)});
                        }
                    }
                }
            }
            return _testData;
        }

        public static string SetMessage()
        {
            return string.Format("プロセス異常発生 - HashToolの実行異常　Hash次数異常 order_num = 0");
        }

        public static string SetMessage(byte start, byte end)
        {
            return string.Format("プロセス異常発生 - HashToolの実行異常 Hash配列指定範囲を出力失敗 startIndex = 0x{0}, endIndex = 0x{1}",
                                 start.ToString("X2"), end.ToString("X2"));
        }
    }

    [Collection("Our Test Collection #1")]
    public class Exec
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
            var MD5 = new MeasureMD5();
            var SHA1 = new MeasureSHA1();
            var SHA256 = new MeasureSHA256();
            var SHA384 = new MeasureSHA384();
            var SHA512 = new MeasureSHA512();
            Parameter.Word = word;
            Conditions.Type = type;
            Conditions.Sensitive = sen;
            Conditions.Order = order;
            Conditions.ByteMaxCount = count;
            Conditions.StartIndex = start;
            Conditions.EndIndex = end;

            string act = "";
            // Act
            if (type == E_HASH_TYPE.MD5)
            {
                MD5.Exec();
                act = MD5.HashValue;
            }
            if (type == E_HASH_TYPE.SHA1)
            {
                SHA1.Exec();
                act = SHA1.HashValue;
            }
            if (type == E_HASH_TYPE.SHA256)
            {
                SHA256.Exec();
                act = SHA256.HashValue;
            }
            if (type == E_HASH_TYPE.SHA384)
            {
                SHA384.Exec();
                act = SHA384.HashValue;
            }
            if (type == E_HASH_TYPE.SHA512)
            {
                SHA512.Exec();
                act = SHA512.HashValue;
            }

            // Assert
            Assert.Equal(expected, act);
        }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.FaileTestData), MemberType = typeof(TestDataClass))]
        public void FaileTest(string name, string word,
                               E_HASH_TYPE type, E_HASH_SENSITIVE sen, E_HASH_ORDER order,
                               byte count, byte start, byte end, string errorMessage)
        {
            Console.WriteLine(name);

            // Arrange
            var MD5 = new MeasureMD5();
            var SHA1 = new MeasureSHA1();
            var SHA256 = new MeasureSHA256();
            var SHA384 = new MeasureSHA384();
            var SHA512 = new MeasureSHA512();
            new Sequence(word);
            Conditions.Type = type;
            Conditions.Sensitive = sen;
            Conditions.Order = order;
            Conditions.ByteMaxCount = count;
            Conditions.StartIndex = start;
            Conditions.EndIndex = end;

            // Act
            var ex = Assert.Throws<ProcessException>(() =>
            {
                if (type == E_HASH_TYPE.MD5)
                    MD5.Exec();
                if (type == E_HASH_TYPE.SHA1)
                    SHA1.Exec();
                if (type == E_HASH_TYPE.SHA256)
                    SHA256.Exec();
                if (type == E_HASH_TYPE.SHA384)
                    SHA384.Exec();
                if (type == E_HASH_TYPE.SHA512)
                    SHA512.Exec();
            });
            Assert.Equal(errorMessage, ex.Message);
        }
    }
}
