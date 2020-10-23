using HashTool.Condition;
using LibBaseSequence;
using System;
using System.Collections.Generic;
using Xunit;

namespace HashTool.Tests.AnalysisConditionTest.SetStartIndex
{
    public class TestDataClass : AnalysisConditionTestBase
    {
        private static readonly Dictionary<byte, List<byte>> Success =
            new Dictionary<byte, List<byte>>();
        private static readonly Dictionary<byte, List<byte>> Faile =
            new Dictionary<byte, List<byte>>();

        public static IEnumerable<object[]> SuccessTestData()
        {
            List<object[]> _testData = new List<object[]>();
            Success.Clear();
            var Count = GetCountList();
            foreach (var count in Count)
            {
                List<byte> list = new List<byte>();
                SetLeftTest(byte.MinValue, count, ref list);
                Success.Add(count, list);
            }
            for (var param = byte.MinValue; param <= byte.MaxValue; param++)
            {
                foreach (var data in Success)
                {
                    if (data.Value.IndexOf(param) == -1) continue;
                    byte expected = param;
                    byte init = data.Key;
                    _testData.Add(
                        new object[] { GetTestName(_testData.Count), param, init, expected });
                }
                if (param == byte.MaxValue) break;
            }
            return _testData;
        }

        public static IEnumerable<object[]> FaileTestData()
        {
            List<object[]> _testData = new List<object[]>();

            Faile.Clear();
            var Count = GetCountList();
            foreach (var data in Count)
            {
                List<byte> list = new List<byte>();
                SetRightTest(byte.MaxValue, (byte)(data - 1), ref list);
                Faile.Add(data, list);
            }

            for (var param = byte.MinValue; param <= byte.MaxValue; param++)
            {
                foreach (var data in Faile)
                {
                    if (data.Value.IndexOf(param) == -1) continue;
                    byte init = data.Key;
                    _testData.Add(new object[] {
                        GetTestName(_testData.Count), param, init, SetMessage("開始Index異常,", "startIndex", param)});
                }
                if (param == byte.MaxValue) break;
            }
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class SetStartIndex
    {
        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.SuccessTestData), MemberType = typeof(TestDataClass))]
        public void SuccessTest(string name, byte param, byte init, byte expected)
        {
            Console.WriteLine(name);

            // Arrange
            var analysis = new AnalysisCondition();
            Conditions.ByteMaxCount = init;

            // Act
            analysis.SetStartIndex(param);

            // Assert
            Assert.Equal(expected, Conditions.StartIndex);
        }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.FaileTestData), MemberType = typeof(TestDataClass))]
        public void FaileTest(string name, byte param, byte init, string errorMessage)
        {
            Console.WriteLine(name);

            // Arrange
            var analysis = new AnalysisCondition();
            Conditions.ByteMaxCount = init;

            // Act
            var ex = Assert.Throws<ProcessException>(() => { analysis.SetStartIndex(param); });
            Assert.Equal(errorMessage, ex.Message);
        }
    }
}
