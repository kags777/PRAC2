using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAC2
{
    class Food
    {
        private string Mass { get};
        private string Name { get};


        public Food(string mass, string name)
        {
            Mass = mass;
            Name = name;
        }

        public void Deconstruct(string mass, string name)
        {
            mass = Mass;
            name = Name;
        }


    }
