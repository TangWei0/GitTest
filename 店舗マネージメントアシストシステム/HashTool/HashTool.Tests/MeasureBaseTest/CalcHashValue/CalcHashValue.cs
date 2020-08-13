using HashTool.Condition;
using HashTool.Constant;
using HashTool.Measurement;
using HashTool.Tests.AnalysisConditionTest.SetType;
using LibBaseSequence;
using System;
using System.Collections.Generic;
using Xunit;

namespace HashTool.Tests.MeasureBaseTest.CalcHashValue
{
    public class TestDataClass : TestBase
    {
        public static IEnumerable<object[]> SuccessTestData()
        {
            List<object[]> _testData = new List<object[]>();
            var measure = new Measure();           
            foreach(var val in measure.Hash1Time)
            {
                var type = val.Key.Item1;
                var sen = val.Key.Item2;
                var param = val.Key.Item3;
                string expected = val.Value;
                _testData.Add(new object[] { 
                    GetTestName(_testData.Count), param, type, TypeCount[type], sen, expected});
            }
            return _testData;
        }

        public static IEnumerable<object[]> FaileTestData ( )
        {
            List<object[]> _testData = new List<object[]>( );
            var measure = new Measure();
            var Sensitive = GetEnumSuccess(typeof(E_HASH_SENSITIVE)); 
            var Type = GetEnumSuccess(typeof(E_HASH_TYPE));
            foreach(var sen in Sensitive)
            {
                foreach(E_HASH_TYPE type in Type)
                {
                    var count = TypeCount[type];
                    var countFaileList = GetCountFaile(count);
                    foreach(var countFaile in countFaileList)
                    {
                        foreach (var param in measure.ByteTest.Keys)
                        {
                            _testData.Add(new object[] { GetTestName(_testData.Count), 
                                param, type, countFaile, sen, SetMessage(count, countFaile)});
                        }
                    }
                }
            }
            return _testData;
        }

        public static string SetMessage(byte count, byte countFaile)
        {
            return string.Format("プロセス異常発生 - HashToolの実行異常　Hash配列サイズ異常 length = 0x{0}, ByteMaxCount = 0x{1}",
                count.ToString("X2"), countFaile.ToString("X2"));
        }
    }

    [Collection("Our Test Collection #1")]
    public class CalcHashValue
    {
        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.SuccessTestData), MemberType = typeof(TestDataClass))]
        public void SuccessTest (string name, string param, 
                                 E_HASH_TYPE type, byte count, 
                                 E_HASH_SENSITIVE sen, string expected)
        {
            Console.WriteLine(name);

            // Arrange
            var MD5 = new MeasureMD5();
            var SHA1 = new MeasureSHA1();
            var SHA256 = new MeasureSHA256();
            var SHA384 = new MeasureSHA384();
            var SHA512 = new MeasureSHA512();

            Conditions.Type = type;
            Conditions.ByteMaxCount = count;
            Conditions.Sensitive = sen;
            var word = param;

            // Act
            if (type == E_HASH_TYPE.MD5)
                MD5.CalcHashValue(ref word);
            if (type == E_HASH_TYPE.SHA1)
                SHA1.CalcHashValue(ref word);
            if (type == E_HASH_TYPE.SHA256)
                SHA256.CalcHashValue(ref word);
            if (type == E_HASH_TYPE.SHA384)
                SHA384.CalcHashValue(ref word);
            if (type == E_HASH_TYPE.SHA512)
                SHA512.CalcHashValue(ref word);

            // Assert
            Assert.Equal(expected, word);
        }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.FaileTestData), MemberType = typeof(TestDataClass))]
        public void FaileTest (string name, string param,
                               E_HASH_TYPE type, byte count, 
                               E_HASH_SENSITIVE sen, string errorMessage)
        {
            Console.WriteLine(name);

            // Arrange
            var MD5 = new MeasureMD5();
            var SHA1 = new MeasureSHA1();
            var SHA256 = new MeasureSHA256();
            var SHA384 = new MeasureSHA384();
            var SHA512 = new MeasureSHA512();

            Conditions.Sensitive = sen;
            Conditions.ByteMaxCount = count;
            Conditions.Type = type;
            var word = param;

            // Act
            var ex = Assert.Throws<ProcessException>(( ) => 
            {
                if (type == E_HASH_TYPE.MD5)
                    MD5.CalcHashValue(ref word); 
                if (type == E_HASH_TYPE.SHA1)
                    SHA1.CalcHashValue(ref word); 
                if (type == E_HASH_TYPE.SHA256)
                    SHA256.CalcHashValue(ref word); 
                if (type == E_HASH_TYPE.SHA384)
                    SHA384.CalcHashValue(ref word); 
                if (type == E_HASH_TYPE.SHA512)
                    SHA512.CalcHashValue(ref word); 
            });
            Assert.Equal(errorMessage, ex.Message);
        }
    }
}
