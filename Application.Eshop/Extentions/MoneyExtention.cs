using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Eshop.Extentions
{
    public static class MoneyExtention
    {

        public static string ToMoney(this int money)
        {
            return money.ToString("#,0");
        }
    }
}
