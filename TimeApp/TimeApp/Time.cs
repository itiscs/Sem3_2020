using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeApp
{
    class Time
    {
        private readonly decimal tick;

        public decimal Tick 
        {
            get => tick;            
        }
         
        public decimal Sec
        {
            get => tick / 18.2m;
        }
        public decimal Min
        {
            get => tick / 18.2m / 60;
        }

        private Time(decimal t)
        {
            tick = t;
        }

        static public Time CreateFromTick(decimal t)
        {
            return new Time(t);
        }

        static public Time CreateFromSec(decimal t)
        {
            return new Time(t * 18.2m);
        }
        static public Time CreateFromMin(decimal t)
        {
            return new Time(t * 60 * 18.2m);
        }

        static public Time operator+(Time t1, Time t2)
        {
            return new Time(t1.Tick + t2.Tick);
        }

        static public Time operator-(Time t1, Time t2)
        {
            return new Time(t1.Tick - t2.Tick);
        }
                                    
        public override string ToString()
        {
            return $"tick-{Tick:0.00}   sec " + 
                $"- {Sec:0.00}  min - {Min:0.00}  ";
        }



    }
}
