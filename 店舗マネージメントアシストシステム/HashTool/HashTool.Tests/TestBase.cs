using HashTool.Constant;
using System;
using System.Collections.Generic;
using System.Linq;

using static HashTool.Constant.Constant;
namespace HashTool.Tests
{
    public class TestBase
    {
        public static Dictionary<E_HASH_TYPE, byte> TypeCount = new Dictionary<E_HASH_TYPE, byte> {
            { E_HASH_TYPE.MD5, MD5_BYTES },
            { E_HASH_TYPE.SHA1, SHA1_BYTES },
            { E_HASH_TYPE.SHA256, SHA256_BYTES },
            { E_HASH_TYPE.SHA384, SHA384_BYTES },
            { E_HASH_TYPE.SHA512, SHA512_BYTES }
        };

        protected static string GetTestName(int count)
        {
            return $"TestCase_{string.Format("{0:D4}", count + 1)}";
        }

        protected static T GetMidNum<T>(T min, T max) where T : struct
        {
            dynamic v1 = min;
            dynamic v2 = max;
            dynamic diff = v2 - v1 - 1;
            return (T)(v1 + (diff + 1) / 2);
        }

        public static void SetLeftTest<T>(T target, T value, ref List<T> list) where T : struct
        {
            dynamic tar = target;
            dynamic val = value;
            if (val > tar) list.Add(tar);
            if (val > tar + 1) list.Add((T)(val - 1));
            if (val > tar + 2) list.Add((T)GetMidNum(tar, val - 1));
        }

        public static void SetRightTest<T>(T target, T value, ref List<T> list) where T : struct
        {
            dynamic tar = target;
            dynamic val = value;
            if (val < tar) list.Add(tar);
            if (val < tar - 1) list.Add((T)(val + 1));
            if (val < tar - 2) list.Add((T)GetMidNum(val + 1, tar));
        }

        public static Array GetEnumSuccess(Type e) => Enum.GetValues(e);

        public static List<byte> GetEnumFaile(Type e, byte Min = byte.MinValue, byte Max = byte.MaxValue)
        {
            List<byte> list = new List<byte>();
            var EnumType = GetEnumSuccess(e);
            byte enumMin = EnumType.Cast<byte>().Min();
            byte enumMax = EnumType.Cast<byte>().Max();
            SetLeftTest(Min, enumMin, ref list);
            SetRightTest(Max, enumMax, ref list);
            return list;
        }

        public static List<byte> GetCountFaile(byte value)
        {
            byte min = (byte)(value - 1);
            byte max = (byte)(value + 1);
            byte midMin = GetMidNum(byte.MinValue, min);
            byte midMax = GetMidNum(max, byte.MaxValue);
            return new List<byte> { byte.MinValue, midMin, min, max, midMax, byte.MaxValue };
        }
    }
}
