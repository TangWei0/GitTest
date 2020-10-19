namespace Log
{
    public static class LogCtrlFactory
    {
        /// <summary> ログ </summary>
        private static LogCtrl logCtrl = null;

        /// <summary>
        /// インスタンスを生成する
        /// </summary>
        public static LogCtrl GetInstance()
        {
            if (logCtrl == null)
                logCtrl = new LogCtrl();
            return logCtrl;
        }
    }
}
