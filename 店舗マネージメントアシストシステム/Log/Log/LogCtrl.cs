using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

using static CommonLib.Common.Common;

namespace Log
{
    public class LogCtrl
    {
        internal readonly Config Config;
        
        /// <summary>ログ出力バッファ</summary>
        internal StringBuilder Buffer = new StringBuilder();
        
        /// <summary>バッファサイズ</summary>
        internal long BufferSize;

        /// <summary>ファイルサイズ</summary>
        internal long FileSize;

        internal DateTime CurrentTime;

        internal string AppName => Path.GetFileNameWithoutExtension(Process.GetCurrentProcess().MainModule.FileName);

        /// <summary>ログパス</summary>
        internal string FileFolder => Path.Combine(Config.LogFilePath, AppName + "\\");

        /// <summary>ログファイル名</summary>
        internal string FileName => AppName + "_" + DateTime.Now.ToString("yyyyMMdd") + ".log";

        /// <summary>ログファイルパス</summary>
        /// <remarks>絶対パスを返す。</remarks>
        internal string FullPath => Path.Combine(FileFolder, FileName);

        // ***** コンストラクタ *****
        public LogCtrl()
        {
            Config = ConfigFactory.Get();
        }

        /// <summary>
        /// LogCtrl初期化処理
        /// </summary>
        public void Init()
        {
            BufferSize = Config.MaxFileSize / 10;
            if (!Config.IsAppend)
                BufferSize *= 9 ;

            FileSize = 0;

            if (!Directory.Exists(FileFolder))
                Directory.CreateDirectory(FileFolder);

            // 古いログファイルを削除する
            DeleteOldLogFile();
        }

        /// <summary>
        /// アプリケーションのログにメッセージを書き込みます。
        /// </summary>
        /// <param name="Category">メッセージの種類</param>
        /// <param name="message">出力するログメッセージ</param>
        /// <remarks></remarks>
        public void WriteEntry(string message, string category)
        {
            // 出力メッセージ作成
            StringBuilder outmessage = new StringBuilder();
            CurrentTime = DateTime.Now;
            outmessage.Append(CurrentTime.ToString("yyyy/MM/dd HH:mm:ss.fff "));
            outmessage.Append("[" + category + "]");
            outmessage.Append("\t");

            // メッセージ部分を揃えるため
            if (TRACE_CAT_ERROR == category)
                outmessage.Append("\t");

            outmessage.Append(message);

            // バッファに追加
            Buffer.AppendLine(outmessage.ToString());

            // ログ出力かを判断し、True場合ログ出力する
            if (IsCheckFlush())
                Flush();
        }

        /// <summary>
        /// Flushするかをチェックする
        /// </summary>
        /// <returns></returns>
        internal bool IsCheckFlush()
        {
            bool IsFlush = false;

            // ログファイルに追記する場合
            if (Config.IsAppend)
            {
                //　自動フラッシュまたログ出力バッファが設定値を超えた場合、
                if ((Buffer.Length > BufferSize) || Config.IsAutoFlush )
                {
                    //　ログファイルサイズを超えた場合、ログファイルをバックアップする
                    if (Config.MaxFileSize < FileSize + Buffer.Length)
                        //　ログファイルをバックアップ
                         BackupLogFile();

                    IsFlush = true;
                }
            }         
            else
            {
                // ログファイルを上書き場合
                //　ログ出力バッファが設定値を超えた場合
                if (Buffer.Length > BufferSize)
                { 
                    //　ログファイルをバックアップ
                    BackupLogFile();

                    IsFlush = true;
                }
            }

            return IsFlush;
        }

        /// <summary>
        /// バッファをログファイルへ出力
        /// </summary>
        /// <remarks>出力後バッファはクリアされる</remarks>
        public void Flush()
        {
            // Buffer長さ０以下場合、ログファイルを出力しない
            if (0 >= Buffer.Length) return;

            // ログ出力
            using (StreamWriter writer = new StreamWriter(FullPath, Config.IsAppend))
            {
                writer.Write(Buffer.ToString());
                writer.Dispose();
            }

            if (Config.IsAppend)
                FileSize += Buffer.Length;
            else
                FileSize = Buffer.Length;

            // バッファクリア
            Buffer.Clear();
        }

        /// <summary>
        /// ログファイルをバックアップする
        /// </summary>
        internal void BackupLogFile()
        {
            string filename = FullPath + ".bk";
            int count = 1;
            while (File.Exists(filename + count.ToString()))
            {
                count++;
            }
            File.Move(FullPath, filename + count.ToString());

            // ログファイルバックアップしたので、ログファイルをクリアする
            FileSize = 0;
        }

        /// <summary>
        /// 古いログファイルを削除する
        /// </summary>
        internal void DeleteOldLogFile()
        {
            if (!Directory.Exists(FileFolder)) return; 

            DateTime retentionDate = DateTime.Today.AddDays(-Config.Period);
            string[] filePathList = Directory.GetFiles(FileFolder);
            foreach (string filePath in filePathList)
            {
                try
                { 
                    string date = Regex.Replace(Path.GetFileNameWithoutExtension(filePath), @"[^0-9]+", "");
                    DateTime logCreatedDate = DateTime.ParseExact(date, "yyyyMMdd", null);
                    if (logCreatedDate < retentionDate)
                    {
                        File.Delete(filePath);
                    }
                }
                catch(Exception)
                {
                    // ログファイル名がフォーマットに従わないので、削除する。
                    File.Delete(filePath);
                }
            }
        }
    }
}
