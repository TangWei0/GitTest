using LibBaseSequence;
using System;
using System.Security.Cryptography;

namespace HashTool.Measurement
{
    public class MeasureSHA384 : MeasureBase
    {
        private SHA384CryptoServiceProvider SHA384CSP;

        public MeasureSHA384 ( )
        {
            SHA384CSP = new SHA384CryptoServiceProvider( );
        }

        /// <summary>
        /// Hash配列に出力
        /// </summary>
        /// <param name="byte_value"></param>
        /// <returns></returns>
        protected override byte[] GetHashValue (byte[] byte_value)
        {
            try
            {
                SHA384CSP.Initialize( );

                /* ハッシュ配列に出力 */
                return SHA384CSP.ComputeHash(byte_value);
            }
            catch(Exception ex)
            {
                throw new ProcessException(
                    String.Format("HashToolの実行異常　SHA384ハッシュ配列出力失敗"),
                    ex.InnerException);
            }
        }
    }
}
