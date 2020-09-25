using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equation
{

    
    class Program
    {
        static void Main(string[] args)
        {
            Equation eq = Equation.CreateEquation(1, 0, -5);

            Console.WriteLine(eq);
            eq.Solve();
            eq.Solution();

        }
    }
}
