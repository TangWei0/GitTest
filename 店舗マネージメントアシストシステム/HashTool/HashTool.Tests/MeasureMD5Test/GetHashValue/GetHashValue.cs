using HashTool.Measurement;
using LibBaseSequence;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Xunit;

namespace HashTool.Tests.MeasureMD5Test.GetHashValue
{
    public class TestDataClass : TestBase
    {
        public static Dictionary<byte[], byte[]> TestCase = new Dictionary<byte[], byte[]> {
            { new byte[] { 0x31,0x32,0x33, },  new byte[] { 0x20,0x2c,0xb9,0x62,0xac,0x59,0x7,0x5b,0x96,0x4b,0x7,0x15,0x2d,0x23,0x4b,0x70, } },
            { new byte[] { 0x61,0x62,0x63, },  new byte[] { 0x90,0x1,0x50,0x98,0x3c,0xd2,0x4f,0xb0,0xd6,0x96,0x3f,0x7d,0x28,0xe1,0x7f,0x72, } },
            { new byte[] { 0xe3,0x83,0x86,0xe3,0x82,0xb9,0xe3,0x83,0x88, },  new byte[] { 0xb0,0xf1,0xc5,0xa4,0x80,0xf4,0x16,0x23,0x4a,0x80,0x3b,0x35,0xd9,0x93,0x2c,0x57, } },
            { new byte[] { 0x20, },  new byte[] { 0x72,0x15,0xee,0x9c,0x7d,0x9d,0xc2,0x29,0xd2,0x92,0x1a,0x40,0xe8,0x99,0xec,0x5f, } },
            { new byte[] { 0x40,0x23,0x24,0x25,0x21, },  new byte[] { 0x3e,0x2,0x64,0x7b,0xe9,0x72,0xf4,0x94,0x1d,0xeb,0xde,0xf,0x57,0x66,0x89,0xd9, } },
        };

        public static IEnumerable<object[]> SuccessTestData()
        {
            List<object[]> _testData = new List<object[]>();
            foreach (var val in TestCase)
            {
                _testData.Add(new object[] { GetTestName(_testData.Count), val.Key, val.Value });
            }
            return _testData;
        }

        public static IEnumerable<object[]> FaileTestData()
        {
            List<object[]> _testData = new List<object[]>();
            _testData.Add(new object[] { GetTestName(_testData.Count), null, SetMessage() });
            foreach (var val in TestCase)
            {
                _testData.Add(new object[] { GetTestName(_testData.Count), val.Key, SetMessage() });
            }
            return _testData;
        }

        public static string SetMessage()
        {
            return $"プロセス異常発生 - HashToolの実行異常　MD5ハッシュ配列出力失敗";
        }
    }

    [Collection("Our Test Collection #1")]
    public class GetHashValue
    {
        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.SuccessTestData), MemberType = typeof(TestDataClass))]
        public void SuccessTest(string name, byte[] param, byte[] expected)
        {
            Console.WriteLine(name);

            // Arrange
            var MD5 = new MeasureMD5();
            // Act
            var act = MD5.GetHashValue(param);
            // Assert
            Assert.Equal(expected, act);
        }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.FaileTestData), MemberType = typeof(TestDataClass))]
        public void FaileTest(string name, byte[] param, string errorMessage)
        {
            Console.WriteLine(name);

            // Arrange
            // Act
            var ex = Assert.Throws<ProcessException>(() => { GetHashValueStub(param); });
            Assert.Equal(errorMessage, ex.Message);
        }

        public byte[] GetHashValueStub(byte[] byte_value)
        {
            try
            {
                if (byte_value != null) throw new ObjectDisposedException("");
                return new MD5CryptoServiceProvider().ComputeHash(byte_value);
            }
            catch (Exception ex)
            {
                throw new ProcessException(
                    string.Format("HashToolの実行異常　MD5ハッシュ配列出力失敗"), ex.InnerException);
            }
        }
    }
}
