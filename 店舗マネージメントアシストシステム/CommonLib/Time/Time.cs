using System;

namespace CommonLib.Time
{
    public class Time
    {
        private readonly DateTime StartTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);

        /// <summary>
        /// 現在時間UTCタイムスタンプを取得
        /// </summary>
        /// <returns></returns>
        public long GetUTCTimeStamp ( )
        {
            return (GetUTCTime( ).Ticks - StartTime.Ticks) / TimeSpan.TicksPerMillisecond;
        }

        /// <summary>
        /// 現在時間タイムスタンプを取得
        /// </summary>
        /// <returns></returns>
        public long GetCurrentTimeStamp ( )
        {
            return (GetCurrentTime( ).Ticks - StartTime.Ticks) / TimeSpan.TicksPerMillisecond;
        }

        /// <summary>
        /// 現在時間UTCを取得
        /// </summary>
        /// <returns></returns>
        public DateTime GetUTCTime ( )
        {
            return DateTime.UtcNow;
        }

        /// <summary>
        /// 現在時間を取得
        /// </summary>
        /// <returns></returns>
        public DateTime GetCurrentTime ( )
        {
            return DateTime.Now;
        }

        public string SetTimeContext (DateTime dateTime)
        {
            return "";
        }
    }
}
