using System;
using CommonLib.Constant.ManagerAssist;

namespace ComputeHash
{
    class Program
    {
        public static void Main (string[] args)
        {
            Console.WriteLine(Constant.test);
            Console.WriteLine(E_FUNCTION_RESULT.ABORT);

            //Console.WriteLine(E_FUNCTION_RESULT.ABORT);
            //Time Time = new Time( );
            //long trick1 = Time.GetCurrentTimeStamp();
            //long trick2 = Time.GetUTCTimeStamp( );
            //Console.WriteLine(trick1);
            //Console.WriteLine(trick2);

            //int i=0;
            //i = i + 1;


            //byte[] key, iv;

            ////ファイルを暗号化する
            //EncryptFile("FunctionEnabled.xml", "abc.xml", out key, out iv);
            //Console.WriteLine(key);
            //Console.WriteLine(iv);

            //RijndaelManaged key = new RijndaelManaged( );
            ////设置密钥:key为32位=数字或字母16个=汉字8个
            //byte[] byteKey = Encoding.Unicode.GetBytes("1111111111111111");
            //key.Key = byteKey;
            //XmlDocument xmlDoc = new XmlDocument( );
            //xmlDoc.PreserveWhitespace = true;
            //xmlDoc.Load("FunctionEnabled.xml");//加载要加密的XML文件
            //if(key != null)
            //{
            //    key.Clear( );
            //}
            //xmlDoc.Save("abc.xml");//生成加密后的XML文件 


            //E_FUNCTION_RESULT ret_fuction;

            //do
            //{
            //    var sw = new System.Diagnostics.Stopwatch( );

            //    // 計測開始
            //    sw.Start( );

            //    Sequence sequence = new Sequence( );
            //    sequence.Parameter.SetValue("abc",
            //                                E_HASH_ORDER.SINGLE,
            //                                E_HASH_TYPE.MD5,
            //                                E_HASH_SENSITIVE.LOWER,
            //                                32);

            //    //ret_fuction = hash.GetHashValue( );
            //    //if(E_FUNCTION_RESULT.SUCCESS != ret_fuction)
            //    //{
            //    //    break;
            //    //}
            //    //Console.WriteLine(hash.GetValue());

            //    // 計測停止
            //    sw.Stop( );

            //    // 結果表示
            //    Console.WriteLine($"　{sw.ElapsedMilliseconds} ミリ秒");

            //    // 経過時間をリセットしてから計測開始
            //    sw.Restart( );

            //    hash = new HashHelper("abc",
            //                     E_HASH_SENSITIVE.UPPER,
            //                     E_HASH_TYPE.SHA1,
            //                     E_HASH_ORDER.SINGLE,
            //                     40);
            //    ret_fuction = hash.GetHashValue( );
            //    if(E_FUNCTION_RESULT.SUCCESS != ret_fuction)
            //    {
            //        break;
            //    }
            //    Console.WriteLine(hash.GetValue( ));

            //    // 計測停止
            //    sw.Stop( );

            //    // 結果表示
            //    Console.WriteLine($"　{sw.ElapsedMilliseconds}ミリ秒");

            //    // 経過時間をリセットしてから計測開始
            //    sw.Restart( );

            //    hash = new HashHelper("abc",
            //                     E_HASH_SENSITIVE.UPPER,
            //                     E_HASH_TYPE.SHA256,
            //                     E_HASH_ORDER.SINGLE,
            //                     64);
            //    ret_fuction = hash.GetHashValue( );
            //    if(E_FUNCTION_RESULT.SUCCESS != ret_fuction)
            //    {
            //        break;
            //    }
            //    Console.WriteLine(hash.GetValue( ));

            //    // 計測停止
            //    sw.Stop( );

            //    // 結果表示
            //    Console.WriteLine($"　{sw.ElapsedMilliseconds}ミリ秒");

            //    // 経過時間をリセットしてから計測開始
            //    sw.Restart( );

            //    hash = new HashHelper("abc",
            //                     E_HASH_SENSITIVE.UPPER,
            //                     E_HASH_TYPE.SHA384,
            //                     E_HASH_ORDER.SINGLE,
            //                     96);
            //    ret_fuction = hash.GetHashValue( );
            //    if(E_FUNCTION_RESULT.SUCCESS != ret_fuction)
            //    {
            //        break;
            //    }
            //    Console.WriteLine(hash.GetValue( ));

            //    // 計測停止
            //    sw.Stop( );

            //    // 結果表示
            //    Console.WriteLine($"　{sw.ElapsedMilliseconds}ミリ秒");

            //    // 経過時間をリセットしてから計測開始
            //    sw.Restart( );

            //    hash = new HashHelper("abc",
            //                     E_HASH_SENSITIVE.UPPER,
            //                     E_HASH_TYPE.SHA512,
            //                     E_HASH_ORDER.SINGLE,
            //                     128);
            //    ret_fuction = hash.GetHashValue( );
            //    if(E_FUNCTION_RESULT.SUCCESS != ret_fuction)
            //    {
            //        break;
            //    }
            //    Console.WriteLine(hash.GetValue( ));

            //    // 計測停止
            //    sw.Stop( );

            //    // 結果表示
            //    Console.WriteLine($"　{sw.ElapsedMilliseconds}ミリ秒");

            //} while(false);
        }

