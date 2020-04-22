using System;
using System.Text;
using System.Security.Cryptography;
//using CommonLib.Enum;

using LibBaseSequence.Interface;
using static HashTool.Head.HeadEnum;

namespace HashTool
{
    class HashCommon
    {
        private readonly int HEXADECIMAL = 16;

        private byte[] byte_value;
        private byte[] byte_hash;
        private string hash_value;

        public string getValue ( )
        {
            return hash_value;
        }

        private void ClearValue ( )
        {
            byte_value = null;
            byte_hash = null;
            hash_value = "";
        }

        /// <summary>
        /// ハッシュ値を取得する
        /// </summary>
        /// <param name="word">ハッシュしたい文字列</param>
        /// <param name="type">ハッシュしたいタイプ</param>
        /// <returns name="ret">
        /// E_FUNCTION_RESULT.SUCCESS;  /* 正常終了 */
        /// E_FUNCTION_RESULT.FAILE;    /* 異常終了 */
        /// </returns>
        public E_FUNCTION_RESULT GetHashValue (string word, E_HASH_TYPE type)
        {
            E_FUNCTION_RESULT ret = E_FUNCTION_RESULT.FAILE;        /* 戻り値               */
            E_FUNCTION_RESULT ret_fun = E_FUNCTION_RESULT.FAILE;    /* 呼び出し関数の戻り値 */

            int byte_size; 

            do
            {
                /* ハッシュ値を取得するため、変数を初期化 */
                ClearValue( );

                try
                {
                    byte_value = Encoding.UTF8.GetBytes(word);
                }
                catch(ArgumentNullException)
                {
                    break;
                }
                catch(EncoderFallbackException)
                {
                    break;
                }

                switch(type)
                {
                    case E_HASH_TYPE.MD5:
                        ret_fun = GetMD5HashValue();
                        break;
                    case E_HASH_TYPE.SHA1:
                        ret_fun = GetSHA1HashValue( );
                        break;
                    case E_HASH_TYPE.SHA256:
                        ret_fun = GetSHA256HashValue( );
                        break;
                    case E_HASH_TYPE.SHA384:
                        ret_fun = GetSHA384HashValue( );
                        break;
                    case E_HASH_TYPE.SHA512:
                        ret_fun = GetSHA512HashValue( );
                        break;
                    default:
                        break;
                }

                if(E_FUNCTION_RESULT.SUCCESS != ret_fun)
                {
                    break;
                }

                byte_size = (int)type / 2;
                ///* ハッシュ値のサイズをチェック */
                if(byte_size != byte_hash.Length)
                {
                    /* 異常終了 */
                    break;
                }

                ret_fun = ByteArrayToHexString( );
                if(E_FUNCTION_RESULT.SUCCESS != ret_fun)
                {
                    break;
                }

                /* 戻り値が正常終了に設定 */
                ret = E_FUNCTION_RESULT.SUCCESS;
            } while(false);

            return ret;
        }

        /// <summary>
        /// MD5ハッシュ値を取得し、ハッシュ配列に格納する
        /// </summary>
        /// <returns name="ret">
        /// E_FUNCTION_RESULT.SUCCESS;  /* 正常終了 */
        /// E_FUNCTION_RESULT.FAILE;    /* 異常終了 */
        /// </returns>
        private E_FUNCTION_RESULT GetMD5HashValue ( )
        {
            E_FUNCTION_RESULT ret = E_FUNCTION_RESULT.FAILE;    /* 戻り値 */
            MD5CryptoServiceProvider MD5CSP;                    /*  */

            do
            {
                try
                {
                    /* MD5CryptoServiceProviderクラスを新規 */
                    MD5CSP = new MD5CryptoServiceProvider( );
                }
                catch(InvalidOperationException)
                {
                    /* 異常終了 */
                    break;
                }

                try
                {
                    /* ハッシュ配列に出力 */
                    byte_hash = MD5CSP.ComputeHash(byte_value);
                }
                catch(ArgumentNullException)
                {
                    /* 異常終了 */
                    break;
                }
                catch(ObjectDisposedException)
                {
                    /* 異常終了 */
                    break;
                }

                /* 戻り値が正常終了に設定 */
                ret = E_FUNCTION_RESULT.SUCCESS;
            } while(false);

            return ret;
        }

        /// <summary>
        /// SHA1ハッシュ値を取得し、ハッシュ配列に格納する
        /// </summary>
        /// <returns name="ret">
        /// E_FUNCTION_RESULT.SUCCESS;  /* 正常終了 */
        /// E_FUNCTION_RESULT.FAILE;    /* 異常終了 */
        /// </returns>
        private E_FUNCTION_RESULT GetSHA1HashValue ()
        {
            E_FUNCTION_RESULT ret = E_FUNCTION_RESULT.FAILE;    /* 戻り値 */
            SHA1CryptoServiceProvider SHA1CSP;                  /*  */

            do
            {
                /* SHA1CryptoServiceProviderクラスを新規 */
                SHA1CSP = new SHA1CryptoServiceProvider( );
 
                try
                {
                    /* ハッシュ配列に出力 */
                    byte_hash = SHA1CSP.ComputeHash(byte_value);
                }
                catch(ArgumentNullException)
                {
                    /* 異常終了 */
                    break;
                }
                catch(ObjectDisposedException)
                {
                    /* 異常終了 */
                    break;
                }

                ret = E_FUNCTION_RESULT.SUCCESS;
            } while(false);

            return ret;
        }

