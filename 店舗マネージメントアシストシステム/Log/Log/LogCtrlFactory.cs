namespace Log
{
    public static class LogCtrlFactory
    {
        /// <summary> ログ </summary>
        private static LogCtrl LogCtrl { get; set; } = new LogCtrl();

        private static bool InitFlag = false;

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
