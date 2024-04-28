using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeanerProject.DAL
{
    public static class TimeCalculator
    {
        public static string getTime (string date)
        {
            DateTime nowDate = Convert.ToDateTime(DateTime.Now.ToString("g"));
            DateTime MessageDate = Convert.ToDateTime(date);

            TimeSpan times = nowDate - MessageDate;
            string time = "";
            if (times.TotalMinutes < 60)
            {
                if (times.TotalMinutes == 0)
                {
                    time = "Şimdi";
                }
                else
                {
                    time = $"{(int)times.TotalMinutes} dakika önce";

                }
            }
            else if (times.TotalHours < 24)
            {
                time = $"{(int)times.TotalHours} saat önce";
            }
            else if (times.TotalDays < 30)
            {
                time = $"{(int)times.TotalDays} gün önce";
            }
            else if (times.TotalDays < 365)
            {
                int MonthSpan = (int)(times.TotalDays / 30);
                time = $"{MonthSpan} ay önce";
            }
            else
            {
                int YearSpan = DateTime.Now.Year - MessageDate.Year;
                time = $"{YearSpan} yıl önce";
            }
            return time;
        }
    
}
}