        /// <summary>
        /// ファイルを暗号化する
        /// </summary>
        /// <param name="sourceFile">暗号化するファイルパス</param>
        /// <param name="destFile">暗号化されたデータを保存するファイルパス</param>
        /// <param name="key">暗号化に使用した共有キー</param>
        /// <param name="iv">暗号化に使用した初期化ベクタ</param>
        public static void EncryptFile (
            string sourceFile, string destFile, out byte[] key, out byte[] iv)
        {
            //RijndaelManagedオブジェクトを作成
            System.Security.Cryptography.RijndaelManaged rijndael =
                new System.Security.Cryptography.RijndaelManaged( );

            //設定を変更するときは、変更する
            //rijndael.KeySize = 256;
            //rijndael.BlockSize = 128;
            //rijndael.FeedbackSize = 128;
            //rijndael.Mode = System.Security.Cryptography.CipherMode.CBC;
            //rijndael.Padding = System.Security.Cryptography.PaddingMode.PKCS7;

            //共有キーと初期化ベクタを作成
            //Key、IVプロパティがnullの時に呼びだすと、自動的に作成される
            //自分で作成するときは、GenerateKey、GenerateIVメソッドを使う
            key = rijndael.Key;
            iv = rijndael.IV;

            //暗号化されたファイルを書き出すためのFileStream
            System.IO.FileStream outFs = new System.IO.FileStream(
                destFile, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            //対称暗号化オブジェクトの作成
            System.Security.Cryptography.ICryptoTransform encryptor =
                rijndael.CreateEncryptor( );
            //暗号化されたデータを書き出すためのCryptoStreamの作成
            System.Security.Cryptography.CryptoStream cryptStrm =
                new System.Security.Cryptography.CryptoStream(
                    outFs, encryptor,
                    System.Security.Cryptography.CryptoStreamMode.Write);

            //暗号化されたデータを書き出す
            System.IO.FileStream inFs = new System.IO.FileStream(
                sourceFile, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            byte[] bs = new byte[1024];
            int readLen;
            while((readLen = inFs.Read(bs, 0, bs.Length)) > 0)
            {
                cryptStrm.Write(bs, 0, readLen);
            }

            //閉じる
            inFs.Close( );
            cryptStrm.Close( );
            encryptor.Dispose( );
            outFs.Close( );
        }

        /// <summary>
        /// ファイルを復号化する
        /// </summary>
        /// <param name="sourceFile">復号化するファイルパス</param>
        /// <param name="destFile">復号化されたデータを保存するファイルパス</param>
        /// <param name="key">暗号化に使用した共有キー</param>
        /// <param name="iv">暗号化に使用した初期化ベクタ</param>
        public static void DecryptFile (
            string sourceFile, string destFile, byte[] key, byte[] iv)
        {
            //RijndaelManagedオブジェクトの作成
            System.Security.Cryptography.RijndaelManaged rijndael =
                new System.Security.Cryptography.RijndaelManaged( );

            //共有キーと初期化ベクタを設定
            rijndael.Key = key;
            rijndael.IV = iv;

            //暗号化されたファイルを読み込むためのFileStream
            System.IO.FileStream inFs = new System.IO.FileStream(
                sourceFile, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            //対称復号化オブジェクトの作成
            System.Security.Cryptography.ICryptoTransform decryptor =
                rijndael.CreateDecryptor( );
            //暗号化されたデータを読み込むためのCryptoStreamの作成
            System.Security.Cryptography.CryptoStream cryptStrm =
                new System.Security.Cryptography.CryptoStream(
                    inFs, decryptor,
                    System.Security.Cryptography.CryptoStreamMode.Read);

            //復号化されたデータを書き出す
            System.IO.FileStream outFs = new System.IO.FileStream(
                destFile, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            byte[] bs = new byte[1024];
            int readLen;
            //復号化に失敗すると例外CryptographicExceptionが発生
            while((readLen = cryptStrm.Read(bs, 0, bs.Length)) > 0)
            {
                outFs.Write(bs, 0, readLen);
            }

            //閉じる
            outFs.Close( );
            cryptStrm.Close( );
            decryptor.Dispose( );
            inFs.Close( );
        }
    }
}
