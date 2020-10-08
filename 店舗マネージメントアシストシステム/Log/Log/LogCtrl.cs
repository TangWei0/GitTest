using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log
{
    public class LogCtrl
    {
        #region 変数
        /// <summary> ログ </summary>
        private static LogCtrl singleton = null;

        /// <summary>ログ出力バッファ</summary>
        private static StringBuilder buffer = new StringBuilder();
        
        /// <summary>バッファサイズ</summary>
        private static long bufferSize = Config.MaxFileSize / 3;

        /// <summary>ファイルサイズ取得時に使用</summary>
        private static FileInfo info;
        #endregion

        #region プロパティ
        // **********************
        // ***** プロパティ *****
        // **********************
        /// <summary>ログファイル名</summary>
        
        private static string FileName
        {
            get { return Config.BaseFileName + "_" + DateTime.Now.ToString("yyyyMMdd") + ".log"; }
        }

        /// <summary>ログファイルパス</summary>
        /// <remarks>絶対パスを返す。</remarks>
        private static string FullPath
        {
            get { return Path.Combine(Config.LogFilePath, FileName); }
        }
        #endregion

        #region コンストラクタ
        // **************************
        // ***** コンストラクタ *****
        // **************************
        static LogCtrl()
        {
            if (!File.Exists(FullPath))
            {
                FileStream fs = File.Create(FullPath);
                fs.Close();
            }
        }
        #endregion

        #region Publicメソッド
        // **************************
        // ***** Publicメソッド *****
        // **************************

        /// <summary>
        /// インスタンスを生成する
        /// </summary>
        public static LogCtrl GetInstance()
        {
            if (singleton == null) 
                singleton = new LogCtrl();
            return singleton;
        }

        /// <summary>
        /// アプリケーションのログにメッセージを書き込みます。
        /// </summary>
        /// <param name="message">出力するログメッセージ</param>
        /// <remarks>メッセージの種類は既定でTraceEventType.Information</remarks>
        public void WriteEntry(string message)
        {
            WriteEntry(message, TraceEventType.INFO);
        }

        /// <summary>
        /// アプリケーションのログにメッセージを書き込みます。
        /// </summary>
        /// <param name="message">出力するログメッセージ</param>
        /// <param name="severity">メッセージの種類</param>
        /// <remarks></remarks>
        public void WriteEntry(string message, TraceEventType severity)
        {
            // メッセージの種類
            string StrSeverity = string.Empty;
            switch(severity)
            {
                case TraceEventType.INFO:
                    StrSeverity = "Info";
                    break;
                case TraceEventType.WARN:
                    StrSeverity = "Warning";
                    break;
                case TraceEventType.ERROR:
                    StrSeverity = "Error";
                    break;
                case TraceEventType.Critical:
                    StrSeverity = "Critical";
                    break;
            }

            // 出力メッセージ作成
            StringBuilder outmessage = new StringBuilder();
            outmessage.Append(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.ffff "));
            outmessage.Append("[" + StrSeverity + "]");
            outmessage.Append("\t");
            outmessage.Append(message);

            // バッファに追加
            buffer.AppendLine(outmessage.ToString());

            // ログ出力
            if (buffer.Length > bufferSize || Config.IsAutoFlush == true)
            {
                Flush();
            }
        }

        /// <summary>
        /// バッファをログファイルへ出力
        /// </summary>
        /// <remarks>出力後バッファはクリアされる</remarks>
        public void Flush()
        {
            // ファイルサイズの上限確認
            CheckFileSize();

            // ログ出力
            using (StreamWriter writer = new StreamWriter(FullPath, Config.IsAppend))
            {
                writer.Write(buffer.ToString());
            }

            // バッファクリア
            buffer.Clear();
        }
        #endregion

        #region Privateメソッド
        // ***************************
        // ***** Privateメソッド *****
        // ***************************

        /// <summary>
        /// ファイルサイズの上限確認
        /// 上限を超えた場合、ファイルをバックアップする
        /// </summary>
        private static void CheckFileSize()
        {
            // ファイルが存在しない場合、ファイルサイズをチェックしない
            if (!File.Exists(FullPath)) return;

            info = new FileInfo(FullPath);
            long FileSize = info.Length + buffer.Length;
            
            //　上限を超えないので、処理を終了する
            if (FileSize <= Config.MaxFileSize) return;

            string filename = FullPath + ".bk";
            int count = 1;
            while (File.Exists(filename + count.ToString()))
            {
                count++;
            }
            info.MoveTo(filename + count.ToString());
            info = null;
        }

        #endregion
    }
}
