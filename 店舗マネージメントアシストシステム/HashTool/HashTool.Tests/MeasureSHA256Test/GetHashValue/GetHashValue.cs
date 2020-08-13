using System;
using System.Collections.Generic;
using Xunit;
using HashTool.Measurement;
using System.Security.Cryptography;
using LibBaseSequence;

namespace HashTool.Tests.MeasureSHA256Test.GetHashValue
{
    public class TestDataClass : TestBase
    {
        public static Dictionary<byte[], byte[]> TestCase = new Dictionary<byte[], byte[]> {
            { new byte[] { 0x31,0x32,0x33, },  new byte[] { 0xa6,0x65,0xa4,0x59,0x20,0x42,0x2f,0x9d,0x41,0x7e,0x48,0x67,0xef,0xdc,0x4f,0xb8,0xa0,0x4a,0x1f,0x3f,0xff,0x1f,0xa0,0x7e,0x99,0x8e,0x86,0xf7,0xf7,0xa2,0x7a,0xe3, } },
            { new byte[] { 0x61,0x62,0x63, },  new byte[] { 0xba,0x78,0x16,0xbf,0x8f,0x1,0xcf,0xea,0x41,0x41,0x40,0xde,0x5d,0xae,0x22,0x23,0xb0,0x3,0x61,0xa3,0x96,0x17,0x7a,0x9c,0xb4,0x10,0xff,0x61,0xf2,0x0,0x15,0xad, } },
            { new byte[] { 0xe3,0x83,0x86,0xe3,0x82,0xb9,0xe3,0x83,0x88, },  new byte[] { 0x8a,0x53,0x5a,0x3f,0x4d,0xcd,0x2c,0x39,0x6d,0xb1,0x1b,0x7c,0x1e,0x54,0x22,0x1d,0x4,0x37,0x5c,0x9f,0x9b,0xe9,0x6b,0xce,0x47,0xdc,0x2f,0xdb,0x23,0x7e,0x86,0xc9, } },
            { new byte[] { 0x20, },  new byte[] { 0x36,0xa9,0xe7,0xf1,0xc9,0x5b,0x82,0xff,0xb9,0x97,0x43,0xe0,0xc5,0xc4,0xce,0x95,0xd8,0x3c,0x9a,0x43,0xa,0xac,0x59,0xf8,0x4e,0xf3,0xcb,0xfa,0xb6,0x14,0x50,0x68, } },
            { new byte[] { 0x40,0x23,0x24,0x25,0x21, },  new byte[] { 0x12,0x5b,0xc5,0xa2,0x1c,0xea,0x28,0x56,0x1a,0x49,0xca,0x60,0x6c,0x10,0x10,0x99,0x9d,0x12,0x1b,0x6e,0x98,0xfd,0x6a,0x4,0x8e,0xd,0x59,0xa,0x3a,0xae,0xff,0xbe, } },        
        };

        public static IEnumerable<object[]> SuccessTestData()
        {
            List<object[]> _testData = new List<object[]>();
            foreach(var val in TestCase)
            {
                _testData.Add(new object[] { GetTestName(_testData.Count), val.Key, val.Value});
            }
            return _testData;
        }

        public static IEnumerable<object[]> FaileTestData ( )
        {
            List<object[]> _testData = new List<object[]>( );
            _testData.Add(new object[] { GetTestName(_testData.Count), null, SetMessage()});
            foreach(var val in TestCase)
            {
                _testData.Add(new object[] { GetTestName(_testData.Count), val.Key, SetMessage()});
            }
            return _testData;
        }

        public static string SetMessage( )
        {
            return $"プロセス異常発生 - HashToolの実行異常　SHA256ハッシュ配列出力失敗";
        }
    }

    [Collection("Our Test Collection #1")]
    public class GetHashValue
    {
        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.SuccessTestData), MemberType = typeof(TestDataClass))]
        public void SuccessTest (string name, byte[] param, byte[] expected )
        {
            Console.WriteLine(name);

            // Arrange
            var SHA256 = new MeasureSHA256( );
            // Act
            var act = SHA256.GetHashValue(param);
            // Assert
            Assert.Equal(expected, act);
        }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.FaileTestData), MemberType = typeof(TestDataClass))]
        public void FaileTest (string name, byte[] param, string errorMessage)
        {
            Console.WriteLine(name);

            // Arrange
            // Act
            var ex = Assert.Throws<ProcessException>(( ) => { GetHashValueStub(param); });
            Assert.Equal(errorMessage, ex.Message);
        }

        public byte[] GetHashValueStub(byte[] byte_value)
        {
            try
            {
                if (byte_value != null) throw new ObjectDisposedException("");
                return new SHA256CryptoServiceProvider().ComputeHash(byte_value);
            }
            catch(Exception ex)
            {
                throw new ProcessException(
                    string.Format("HashToolの実行異常　SHA256ハッシュ配列出力失敗"), ex.InnerException);
            }
        }
    }
}
