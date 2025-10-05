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
        public  const int MAXCUTSLICES = 10;
        public int Slices { get; set; }
        public int WeightToSize { get; set; }

        public Pizza()
        {
            Name = "";
            Mass = 0;
            Slices = 0;
            Calories = 0;
            Pineapple = "";
        }
        public Pizza(string name, int mass, int slices, int calories, string pineapple) : base(name, mass)
        {
            Slices = slices;
            Calories = calories;
            Pineapple = pineapple;
        }

        public override string ToString()//Перегруж метод ToString
        {
            return $"{Name} — {Mass}г, {Slices} кусков, {Calories} ккал, ананасы: {Pineapple}";
        }

        public static void Eat(int a)
        {
            Console.WriteLine($"Вы съели позицию {a}");
        }

        public void Cut()
        {
            do
            {
                Console.WriteLine("\nВведите количество кусков на которое вы хотите дополнительно порезать пиццу:");
                string MoreSlicesStr = Console.ReadLine();

                if (int.TryParse(MoreSlicesStr, out MoreSlices) && (MoreSlices <= MAXCUTSLICES))
                {
                    a = 1;
                }
                else
                {
                    Console.WriteLine("Ошибка! Введите число!");
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
            Console.WriteLine($"Стало {Slices} куск(а)ов");

        }

        public static void Bake(string pizza)
        {
            Console.WriteLine("Заказ готовится...");
            Thread.Sleep(3000); // пауза
            Console.WriteLine($"Позиция {pizza}  готова!");
        }

        /*НАПОМИНАНИЕ ПРО АНАНАСЫ*/
        public static int PineappleReminder()
        {
            do
            {
                do
                {
                    Console.WriteLine("Не желаете ли добавить ананасы в пиццу?  1 - Добавить ананасы.  2 - Не добавлять ананасы.");
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
                        return 1;
                        break;
                    case 2:
                        Console.WriteLine("В пиццу не добавлены ананасы!");
                        v = 1;
                        return 0;
                        break;
                    default:
                        Console.WriteLine("Вы ввели некорректный вариант ответа!");
                        v = 0;
                        return 0;
                        break;
                }
            } while (v != 1);
        }
    }
}
