using LibBaseSequence;
using System;
using System.Security.Cryptography;

namespace HashTool.Measurement
{
    public class MeasureSHA512 : MeasureBase
    {
        private readonly SHA512CryptoServiceProvider SHA512CSP = new SHA512CryptoServiceProvider( );

        /// <summary>
        /// Hash配列に出力
        /// </summary>
        /// <param name="byte_value"></param>
        /// <returns></returns>
        internal override byte[] GetHashValue (byte[] byte_value)
        {
            try
            {
                SHA512CSP.Initialize( );

                /* ハッシュ配列に出力 */
                return SHA512CSP.ComputeHash(byte_value);
            }
            catch(Exception ex)
            {
                throw new ProcessException(
                    String.Format("HashToolの実行異常　SHA512ハッシュ配列出力失敗"),
                    ex.InnerException);
            }
        }
    }
}
