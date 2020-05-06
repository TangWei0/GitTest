using LibBaseSequence;
using System;
using System.Security.Cryptography;

namespace HashTool.Measurement
{
    public class MeasureSHA512 :MeasureBase
    {
        private SHA512CryptoServiceProvider SHA512CSP;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="parameter"></param>
        public MeasureSHA512 (Parameter parameter) : base(parameter) { }

        /// <summary>
        /// MD5CryptoServiceProviderインスタンス
        /// </summary>
        protected override void Instance ( )
        {
            SHA512CSP = new SHA512CryptoServiceProvider( );
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