        /// <summary>
        /// SHA256ハッシュ値を取得し、ハッシュ配列に格納する
        /// </summary>
        /// <returns name="ret">
        /// E_FUNCTION_RESULT.SUCCESS;  /* 正常終了 */
        /// E_FUNCTION_RESULT.FAILE;    /* 異常終了 */
        /// </returns>
        private E_FUNCTION_RESULT GetSHA256HashValue ( )
        {
            E_FUNCTION_RESULT ret = E_FUNCTION_RESULT.FAILE;    /* 戻り値 */
            SHA256CryptoServiceProvider SHA256CSP;              /*  */

            do
            {
                /* SHA256CryptoServiceProviderクラスを新規 */
                SHA256CSP = new SHA256CryptoServiceProvider( );
                
                try
                {
                    /* ハッシュ配列に出力 */
                    byte_hash = SHA256CSP.ComputeHash(byte_value);
                }
                catch(ArgumentNullException)
                {
                    /* 異常終了 */
                    break;
                }
                catch(ObjectDisposedException)
                {
                    /* 異常終了 */
                    break;
                }

                ret = E_FUNCTION_RESULT.SUCCESS;
            } while(false);

            return ret;
        }

        /// <summary>
        /// SHA384ハッシュ値を取得し、ハッシュ配列に格納する
        /// </summary>
        /// <returns name="ret">
        /// E_FUNCTION_RESULT.SUCCESS;  /* 正常終了 */
        /// E_FUNCTION_RESULT.FAILE;    /* 異常終了 */
        /// </returns>
        private E_FUNCTION_RESULT GetSHA384HashValue ( )
        {
            E_FUNCTION_RESULT ret = E_FUNCTION_RESULT.FAILE;    /* 戻り値 */
            SHA384CryptoServiceProvider SHA384CSP;              /*  */

            do
            {
                /* SHA384CryptoServiceProviderクラスを新規 */
                SHA384CSP = new SHA384CryptoServiceProvider( );
                
                try
                {
                    /* ハッシュ配列に出力 */
                    byte_hash = SHA384CSP.ComputeHash(byte_value);
                }
                catch(ArgumentNullException)
                {
                    /* 異常終了 */
                    break;
                }
                catch(ObjectDisposedException)
                {
                    /* 異常終了 */
                    break;
                }

                ret = E_FUNCTION_RESULT.SUCCESS;
            } while(false);

            return ret;
        }

        /// <summary>
        /// SHA512ハッシュ値を取得し、ハッシュ配列に格納する
        /// </summary>
        /// <returns name="ret">
        /// E_FUNCTION_RESULT.SUCCESS;  /* 正常終了 */
        /// E_FUNCTION_RESULT.FAILE;    /* 異常終了 */
        /// </returns>
        private E_FUNCTION_RESULT GetSHA512HashValue ( )
        {
            E_FUNCTION_RESULT ret = E_FUNCTION_RESULT.FAILE;    /* 戻り値 */
            SHA512CryptoServiceProvider SHA512CSP;              /*  */

            do
            {    
                /* MD5CryptoServiceProviderクラスを新規 */
                SHA512CSP = new SHA512CryptoServiceProvider( );

                try
                {
                    /* ハッシュ配列に出力 */
                    byte_hash = SHA512CSP.ComputeHash(byte_value);
                }
                catch(ArgumentNullException)
                {
                    /* 異常終了 */
                    break;
                }
                catch(ObjectDisposedException)
                {
                    /* 異常終了 */
                    break;
                }

                ret = E_FUNCTION_RESULT.SUCCESS;
            } while(false);

            return ret;
        }

        /// <summary>
        /// ハッシュ配列を16進数へ変換する
        /// </summary>
        /// <returns name="ret">
        /// E_FUNCTION_RESULT.SUCCESS;  /* 正常終了 */
        /// E_FUNCTION_RESULT.FAILE;    /* 異常終了 */
        /// </returns>
        private E_FUNCTION_RESULT ByteArrayToHexString ( )
        {
            E_FUNCTION_RESULT ret = E_FUNCTION_RESULT.FAILE;    /* 戻り値 */

            do
            {
                foreach(byte b in byte_hash)
                {
                    try
                    {
                        hash_value += Convert.ToString(b, HEXADECIMAL).PadLeft(2, '0');
                    }
                    catch(ArgumentOutOfRangeException)
                    {
                        break;
                    }
                    catch(ArgumentException)
                    {
                        break;
                    }
                }
                ret = E_FUNCTION_RESULT.SUCCESS;
            } while(false);

            return ret;
        }
    }
}
