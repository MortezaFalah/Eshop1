using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Eshop.Generators
{
    public class CodeGenerator
    {

        public static string RndGenerate()
        {
            Random random = new Random();

            int rnd = random.Next(100_000,999999);

            return rnd.ToString();
        }
       
        
    }
}
