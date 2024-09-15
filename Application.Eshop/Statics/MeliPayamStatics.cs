using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Eshop.Statics
{
    public class MeliPayamStatics
    {

        //[JsonPropertyName("ApiKey")]
        public static string  ApiKey { get; set; }

        //[JsonPropertyName("Sender")]
        public static string Sender { get; set; }
    }
}
