using System;
using System.Security.Cryptography;
using LibBaseSequence;

namespace HashTool.Measurement
{
    public class MeasureMD5 : MeasureBase
    {
        private MD5CryptoServiceProvider MD5CSP;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="parameter"></param>
        public MeasureMD5 (Parameter parameter) : base(parameter) { }

        /// <summary>
        /// MD5CryptoServiceProviderインスタンス
        /// </summary>
        protected override void Instance ( )
        {
            try
            {
                MD5CSP = new MD5CryptoServiceProvider( );
            }
            catch(Exception ex)
            {
                throw new ProcessException(
                    String.Format("HashToolの実行異常　MD5CryptoServiceProviderインスタンス失敗"),
                    ex.InnerException);
            }
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
                MD5CSP.Initialize( );

                /* ハッシュ配列に出力 */
                return MD5CSP.ComputeHash(byte_value);
            }
            catch(Exception ex)
            {
                throw new ProcessException(
                    String.Format("HashToolの実行異常　MD5ハッシュ配列出力失敗"),
                    ex.InnerException);
            }
        }
    }
}
