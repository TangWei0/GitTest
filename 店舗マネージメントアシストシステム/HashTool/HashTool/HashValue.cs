//using CommonLib.Enum;
using static HashTool.Head.HeadEnum;
using LibBaseSequence.Interface;

namespace HashTool
{
    public class HashValue : HashContextBase
    {
        HashCommon hash = new HashCommon( );
        
        private E_HASH_SENSITIVE sensitive;
        private E_HASH_TYPE type;
        private E_HASH_ORDER order;
        private string calc_value;

        public E_HASH_SENSITIVE GetSensitive ( )
        {
            return sensitive;
        }

        public void SetSensitive (E_HASH_SENSITIVE _sensitive)
        {
            this.sensitive = _sensitive;
        }

        public E_HASH_TYPE GetHashType ( )
        {
            return type;
        }

        public void SetHashType (E_HASH_TYPE _type)
        {
            this.type = _type;
        }

        public E_HASH_ORDER GetOrder ( )
        {
            return order;
        }

        public void SetOrder (E_HASH_ORDER _order)
        {
            this.order = _order;
        }

        public string GetCalcHashValue ( )
        {
            return calc_value;
        }

        /// <summary>
        /// ハッシュ値を計算する
        /// </summary>
        /// <returns name="ret">
        /// E_FUNCTION_RESULT.SUCCESS;  /* 正常終了 */
        /// E_FUNCTION_RESULT.FAILE;    /* 異常終了 */
        /// </returns>
        public E_FUNCTION_RESULT CalcHashValue ( )
        {
            E_FUNCTION_RESULT ret = E_FUNCTION_RESULT.FAILE;    /* 戻り値               */
            E_FUNCTION_RESULT ret_fun;                          /* 呼び出し関数の戻り値 */

            do
            {
                /* ハッシュ値を取得 */
                ret_fun = hash.GetHashValue(GetString(),type);
                if(E_FUNCTION_RESULT.SUCCESS != ret_fun)
                {
                    break;
                }

                /* 出力ハッシュ値の大文字/小文字を指定し、出力ハッシュ値に出力 */
                calc_value = ((sensitive == E_HASH_SENSITIVE.UPPER) ? 
                    hash.getValue().ToUpper( ) : 
                    hash.getValue( ).ToLower( ));

                /* 戻り値が正常終了に設定 */
                ret = E_FUNCTION_RESULT.SUCCESS;
            } while(false);

            return ret;
        }
    }
}
