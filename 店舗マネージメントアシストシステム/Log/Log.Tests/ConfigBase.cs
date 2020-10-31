using System.Collections.Generic;
using System.IO;
using System.Xml;
using static Log.Constant;

namespace Log.Tests
{
    public class ConfigBase
    {
        protected string expectedLogFilePath = @"C:\Log\";
        protected bool expectedIsAppend = false;
        protected string expectedCategory = "Error";
        protected E_TRACE_EVENT_LEVEL expectedOutputLevel = E_TRACE_EVENT_LEVEL.Critical;
        protected long expectedMaxFileSize = 100 * KB_SIZE;
        protected int expectedPeriod = 30;
        protected bool expectedIsAutoFlush = true;

        private readonly string Path;


        public ConfigBase(string path)
        {
            Path = path;
        }

        public static Dictionary<string, string> DefalutNodeList { get; set; } = 
            new Dictionary<string, string>()
        {
            { NODE_LOG_FILE_PATH, @"C:\Log\" },
            { NODE_IS_APPEND, "FALSE" },
            { NODE_CATEGORY, "Error" },
            { NODE_OUTPUT_LEVEL, "5" },
            { NODE_MAX_FILE_SIZE, "100" },
            { NODE_PERIOD, "30" },
            { NODE_IS_AUTO_FLUSH, "TRUE" },
        };
        
        public void CreatTestXml()
        {
            DeleteTestXml();

            var xmldoc = new XmlDocument();
            var xmldecl = xmldoc.CreateXmlDeclaration("1.0", "utf-8", null);
            xmldoc.AppendChild(xmldecl);
            var xmlelem = xmldoc.CreateElement("Test");
            xmldoc.AppendChild(xmlelem);
            xmldoc.Save(Path);
        }
        
        public void CreatTestRootXml()
        {
            DeleteTestXml();

            var xmldoc = new XmlDocument();
            var xmldecl = xmldoc.CreateXmlDeclaration("1.0", "utf-8", null);
            xmldoc.AppendChild(xmldecl);
            var xmlelem = xmldoc.CreateElement(ROOT_NAME);
            xmldoc.AppendChild(xmlelem);

            xmldoc.Save(Path);
        }

        public void CreatTestXml(Dictionary<string, string> nodeList)
        {
            DeleteTestXml();

            var xmldoc = new XmlDocument();
            var xmldecl = xmldoc.CreateXmlDeclaration("1.0", "utf-8", null);
            xmldoc.AppendChild(xmldecl);
            var xmlelem = xmldoc.CreateElement(ROOT_NAME);
            xmldoc.AppendChild(xmlelem);
            var xmlroot = xmldoc.SelectSingleNode(ROOT_NAME);

            foreach (var node in nodeList)
            {
                var subNode = xmldoc.CreateElement(node.Key);
                subNode.InnerText = node.Value;
                xmlroot.AppendChild(subNode);
            }
            
            xmldoc.Save(Path);            
        }

        public Config ReadTestXmlTitle()
        {
            Config config = new Config
            {
                xmldoc = new XmlDocument()
            };

            return config;
        }

        public Config ReadTestXmlRoot()
        {
            Config config = new Config
            {
                xmldoc = new XmlDocument()
            };
            config.xmldoc.Load(Path);
            config.xmlroot = config.xmldoc.SelectSingleNode(ROOT_NAME);

            return config;
        }

        public Config ReadTestXmlNode(string node)
        {
            Config config = new Config
            {
                xmldoc = new XmlDocument()
            };
            config.xmldoc.Load(Path);
            config.xmlroot = config.xmldoc.SelectSingleNode(ROOT_NAME);
            config.xmlnode = config.xmlroot.SelectSingleNode(node);

            return config;
        }

        public void DeleteTestXml()
        {
            if (File.Exists(Path))
                File.Delete(Path);
        }
    }
}
