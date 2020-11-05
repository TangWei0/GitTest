using System;
using System.Diagnostics;

using static CommonLib.Common.Common;

namespace Log
{
    public class LogCtrlTraceListener : TraceListener
    {
        private readonly Config Config = null;
        private readonly LogCtrl LogCtrl = null;

        public LogCtrlTraceListener()
        {
            Config = ConfigFactory.Get();
            LogCtrl = LogCtrlFactory.Get();
        }

        public override void Write(string message)
        {
            WriteLine(message);
        }

        /// <summary>
        /// オブジェクトを出力する
        /// </summary>
        /// <param name="ex">例外オブジェクト</param>
        public override void Write(object value)
        {
            WriteLine(value);
        }

        public override void WriteLine(string message)
        {
            WriteLine(message, Config.Category);
        }

        public override void WriteLine(object value)
        {
            WriteLine(value, Config.Category);
        }

        public override void WriteLine(string message, string category)
        {
            // 出力チェック
            if (CheckLevel(category))
                LogCtrl.WriteEntry(message, category);

            // ログ出力かを判断し、True場合ログ出力する
            if (LogCtrl.IsCheckFlush())
                LogCtrl.Flush();
        }

        /// <summary>
        /// オブジェクトを出力する
        /// </summary>
        /// <param name="ex">例外オブジェクト</param>
        public override void WriteLine(object value, string category)
        {
            if (!(value is Exception ex)) return;
            StackTrace st = new StackTrace(true);
            WriteLine(ex.Message + Environment.NewLine + st.ToString(), category);
        }

        /// <summary>
        /// Category⇒E_TRACE_EVENT_LEVELの整数に変更
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        private int CategoryToLevel(string category)
        {
            var level = (int)E_TRACE_EVENT_LEVEL.OFF;
            switch(category)
            {
                case TRACE_CAT_DEBUG:
                    level = (int)E_TRACE_EVENT_LEVEL.Debug;
                    break;
                case TRACE_CAT_INFO:
                    level = (int)E_TRACE_EVENT_LEVEL.Information;
                    break;
                case TRACE_CAT_WARN:
                    level = (int)E_TRACE_EVENT_LEVEL.Warning;
                    break;
                case TRACE_CAT_ERROR:
                    level = (int)E_TRACE_EVENT_LEVEL.Error;
                    break;
                case TRACE_CAT_CRITI:
                    level = (int)E_TRACE_EVENT_LEVEL.Critical;
                    break;
                default:
                    break;
            }

            return level;
        }

        /// <summary>
        /// 出力レベルをチェックする
        /// </summary>
        /// <param name="category"></param>
        /// <returns>True　ログバッファに追加する</returns>
        /// <returns>False　ログバッファに追加しない</returns>
        private bool CheckLevel(string category)
        {
            bool IsCheckLevel = false;

            //　出力レベルがOFF場合、何も出力しない
            if (E_TRACE_EVENT_LEVEL.OFF == Config.OutputLevel)
                return IsCheckLevel;

            //　イベントレベルをチェックする
            var level = CategoryToLevel(category);
            if ((int)Config.OutputLevel <= level)
                IsCheckLevel = true;
            
            return IsCheckLevel;
        }

        /// <summary>
        /// アプリ終了か異常落ちる場合、ログファイルに出力する
        /// </summary>
        public override void Close()
        {
            //　ログファイルに出力
            LogCtrl.Flush();
        }
    }
}
