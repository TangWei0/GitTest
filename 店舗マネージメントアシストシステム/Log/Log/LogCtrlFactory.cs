namespace Log
{
    public static class LogCtrlFactory
    {
        /// <summary> ログ </summary>
        internal static LogCtrl logCtrl = null;

        /// <summary>
        /// インスタンスを生成する
        /// </summary>
        public static LogCtrl GetInstance()
        {
            if (logCtrl == null)
                logCtrl = new LogCtrl();
                logCtrl.Init();
            return logCtrl;
        }
    }
}
