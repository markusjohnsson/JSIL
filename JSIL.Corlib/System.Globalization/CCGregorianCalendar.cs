using System;

namespace System.Globalization
{
    public class CCFixed
    {
        public static int FromDateTime(DateTime time)
        {
            return 1 + (int)(time.Ticks / 864000000000L);
        }

        public static DateTime ToDateTime(int date)
        {
            return new DateTime((date - 1) * 864000000000L);
        }

        public static DayOfWeek day_of_week(int date)
        {
            return (DayOfWeek)CCMath.mod(date, 7);
        }

        public static DateTime ToDateTime(int date, int hour, int minute, int second, double milliseconds)
        {
            DateTime dateTime = CCFixed.ToDateTime(date);
            dateTime = dateTime.AddHours((double)hour);
            dateTime = dateTime.AddMinutes((double)minute);
            dateTime = dateTime.AddSeconds((double)second);
            return dateTime.AddMilliseconds(milliseconds);
        }
    }

    public class CCMath
    {
        public static int div(int x, int y)
        {
            return (int)Math.Floor((double)x / (double)y);
        }

        public static int mod(int x, int y)
        {
            return x - y * CCMath.div(x, y);
        }

        public static int div_mod(out int remainder, int x, int y)
        {
            int i = CCMath.div(x, y);
            remainder = x - y * i;
            return i;
        }
    }

    public class CCGregorianCalendar
    {
        public static DateTime AddMonths(DateTime time, int months)
        {
            int i = CCFixed.FromDateTime(time);
            int j;
            int k;
            int l;
            CCGregorianCalendar.dmy_from_fixed(out j, out k, out l, i);
            k += months;
            l += CCMath.div_mod(out k, k, 12);
            int daysInMonth = CCGregorianCalendar.GetDaysInMonth(l, k);
            if (j > daysInMonth)
            {
                j = daysInMonth;
            }
            DateTime dateTime = CCFixed.ToDateTime(CCGregorianCalendar.fixed_from_dmy(j, k, l));
            return dateTime.Add(time.TimeOfDay);
        }

        public static int GetDaysInMonth(int year, int month)
        {
            int i = CCGregorianCalendar.fixed_from_dmy(1, month, year);
            return CCGregorianCalendar.fixed_from_dmy(1, month + 1, year) - i;
        }
        
        public static int GetDayOfMonth(DateTime time)
        {
            return CCGregorianCalendar.day_from_fixed(CCFixed.FromDateTime(time));
        }

        public static int day_from_fixed(int date)
        {
            int i;
            int j;
            int k;
            CCGregorianCalendar.dmy_from_fixed(out i, out j, out k, date);
            return i;
        }

        public static void dmy_from_fixed(out int day, out int month, out int year, int date)
        {
            CCGregorianCalendar.my_from_fixed(out month, out year, date);
            day = date - CCGregorianCalendar.fixed_from_dmy(1, month, year) + 1;
        }

        public static void my_from_fixed(out int month, out int year, int date)
        {
            year = CCGregorianCalendar.year_from_fixed(date);
            int i = date - CCGregorianCalendar.fixed_from_dmy(1, 1, year);
            int j = (date >= CCGregorianCalendar.fixed_from_dmy(1, 3, year)) ? ((!CCGregorianCalendar.is_leap_year(year)) ? 2 : 1) : 0;
            month = CCMath.div(12 * (i + j) + 373, 367);
        }

        public static int fixed_from_dmy(int day, int month, int year)
        {
            int i = 0;
            i += 365 * (year - 1);
            i += CCMath.div(year - 1, 4);
            i -= CCMath.div(year - 1, 100);
            i += CCMath.div(year - 1, 400);
            i += CCMath.div(367 * month - 362, 12);
            if (month > 2)
            {
                int arg_69_0 = i;
                int arg_69_1 = (!CCGregorianCalendar.is_leap_year(year)) ? -2 : -1;
                i = arg_69_0 + arg_69_1;
            }
            i += day;
            return i;
        }

        public static bool is_leap_year(int year)
        {
            if (CCMath.mod(year, 4) != 0)
            {
                return false;
            }
            int i = CCMath.mod(year, 400);
            if (i == 100)
            {
                return false;
            }
            if (i == 200)
            {
                return false;
            }
            if (i == 300)
            {
                return false;
            }
            return true;
        }

        public static int year_from_fixed(int date)
        {
            int i = date - 1;
            int j = CCMath.div_mod(out i, i, 146097);
            int k = CCMath.div_mod(out i, i, 36524);
            int l = CCMath.div_mod(out i, i, 1461);
            int m = CCMath.div(i, 365);
            int n = 400 * j + 100 * k + 4 * l + m;
            int arg_6A_0;
            if (k != 4 && m != 4)
            {
                arg_6A_0 = n + 1;
            }
            else
            {
                arg_6A_0 = n;
            }
            return arg_6A_0;
        }

        public static DateTime AddYears(DateTime time, int years)
        {
            int i = CCFixed.FromDateTime(time);
            int j;
            int k;
            int l;
            CCGregorianCalendar.dmy_from_fixed(out j, out k, out l, i);
            l += years;
            int daysInMonth = CCGregorianCalendar.GetDaysInMonth(l, k);
            if (j > daysInMonth)
            {
                j = daysInMonth;
            }
            DateTime dateTime = CCFixed.ToDateTime(CCGregorianCalendar.fixed_from_dmy(j, k, l));
            return dateTime.Add(time.TimeOfDay);
        }
        
        public static int GetDayOfYear(DateTime time)
        {
            int i = CCFixed.FromDateTime(time);
            int j = CCGregorianCalendar.year_from_fixed(i);
            return i - CCGregorianCalendar.fixed_from_dmy(1, 1, j) + 1;
        }

        public static int GetDaysInYear(int year)
        {
            int i = CCGregorianCalendar.fixed_from_dmy(1, 1, year);
            return CCGregorianCalendar.fixed_from_dmy(1, 1, year + 1) - i;
        }

        public static int GetMonth(DateTime time)
        {
            return CCGregorianCalendar.month_from_fixed(CCFixed.FromDateTime(time));
        }

        public static int month_from_fixed(int date)
        {
            int i;
            int j;
            CCGregorianCalendar.my_from_fixed(out i, out j, date);
            return i;
        }

        public static int GetYear(DateTime time)
        {
            return CCGregorianCalendar.year_from_fixed(CCFixed.FromDateTime(time));
        }

        public static bool IsLeapDay(int year, int month, int day)
        {
            bool arg_1A_0;
            if (!CCGregorianCalendar.is_leap_year(year) || month != 2)
            {
                arg_1A_0 = false;
            }
            else
            {
                arg_1A_0 = (day == 29);
            }
            return arg_1A_0;
        }
        
        public static DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int milliseconds)
        {
            return CCFixed.ToDateTime(CCGregorianCalendar.fixed_from_dmy(day, month, year), hour, minute, second, (double)milliseconds);
        }
        
        public static DayOfWeek GetDayOfWeek(DateTime time)
        {
            int rd = CCFixed.FromDateTime(time);
            return (DayOfWeek)CCFixed.day_of_week(rd);
        }
    }
}
