using System.Collections.Generic;
using System.IO;
using System.Xml;
using static Log.Constant;

namespace Log.Tests
{
    public class ConfigBase
    {
        private readonly string Path;

        public ConfigBase(string path)
        {
            Path = path;
        }

        public Dictionary<string, string> DefalutNodeList = new Dictionary<string, string>()
        {
            { NODE_LOG_FILE_PATH, DEFAULT_LOG_FILE_PATH },
            { NODE_IS_APPEND, DEFAULT_IS_APPEND.ToString().ToUpper() },
            { NODE_CATEGORY, DEFAULT_CATEGORY },
            { NODE_OUTPUT_LEVEL, ((int)DEFAULT_OUTPUT_LEVEL).ToString() },
            { NODE_MAX_FILE_SIZE, DEFAULT_MAX_FILE_SIZE.ToString() },
            { NODE_PERIOD, DEFAULT_PERIOD.ToString() },
            { NODE_IS_AUTO_FLUSH, DEFAULT_IS_AUTO_FLUSH.ToString().ToUpper() },
        };

        public void CreatTestXml(Dictionary<string, string> nodeList)
        {
            DelectTestXml();

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

        public void DelectTestXml()
        {
            if (File.Exists(Path))
                File.Delete(Path);
        }
    }
}
