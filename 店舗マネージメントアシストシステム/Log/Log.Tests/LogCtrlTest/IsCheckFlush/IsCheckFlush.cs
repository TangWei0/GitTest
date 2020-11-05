using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http.Headers;
using Xunit;

using static Log.Constant;

namespace Log.Tests.LogCtrlTest.IsCheckFlush
{
    public class TestDataClass : TestBase
    {
        public static long[] MaxSizeTestCase = new long[] { KB_SIZE, 10 * KB_SIZE, GB_SIZE };
        public static IEnumerable<object[]> AppendFalseTestData()
        {
            List<object[]> _testData = new List<object[]>();

            foreach(var maxSize in MaxSizeTestCase)
            {
                var size = maxSize * 9 / 10;
                var Length = new int[] { 0, (int)size, (int)(size + 1) };
                for (int i = 0; i < Length.Length; i++)
                {
                    var rel = i > 1;
                    _testData.Add(new object[] { GetTestName(_testData.Count), rel, Length[i], size });
                }
            }
            return _testData;
        }

        public static IEnumerable<object[]> AppendTrueTestData()
        {
            List<object[]> _testData = new List<object[]>();
           
            foreach (var maxSize in MaxSizeTestCase)
            {
                var buffSize = maxSize / 10;
                var Length = new int[] {0, (int)buffSize, (int)(buffSize + 1) };
                for(var i = 0; i < Length.Length; i++)
                {
                    foreach (bool autoFlush in new[] { false, true })
                    {
                        bool expectedRel = false;
                        if (i > 1 || autoFlush)
                            expectedRel = true;
                        
                        if (!expectedRel)
                        { 
                            _testData.Add(new object[] { GetTestName(_testData.Count),
                                expectedRel, false, Length[i], buffSize, autoFlush, 0, maxSize });
                            continue;
                        }

                        List<long> FileSize = new List<long> { 0, maxSize - Length[i] - 1, maxSize - Length[i] };
                        for(var j = 0; j < FileSize.Count; j++)
                        {
                            var expectedBackup = j > 1;
                            _testData.Add(new object[] { GetTestName(_testData.Count),
                                expectedRel, expectedBackup, Length[i], buffSize, autoFlush, FileSize[j], maxSize });
                        }
                    }
                }
            }
            return _testData;
        }
    }

    [Collection("Our Test Collection #1")]
    public class IsCheckFlush
    {
        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.AppendFalseTestData), MemberType = typeof(TestDataClass))]
        public void IsCheckFlushAppendFalseTest(string name, bool expected, int length, long size)
        {
            Console.WriteLine(name);
            // Arrange
            ConfigFactory.InitFlag = true;
            ConfigFactory.Config = new Config
            {
                LogFilePath = @"C:\Log\Test",
                IsAppend = false,
            };

            var logCtrl = new LogCtrl_Stub
            {
                BufferSize = size,
            };
            logCtrl.Buffer.Length = length;

            // Act
            var rel = logCtrl.IsCheckFlush();

            // Assert
            Assert.Equal(expected, rel);
            Assert.Equal(expected, logCtrl.IsBackup);

            // 初期化
            ConfigFactory.Config = new Config();
            ConfigFactory.InitFlag = false;
        }

        // テストメソッド
        [Theory]
        [MemberData(nameof(TestDataClass.AppendTrueTestData), MemberType = typeof(TestDataClass))]
        public void IsCheckFlushAppendTrueTest(string name, bool expectedRel, bool expectedBackup, 
            int length, long buffSize, bool autoFlush, long fileSize, long maxSize)
        {
            Console.WriteLine(name);
            // Arrange
            ConfigFactory.InitFlag = true;
            ConfigFactory.Config = new Config
            {
                LogFilePath = @"C:\Log\Test",
                IsAppend = true,
                MaxFileSize = maxSize,
                IsAutoFlush = autoFlush,
            };

            var logCtrl = new LogCtrl_Stub()
            {
                BufferSize = buffSize,
                FileSize = fileSize,
            };
            logCtrl.Buffer.Length = length;

            // Act
            var rel = logCtrl.IsCheckFlush();

            // Assert
            Assert.Equal(expectedRel, rel);
            Assert.Equal(expectedBackup, logCtrl.IsBackup);
            
            // 初期化
            ConfigFactory.Config = new Config();
            ConfigFactory.InitFlag = false;
        }
    }

    public class LogCtrl_Stub : LogCtrl
    {
        public bool IsBackup { get; set; } = false;

        public override bool IsCheckFlush()
        {
            bool IsFlush = false;

            // ログファイルに追記する場合
            if (Config.IsAppend)
            {
                //　自動フラッシュまたログ出力バッファが設定値を超えた場合、
                if ((Buffer.Length > BufferSize) || Config.IsAutoFlush)
                {
                    //　ログファイルサイズを超えた場合、ログファイルをバックアップする
                    if (Config.MaxFileSize <= FileSize + Buffer.Length)
                        IsBackup = true;

                    IsFlush = true;
                }
            }
            else
            {
                // ログファイルを上書き場合
                //　ログ出力バッファが設定値を超えた場合
                if (Buffer.Length > BufferSize)
                {
                    IsBackup = true;
                    IsFlush = true;
                }
            }

            return IsFlush;
        }
    }
}
