using System;
using CommonLib.EnumExtension;
using LibBaseSequence;
using HashTool.Constant;

using static CommonLib.Constant.ManagerAssist.Common;

namespace HashTool.Condition
{
    public class CreatCondition : ConditionBase
    {
        public override void Exec ( )
        {
            // 大小文字を生成
            CreatSensitive( );

            // Hash次数を生成
            CreatOrder( );

            // Hashタイプを生成
            CreatType( );

            // 出力最大Bytesを取得
            Conditions.ByteMaxCount = GetTypeMaxBytes( );

            // 開始Indexを生成
            CreatStartIndex( );

            // 終了Indexを生成
            CreatEndIndex( );

            // Hash条件生成
            Conditions.Condition = ((byte)Conditions.Sensitive    << SHIFT_30) |
                                   ((byte)Conditions.Order        << SHIFT_28) |
                                   ((byte)Conditions.Type         << SHIFT_24) |
                                   (      Conditions.ByteMaxCount << SHIFT_16) |
                                   (      Conditions.StartIndex   << SHIFT_8 ) |
                                   (      Conditions.EndIndex                );
        }

        /// <summary>
        /// 大小文字をランダム生成
        /// </summary>
        private void CreatSensitive ( )
        {
            bool rel = false;
            E_HASH_SENSITIVE sensitive = E_HASH_SENSITIVE.LOWER;

            do
            {
                if(!EnumExtension.GenerateToEnum(ref sensitive))
                {
                    Console.WriteLine("Sensitiveランダム生成失敗");
                    break;
                }

                // 正常終了
                rel = true;
                Conditions.Sensitive = sensitive;
            } while(false);

            if(!rel)
            {
                throw new ProcessException(String.Format("HashToolのSensitive生成異常"));
            }
        }

        /// <summary>
        /// Hash次数をランダム生成
        /// </summary>
        private void CreatOrder ( )
        {
            bool rel = false;
            E_HASH_ORDER order = E_HASH_ORDER.SINGLE;

            do
            {
                if(!EnumExtension.GenerateToEnum(ref order))
                {
                    Console.WriteLine("Orderランダム生成失敗");
                    break;
                }

                // 正常終了
                rel = true;
                Conditions.Order = order;
            } while(false);

            if(!rel)
            {
                throw new ProcessException(String.Format("HashToolのOrder生成異常"));
            }
        }

        /// <summary>
        /// Hashタイプをランダム生成
        /// </summary>
        private void CreatType ( )
        {
            bool rel = false;
            E_HASH_TYPE type = E_HASH_TYPE.MD5;

            do
            {
                if(!EnumExtension.GenerateToEnum(ref type))
                {
                    Console.WriteLine("Typeランダム生成失敗");
                    break;
                }

                // 正常終了
                rel = true;
                Conditions.Type = type;
            } while(false);

            if(!rel)
            {
                throw new ProcessException(String.Format("HashToolのType生成異常"));
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
                    int random = new Random( ).Next(Conditions.ByteMaxCount);
                    Conditions.StartIndex = (byte)(random & MASK_BIT_0_7);
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
        /// Hash終了Indexをランダム生成
        /// </summary>
        private void CreatEndIndex ( )
        {
            bool rel = false;

            do
            {
                try
                {
                    int random = new Random( ).Next(Conditions.StartIndex + Conditions.ByteMaxCount, 
                                                    Conditions.ByteMaxCount * 2);
                    Conditions.EndIndex = (byte)(random & MASK_BIT_0_7);
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
    }
}
