using LibBaseSequence;
using System;
using System.Security.Cryptography;

namespace HashTool.Measurement
{
    public class MeasureSHA256 : MeasureBase
    {
        private readonly SHA256CryptoServiceProvider SHA256CSP = new SHA256CryptoServiceProvider( );

        /// <summary>
        /// Hash配列に出力
        /// </summary>
        /// <param name="byte_value"></param>
        /// <returns></returns>
        internal override byte[] GetHashValue (byte[] byte_value)
        {
            try
            {
                SHA256CSP.Initialize( );

                /* ハッシュ配列に出力 */
                return SHA256CSP.ComputeHash(byte_value);
            }
            catch(Exception ex)
            {
                throw new ProcessException(
                    String.Format("HashToolの実行異常　SHA256ハッシュ配列出力失敗"),
                    ex.InnerException);
            }
        }
    }
}
