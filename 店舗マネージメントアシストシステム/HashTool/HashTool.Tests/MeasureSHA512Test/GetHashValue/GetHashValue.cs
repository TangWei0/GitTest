﻿using HashTool.Measurement;
using LibBaseSequence;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Xunit;

namespace HashTool.Tests.MeasureSHA512Test.GetHashValue
{
    public class TestDataClass : TestBase
    {
        public static Dictionary<byte[], byte[]> TestCase = new Dictionary<byte[], byte[]> {
            { new byte[] { 0x31,0x32,0x33, },  new byte[] { 0x3c,0x99,0x9,0xaf,0xec,0x25,0x35,0x4d,0x55,0x1d,0xae,0x21,0x59,0xb,0xb2,0x6e,0x38,0xd5,0x3f,0x21,0x73,0xb8,0xd3,0xdc,0x3e,0xee,0x4c,0x4,0x7e,0x7a,0xb1,0xc1,0xeb,0x8b,0x85,0x10,0x3e,0x3b,0xe7,0xba,0x61,0x3b,0x31,0xbb,0x5c,0x9c,0x36,0x21,0x4d,0xc9,0xf1,0x4a,0x42,0xfd,0x7a,0x2f,0xdb,0x84,0x85,0x6b,0xca,0x5c,0x44,0xc2, } },
            { new byte[] { 0x61,0x62,0x63, },  new byte[] { 0xdd,0xaf,0x35,0xa1,0x93,0x61,0x7a,0xba,0xcc,0x41,0x73,0x49,0xae,0x20,0x41,0x31,0x12,0xe6,0xfa,0x4e,0x89,0xa9,0x7e,0xa2,0xa,0x9e,0xee,0xe6,0x4b,0x55,0xd3,0x9a,0x21,0x92,0x99,0x2a,0x27,0x4f,0xc1,0xa8,0x36,0xba,0x3c,0x23,0xa3,0xfe,0xeb,0xbd,0x45,0x4d,0x44,0x23,0x64,0x3c,0xe8,0xe,0x2a,0x9a,0xc9,0x4f,0xa5,0x4c,0xa4,0x9f, } },
            { new byte[] { 0xe3,0x83,0x86,0xe3,0x82,0xb9,0xe3,0x83,0x88, },  new byte[] { 0xb,0x5d,0x8c,0x7f,0xb5,0xb9,0x42,0xcb,0x9,0xb0,0x39,0xd,0xb6,0xfd,0x9,0xff,0x77,0xaa,0x56,0x27,0xa,0xae,0x66,0xee,0x13,0x9b,0x89,0xb,0x16,0x31,0x16,0x61,0xc,0x91,0x5f,0x12,0x46,0xc7,0x20,0x42,0x37,0xe3,0x22,0x43,0x60,0xa0,0x1e,0xc1,0xad,0x63,0x39,0x18,0xda,0x91,0x9c,0xbe,0x2b,0x24,0xd5,0xba,0x8c,0x5b,0x3d,0xdc, } },
            { new byte[] { 0x20, },  new byte[] { 0xf9,0xd,0xdd,0x77,0xe4,0x0,0xdf,0xe6,0xa3,0xfc,0xf4,0x79,0xb0,0xb,0x1e,0xe2,0x9e,0x70,0x15,0xc5,0xbb,0x8c,0xd7,0xf,0x5f,0x15,0xb4,0x88,0x6c,0xc3,0x39,0x27,0x5f,0xf5,0x53,0xfc,0x8a,0x5,0x3f,0x8d,0xdc,0x73,0x24,0xf4,0x51,0x68,0xcf,0xfa,0xf8,0x1f,0x8c,0x3a,0xc9,0x39,0x96,0xf6,0x53,0x6e,0xef,0x38,0xe5,0xe4,0x7,0x68, } },
            { new byte[] { 0x40,0x23,0x24,0x25,0x21, },  new byte[] { 0x51,0xa1,0x38,0x1,0xa9,0x8d,0xe7,0xb2,0xdb,0xee,0xbb,0xad,0x3,0xce,0x87,0xb6,0xe7,0x88,0xed,0x52,0x44,0x7d,0x4b,0x7,0xe2,0x16,0x81,0xa2,0x59,0x5e,0x41,0xfe,0xbc,0x52,0x61,0x4c,0xd4,0xa3,0x6,0x44,0xd0,0x86,0xb6,0x30,0xfe,0x3,0x80,0xba,0x38,0x1f,0x50,0x70,0xc1,0x79,0x41,0x6a,0x43,0xb7,0x3,0x77,0xab,0xf,0xe4,0xae, } },
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
            return $"プロセス異常発生 - HashToolの実行異常　SHA512ハッシュ配列出力失敗";
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
            var SHA512 = new MeasureSHA512();
            // Act
            var act = SHA512.GetHashValue(param);
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
                return new SHA512CryptoServiceProvider().ComputeHash(byte_value);
            }
            catch (Exception ex)
            {
                throw new ProcessException(
                    string.Format("HashToolの実行異常　SHA512ハッシュ配列出力失敗"), ex.InnerException);
            }
        }
    }
}
