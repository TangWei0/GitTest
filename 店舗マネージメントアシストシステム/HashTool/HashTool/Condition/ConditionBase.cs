using System;
using CommonLib.EnumExtension;
using HashTool.Constant;
using LibBaseSequence;

using static HashTool.Constant.Constant;

namespace HashTool.Condition
{   
    public class ConditionBase
    {
        /// <summary>
        /// Hash条件実行
        /// </summary>
        public virtual void Exec ( ){ }

        /// <summary>
        /// HashTypeより出力最大Bytesを取得
        /// </summary>
        /// <returns></returns>
        internal byte GetTypeMaxBytes ( )
        {
            bool rel = false;
            byte maxBytes = 0;

            do
            {
                switch(Conditions.Type)
                {
                    case E_HASH_TYPE.MD5:
                        maxBytes = MD5_BYTES;
                        break;
                    case E_HASH_TYPE.SHA1:
                        maxBytes = SHA1_BYTES;
                        break;
                    case E_HASH_TYPE.SHA256:
                        maxBytes = SHA256_BYTES;
                        break;
                    case E_HASH_TYPE.SHA384:
                        maxBytes = SHA384_BYTES;
                        break;
                    case E_HASH_TYPE.SHA512:
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

            if(!rel) throw new ProcessException(string.Format("HashToolの出力最大Byte数異常 MaxBytes = 0"));
            return maxBytes;
        }
    }
}
