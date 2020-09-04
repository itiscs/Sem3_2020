using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Time t1, t2, t3;
            t1 = Time.CreateFromTick(100);
            t2 = Time.CreateFromSec(100);
            t3 = Time.CreateFromMin(100);
            Console.WriteLine(t1);
            Console.WriteLine(t2);
            Console.WriteLine(t3);

            Console.WriteLine(t1 + t2);
            Console.WriteLine(t3 - t2);
            Console.WriteLine(t1 - t2);




        }
    }
}
