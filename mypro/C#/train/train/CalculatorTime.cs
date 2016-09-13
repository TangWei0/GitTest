using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace train
{
    public class CalculatorTime
    {
        public DateTime StationUpdateTime(DateTime dateTime)
        {
            DateTime stationUpdate = new DateTime();

            if (dateTime.Minute < 50)
            {
                stationUpdate = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, (dateTime.Month / 10 + 1) * 10, 0);
            }
            else
            {
                if (dateTime.Hour < 23)
                {
                    stationUpdate = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour + 1, 0, 0);
                }
                else
                {
                    if (checkTime(dateTime) == false)
                    {
                        stationUpdate = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day + 1, 0, 0, 0);
                    }
                    else
                    {
                        if (dateTime.Month != 12)
                        {
                            stationUpdate = new DateTime(dateTime.Year, dateTime.Month + 1, 1, 0, 0, 0);
                        }
                        else
                        {
                            stationUpdate = new DateTime(dateTime.Year + 1, 1, 1, 0, 0, 0);
                        }
                    }
                }
            }

            return stationUpdate;
        }

        public int diffTime(DateTime closeTime, DateTime nowTime)
        {
            int diff = 0;
            TimeSpan span = new TimeSpan();
            span = nowTime - closeTime;
            diff = span.Days * 144 + span.Hours * 6 + span.Minutes / 10;
            return diff;
        }

        public int countdownTime(DateTime nowTime, DateTime nowTimeNextUpdateTime)
        {
            int countTime = 0;
            TimeSpan span = new TimeSpan();
            span = nowTimeNextUpdateTime - nowTime;
            countTime = span.Minutes * 60000 + span.Seconds * 1000;
            return countTime;
        }

        /// <summary>
        /// 判断时间条件
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private bool checkTime(DateTime dateTime)
        {
            bool check = false;

            if (dateTime.Month == 1 && dateTime.Day == 31)
            {
                check = true;
            }

            if (dateTime.Month == 3 && dateTime.Day == 31)
            {
                check = true;
            }

            if (dateTime.Month == 5 && dateTime.Day == 31)
            {
                check = true;
            }

            if (dateTime.Month == 7 && dateTime.Day == 31)
            {
                check = true;
            }

            if (dateTime.Month == 8 && dateTime.Day == 31)
            {
                check = true;
            }

            if (dateTime.Month == 10 && dateTime.Day == 31)
            {
                check = true;
            }

            if (dateTime.Month == 12 && dateTime.Day == 31)
            {
                check = true;
            }

            if (dateTime.Month == 4 && dateTime.Day == 30)
            {
                check = true;
            }

            if (dateTime.Month == 6 && dateTime.Day == 30)
            {
                check = true;
            }

            if (dateTime.Month == 9 && dateTime.Day == 30)
            {
                check = true;
            }

            if (dateTime.Month == 11 && dateTime.Day == 30)
            {
                check = true;
            }

            if (dateTime.Year % 4 == 0)
            {
                if (dateTime.Month == 2 && dateTime.Day == 29)
                {
                    check = true;
                }
            }
            else
            {
                if (dateTime.Month == 2 && dateTime.Day == 28)
                {
                    check = true;
                }
            }

            return check;
        }
    }
}
