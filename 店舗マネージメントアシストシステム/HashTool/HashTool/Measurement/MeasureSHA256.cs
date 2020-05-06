using LibBaseSequence;
using System;
using System.Security.Cryptography;

namespace HashTool.Measurement
{
    public class MeasureSHA256 :MeasureBase
    {
        private SHA256CryptoServiceProvider SHA256CSP;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="parameter"></param>
        public MeasureSHA256 (Parameter parameter) : base(parameter) { }

        /// <summary>
        /// MD5CryptoServiceProviderインスタンス
        /// </summary>
        protected override void Instance ( )
        {
            SHA256CSP = new SHA256CryptoServiceProvider( );
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
