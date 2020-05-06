using System;
using CommonLib.EnumExtension;
using LibBaseSequence;
using HashTool.Constant;

using static CommonLib.Constant.ManagerAssist.Common;
using static HashTool.Constant.Constant;

namespace HashTool
{
    public class Condition
    {
        private int condition;

        private E_HASH_ORDER order;
        public E_HASH_ORDER GetOrder ( ) { return order; }

        private E_HASH_SENSITIVE sensitive;
        public E_HASH_SENSITIVE GetSensitive ( ) { return sensitive; }

        private E_HASH_TYPE type;
        public E_HASH_TYPE GetHashType( ) { return type; }

        private byte byteMaxCount;
        public byte GetByteMaxCount ( ) { return byteMaxCount; }

        private byte startIndex;
        public byte GetStartIndex ( ) { return startIndex; }

        private byte endIndex;
        public byte GetEndIndex ( ) { return endIndex; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="_condition"></param>
        public Condition (int _condition)
        {
            condition = _condition;
        }

        /// <summary>
        /// Hash条件実行
        /// </summary>
        public void Exec ( )
        {
            if(condition == 0)
            {
                // Hash条件生成
                CreatCondition( );
            }
            else
            {
                // Hash条件分析
                AnalysisCondition( );
            }
        }

        /// <summary>
        /// Hash条件生成
        /// </summary>
        private void CreatCondition ( )
        {
            // 大小文字を生成
            CreatSensitive( );

            // Hash次数を生成
            CreatOrder( );

            // Hashタイプを生成
            CreatType( );

            // 出力最大Bytesを取得
            byteMaxCount = GetTypeMaxBytes( );

            // 開始Indexを生成
            CreatStartIndex( );

            // 終了Indexを生成
            CreatEndIndex( );

            condition = ((byte)sensitive    << SHIFT_30) |
                        ((byte)order        << SHIFT_28) |
                        ((byte)type         << SHIFT_24) |
                        (      byteMaxCount << SHIFT_16) |
                        (      startIndex   << SHIFT_8 ) |
                        (      endIndex                );
        }

        /// <summary>
        /// Hash条件分析
        /// </summary>
        private void AnalysisCondition ( )
        {
            // 算出データ
            byte tmp;

            // Hash条件より、パラメータ設定
            tmp = (byte)((condition & MASK_BIT_30) >> SHIFT_30);
            SetSensitive(tmp);

            tmp = (byte)((condition & MASK_BIT_28_29) >> SHIFT_28);
            SetOrder(tmp);

            tmp = (byte)((condition & MASK_BIT_24_27) >> SHIFT_24);
            SetType(tmp);

            tmp = (byte)((condition & MASK_BIT_16_23) >> SHIFT_16);
            SetByteMaxCount(tmp);

            tmp = (byte)((condition & MASK_BIT_8_15) >> SHIFT_8);
            SetStartIndex(tmp);

            tmp = (byte)(condition & MASK_BIT_0_7);
            SetEndIndex(tmp);
        }

        /// <summary>
        /// 大小文字を設定
        /// </summary>
        /// <param name="value"></param>
        private void SetSensitive (byte value)
        {
            bool rel = false;

            do
            {
                if(!EnumExtension.ConvertToEnum(value, ref sensitive))
                {
                    Console.WriteLine("Byte型からEnumに変換失敗 {0}", value.ToString("X2"));
                    break;
                }

                // 正常終了
                rel = true;
            } while(false);

            if(!rel)
            {
                throw new ProcessException(
                    String.Format("HashToolのCondition条件異常　Enumに変換失敗 {0} = 0x{1}", 
                        "condition", condition.ToString("X8")));
            }
        }

        /// <summary>
        /// 大小文字をランダム生成
        /// </summary>
        private void CreatSensitive ( )
        {
            bool rel = false;

            do
            {
                if(!EnumExtension.GenerateToEnum(ref sensitive))
                {
                    Console.WriteLine("Sensitiveランダム生成失敗");
                    break;
                }

                // 正常終了
                rel = true;
            } while(false);

            if(!rel)
            {
                throw new ProcessException(String.Format("HashToolのSensitive生成異常"));
            }
        }

        /// <summary>
        /// Hash次数を設定
        /// </summary>
        /// <param name="value"></param>
        private void SetOrder (byte value)
        {
            bool rel = false;

            do
            {
                if(!EnumExtension.ConvertToEnum(value, ref order))
                {
                    Console.WriteLine("Byte型からEnumに変換失敗 {0}", value.ToString("X2"));
                    break;
                }

                // 正常終了
                rel = true;
            } while(false);

            if(!rel)
            {
                throw new ProcessException(
                    String.Format("HashToolのCondition条件異常 Enumに変換失敗 {0} = 0x{1}", 
                        "condition", condition.ToString("X8")));
            }
        }

        /// <summary>
        /// Hash次数をランダム生成
        /// </summary>
        private void CreatOrder ( )
        {
            bool rel = false;

            do
            {
                if(!EnumExtension.GenerateToEnum(ref order))
                {
                    Console.WriteLine("Orderランダム生成失敗");
                    break;
                }

                // 正常終了
                rel = true;
            } while(false);

            if(!rel)
            {
                throw new ProcessException(String.Format("HashToolのOrder生成異常"));
            }
        }

        /// <summary>
        /// Hashタイプを設定
        /// </summary>
        /// <param name="value"></param>
        private void SetType (byte value)
        {
            bool rel = false;

            do
            {
                if(!EnumExtension.ConvertToEnum(value, ref type))
                {
                    Console.WriteLine("Byte型からEnumに変換失敗 {0}", value.ToString("X2"));
                    break;
                }

                // 正常終了
                rel = true;
            } while(false);

            if(!rel)
            {
                throw new ProcessException(
                    String.Format("HashToolのCondition条件異常 Enumに変換失敗 {0} = 0x{1}", 
                        "condition", condition.ToString("X8")));
            }
        }

        /// <summary>
        /// Hashタイプをランダム生成
        /// </summary>
        private void CreatType ( )
        {
            bool rel = false;

            do
            {
                if(!EnumExtension.GenerateToEnum(ref type))
                {
                    Console.WriteLine("Typeランダム生成失敗");
                    break;
                }

                // 正常終了
                rel = true;
            } while(false);

            if(!rel)
            {
                throw new ProcessException(String.Format("HashToolのType生成異常"));
            }
        }

        /// <summary>
        /// 出力最大Bytesを設定
        /// </summary>
        /// <param name="value"></param>
        private void SetByteMaxCount (byte value)
        {
            bool rel = false;

            do
            {
                // MaxBytes取得
                var maxNum = GetTypeMaxBytes( );

                // MaxBytesとCondition条件と不一致
                if(!(maxNum == value))
                    break;

                byteMaxCount = value;

                rel = true;
            } while(false);

            if(!rel)
            {
                throw new ProcessException(
                    String.Format("HashToolのCondition条件異常 出力最大Bytes {0} = 0x{1}", 
                        "condition", condition.ToString("X8")));
            }
        }

        /// <summary>
        /// Hash開始Indexを設定
        /// </summary>
        /// <param name="value"></param>
        private void SetStartIndex (byte value)
        {
            bool rel = false;

            do
            {
                if((value < 0) || (value >= byteMaxCount))
                {
                    Console.WriteLine("HashToolの開始Index異常 {0}", value.ToString("X2"));
                    break;
                }

                startIndex = value;

                rel = true;
            } while(false);

            if(!rel)
            {
                throw new ProcessException(
                    String.Format("HashToolのCondition条件異常 開始Index異常 {0} = 0x{1}", 
                        "condition", condition.ToString("X8")));
            }
        }

        /// <summary>
        /// Hash開始Indexをランダム生成
        /// </summary>
        private void CreatStartIndex ( )
        {
            bool rel = false;

            do
            {
                try
                {
                    int random = new Random( ).Next(byteMaxCount);
                    startIndex = (byte)(random & MASK_BIT_0_7);
                }
                catch(Exception)
                {
                    Console.WriteLine("HashToolのStartIndex生成異常");
                    break;
                }

                // 正常終了
                rel = true;
            } while(false);

            if(!rel)
            {
                throw new ProcessException(String.Format("HashToolのStartIndex生成異常"));
            }
        }

        /// <summary>
        /// Hash終了Indexを設定
        /// </summary>
        /// <param name="value"></param>
        private void SetEndIndex (byte value)
        {
            bool rel = false;

            do
            {
                if((value < startIndex + byteMaxCount) || (value >= byteMaxCount * 2))
                {
                    Console.WriteLine("HashToolの終了Index異常 {0}", value.ToString("X2"));
                    break;
                }

                endIndex = value;

                rel = true;
            } while(false);

            if(!rel)
            {
                throw new ProcessException(
                    String.Format("HashToolのCondition条件異常 終了Index異常 {0} = 0x{1}", 
                        "condition", condition.ToString("X8")));
            }
        }

        /// <summary>
        /// Hash終了Indexをランダム生成
        /// </summary>
        private void CreatEndIndex ( )
        {
            bool rel = false;

            do
            {
                try
                {
                    int random = new Random( ).Next(startIndex + byteMaxCount, byteMaxCount * 2);
                    endIndex = (byte)(random & MASK_BIT_0_7);
                }
                catch(Exception)
                {
                    Console.WriteLine("HashToolのEndIndex生成異常");
                    break;
                }

                // 正常終了
                rel = true;
            } while(false);

            if(!rel)
            {
                throw new ProcessException(String.Format("HashToolのEndIndex生成異常"));
            }
        }

        /// <summary>
        /// HashTypeより出力最大Bytesを取得
        /// </summary>
        /// <returns></returns>
        private byte GetTypeMaxBytes ( )
        {
            bool rel = false;
            byte maxBytes = 0;

            do
            {
                string name = null;
                if(!EnumExtension.GetName(type, ref name))
                {
                    Console.WriteLine("HashToolのType名称取得失敗");
                    break;
                }
                switch(name)
                {
                    case "MD5":
                        maxBytes = MD5_BYTES;
                        break;
                    case "SHA1":
                        maxBytes = SHA1_BYTES;
                        break;
                    case "SHA256":
                        maxBytes = SHA256_BYTES;
                        break;
                    case "SHA384":
                        maxBytes = SHA384_BYTES;
                        break;
                    case "SHA512":
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
                    String.Format("HashToolの出力最大Byte数取得失敗 {0} = 0x{1}",
                        "MaxBytes", maxBytes.ToString("X2")));
            }

            return maxBytes;
        }
    }
}
