using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace train
{
    public class CalculatorTime
    {
        public Array StationUpdateTimeArray(DateTime closeTime)
        {
            int[] stationUpdateTimeArray = new int[2];
            DateTime closeTimeNextUpdateTime = new DateTime();
            DateTime nowTimeNextUpdateTime = new DateTime();

            closeTimeNextUpdateTime = StationUpdateTime(closeTime);
            nowTimeNextUpdateTime = StationUpdateTime(DateTime.Now);

            stationUpdateTimeArray[0] = countdownTime(DateTime.Now, nowTimeNextUpdateTime);

            if (closeTimeNextUpdateTime != nowTimeNextUpdateTime)
            {
                stationUpdateTimeArray[1] = UpdateTimes(DateTime.Now, nowTimeNextUpdateTime);
            }
            else
            {
                stationUpdateTimeArray[1] = 0;
            }

            return stationUpdateTimeArray;
        }

        public int StoreUpdateTime(DateTime storeTime)
        {
            int storeUpdateTime = 300000;
            if (DateTime.Now <= storeTime)
            {
                storeUpdateTime = ((storeTime - DateTime.Now).Minutes * 60 + (storeTime - DateTime.Now).Seconds) * 1000;
            }
            return storeUpdateTime;
        }

        private DateTime StationUpdateTime(DateTime dateTime)
        {
            DateTime stationUpdateTime = new DateTime();

            if (dateTime.Minute < 50)
            {
                stationUpdateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, (dateTime.Minute / 10 + 1) * 10, 0);
            }
            else
            {
                if (dateTime.Hour < 23)
                {
                    stationUpdateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour + 1, 0, 0);
                }
                else
                {
                    if (checkTime(dateTime) == false)
                    {
                        stationUpdateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day + 1, 0, 0, 0);
                    }
                    else
                    {
                        if (dateTime.Month != 12)
                        {
                            stationUpdateTime = new DateTime(dateTime.Year, dateTime.Month + 1, 1, 0, 0, 0);
                        }
                        else
                        {
                            stationUpdateTime = new DateTime(dateTime.Year + 1, 1, 1, 0, 0, 0);
                        }
                    }
                }
            }
            return stationUpdateTime;
        }

        private int UpdateTimes(DateTime closeTime, DateTime nowTime)
        {
            int updateTimes = 0;
            TimeSpan span = new TimeSpan();
            span = nowTime - closeTime;
            updateTimes = span.Days * 144 + span.Hours * 6 + span.Minutes / 10;
            return updateTimes;
        }

        private int countdownTime(DateTime nowTime, DateTime nowTimeNextUpdateTime)
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
