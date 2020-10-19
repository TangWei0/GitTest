using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log
{
    public static class ConfigFactory
    {
        /// <summary> ログ </summary>
        private static Config config = null;

        /// <summary>
        /// インスタンスを生成する
        /// </summary>
        public static Config GetInstance()
        {
            if (config == null)
                config = new Config();
            return config;
        }
    }
}
