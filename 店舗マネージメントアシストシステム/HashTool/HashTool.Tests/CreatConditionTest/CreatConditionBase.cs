using HashTool.Condition;
using HashTool.Constant;
using HashTool.Tests.ConditionBaseTest;
using LibBaseSequence;
using System;
using static CommonLib.Common.Common;

namespace HashTool.Tests.CreatConditionTest
{
    public class CreatConditionTestBase : ConditionBaseBase
    {
        public static bool CreatEnum<T>()
            where T : Enum
        { return false; }

        public static bool CreatRandom()
        { return false; }

        public static bool IsContain<T>(T en)
            where T : Enum
        {
            var List = GetEnum<T>();
            if (List.IndexOf(en) == -1) return false;
            return true;
        }

        public static bool IsContain(byte index, byte max, byte min = byte.MinValue)
        {
            if ((index >= min) || (index < max)) return true;
            return false;
        }

        public static void ExecStub(int step)
        {
            var creat = new CreatCondition();
            if (step == 0) CreatSensitiveStub();
            else creat.CreatSensitive();

            if (step == 1) CreatOrderStub();
            else creat.CreatOrder();

            if (step == 2) CreatTypeStub();
            else creat.CreatType();

            if (step == 3) Conditions.ByteMaxCount = GetTypeMaxBytesStub();
            else Conditions.ByteMaxCount = creat.GetTypeMaxBytes();

            if (step == 4) CreatStartIndexStub();
            else creat.CreatStartIndex();

            if (step == 5) CreatEndIndexStub();
            else CreatEndIndexStub();
        }

        public static void CreatSensitiveStub()
        {
            bool rel = false;
            E_HASH_SENSITIVE sensitive = E_HASH_SENSITIVE.LOWER;

            do
            {
                if (!CreatEnum<E_HASH_SENSITIVE>())
                {
                    Console.WriteLine("Sensitiveランダム生成失敗");
                    break;
                }

                // 正常終了
                rel = true;
                Conditions.Sensitive = sensitive;
            } while (false);

            if (!rel) throw new ProcessException(string.Format("HashToolのSensitive生成異常"));
        }

        public static void CreatOrderStub()
        {
            bool rel = false;
            E_HASH_ORDER order = E_HASH_ORDER.SINGLE;

            do
            {
                if (!CreatEnum<E_HASH_ORDER>())
                {
                    Console.WriteLine("Orderランダム生成失敗");
                    break;
                }

                // 正常終了
                rel = true;
                Conditions.Order = order;
            } while (false);

            if (!rel) throw new ProcessException(string.Format("HashToolのOrder生成異常"));
        }

        public static void CreatTypeStub()
        {
            bool rel = false;
            E_HASH_TYPE type = E_HASH_TYPE.MD5;

            do
            {
                if (!CreatEnum<E_HASH_TYPE>())
                {
                    Console.WriteLine("Typeランダム生成失敗");
                    break;
                }

                // 正常終了
                rel = true;
                Conditions.Type = type;
            } while (false);

            if (!rel) throw new ProcessException(string.Format("HashToolのType生成異常"));
        }

        public static void CreatStartIndexStub()
        {
            bool rel = false;
            int random = 0;

            do
            {
                if (!CreatRandom())
                {
                    Console.WriteLine("HashToolのStartIndex生成異常");
                    break;
                }
                Conditions.StartIndex = (byte)(random & MASK_BIT_0_7);

                // 正常終了
                rel = true;
            } while (false);

            if (!rel) throw new ProcessException(string.Format("HashToolのStartIndex生成異常"));
        }

        public static void CreatEndIndexStub()
        {
            bool rel = false;
            int random = 0;
            do
            {
                if (!CreatRandom())
                {
                    Console.WriteLine("HashToolのEndIndex生成異常");
                    break;
                }
                Conditions.EndIndex = (byte)(random & MASK_BIT_0_7);
                // 正常終了
                rel = true;
            } while (false);

            if (!rel) throw new ProcessException(string.Format("HashToolのEndIndex生成異常"));
        }

        protected static string SetMessage(string reason)
        {
            return $"プロセス異常発生 - HashToolの{reason}生成異常";
        }
    }
}
