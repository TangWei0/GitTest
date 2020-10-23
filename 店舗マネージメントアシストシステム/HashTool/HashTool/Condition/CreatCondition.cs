using CommonLib.EnumExtension;
using HashTool.Constant;
using LibBaseSequence;
using System;
using System.Diagnostics;
using static CommonLib.Common.Common;

namespace HashTool.Condition
{
    public class CreatCondition : ConditionBase
    {
        public override void Exec()
        {
            // 大小文字を生成
            CreatSensitive();

            // Hash次数を生成
            CreatOrder();

            // Hashタイプを生成
            CreatType();

            // 出力最大Bytesを取得
            Conditions.ByteMaxCount = GetTypeMaxBytes();

            // 開始Indexを生成
            CreatStartIndex();

            // 終了Indexを生成
            CreatEndIndex();

            // Hash条件生成
            Conditions.Condition = ((byte)Conditions.Sensitive << SHIFT_30) |
                                   ((byte)Conditions.Order << SHIFT_28) |
                                   ((byte)Conditions.Type << SHIFT_24) |
                                   (Conditions.ByteMaxCount << SHIFT_16) |
                                   (Conditions.StartIndex << SHIFT_8) |
                                   (Conditions.EndIndex);
        }

        /// <summary>
        /// 大小文字をランダム生成
        /// </summary>
        internal void CreatSensitive()
        {
            bool rel = false;
            E_HASH_SENSITIVE sensitive = E_HASH_SENSITIVE.LOWER;

            do
            {
                if (!EnumExtension.GenerateToEnum(ref sensitive))
                {
                    Trace.WriteLine("Sensitiveランダム生成失敗", TRACE_CAT_ERROR);
                    break;
                }

                // 正常終了
                rel = true;
                Conditions.Sensitive = sensitive;
            } while (false);
            if (!rel) throw new ProcessException("HashToolのSensitive生成異常");
        }

        /// <summary>
        /// Hash次数をランダム生成
        /// </summary>
        internal void CreatOrder()
        {
            bool rel = false;
            E_HASH_ORDER order = E_HASH_ORDER.SINGLE;

            do
            {
                if (!EnumExtension.GenerateToEnum(ref order))
                {
                    Trace.WriteLine("Orderランダム生成失敗", TRACE_CAT_ERROR);
                    break;
                }

                // 正常終了
                rel = true;
                Conditions.Order = order;
            } while (false);

            if (!rel) throw new ProcessException("HashToolのOrder生成異常");
        }

        /// <summary>
        /// Hashタイプをランダム生成
        /// </summary>
        internal void CreatType()
        {
            bool rel = false;
            E_HASH_TYPE type = E_HASH_TYPE.MD5;

            do
            {
                if (!EnumExtension.GenerateToEnum(ref type))
                {
                    Trace.WriteLine("Typeランダム生成失敗", TRACE_CAT_ERROR);
                    break;
                }

                // 正常終了
                rel = true;
                Conditions.Type = type;
            } while (false);

            if (!rel) throw new ProcessException("HashToolのType生成異常");
        }

        /// <summary>
        /// Hash開始Indexをランダム生成
        /// </summary>
        internal void CreatStartIndex()
        {
            bool rel = false;

            do
            {
                try
                {
                    int random = new Random().Next(Conditions.ByteMaxCount);
                    Conditions.StartIndex = (byte)(random & MASK_BIT_0_7);
                }
                catch (Exception)
                {
                    Trace.WriteLine("HashToolのStartIndex生成異常", TRACE_CAT_ERROR);
                    break;
                }

                // 正常終了
                rel = true;
            } while (false);

            if (!rel) throw new ProcessException("HashToolのStartIndex生成異常");
        }

        /// <summary>
        /// Hash終了Indexをランダム生成
        /// </summary>
        internal void CreatEndIndex()
        {
            bool rel = false;

            do
            {
                try
                {
                    int random = new Random().Next(Conditions.StartIndex + Conditions.ByteMaxCount,
                                                    Conditions.ByteMaxCount * 2);
                    Conditions.EndIndex = (byte)(random & MASK_BIT_0_7);
                }
                catch (Exception)
                {
                    Trace.WriteLine("HashToolのEndIndex生成異常", TRACE_CAT_ERROR);
                    break;
                }

                // 正常終了
                rel = true;
            } while (false);

            if (!rel)
            {
                throw new ProcessException("HashToolのEndIndex生成異常");
            }
        }
    }
}
