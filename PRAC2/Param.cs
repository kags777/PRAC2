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

        public class MyNumber
        {
            public int Value;

            public MyNumber(int value)
            {
                Value = value;
            }

            // "Перегрузка присваивания" через конструктор копирования
            public MyNumber(MyNumber other)
            {
                Value = other.Value;
            }

            // Перегрузка арифметической операции +
            public static MyNumber operator +(MyNumber a, MyNumber b)
            {
                return new MyNumber(a.Value + b.Value);
            }

            public override string ToString()
            {
                return Value.ToString();
            }
        }

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

        public static void ChoosePizzaSize(List<Pizza> pizzaList, int index)
        {
            Param.PizzaSize size;
            int quantity;

            while (true)
            {
                Console.WriteLine("Введите размер пиццы (small,medium,large,extraLarge):");
                string input = Console.ReadLine();

                if (Enum.TryParse(input, true, out size) && int.TryParse(input, out quantity) == false)
                {
                    Console.WriteLine($"Вы выбрали размер: {size}");

                    if (size == Param.PizzaSize.medium)
                    {
                        pizzaList[index].Slices += 2;
                        pizzaList[index].Calories += 100;
                        pizzaList[index].Mass += 100;
                    }
                    else if (size == Param.PizzaSize.large)
                    {
                        pizzaList[index].Slices += 4;
                        pizzaList[index].Calories += 200;
                        pizzaList[index].Mass += 200;
                    }
                    else if (size == Param.PizzaSize.extraLarge)
                    {
                        pizzaList[index].Slices += 6;
                        pizzaList[index].Calories += 300;
                        pizzaList[index].Mass += 300;
                    }

                    break;
                }
                else
                {
                    Console.WriteLine("Ошибка: такого размера нет! Попробуйте снова.");
                }
            }
        }

    }
}
   