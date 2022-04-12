using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_framwork.Infrastructure
{
    public static class Convertor
    {
        public static DateTime ToShamsi(this DateTime date)
        {
            PersianCalendar pc = new PersianCalendar();
            var datetime = new DateTime(pc.GetYear(date), pc.GetMonth(date), pc.GetDayOfMonth(date));
            return datetime;
        }
    }
}
