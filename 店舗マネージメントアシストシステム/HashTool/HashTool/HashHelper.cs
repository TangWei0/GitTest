using static HashTool.Head.HeadEnum;
using System;
using LibBaseSequence.Interface;
//using CommonLib.Enum;

namespace HashTool
{
    public class HashHelper : HashValue
    {
        private int bit_num;
        private int bit_index;
        private string hash_value;

        //コンストラクタ
        public HashHelper(string _word,
                          E_HASH_SENSITIVE _sensitve,
                          E_HASH_TYPE _type,
                          E_HASH_ORDER _order,
                          int _num)
        {
            //SetWord(_word);
            SetSensitive(_sensitve);
            SetHashType(_type);
            SetOrder(_order);

            /* 出力ビット数を設定 */
            SetBitNum(_num);
        }

        public string GetValue ( )
        {
            return hash_value;
        }

        private void SetBitNum (int num)
        {
            int BitMax = (int)GetHashType();
            int BitMaxHalf = BitMax / 2;

            bit_num = num;
            if(bit_num > BitMax)
            {
                bit_num = BitMax;
            }

            if(bit_num < BitMaxHalf)
            {
                bit_num = BitMaxHalf;
            }

            bit_index = BitMaxHalf - (bit_num / 2);
        }

        /// <summary>
        /// ハッシュ値を計算する
        /// </summary>
        /// <returns name="ret">
        /// E_FUNCTION_RESULT.SUCCESS;  /* 正常終了 */
        /// E_FUNCTION_RESULT.FAILE;    /* 異常終了 */
        /// </returns>
        public E_FUNCTION_RESULT GetHashValue ( )
        {
            E_FUNCTION_RESULT ret = E_FUNCTION_RESULT.FAILE;    /* 戻り値               */
            E_FUNCTION_RESULT ret_function;                     /* 呼び出す関数用戻り値 */

            int order_num;
            int loop_order;
            bool end_flag;

            do
            {
                /* 処理フラグを初期化 */
                end_flag = false;

                /* ハッシュ取得次数を取得 */
                order_num = (int)(GetOrder());
                for(loop_order = 0; loop_order < order_num; loop_order++)
                {
                    /* ハッシュ値を計算 */
                    ret_function = CalcHashValue( );
                    if(E_FUNCTION_RESULT.SUCCESS != ret_function)
                    {
                        /* 処理フラグをTRUEに設定 */
                        end_flag = true;
                        break;
                    }

                    try
                    {
                        /* 計算したハッシュ値を取得 */
                        hash_value = GetCalcHashValue( ).Substring(bit_index, bit_num);
                    }
                    catch(ArgumentOutOfRangeException)
                    {
                        /* 処理フラグをTRUEに設定 */
                        end_flag = true;
                        break;
                    }

                    /* 多重ハッシュを設定するため、文字列を再設定 */
                    //SetWord(hash_value);
                }

                /* 異常処理かをチェック */
                if(false != end_flag)
                {
                    break;
                }

                // 正常終了に設定
                ret = E_FUNCTION_RESULT.SUCCESS;
            } while(false);

            return ret;
        }
    }
}
