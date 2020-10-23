namespace Log
{
    public static class ConfigFactory
    {
        /// <summary> ログ </summary>
        internal static Config config = null;

        /// <summary>
        /// インスタンスを生成する
        /// </summary>
        public static Config GetInstance()
        {
            if (config == null)
                config = new Config();
                config.ReadConfig();
            return config;
        }
    }
}
