using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Eshop.Extentions
{
    public static class DateConvertor
    {
        public static string ToShamsiWithday(this DateTime date)
        {
            var calendar = new PersianCalendar();
            var persianDate = new DateTime(calendar.GetYear(date), calendar.GetMonth(date), calendar.GetDayOfMonth(date));
            string result = persianDate.ToString("yyyy MMM ddd", CultureInfo.GetCultureInfo("fa-Ir"));
            return result;
        }



        //public static string ToShamsi(this DateTime value)
        //{
        //    PersianCalendar persian = new PersianCalendar();
        //    return persian.GetYear(value) + "/" + persian.GetMonth(value).ToString("00")
        //        + "/" + persian.GetDayOfMonth(value).ToString("00");
        //}
        //متد روبا try catch جی پی تی لطف کرد برام نوشت
        public static string ToShamsi(this DateTime value)
        {
            try
            {
                PersianCalendar persian = new PersianCalendar();
                return persian.GetYear(value) + "/" + persian.GetMonth(value).ToString("00")
                    + "/" + persian.GetDayOfMonth(value).ToString("00");
            }
            catch (ArgumentOutOfRangeException)
            {
                // در صورت بروز خطا، می‌توانید یک رشته خالی یا پیام خطا برگردانید  
                return "تاریخ نامعتبر است";
            }
            catch (Exception ex)
            {
                // در صورت بروز هر خطای دیگری، می‌توانید آن را ثبت کنید یا پیام مناسب برگردانید  
                return $"خطا: {ex.Message}";
            }


        }
    }
}
