using CommonLib.EnumExtension;
using HashTool.Constant;
using LibBaseSequence;
using System.Diagnostics;
using static CommonLib.Common.Common;

namespace HashTool.Condition
{
    public class AnalysisCondition : ConditionBase
    {
        public override void Exec()
        {
            // 算出データ
            byte tmp;

            // Hash条件より、パラメータ設定
            tmp = (byte)((Conditions.Condition & MASK_BIT_30) >> SHIFT_30);
            SetSensitive(tmp);

            tmp = (byte)((Conditions.Condition & MASK_BIT_28_29) >> SHIFT_28);
            SetOrder(tmp);

            tmp = (byte)((Conditions.Condition & MASK_BIT_24_27) >> SHIFT_24);
            SetType(tmp);

            tmp = (byte)((Conditions.Condition & MASK_BIT_16_23) >> SHIFT_16);
            SetByteMaxCount(tmp);

            tmp = (byte)((Conditions.Condition & MASK_BIT_8_15) >> SHIFT_8);
            SetStartIndex(tmp);

            tmp = (byte)(Conditions.Condition & MASK_BIT_0_7);
            SetEndIndex(tmp);
        }

        /// <summary>
        /// 大小文字を設定
        /// </summary>
        /// <param name="value"></param>
        internal void SetSensitive(byte value)
        {
            bool rel = false;
            E_HASH_SENSITIVE sensitive = E_HASH_SENSITIVE.LOWER;

            do
            {
                if (!EnumExtension.ConvertToEnum(value, ref sensitive))
                {
                    Trace.WriteLine($"Byte型からEnumに変換失敗 {value:X2)}", TRACE_CAT_ERROR);
                    break;
                }

                // 正常終了
                rel = true;
                Conditions.Sensitive = sensitive;
            } while (false);

            if (!rel)
            {
                throw new ProcessException($"HashToolのCondition条件異常 Enumに変換失敗, " +
                                           $"sensitive = 0x{value:X8}");
            }
        }

        /// <summary>
        /// Hash次数を設定
        /// </summary>
        /// <param name="value"></param>
        internal void SetOrder(byte value)
        {
            bool rel = false;
            E_HASH_ORDER order = E_HASH_ORDER.SINGLE;

            do
            {
                if (!EnumExtension.ConvertToEnum(value, ref order))
                {
                    Trace.WriteLine($"Byte型からEnumに変換失敗 {value:X2}", TRACE_CAT_ERROR);
                    break;
                }

                // 正常終了
                rel = true;
                Conditions.Order = order;
            } while (false);

            if (!rel)
            {
                throw new ProcessException($"HashToolのCondition条件異常 Enumに変換失敗, " +
                                           $"order = 0x{value:X8}");
            }
        }

        /// <summary>
        /// Hashタイプを設定
        /// </summary>
        /// <param name="value"></param>
        internal void SetType(byte value)
        {
            bool rel = false;
            E_HASH_TYPE type = E_HASH_TYPE.MD5;

            do
            {
                if (!EnumExtension.ConvertToEnum(value, ref type))
                {
                    Trace.WriteLine($"Byte型からEnumに変換失敗 {value:X2}", TRACE_CAT_ERROR);
                    break;
                }

                // 正常終了
                rel = true;
                Conditions.Type = type;
            } while (false);

            if (!rel)
            {
                throw new ProcessException($"HashToolのCondition条件異常 Enumに変換失敗, " +
                                           $"type = 0x{value:X8}");
            }
        }

        /// <summary>
        /// 出力最大Bytesを設定
        /// </summary>
        /// <param name="value"></param>
        internal void SetByteMaxCount(byte value)
        {
            bool rel = false;

            do
            {
                // MaxBytes取得
                var maxNum = GetTypeMaxBytes();

                // MaxBytesとCondition条件と不一致
                if (maxNum != value) break;

                Conditions.ByteMaxCount = value;
                rel = true;
            } while (false);

            if (!rel)
            {
                throw new ProcessException($"HashToolのCondition条件異常 出力最大Bytes, " +
                                           $"maxNum = 0x{value:X8}");
            }
        }

        /// <summary>
        /// Hash開始Indexを設定
        /// </summary>
        /// <param name="value"></param>
        internal void SetStartIndex(byte value)
        {
            bool rel = false;

            do
            {
                if (value >= Conditions.ByteMaxCount)
                {
                    Trace.WriteLine($"HashToolの開始Index異常 {value:X2}", TRACE_CAT_ERROR);
                    break;
                }

                Conditions.StartIndex = value;

                rel = true;
            } while (false);

            if (!rel)
            {
                throw new ProcessException($"HashToolのCondition条件異常 開始Index異常, " +
                                           $"startIndex = 0x{value:X8}");
            }
        }

        /// <summary>
        /// Hash終了Indexを設定
        /// </summary>
        /// <param name="value"></param>
        internal void SetEndIndex(byte value)
        {
            bool rel = false;

            do
            {
                if ((value < Conditions.StartIndex + Conditions.ByteMaxCount) ||
                   (value >= Conditions.ByteMaxCount * 2))
                {
                    Trace.WriteLine($"HashToolの終了Index異常 {value:X2}", TRACE_CAT_ERROR);
                    break;
                }

                Conditions.EndIndex = value;

                rel = true;
            } while (false);

            if (!rel)
            {
                throw new ProcessException($"HashToolのCondition条件異常 終了Index異常, " +
                                           $"endIndex = 0x{value:X8}");
            }
        }
    }
}