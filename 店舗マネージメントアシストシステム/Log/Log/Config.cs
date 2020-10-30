using System.Xml;
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
        internal XmlDocument xmldoc = null;
        internal XmlNode xmlroot = null;
        internal XmlNode xmlnode = null;

        internal string XML_PATH  => Path.Combine(Directory.GetCurrentDirectory(),
                                                  Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location) + ".xml");

        // **********************
        // ***** プロパティ *****
        // **********************
        /// <summary>ログファイルパス</summary>
        /// <remarks>絶対パスで設定する</remarks>
        public string LogFilePath { get; set; } = DEFAULT_LOG_FILE_PATH;

        /// <summary>追記可／不可</summary>
        public bool IsAppend { get; set; } = DEFAULT_IS_APPEND;

        /// <summary>メッセージCategory</summary>
        /// <remarks>ログメッセージのCategory未設定場合、この値を使用する</remarks>
        public string Category { get; set; } = DEFAULT_CATEGORY;

        /// <summary>出力レベル</summary>
        public E_TRACE_EVENT_LEVEL OutputLevel { get; set; } = DEFAULT_OUTPUT_LEVEL;

        /// <summary>ログファイルサイズの上限</summary>
        /// <remarks>単位はバイト(B)</remarks>
        public long MaxFileSize { get; set; } = DEFAULT_MAX_FILE_SIZE;

        /// <summary>ログファイル保存日</summary>
        /// <remarks>単位は日</remarks>
        public int Period { get; set;} = DEFAULT_PERIOD;

        /// <summary>自動フラッシュ</summary>
        /// <remarks>明示的にFlashメソッドを呼び出さなくても自動的にフラッシュされるようにするにはtrueを設定します</remarks>
        public bool IsAutoFlush { get; set; } = DEFAULT_IS_AUTO_FLUSH;

        // **************************
        // ***** コンストラクタ *****
        // **************************
        public Config()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public void Init()
        {
            if (!File.Exists(XML_PATH))
                CreatConfigXML();
            else
            {
                // Xmlを読み込み
                xmldoc = new XmlDocument();
                xmldoc.Load(XML_PATH);

                // XmlのRootとNodeが存在するかをチェックする。
                CheckRootAndNodeExist();

                // プロパティを設定する
                SetPropertyALL();
            }

            xmldoc.Save(XML_PATH);
        }

        /// <summary>
        /// XMLファイルがなければ作成する。
        /// </summary>
        private void CreatConfigXML()
        {
            xmldoc = new XmlDocument();
            var xmldecl = xmldoc.CreateXmlDeclaration("1.0", "utf-8", null);
            xmldoc.AppendChild(xmldecl);

            CreatRootElement();
            xmldoc.Save(XML_PATH);
        }

        private void CreatRootElement()
        {
            var xmlelem = xmldoc.CreateElement(ROOT_NAME);
            xmldoc.AppendChild(xmlelem);
            xmlroot = xmldoc.SelectSingleNode(ROOT_NAME);

            CreatNodeElement(NODE_LOG_FILE_PATH);
            CreatNodeElement(NODE_IS_APPEND);
            CreatNodeElement(NODE_CATEGORY);
            CreatNodeElement(NODE_OUTPUT_LEVEL);
            CreatNodeElement(NODE_MAX_FILE_SIZE);
            CreatNodeElement(NODE_PERIOD);
            CreatNodeElement(NODE_IS_AUTO_FLUSH);
        }

        private void CheckRootAndNodeExist()
        {
            // Root存在しない場合、作成する。
            xmlroot = xmldoc.SelectSingleNode(ROOT_NAME);
            if (xmlroot == null)
            {     
                CreatRootElement(); 
                return;
            }

            if (xmlroot.SelectSingleNode(NODE_LOG_FILE_PATH) == null)
                CreatNodeElement(NODE_LOG_FILE_PATH);
            if (xmlroot.SelectSingleNode(NODE_IS_APPEND) == null)
                CreatNodeElement(NODE_IS_APPEND);
            if (xmlroot.SelectSingleNode(NODE_CATEGORY) == null)
                CreatNodeElement(NODE_CATEGORY);
            if (xmlroot.SelectSingleNode(NODE_OUTPUT_LEVEL) == null)
                CreatNodeElement(NODE_OUTPUT_LEVEL);
            if (xmlroot.SelectSingleNode(NODE_MAX_FILE_SIZE) == null)
                CreatNodeElement(NODE_MAX_FILE_SIZE);
            if (xmlroot.SelectSingleNode(NODE_PERIOD) == null)
                CreatNodeElement(NODE_PERIOD);
            if (xmlroot.SelectSingleNode(NODE_IS_AUTO_FLUSH) == null)
                CreatNodeElement(NODE_IS_AUTO_FLUSH);
        }

        private void CreatNodeElement(string NodeName)
        {
            var subNode = xmldoc.CreateElement(NodeName);
            subNode.InnerText = NODE_INFO[NodeName].NodeValue;
            xmlroot.AppendChild(subNode);
            foreach (var list in NODE_INFO[NodeName].NodeComment)
            {
                var comment = xmldoc.CreateComment(list);
                xmlroot.InsertBefore(comment, subNode);
            }

            SetProperty(NodeName);
        }

        /// <summary>
        /// プロパティを設定する
        /// </summary>
        private void SetPropertyALL()
        {
            SetProperty(NODE_LOG_FILE_PATH);
            SetProperty(NODE_IS_APPEND);
            SetProperty(NODE_CATEGORY);
            SetProperty(NODE_OUTPUT_LEVEL);
            SetProperty(NODE_MAX_FILE_SIZE);
            SetProperty(NODE_PERIOD);
            SetProperty(NODE_IS_AUTO_FLUSH);
        }

        internal void SetProperty(string NodeName) 
        {
            xmlnode = xmlroot.SelectSingleNode(NodeName);
            switch(NodeName)
            {
                case NODE_LOG_FILE_PATH:
                    SetLogFilePath();
                    break;
                case NODE_IS_APPEND:
                    SetIsAppend();
                    break;
                case NODE_CATEGORY:
                    SetCategory();
                    break;
                case NODE_OUTPUT_LEVEL:
                    SetOutputLevel();
                    break;
                case NODE_MAX_FILE_SIZE:
                    SetMaxFileSize();
                    break;
                case NODE_PERIOD:
                    SetPeriod();
                    break;
                case NODE_IS_AUTO_FLUSH:
                    SetIsAutoFlush();
                    break;
                default:
                    break;
            }
        }

        internal void SetLogFilePath()
        {
            try
            {
                var path = xmlnode.InnerText;
                if (!Directory.Exists(path))
                    // 存在しない場合、作成する。
                    Directory.CreateDirectory(path);

                LogFilePath = path;
            }
            catch (Exception)
            { 
                //　作成失敗場合
                LogFilePath = DEFAULT_LOG_FILE_PATH;
            }

            xmlnode.InnerText = LogFilePath;
        }

        internal void SetIsAppend()
        {
            switch(xmlnode.InnerText.ToUpper())
            {
                case "TRUE":
                    IsAppend = true;
                    break;
                case "FALSE":
                    IsAppend = false;
                    break;
                default:
                    IsAppend = DEFAULT_IS_APPEND;
                    break;
            }

            xmlnode.InnerText = IsAppend.ToString().ToUpper();
        }

        internal void SetCategory()
        {
            var category = xmlnode.InnerText;
            switch (category)
            {
                case TRACE_CAT_DEBUG:
                case TRACE_CAT_INFO:
                case TRACE_CAT_WARN:
                case TRACE_CAT_ERROR:
                case TRACE_CAT_CRITI:
                    Category = category;
                    break;
                default:
                    Category = DEFAULT_CATEGORY;
                    break;
            }

            xmlnode.InnerText = Category;
        }

        internal void SetOutputLevel()
        {
            bool IsCorr = false;
            var level = E_TRACE_EVENT_LEVEL.Debug;
            try
            {
                var index = int.Parse(xmlnode.InnerText);
                IsCorr = ConvertToEnum(index, ref level);
            }
            catch(Exception){ }

            OutputLevel = IsCorr ? level : DEFAULT_OUTPUT_LEVEL;
            xmlnode.InnerText = ((int)OutputLevel).ToString();
        }

        internal void SetMaxFileSize()
        {
            bool IsCorr = false;
            long bytes = 0;

            try
            {
                bytes = long.Parse(xmlnode.InnerText) * KB_SIZE;
                if (KB_SIZE <= bytes && GB_SIZE >= bytes) 
                    IsCorr = true;
            }
            catch (Exception) { }

            MaxFileSize = IsCorr ? bytes : DEFAULT_MAX_FILE_SIZE;
            xmlnode.InnerText = MaxFileSize.ToString();
        }

        internal void SetPeriod()
        {
            bool IsCorr = false;
            int days = 0;

            try
            {
                days = int.Parse(xmlnode.InnerText);
                if (PERIOD_MIN <= days && PERIOD_MAX >= days)
                    IsCorr = true;
            }
            catch (Exception) { }

            Period = IsCorr ? days : DEFAULT_PERIOD;
            xmlnode.InnerText = Period.ToString();
        }

        internal void SetIsAutoFlush()
        {
            switch (xmlnode.InnerText.ToUpper())
            {
                case "TRUE":
                    IsAutoFlush = true;
                    break;
                case "FALSE":
                    IsAutoFlush = false;
                    break;
                default:
                    IsAutoFlush = DEFAULT_IS_AUTO_FLUSH;
                    break;
            }

            xmlnode.InnerText = IsAutoFlush.ToString().ToUpper();
        }
    }
}
