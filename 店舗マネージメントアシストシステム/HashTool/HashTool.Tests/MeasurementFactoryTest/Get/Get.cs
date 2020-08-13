using HashTool.Condition;
using HashTool.Constant;
using HashTool.Measurement;
using LibBaseSequence;
using System;
using System.Collections.Generic;
using Xunit;

namespace HashTool.Tests.MeasurementFactoryTest.Get
{
    public class TestDataClass : TestBase
    {
        public static IEnumerable<object[]> SuccessTestData()
        {
            List<object[]> _testData = new List<object[]>();
            var Type = GetEnumSuccess(typeof(E_HASH_TYPE));
            foreach(var type in Type)
            {
                _testData.Add(new object[] { GetTestName(_testData.Count), type });
            }
            return _testData;
        }

        public static IEnumerable<object[]> FaileTestData ( )
        {
            List<object[]> _testData = new List<object[]>( );
            var Type = GetEnumFaile(typeof(E_HASH_TYPE));
            foreach(var type in Type)
            {
                _testData.Add(new object[] { GetTestName(_testData.Count), (E_HASH_TYPE)type, SetMessage((E_HASH_TYPE)type) });
            }
            return _testData;
        }

        public static string SetMessage(E_HASH_TYPE type)
        {
            return $"プロセス異常発生 - HashToolの実行異常　Hashタイプ異常 type = {type}";
        }
    }

    [Collection("Our Test Collection #1")]
    public class Get
    {
        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.SuccessTestData), MemberType = typeof(TestDataClass))]
        public void SuccessTest (string name, E_HASH_TYPE type)
        {
            Console.WriteLine(name);
            // Arrange
            Conditions.Type = type;

            // Act
            var con = MeasurementFactory.Get();

            // Assert
            if (type == E_HASH_TYPE.MD5)
                Assert.IsType<MeasureMD5>(con);
            if (type == E_HASH_TYPE.SHA1)
                Assert.IsType<MeasureSHA1>(con);
            if (type == E_HASH_TYPE.SHA256)
                Assert.IsType<MeasureSHA256>(con);
            if (type == E_HASH_TYPE.SHA384)
                Assert.IsType<MeasureSHA384>(con);
            if (type == E_HASH_TYPE.SHA512)
                Assert.IsType<MeasureSHA512>(con);
        }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.FaileTestData), MemberType = typeof(TestDataClass))]
        public void FaileTest (string name, E_HASH_TYPE param, string errorMessage)
        {
            Console.WriteLine(name);
            // Arrange
            Conditions.Type = param;
            // Arrange
            // Act
            var ex = Assert.Throws<ProcessException>(( ) => { MeasurementFactory.Get(); });
            Assert.Equal(errorMessage, ex.Message);
        }
    }
}