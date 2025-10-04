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
        public string Pineapple { get; set; }

        public Calzone( string name, int mass, int slices, int calories, string pineapple) : base(name, mass, slices)
        {
            Calories = calories;
            Pineapple = pineapple;
        }

        public override string ToString()
        {
            return $"{Name} — {Mass}г, {Slices} кусков, {Calories} ккал, ананасы: {Pineapple}" ;
        }
    }
}
