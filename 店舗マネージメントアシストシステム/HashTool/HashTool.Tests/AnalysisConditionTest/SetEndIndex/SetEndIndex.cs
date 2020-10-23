using HashTool.Condition;
using LibBaseSequence;
using System;
using System.Collections.Generic;
using Xunit;

namespace HashTool.Tests.AnalysisConditionTest.SetEndIndex
{
    public class TestDataClass : AnalysisConditionTestBase
    {
        private static readonly Dictionary<Tuple<byte, byte>, List<byte>> Success =
            new Dictionary<Tuple<byte, byte>, List<byte>>();
        private static readonly Dictionary<Tuple<byte, byte>, List<byte>> Fail =
            new Dictionary<Tuple<byte, byte>, List<byte>>();

        public static IEnumerable<object[]> SuccessTestData()
        {
            List<object[]> _testData = new List<object[]>();
            Success.Clear();

            var Count = GetCountList();
            foreach (var count in Count)
            {
                List<byte> StartList = new List<byte>();
                SetLeftTest(byte.MinValue, count, ref StartList);
                foreach (var start in StartList)
                {
                    List<byte> EndList = new List<byte>();
                    byte endMin = (byte)(start + count);
                    byte endMax = (byte)(2 * count);
                    SetLeftTest(endMin, endMax, ref EndList);
                    Success.Add(Tuple.Create(count, start), EndList);
                }
            }

            for (var param = byte.MinValue; param <= byte.MaxValue; param++)
            {
                foreach (var data in Success)
                {
                    if (data.Value.IndexOf(param) == -1) continue;
                    byte expected = param;
                    _testData.Add(new object[]
                        { GetTestName(_testData.Count), param, data.Key.Item1, data.Key.Item2, expected });
                }
                if (param == byte.MaxValue) break;
            }
            return _testData;
        }

        public static IEnumerable<object[]> FaileTestData()
        {
            List<object[]> _testData = new List<object[]>();
            Fail.Clear();

            var Count = GetCountList();
            foreach (var count in Count)
            {
                List<byte> StartList = new List<byte>();
                SetLeftTest(byte.MinValue, count, ref StartList);
                foreach (var start in StartList)
                {
                    List<byte> EndList = new List<byte>();
                    byte endMin = (byte)(start + count);
                    byte endMax = (byte)(2 * count - 1);
                    SetLeftTest(byte.MinValue, endMin, ref EndList);
                    SetRightTest(byte.MaxValue, endMax, ref EndList);
                    Fail.Add(Tuple.Create(count, start), EndList);
                }
            }
            for (var param = byte.MinValue; param <= byte.MaxValue; param++)
            {
                foreach (var data in Fail)
                {
                    if (data.Value.IndexOf(param) == -1) continue;
                    _testData.Add(new object[] { GetTestName(_testData.Count),
                        param, data.Key.Item1, data.Key.Item2,
                        SetMessage("終了Index異常,", "endIndex", param)});
                }
                if (param == byte.MaxValue) break;
            }
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class SetEndIndex
    {
        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.SuccessTestData), MemberType = typeof(TestDataClass))]
        public void SuccessTest(string name, byte param, byte initMaxCount, byte initStartIndex, byte expected)
        {
            Console.WriteLine(name);

            // Arrange
            var analysis = new AnalysisCondition();
            Conditions.ByteMaxCount = initMaxCount;
            Conditions.StartIndex = initStartIndex;

            // Act
            analysis.SetEndIndex(param);

            // Assert
            Assert.Equal(expected, Conditions.EndIndex);
        }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.FaileTestData), MemberType = typeof(TestDataClass))]
        public void FaileTest(string name, byte param, byte initStartIndex, byte initMaxCount, string errorMessage)
        {
            Console.WriteLine(name);

            // Arrange
            var analysis = new AnalysisCondition();
            Conditions.ByteMaxCount = initMaxCount;
            Conditions.StartIndex = initStartIndex;

            // Act
            var ex = Assert.Throws<ProcessException>(() => { analysis.SetEndIndex(param); });
            Assert.Equal(errorMessage, ex.Message);
        }
    }
}
