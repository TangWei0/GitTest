using HashTool.Measurement;
using LibBaseSequence;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Xunit;

namespace HashTool.Tests.MeasureSHA1Test.GetHashValue
{
    public class TestDataClass : TestBase
    {
        public static Dictionary<byte[], byte[]> TestCase = new Dictionary<byte[], byte[]> {
            { new byte[] { 0x31,0x32,0x33, },  new byte[] { 0x40,0xbd,0x0,0x15,0x63,0x8,0x5f,0xc3,0x51,0x65,0x32,0x9e,0xa1,0xff,0x5c,0x5e,0xcb,0xdb,0xbe,0xef, } },
            { new byte[] { 0x61,0x62,0x63, },  new byte[] { 0xa9,0x99,0x3e,0x36,0x47,0x6,0x81,0x6a,0xba,0x3e,0x25,0x71,0x78,0x50,0xc2,0x6c,0x9c,0xd0,0xd8,0x9d, } },
            { new byte[] { 0xe3,0x83,0x86,0xe3,0x82,0xb9,0xe3,0x83,0x88, },  new byte[] { 0x63,0xb5,0x60,0xdb,0x88,0x49,0xe0,0x87,0x97,0x62,0x4b,0x58,0x33,0x52,0x40,0xe0,0xd0,0x62,0x82,0xbd, } },
            { new byte[] { 0x20, },  new byte[] { 0xb8,0x58,0xcb,0x28,0x26,0x17,0xfb,0x9,0x56,0xd9,0x60,0x21,0x5c,0x8e,0x84,0xd1,0xcc,0xf9,0x9,0xc6, } },
            { new byte[] { 0x40,0x23,0x24,0x25,0x21, },  new byte[] { 0x64,0xe2,0x5e,0x72,0x1b,0x7a,0x29,0x2d,0x5e,0xf6,0x28,0x1f,0xf0,0x22,0x17,0x44,0x72,0xd1,0x92,0x9a, } },
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
            return $"プロセス異常発生 - HashToolの実行異常　SHA1ハッシュ配列出力失敗";
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
            var SHA1 = new MeasureSHA1();
            // Act
            var act = SHA1.GetHashValue(param);
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
                return new SHA1CryptoServiceProvider().ComputeHash(byte_value);
            }
            catch (Exception ex)
            {
                throw new ProcessException(
                    string.Format("HashToolの実行異常　SHA1ハッシュ配列出力失敗"), ex.InnerException);
            }
        }
    }
}
