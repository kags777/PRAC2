using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAC2
{
    class Calzone : Pizza
    {
        public int Calories { get; set; }
        public Calzone( string name, int mass, int slices, int calories) : base(name, mass, slices)
        {
            Calories = calories;
        }


    }
}
