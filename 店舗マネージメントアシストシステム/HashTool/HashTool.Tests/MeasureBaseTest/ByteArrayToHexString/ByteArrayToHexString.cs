using LibBaseSequence;
using System;
using System.Collections.Generic;
using Xunit;

namespace HashTool.Tests.MeasureBaseTest.ByteArrayToHexString
{
    public class TestDataClass : TestBase
    {
        public static IEnumerable<object[]> SuccessTestData()
        {
            List<object[]> _testData = new List<object[]>();
            var measure = new Measure();
            var byteTest = measure.GetByteTest();
            foreach (var val in byteTest)
            {
                var expected = measure.GetByteString(val);
                _testData.Add(new object[] { GetTestName(_testData.Count), val, expected });
            }
            return _testData;
        }

        public static IEnumerable<object[]> FaileTestData()
        {
            List<object[]> _testData = new List<object[]>();
            var measure = new Measure();
            var byteTest = measure.GetByteTest();
            _testData.Add(new object[] { GetTestName(_testData.Count), byteTest[0], 0, 0, SetMessage() });
            _testData.Add(new object[] { GetTestName(_testData.Count), byteTest[1], 2, -1, SetMessage() });
            return _testData;
        }

        public static string SetMessage()
        {
            return $"プロセス異常発生 - HashToolの実行異常　ハッシュ配列を16進数へ変換する";
        }
    }

    [Collection("Our Test Collection #1")]
    public class ByteArrayToHexString
    {
        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.SuccessTestData), MemberType = typeof(TestDataClass))]
        public void SuccessTest(string name, byte[] param, string expected)
        {
            Console.WriteLine(name);

            // Arrange
            var measure = new Measure();
            // Act
            var actual = measure.ByteArrayToHexString(param);
            // Assert
            Assert.Equal(expected, actual);
        }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.FaileTestData), MemberType = typeof(TestDataClass))]
        public void FaileTest(string name, byte[] param, int toBase, int shift, string errorMessage)
        {
            Console.WriteLine(name);

            // Arrange
            var mearsure = new Measure();
            // Act
            var ex = Assert.Throws<ProcessException>(() => { mearsure.ByteArrayToHexStringStub(param, toBase, shift); });
            Assert.Equal(errorMessage, ex.Message);
        }
    }
}
