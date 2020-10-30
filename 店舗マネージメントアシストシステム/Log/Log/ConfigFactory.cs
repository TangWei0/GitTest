namespace Log
{
    public static class ConfigFactory
    {
        /// <summary> ログ </summary>
        internal static Config Config { get; set; } = new Config();

        internal static bool InitFlag = false;

        public static Config Get()
        {
            if (!InitFlag)
            { 
                Config.Init();
                InitFlag = true;
            }
            return Config;
        }
    }
}
