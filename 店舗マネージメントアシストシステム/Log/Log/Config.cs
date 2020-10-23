using System.Xml.Linq;
using System.Xml.XPath;
using System.IO;
using System.Reflection;
using System;

using static CommonLib.EnumExtension.EnumExtension;
using static CommonLib.Common.Common;
using static Log.Constant;

namespace Log
{
    public class Config
    {
        internal XDocument xdoc = null;

        internal string XML_PATH  => Path.Combine(Directory.GetCurrentDirectory(),
                                                  Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location) + ".xml");

        // **********************
        // ***** プロパティ *****
        // **********************
        /// <summary>ログファイルパス</summary>
        /// <remarks>絶対パスで設定する</remarks>
        public string LogFilePath { get; set; }

        /// <summary>追記可／不可</summary>
        public bool IsAppend { get; set; }

        /// <summary>メッセージCategory</summary>
        /// <remarks>ログメッセージのCategory未設定場合、この値を使用する</remarks>
        public string Category { get; set; }

        /// <summary>出力レベル</summary>
        public E_TRACE_EVENT_LEVEL OutputLevel { get; set; }

        /// <summary>ログファイルサイズの上限</summary>
        /// <remarks>単位はキロバイト(KB)</remarks>
        public long MaxFileSize { get; set; }

        /// <summary>ログファイル保存日</summary>
        /// <remarks>単位は日</remarks>
        public int Period { get; set;}

        /// <summary>自動フラッシュ</summary>
        /// <remarks>明示的にFlashメソッドを呼び出さなくても自動的にフラッシュされるようにするにはtrueを設定します</remarks>
        public bool IsAutoFlush { get; set; }

        // **************************
        // ***** コンストラクタ *****
        // **************************
        public Config()
        {
        }

        /// <summary>
        /// Config定義を読み込み
        /// </summary>
        public void ReadConfig()
        {
            var XML_PATH = Path.Combine(Directory.GetCurrentDirectory(),
                                        Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location) + ".xml");
            xdoc = XDocument.Load(XML_PATH);

