using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PRAC2
{
    class Pizza : Food
    {
        public static int a = 0;//вспомогательная переменная
        public int b = 0;//вспомогательная переменная
        public static int v = 1;//вспомогательная переменная
        public int MoreSlices;// сколько кусков будет доп нарезано
        public int quantity;//количество кусков, которое будет съедено
        public int PizzaCount;//количество пицц, которые надо испечь
        public static int Reminder;//нужны ли ананасы
        public int Slices { get; set; }
        public Pizza(string name, int mass, int slices) : base(name,mass)
        {
            Slices = slices;
        }

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
        public static void PineappleReminder()
        {
            do
            {
                do
                {
                    Console.WriteLine("Не желаете ли добавить анансы в пиццу?  1 - Добавить ананасы.  2 - Не добавлять ананасы.");
                    string A = Console.ReadLine();
                    if (int.TryParse(A, out Reminder))
                    {
                        a = 1;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: это не число!");
                    }
                } while (a != 1);

                switch (Reminder)
                {

                    case 1:
                        Console.WriteLine("В пиццу добавлены ананасы!");
                        v = 1;
                        break;
                    case 2:
                        Console.WriteLine("В пиццу не добавлены ананасы!");
                        v = 1;
                        break;
                    default:
                        Console.WriteLine("Вы ввели некорректный вариант ответа!");
                        v = 0;
                        break;
                }
            } while (v != 1);
        }
    }
}
