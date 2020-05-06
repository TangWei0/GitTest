using System;
using System.Text;
using LibBaseSequence;

namespace HashTool.Measurement
{
    public abstract class MeasureBase
    {
        private const int HEXADECIMAL = 16;
        private readonly Parameter Parameter;

        private string hash_value;
        public string GetHashValue ( ) { return hash_value; }

        public MeasureBase (Parameter parameter)
        {
            Parameter = parameter;
            Instance( );
        }

        /// <summary>
        /// インスタンス
        /// </summary>
        protected abstract void Instance ( );

        public void Exec ( )
        {
            // Hash次数を取得
            var order_num = (byte)Parameter.GetCondition( ).GetOrder( );
            if(order_num == 0)
            {
                throw new ProcessException(
                    string.Format("HashToolの実行異常　Hash次数異常 order_num = 0"));
            }

            // ハッシュしたい文字列を取得
            var word = Parameter.GetWord( );
            for(var order_loop = 0;order_loop < order_num;order_loop++)
            {
                /* ハッシュ値を計算 */
                CalcHashValue(ref word);
            }

            // 開始Indexを取得
            var startIndex = Parameter.GetCondition( ).GetStartIndex( );
            
            // 終了Indexを取得
            var endIndex = Parameter.GetCondition( ).GetEndIndex( );
            
            try
            {
                /* Hash配列指定範囲を出力 */
                hash_value = word.Substring(startIndex, endIndex - startIndex + 1);
            }
            catch(Exception ex)
            {
                throw new ProcessException(
                    string.Format("HashToolの実行異常 Hash配列指定範囲を出力失敗 startIndex = 0x{0}, endIndex = 0x{1}",
                        startIndex.ToString("X2"), endIndex.ToString("X2")),
                    ex.InnerException);
            }
        }

        private void CalcHashValue (ref string word)
        {
            /* 出力したい文字列をByte型に変換 */
            var byte_value = ChangeWordToByte(word);

            /* Hash配列に出力 */
            var byte_hash = GetHashValue(byte_value);
            if(Parameter.GetCondition( ).GetByteMaxCount( ) != byte_hash.Length)
            {
                throw new ProcessException(
                    string.Format("HashToolの実行異常　Hash配列サイズ異常 length = 0x{0}, ByteMaxCount = 0x{1}",
                        byte_hash.Length.ToString("X2"),
                        Parameter.GetCondition( ).GetByteMaxCount( ).ToString("X2")));
            }

            word = ByteArrayToHexString(byte_hash);
            if(Parameter.GetCondition( ).GetSensitive( ) == Constant.E_HASH_SENSITIVE.UPPER) 
            { 
                word = word.ToUpper( ); 
            }
        }

        /// <summary>
        /// 出力したい文字列をByte型に変換
        /// </summary>
        /// <param name="byte_value"></param>
        private byte[] ChangeWordToByte (string word)
        {
            try
            {
                return Encoding.UTF8.GetBytes(word);
            }
            catch(Exception ex)
            {
                throw new ProcessException(
                    string.Format("HashToolの実行異常　出力したい文字列をByteに変換失敗 word = {0}", word),
                    ex.InnerException);
            }
        }

        protected abstract byte[] GetHashValue (byte[] byte_value);

        /// <summary>
        /// ハッシュ配列を16進数へ変換する
        /// </summary>
        /// <param name="byte_hash"></param>
        /// <returns></returns>
        private string ByteArrayToHexString (byte[] byte_hash)
        {
            string hash_value = "";

            foreach(byte b in byte_hash)
            {
                try
                {
                    hash_value += Convert.ToString(b, HEXADECIMAL).PadLeft(2, '0');
                }
                catch(Exception ex)
                {
                    throw new ProcessException(
                        String.Format("HashToolの実行異常　ハッシュ配列を16進数へ変換する"),
                        ex.InnerException);
                }
            }

            return hash_value;
        }
    }
}
