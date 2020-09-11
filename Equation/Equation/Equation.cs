using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equation
{

    //ax^2+bx+c=0

    public class Equation
    {
        protected int countSol;

        public virtual void Solve()
        {
            Console.WriteLine("Решаем уравнение...");
        }

        public virtual void Solution()
        {
            Console.WriteLine("Решение уравнения - ...");
        }

        public static Equation CreateEquation(params int[] par )
        {
            if (par[0] == 0 && par.Length>1)
            {
                return CreateEquation(par.Skip(1).ToArray());
            }
            switch(par.Length)
            {
                case 1:
                    return new Equation0(par[0]);
                case 2:
                    return new Equation1(par[0], par[1]);
                case 3:
                    return new Equation2(par[0], par[1], par[2]);
                default:
                    throw new ArgumentOutOfRangeException(
                        "неправильное количество параметров");
            }


        }



    }

    public class Equation0:Equation
    {
        protected int c;
        
        public Equation0(int _c)
        {
            c = _c;
        }

        public override void Solve()
        {
            if (c != 0)
                countSol = 0;
            else
                countSol = int.MaxValue;
        }

        public override void Solution()
        {
            if (countSol == 0)
                Console.WriteLine("Решений нет");
            else
                Console.WriteLine("x - вся числовая ось");
        }

        public override string ToString()
        {
            return $"{c} = 0";
        }
    }
    public class Equation1 : Equation0
    {
        protected int b;

        protected double x1;

        public Equation1(int _b, int _c):base(_c)
        {
            b = _b;
        }

        public override void Solve()
        {
            countSol = 1;
            x1 = Convert.ToDouble(-c) / b;
        }

        public override void Solution()
        {
            Console.WriteLine($"x = {x1:0.000}");
        }

        public override string ToString()
        {
            return $"{b}*x + {c} = 0";
        }
    }

    public class Equation2 : Equation1
    {
        protected int a;

        protected double x2;

        public Equation2(int _a, int _b, int _c) : 
            base(_b,_c)
        {
            a = _a;
            
        }

        public override void Solve()
        {
            var d = b * b - 4 * a * c;
            if (d < 0)
                countSol = 0;
            else
            {
                countSol = 2;
                x1 = (Convert.ToDouble(-b) + Math.Sqrt(d)) / (2*a);
                x2 = (Convert.ToDouble(-b) - Math.Sqrt(d)) / (2*a);

            }
        }

        public override void Solution()
        {
            if(countSol==0)
                Console.WriteLine("Вещественных решений нет");
            else
                Console.WriteLine($"x1 = {x1:0.000}\n" +
                    $"x2 = {x2:0.000} ");
        }

        public override string ToString()
        {
            return $"{a}*x^2 + {b}*x + {c} = 0";
        }
    }








}
