using PRAC2;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PRAC2
{
    internal class Param
    {
       

        public enum PizzaSize
        {
            small,
            medium,
            large,
            extraLarge
        }

        struct Weight
        {
            public int Mass;

            public int GetMass()
            {
                return Mass;
            }
        }

        public static bool TryParseNumber(string input, out int result)
        {
            if (int.TryParse(input, out result))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Ошибка: это не число!");
                return false;
            }
        }

    }
}
