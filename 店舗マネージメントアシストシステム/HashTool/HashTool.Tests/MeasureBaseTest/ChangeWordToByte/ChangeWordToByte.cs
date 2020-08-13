using LibBaseSequence;
using System;
using System.Collections.Generic;
using Xunit;

namespace HashTool.Tests.MeasureBaseTest.ChangeWordToByte
{
    public class TestDataClass : TestBase
    {
        public static IEnumerable<object[]> SuccessTestData()
        {
            List<object[]> _testData = new List<object[]>();
            var measure = new Measure();
            foreach(var val in measure.ByteTest)
            {
                _testData.Add(new object[] { GetTestName(_testData.Count), val.Key, val.Value});
            }
            return _testData;
        }

        public static IEnumerable<object[]> FaileTestData ( )
        {
            List<object[]> _testData = new List<object[]>( );
            _testData.Add(new object[] { GetTestName(_testData.Count), null, SetMessage(null)});
            _testData.Add(new object[] { GetTestName(_testData.Count), "", SetMessage("")});
            return _testData;
        }

        public static string SetMessage(string word)
        {
            return $"プロセス異常発生 - HashToolの実行異常　出力したい文字列をByteに変換失敗 word = {word}";
        }
    }

    [Collection("Our Test Collection #1")]
    public class ChangeWordToByte : Measure
    {
        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.SuccessTestData), MemberType = typeof(TestDataClass))]
        public void SuccessTest(string name, string word, byte[] expected)
        {
            Console.WriteLine(name);

            // Arrange
            // Act
            var actual = ChangeWordToByte(word);
            // Assert
            Assert.Equal(expected, actual);
        }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.FaileTestData), MemberType = typeof(TestDataClass))]
        public void FaileTest (string name, string word, string errorMessage)
        {
            Console.WriteLine(name);

            // Arrange
            // Act
            var ex = Assert.Throws<ProcessException>(( ) => { ChangeWordToByteStub(word); });
            Assert.Equal(errorMessage, ex.Message);
        }
    }
}
