using LibBaseSequence;
using System;
using System.Security.Cryptography;

namespace HashTool.Measurement
{
    public class MeasureSHA1 : MeasureBase
    {
        private readonly SHA1CryptoServiceProvider SHA1CSP = new SHA1CryptoServiceProvider( );

        /// <summary>
        /// Hash配列に出力
        /// </summary>
        /// <param name="byte_value"></param>
        /// <returns></returns>
        internal override byte[] GetHashValue (byte[] byte_value)
        {
            try
            {
                SHA1CSP.Initialize( );

                /* ハッシュ配列に出力 */
                return SHA1CSP.ComputeHash(byte_value);
            }
            catch(Exception ex)
            {
                throw new ProcessException(
                    String.Format("HashToolの実行異常　SHA1ハッシュ配列出力失敗"),
                    ex.InnerException);
            }
        }
    }
}
