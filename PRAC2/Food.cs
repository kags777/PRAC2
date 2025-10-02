using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAC2
{
    class Food
    {
        public string Name { get; set; }
        public int Mass { get; set; }
        
        public Food(string name, int mass)
        {
            Name = name;
            Mass = mass;
        }

        public void Deconstruct(out string name, out int mass)
        {
            name = Name;
            mass = Mass;
        }
    }
}
