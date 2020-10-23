using System;
using System.Collections.Generic;

using static CommonLib.Common.Common;

namespace HashTool.Tests.AnalysisConditionTest
{
    public class AnalysisConditionTestBase : TestBase
    {
        public static List<byte> GetCountList()
        {
            var Count = new List<byte>();
            byte LimitMin = 1;
            byte LimitMax = 127;
            foreach (var count in TypeCount)
            {
                byte min = (byte)(count.Value - 1);
                byte max = (byte)(count.Value + 1);
                byte midMax = GetMidNum(LimitMin, min);
                byte midMin = GetMidNum(max, LimitMax);
                if (Count.IndexOf(midMin) == -1) Count.Add(midMin);
                if (Count.IndexOf(min) == -1) Count.Add(min);
                if (Count.IndexOf(count.Value) == -1) Count.Add(count.Value);
                if (Count.IndexOf(midMax) == -1) Count.Add(midMax);
                if (Count.IndexOf(max) == -1) Count.Add(max);
            }
            return Count;
        }

        public static int SetCondition(Tuple<byte, byte, byte, byte, byte, byte> key)
        {
            int condition = (key.Item1 << SHIFT_30) |
                            (key.Item2 << SHIFT_28) |
                            (key.Item3 << SHIFT_24) |
                            (key.Item4 << SHIFT_16) |
                            (key.Item5 << SHIFT_8) |
                            (key.Item6);
            return condition;
        }

        protected static string SetMessage(string reason, string title, byte val)
        {
            return $"プロセス異常発生 - HashToolのCondition条件異常 {reason} " +
                   $"{title} = 0x{string.Format("{0,0:X8}", val)}";
        }
    }
}
