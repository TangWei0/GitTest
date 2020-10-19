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
        /// <summary>ログ出力バッファ</summary>
        private readonly StringBuilder Buffer = new StringBuilder();
        
        /// <summary>バッファサイズ</summary>
        private readonly long BufferSize;

        /// <summary>ファイルサイズ</summary>
        private long FileSize;

        private string AppName => Path.GetFileNameWithoutExtension(Process.GetCurrentProcess().MainModule.FileName);

        /// <summary>ログパス</summary>
        private string FileFolder => Path.Combine(ConfigFactory.GetInstance().LogFilePath, AppName + "\\");

        /// <summary>ログファイル名</summary>
        private string FileName => AppName + "_" + DateTime.Now.ToString("yyyyMMdd") + ".log";

        /// <summary>ログファイルパス</summary>
        /// <remarks>絶対パスを返す。</remarks>
        private string FullPath => Path.Combine(FileFolder, FileName);

        // ***** コンストラクタ *****
        public LogCtrl()
        {
            if (ConfigFactory.GetInstance().IsAppend)
                BufferSize = ConfigFactory.GetInstance().MaxFileSize / 10;
            else
                BufferSize = ConfigFactory.GetInstance().MaxFileSize * 9 / 10 ;

            FileSize = 0;

            CreatFolder();

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
            outmessage.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff "));
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
        /// フォルダを作成
        /// </summary>
        private void CreatFolder()
        {
            if (Directory.Exists(FileFolder)) return;

            Directory.CreateDirectory(FileFolder);
        }
        /// <summary>
        /// Flushするかをチェックする
        /// </summary>
        /// <returns></returns>
        private bool IsCheckFlush()
        {
            bool IsFlush = false;

            // ログファイルに追記する場合
            if (ConfigFactory.GetInstance().IsAppend)
            {
                //　自動フラッシュまたログ出力バッファが設定値を超えた場合、
                if ((Buffer.Length > BufferSize) || ConfigFactory.GetInstance().IsAutoFlush )
                {
                    //　ログファイルサイズを超えた場合、ログファイルをバックアップする
                    if (!CheckFileSize())
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
            using (StreamWriter writer = new StreamWriter(FullPath, ConfigFactory.GetInstance().IsAppend))
            {
                writer.Write(Buffer.ToString());
                FileSize += Buffer.Length;
            }

            // バッファクリア
            Buffer.Clear();
        }

        /// <summary>
        /// ファイルサイズの上限確認
        /// 上限を超えた場合、ファイルをバックアップする
        /// </summary>
        private bool CheckFileSize()
        {
            //　上限を超えないので、処理を終了する
            if (ConfigFactory.GetInstance().MaxFileSize >= FileSize + Buffer.Length) 
                return false;

            return true;
        }

        /// <summary>
        /// ログファイルをバックアップする
        /// </summary>
        private void BackupLogFile()
        {
            string filename = FullPath + ".bk";
            int count = 1;
            while (File.Exists(filename + count.ToString()))
            {
                count++;
            }
            File.Move(FullPath, filename);

            // ログファイルバックアップしたので、ログファイルをクリアする
            FileSize = 0;
        }

        /// <summary>
        /// 古いログファイルを削除する
        /// </summary>
        private void DeleteOldLogFile()
        {
            DateTime retentionDate = DateTime.Today.AddDays(-ConfigFactory.GetInstance().Period);
            string[] filePathList = Directory.GetFiles(FileFolder);
            foreach (string filePath in filePathList)
            {
                string date = Regex.Replace(Path.GetFileNameWithoutExtension(filePath), @"[^0-9]+", "");
                DateTime logCreatedDate = DateTime.ParseExact(date, "yyyyMMdd", null);
                if (logCreatedDate < retentionDate)
                {
                    File.Delete(filePath);
                }
            }
        }
    }
}
