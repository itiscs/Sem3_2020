using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AppRegexp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Regex reg = new Regex(@"(\d{1,2}[./]\d{1,2}[./](\d{4}|\d{2}))");
            Regex reg = new
                Regex(@"(^[1-9]{1}$|^[1-4]{1}[0-9]{1}$|^50$)");
            
            String str = "50";

            Console.WriteLine(reg.IsMatch(str));

            foreach (var m in reg.Matches(str))
                Console.WriteLine(m);

            




        }
    }
}
