using HashTool.Condition;
using HashTool.Constant;
using LibBaseSequence;
using System;
using System.Collections.Generic;
using static HashTool.Constant.Constant;

namespace HashTool.Tests.ConditionBaseTest
{
    public class ConditionBaseBase : TestBase
    {
        public static byte GetTypeMaxBytesStub(bool flag = true)
        {
            bool rel = false;
            byte maxBytes = 0;
            do
            {
                var type = flag ? (byte)Conditions.Type : byte.MaxValue;
                switch(type)
                {
                    case (byte)E_HASH_TYPE.MD5:
                        maxBytes = MD5_BYTES;
                        break;
                    case (byte)E_HASH_TYPE.SHA1:
                        maxBytes = SHA1_BYTES;
                        break;
                    case (byte)E_HASH_TYPE.SHA256:
                        maxBytes = SHA256_BYTES;
                        break;
                    case (byte)E_HASH_TYPE.SHA384:
                        maxBytes = SHA384_BYTES;
                        break;
                    case (byte)E_HASH_TYPE.SHA512:
                        maxBytes = SHA512_BYTES;
                        break;
                    default:
                        break;
                }

                // 出力最大Byte数異常
                if(maxBytes == 0)
                {
                    Console.WriteLine("HashToolの出力最大Byte数異常 MaxBytes = 0");
                    break;
                }

                // 正常終了
                rel = true;
            } while(false);

            if(!rel)
            {
                throw new ProcessException(
                    string.Format("HashToolの出力最大Byte数異常 MaxBytes = 0"));
            }

            return maxBytes;
        }

        protected static string SetMessage()
        {
            return string.Format("プロセス異常発生 - HashToolの出力最大Byte数異常 MaxBytes = 0");
        }

        public static List<T> GetEnum<T>()
        {
            var list = new List<T>();
            foreach(T val in Enum.GetValues(typeof(T))) list.Add(val);
            return list;
        }
    }
}
