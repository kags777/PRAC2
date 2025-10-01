using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PRAC2
{
    internal class Param
    {
        enum PizzaSize
        {
            Small,
            Medium,
            Large,
            ExtraLarge
        }

        struct Weight
        {
            private string Mass;

            public string GetMass()
            {
                return Mass;
            }

        }
    }
}