            // 値チェックエラー場合、デフォルト値としてXMLを保存する。
            if (!CheckConfig())
                SaveConfig();
        }

        /// <summary>
        /// Config値をチェック
        /// チェックエラー場合、デフォルト値を設定
        /// チェック成功の場合、Config値を設定
        /// </summary>
        private bool CheckConfig()
        {
            bool IsCorr = false;
            bool SetDefFlag = false; // デフォルト値設定フラグ

            //　ログファイルパスを設定する
            //　デフォルト値設定する場合、デフォルト値設定フラグを立てる
            if (!SetLogFilePath())
                SetDefFlag = true;

            //　上書き有効無効を設定
            if (!SetIsAppend())
                SetDefFlag = true;

            //　Categoryを設定
            if (!SetCategory())
                SetDefFlag = true;

            //　出力メッセージのレベルを設定
            if (!SetOutputLevel())
                SetDefFlag = true;

            //　ログファイルサイズの上限を設定
            if (!SetMaxFileSize())
                SetDefFlag = true;

            //　ログファイル保存日を設定
            if (!SetPeriod())
                SetDefFlag = true;

            if (!SetIsAutoFlush())
                SetDefFlag = true;

            //　すべて値が正常の場合、チェック成功
            if (!SetDefFlag) 
                IsCorr = true;

            return IsCorr;
        }

        private void SaveConfig()
        {
            xdoc.XPathSelectElement("//Setting/LogFilePath").Value = LogFilePath;
            xdoc.XPathSelectElement("//Setting/IsAppend").Value = IsAppend ? bool.TrueString : bool.FalseString;
            xdoc.XPathSelectElement("//Setting/Category").Value = Category;
            xdoc.XPathSelectElement("//Setting/OutputLevel").Value = ((int)OutputLevel).ToString();
            xdoc.XPathSelectElement("//Setting/MaxFileSize").Value = (MaxFileSize / 1024).ToString();
            xdoc.XPathSelectElement("//Setting/Period").Value = Period.ToString();
            xdoc.XPathSelectElement("//Setting/IsAutoFlush").Value = IsAutoFlush ? bool.TrueString : bool.FalseString;

            xdoc.Save(XML_PATH);
        }

        internal bool SetLogFilePath()
        {
            bool IsCorr = false;
            
            do
            { 
                var node = xdoc.XPathSelectElement("//Setting/LogFilePath");
                if (node == null) break;

                LogFilePath = node.Value;
                try
                {
                    if (!Directory.Exists(LogFilePath))
                        // 存在しない場合、作成する。
                        Directory.CreateDirectory(LogFilePath);
                    IsCorr = true;
                }
                catch (Exception) { //　作成失敗場合 
                }
            }while(false);

            if (!IsCorr) 
                LogFilePath = DEFAULT_LOG_FILE_PATH;
            return IsCorr;
        }

        internal bool SetIsAppend()
        {
            bool IsCorr = false;
            do
            {
                var node = xdoc.XPathSelectElement("//Setting/IsAppend");
                if (node == null) break;

                switch (node.Value.ToUpper())
                {
                    case "TRUE":
                        IsAppend = true;
                        IsCorr = true;
                        break;
                    case "FALSE":
                        IsAppend = false;
                        IsCorr = true;
                        break;
                    default:
                        break;
                }
            }while(false);

            if (!IsCorr)
                IsAppend = DEFAULT_IS_APPEND;
            return IsCorr;
        }

        internal bool SetCategory()
        {
            bool IsCorr = false;
            do
            {
                var node = xdoc.XPathSelectElement("//Setting/Category");
                if (node == null) break;

                Category = node.Value;
                switch (Category)
                {
                    case TRACE_CAT_DEBUG:
                    case TRACE_CAT_INFO:
                    case TRACE_CAT_WARN:
                    case TRACE_CAT_ERROR:
                    case TRACE_CAT_CRITI:
                        IsCorr = true;
                        break;
                    default:
                        break;
                }
            } while (false);

            if (!IsCorr)
                Category = DEFAULT_CATEGORY;
            return IsCorr;
        }

        internal bool SetOutputLevel()
        {
            bool IsCorr = false;
            var level = E_TRACE_EVENT_LEVEL.Debug;
            do
            {
                var node = xdoc.XPathSelectElement("//Setting/OutputLevel");
                if (node == null) break;
                try
                {
                    IsCorr = ConvertToEnum(int.Parse(node.Value), ref level); 
                }
                catch (Exception){ }
            } while (false);

            OutputLevel = IsCorr ? level : DEFAULT_OUTPUT_LEVEL;
            return IsCorr;
        }

        internal bool SetMaxFileSize()
        {
            bool IsCorr = false;
            do
            {
                var node = xdoc.XPathSelectElement("//Setting/MaxFileSize");
                if (node == null) break;
                try
                {
                    MaxFileSize = long.Parse(node.Value) * 1024;
                    IsCorr = true;
                }
                catch (Exception) { }
            } while (false);

            if (!IsCorr)
                MaxFileSize = DEFAULT_MAX_FILE_SIZE;
            return IsCorr;
        }

        private bool SetPeriod()
        {
            bool IsCorr = true;

            var value = xdoc.XPathSelectElement("//Setting/Period").Value;

            try
            {
                Period = int.Parse(value);
            }
            catch (Exception)
            {
                IsCorr = false;
            }

            if (!IsCorr)
                Period = DEFAULT_PERIOD;
            return IsCorr;
        }

        internal bool SetIsAutoFlush()
        {
            bool IsCorr = false;
            do
            {
                var node = xdoc.XPathSelectElement("//Setting/IsAutoFlush");
                if (node == null) break;

                switch (node.Value.ToUpper())
                {
                    case "TRUE":
                        IsAutoFlush = true;
                        IsCorr = true;
                        break;
                    case "FALSE":
                        IsAutoFlush = false;
                        IsCorr = true;
                        break;
                    default:
                        break;
                }
            } while (false);

            if (!IsCorr)
                IsAutoFlush = DEFAULT_IS_AUTO_FLUSH;
            return IsCorr;
        }
    }
}
