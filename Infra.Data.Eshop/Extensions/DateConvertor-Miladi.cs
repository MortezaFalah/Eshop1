using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Eshop.Extensions
{
    public static class DateConvertor_Miladi
    {
        public static string ToMiladi(this DateTime value)
        {
            try
            {
                int year = value.Year;
                int month = value.Month;
                int day = value.Day;

                PersianCalendar pc = new PersianCalendar();
                DateTime newdate = pc.ToDateTime(year, month, day, 0, 0, 0, 0);
                return newdate.ToString();

            }
            catch
            {
                return "تاریخ وارد شده نامعتبر است";
            }
        }
    }
}
