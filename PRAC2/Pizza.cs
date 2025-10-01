using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAC2
{
    class Pizza : Food
    {
        private int Slices;

        public int a = 0;//вспомогательная переменная
        public int MoreSlices;// сколько кусков будет доп нарезано
        public int quantity;//количество кусков, которое будет съедено
        public int PizzaCount;//количество пицц, которые надо испечь

        public void Eat()
        {


            do
            {
                Console.WriteLine("Введите количество кусков которое вы хотите съесть:");
                string quantityStr = Console.ReadLine();

                if (int.TryParse(quantityStr, out quantity))
                {
                    a = 1;
                }
                else
                {
                    Console.WriteLine("Ошибка: это не число!");
                }
            } while (a != 1);

            for (int i = 0; i < quantity; i++)
            {
                Slices--;
            }
            Console.WriteLine($"Съедено: {quantity}. Осталось:{Slices}");
        }

        public void Cut()
        {
            Console.WriteLine("Введите количество кусков на которое вы хотите дополнительно порезать пиццу:");
            string MoreSlicesStr = Console.ReadLine();

            do
            {

                if (int.TryParse(MoreSlicesStr, out MoreSlices))
                {
                    a = 1;
                }
                else
                {
                    Console.WriteLine("Ошибка: это не число!");
                }
            } while (a != 1);

            do
            {
                if (MoreSlices == 0)
                {
                    a = 0;
                    Console.WriteLine("Ошибка! вы не нарезали ни одного куска.");
                }
            } while (a == 0);

            Slices += MoreSlices;
            Console.WriteLine($"Стало{Slices} куск(а)ов");

        }

        public void Bake()
        {

            do
            {
            do
            {
                Console.WriteLine("Введите количество пицц, которое вы хотите испечь:");
                string pizzaCount = Console.ReadLine();

                if (int.TryParse(pizzaCount, out PizzaCount))
                {
                    a = 1;
                }
                else
                {
                    Console.WriteLine("Ошибка: это не число!");
                }
            } while (a != 1);

            
                if (MoreSlices == 0)
                {
                    a = 0;
                    Console.WriteLine("Ошибка! Вы не испекли ни одной пиццы.");
                }
            } while (a == 0);

            Console.WriteLine($"Испечено: {PizzaCount} шт");
        }

        /*НАПОМИНАНИЕ ПРО АНАНАСЫ*/
        public void PineappleReminder()
        {


            do
            {
                Console.WriteLine("Не желаете ли добавить анансы в пиццу?  1 - Добавить ананасы.  2 - Не добавлять ананасы.");
                string A = Console.ReadLine();
                if (int.TryParse(A, out a))
                {
                    a = 1;
                }
                else
                {
                    Console.WriteLine("Ошибка: это не число!");
                }
            } while (a != 1);

            do
            {
                if (MoreSlices == 0)
                {
                    a = 0;
                    Console.WriteLine("Ошибка! Вы не испекли ни одной пиццы.");
                }
            } while (a == 0);
            Console.WriteLine($"Испечено: {PizzaCount} шт");
            if 1
        }















    }
}
