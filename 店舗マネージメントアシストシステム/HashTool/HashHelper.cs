using System;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using static ClassLibrary.Enum;

namespace HashTool
{
    /// <summary>
    ///  C# 文字列/ファイルのハッシュ値（MD5、SHA）を計算
    ///  1）String_Hash_MD5_32      ：32ビットMD5ハッシュ値を計算
    ///  2）String_Hash_MD5_16      ：16ビットMD5ハッシュ値を計算
    ///  3）String_Hash_2_MD5_32    ：2重32ビットMD5ハッシュ値を計算
    ///  4）String_Hash_2_MD5_16    ：2重16ビットMD5ハッシュ値を計算
    ///  5）String_Hash_SHA_1       ：Hash-1ハッシュ値を計算
    ///  6）String_Hash_SHA_256     ：SHA-256ハッシュ値を計算
    ///  7）String_Hash_SHA_384     ：SHA-384ハッシュ値を計算
    ///  8）String_Hash_SHA_512     ：SHA-512ハッシュ値を計算
    ///  9）File_Hash_SHA_256       ：ファイルSHA-256ハッシュ値を計算
    /// 10）File_Hash_MD5           ：ファイルMD5ハッシュ値を計算
    /// 11）File_Hash_SHA_1         ：ファイルSHA1ハッシュ値を計算

    public class HashHelper
    {
        static byte[] G_ByteValue;

        static void GetWordToBytes (string word)
        {
            G_ByteValue = Encoding.UTF8.GetBytes(word);
        }
        /// <summary>
        /// 32ビットMD5ハッシュ値を計算
        /// </summary>
        /// <param name="word">ハッシュしたい文字列</param>
        /// <param name="upper_lower">出力ハッシュ値の大文字/小文字を指定</param>
        /// <param name="hash_value">出力ハッシュ値</param>
        /// <returns name="ret"> </returns>
        public static E_FUNCTION_RESULT String_Hash_MD5_32(string word,
                                                           E_HASH_PARAMETER upper_lower,
                                                           out string hash_value)
        {
            E_FUNCTION_RESULT ret = E_FUNCTION_RESULT.FAILE;
            byte[] bytHash;

            do
            {
                try
                {
                    MD5CryptoServiceProvider MD5CSP = new MD5CryptoServiceProvider( );
                    GetWordToBytes(word);
                    bytHash = MD5CSP.ComputeHash(G_ByteValue);
                    MD5CSP.Clear( );

                    //根据计算得到的Hash码翻译为MD5码
                    string sHash = "", sTemp = "";
                    for(int counter = 0;counter < bytHash.Count( );counter++)
                    {
                        long i = bytHash[counter] / 16;
                        if(i > 9)
                        {
                            sTemp = ((char)(i - 10 + 0x41)).ToString( );
                        }
                        else
                        {
                            sTemp = ((char)(i + 0x30)).ToString( );
                        }
                        i = bytHash[counter] % 16;
                        if(i > 9)
                        {
                            sTemp += ((char)(i - 10 + 0x41)).ToString( );
                        }
                        else
                        {
                            sTemp += ((char)(i + 0x30)).ToString( );
                        }
                        sHash += sTemp;
                    }

                    //根据大小写规则决定返回的字符串
                    hash_value = ((upper_lower == E_HASH_PARAMETER.UPPER) ? sHash : sHash.ToLower());
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                // 正常終了に設定
                ret = E_FUNCTION_RESULT.SUCCESS;
            } while (false);

            return ret;
        }
    
    }
}
