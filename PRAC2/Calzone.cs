using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAC2
{
    class Calzone : Food
    {
        public int Calories { set; get; }
        public int NumCalz;//для хранения выбора номера кальцоне
        public int invalidCalzone;// для хранения состояния ввода
        Param.PizzaSize size;//переменная перечисляемого типа
        int quantity;//для определение ошибки при вводе размера нужного

        public Calzone(string name, int mass, int calories) : base(name, mass)
        {
            Calories = calories;
        }

        public override string ToString()
        {
            return $"{Name} {Mass} г  {Calories} ккал";
        }

        public static List<Calzone> calzone = new List<Calzone>
        {
            new Calzone("Мясная кальцоне", 450, 395),
            new Calzone("Овощная кальцоне", 390, 270),
            new Calzone("Кальцоне Карбонара", 425, 360),
            new Calzone("Кальцоне с тунцом", 400, 310),
            new Calzone("Капричоза кальцоне", 415, 345),
            new Calzone("Мексиканская кальцоне", 435, 380),
            new Calzone("Кальцоне с лососем ", 405, 325),
            new Calzone("Гавайская кальцоне", 420, 335),
            new Calzone("Кальцоне с беконом ", 440, 385),
            new Calzone("Кальцоне с селедкой", 410, 330),
            new Calzone("Кальцоне с прошутто", 400, 315),
        };


        public static int ChooseCalzone()
        {
            int selectedIndex = -1;
            bool isValid = false;

            do
            {
                Console.WriteLine("Введите номер кальцоне, которую хотите добавить в заказ:\n" +
                                  "РАЗВЕСОВКА, КАЛОРИИ ПРИВЕДЕНЫ ДЛЯ МАЛЕНЬКОГО РАЗМЕРА КАЛЬЦОНЕ");

                int index = 1;
                foreach (var calz in calzone)
                {
                    Console.WriteLine($"{index,2}) {calz.Name,-25} {calz.Mass,12} г  {calz.Calories,5} ккал");
                    index++;
                }

                string numCalz = Console.ReadLine();

                if (Param.TryParseNumber(numCalz, out int NumCalz))
                {
                    if (NumCalz >= 1 && NumCalz <= calzone.Count)
                    {
                        selectedIndex = NumCalz - 1; // для работы с индексом
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: выберите кальцоне из списка!");
                    }
                }
            } while (!isValid);

            return selectedIndex;
        }
    


    public static void ChooseCalzoneSize(List<Food> orders, int numCalz)
        {
            while (true)
            {
                Console.WriteLine("Введите размер кальцоне (small,medium,large,extraLarge):");
                string input = Console.ReadLine();

                if (Enum.TryParse(input, true, out Param.PizzaSize size) && !int.TryParse(input, out _))
                {
                    Console.WriteLine($"Вы выбрали размер: {size}");

                    if (size == Param.PizzaSize.medium)
                    {
                        calzone[numCalz - 1].Calories += 100;
                        calzone[numCalz - 1].Mass += 100;
                    }
                    else if (size == Param.PizzaSize.large)
                    {
                        calzone[numCalz - 1].Calories += 200;
                        calzone[numCalz - 1].Mass += 200;
                    }
                    else if (size == Param.PizzaSize.extraLarge)
                    {
                        calzone[numCalz - 1].Calories += 300;
                        calzone[numCalz - 1].Mass += 300;
                    }

                    break;
                }
                else
                {
                    Console.WriteLine("Ошибка: такого размера нет! Попробуйте снова.");
                }
            }

            orders.Add(calzone[numCalz - 1]);
            Console.WriteLine("\nКальцоне добавлена в заказ!");
        }


    }
}

