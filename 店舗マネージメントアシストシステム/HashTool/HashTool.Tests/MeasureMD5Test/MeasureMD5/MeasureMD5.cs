using LibBaseSequence;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Xunit;
using HashTool.Measurement;

namespace HashTool.Tests.MeasureMD5Test.MD5
{
    public class TestDataClass : TestBase
    {
        public static IEnumerable<object[]> SuccessTestData()
        {
            List<object[]> _testData = new List<object[]>();
            _testData.Add(new object[] { GetTestName(_testData.Count)});
            return _testData;
        }

        public static IEnumerable<object[]> FaileTestData ( )
        {
            List<object[]> _testData = new List<object[]>( );
            _testData.Add(new object[] { GetTestName(_testData.Count), SetMessage( )});
            return _testData;
        }

        public static string SetMessage( )
        {
            return $"プロセス異常発生 - HashToolの実行異常　MD5CryptoServiceProviderインスタンス失敗";
        }
    }

    [Collection("Our Test Collection #1")]
    public class MD5
    {
        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.SuccessTestData), MemberType = typeof(TestDataClass))]
        public void SuccessTest (string name)
        {
            Console.WriteLine(name);

            // Arrange
            // Act
            var MD5 = new MeasureMD5( );
            // Assert
            Assert.IsType<MD5CryptoServiceProvider>(MD5.MD5CSP);
        }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.FaileTestData), MemberType = typeof(TestDataClass))]
        public void FaileTest (string name, string errorMessage)
        {
            Console.WriteLine(name);

            // Arrange
            // Act
            var ex = Assert.Throws<ProcessException>(( ) => { MeasureMD5Stub( ); });
            Assert.Equal(errorMessage, ex.Message);
        }

        internal void MeasureMD5Stub( )
        {
            try
            {
                throw new InvalidOperationException();
            }
            catch(Exception ex)
            {
                throw new ProcessException(
                    string.Format("HashToolの実行異常　MD5CryptoServiceProviderインスタンス失敗"),
                    ex.InnerException);
            }
        }
    }
}
