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
        public int WeightToSize { get; set; }
        public Pizza(string name, int mass, int slices) : base(name, mass)
        {
            Slices = slices;

        }

        //public int Eat()
        //{
        //    do
        //    {
        //        Console.WriteLine("Введите количество кусков которое вы хотите съесть:");
        //        string quantityStr = Console.ReadLine();

        //        if (int.TryParse(quantityStr, out quantity))
        //        {
        //            a = 1;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Ошибка: это не число!");
        //        }
        //    } while (a != 1);

        //    for (int i = 0; i < quantity; i++)
        //    {
        //        Slices--;
        //    }
        //    Console.WriteLine($"Съедено: {quantity}. Осталось:{Slices}");
        //    return Slices;
        //}

        public int Eat()
        {
            int quantity = 0;
            bool validInput = false;

            // Проверка корректного ввода
            do
            {
                Console.WriteLine($"Введите количество кусков, которое вы хотите съесть (доступно: {Slices}):");
                string quantityStr = Console.ReadLine();

                if (int.TryParse(quantityStr, out quantity))
                {
                    if (quantity <= 0)
                    {
                        Console.WriteLine("Ошибка: количество должно быть положительным!");
                    }
                    else if (quantity > Slices)
                    {
                        Console.WriteLine($"Ошибка: нельзя съесть больше, чем есть! Всего доступно {Slices} кусков.");
                    }
                    else
                    {
                        validInput = true;
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка: это не число!");
                }

            } while (!validInput);

            // Уменьшаем количество кусков
            Slices -= quantity;
            Console.WriteLine($"Съедено: {quantity}. Осталось: {Slices}");

            // Если пицца съедена полностью
            if (Slices == 0)
            {
                Console.WriteLine("Вы съели всю пиццу!");
            }

            return Slices;
        }


        public void Cut()
        {


            do
            {
                Console.WriteLine("\nВведите количество кусков на которое вы хотите дополнительно порезать пиццу:");
                string MoreSlicesStr = Console.ReadLine();

                if (int.TryParse(MoreSlicesStr, out MoreSlices) && (MoreSlices <= 10))
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
            Console.WriteLine("Пицца готовится...");
            Thread.Sleep(3000); // пауза
            Console.WriteLine($"Пицца {pizza}  готова!");
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
