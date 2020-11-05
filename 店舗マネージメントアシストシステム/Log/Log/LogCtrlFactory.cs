namespace Log
{
    public static class LogCtrlFactory
    {
        /// <summary> ログ </summary>
        internal static LogCtrl LogCtrl { get; set; } = new LogCtrl();

        internal static bool InitFlag = false;

        public static LogCtrl Get()
        {
            if (!InitFlag)
            { 
                LogCtrl.Init();
                InitFlag = true;
            }
            return LogCtrl;
        }
    }
}
