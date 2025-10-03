using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAC2
{
    internal class Kitchen : IKitchen
    {
        int a = 0;//вспомогательная переменная
        int Num;//вспомогательная переменная для хранения номера пиццы в заказе
        public List<Calzone> pizza = new List<Calzone>
        {
            new Calzone("Маргарита", 400, 8, 285),
            new Calzone("Пепперони", 450, 8, 300),
            new Calzone("Гавайская", 450, 8, 290),
            new Calzone("Четыре сыра", 500, 8, 350),
            new Calzone("Вегетарианская", 400, 8, 270),
            new Calzone("Мясная", 500, 8, 400),
            new Calzone("Барбекю с курицей", 500, 8, 350),
            new Calzone("С морепродуктами", 450, 8, 320),
            new Calzone("Пицца с ананасами", 450, 8, 280),
            new Calzone("Пицца с беконом", 500, 8, 360),
            new Calzone("Пицца с грибами", 450, 8, 310),
            new Calzone("Пицца с ветчиной", 500, 8, 330),
        };

        public List<int> orders = new List<int>//пустой список для хранения заказов
        { };


        public void ShowMenu()
        {
            do
            {
                do
                {
                    Console.WriteLine("1 - Добавить пиццу в заказ\n  2 - Удалить пиццу из заказа\n  3 - Пойти за столик покушать\n   4 - Выйти");
                    string num = Console.ReadLine();

                    if (int.TryParse(num, out Num))
                    {
                        a = 1;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: это не число!");
                    }
                } while (a != 1);

                switch ()
                {
                    case 1:
                        do
                        {
                            do
                            {
                                Console.WriteLine("Выберите пиццу:");
                                int index = 1;//вспомогательная переменная для нумерации пицц   
                                foreach (var item in pizza)
                                {
                                    Console.WriteLine($"{index}) {item.Name} - {item.Mass}г, {item.Slices} кусков, {item.Calories} ккал.");
                                    index++;
                                }

                                string num = Console.ReadLine();

                                if (int.TryParse(num, out Num))
                                {
                                    a = 1;
                                }
                                else
                                {
                                    Console.WriteLine("Ошибка: это не число!");
                                }
                            } while (a != 1);

                            if (Num < 1 || Num > pizza.Count)
                            {
                                Console.WriteLine("Ошибка: выберите пиццу из списка!");
                                a = 3;
                            }
                            else
                            {
                                a = 0;
                            }
                        } while (a == 3);

                        orders.Add(Num);
                        Console.WriteLine("Пицца добавлена в заказ!");
                        Console.WriteLine("Ваш текущий заказ:");

                        break;

                }
                do
                {
                    Console.WriteLine("Выберите пиццу:");
                    int index = 1;//вспомогательная переменная для нумерации пицц   
                    foreach (var item in pizza)
                    {
                        Console.WriteLine($"{index}) {item.Name} - {item.Mass}г, {item.Slices} кусков, {item.Calories} ккал.");
                        index++;
                    }

                    string num = Console.ReadLine();

                    if (int.TryParse(num, out Num))
                    {
                        a = 1;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: это не число!");
                    }
                } while (a != 1);

                switch ()
                {
                    case "1":
                        pizza[0].Eat();
                        break;
                    case "2":
                        pizza[1].Eat();
                        break;
                    case "3":
                        pizza[2].Eat();
                        break;
                    case "4":
                        pizza[3].Eat();
                        break;
                    case "5":
                        pizza[4].Eat();
                        break;
                    case "6":
                        pizza[5].Eat();
                        break;
                    case "7":
                        pizza[6].Eat();
                        break;
                    case "8":
                        pizza[7].Eat();
                        break;
                    case "9":
                        pizza[8].Eat();
                        break;
                    case "10":
                        pizza[9].Eat();
                        break;
                    case "11":
                        pizza[10].Eat();
                        break;
                    case "12":
                        pizza[11].Eat();
                        break;
                    default:
                        Console.WriteLine("Ошибка: выберите пиццу из списка!");
                        break;
                }

            } while ();
        }
    }
}
