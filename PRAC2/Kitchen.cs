using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAC2
{
    internal class Kitchen : IKitchen
    {
        int a = 0;//вспомогательная переменная
        int Num;//вспомогательная переменная для хранения номера пиццы в заказе
        int Num1;//вспомогательная переменная для хранения выбора действия 
        Param.PizzaSize size;//переменная перечисляемого типа
        Pizza A;//объявление экземпляра класса
        int quantity;//для определение ошибки при вводе размера нужного
        int Choice; //для выбора резать ли пиццу на куски или нет
        int QuantityDelete; //номер пиццы, которую удалять собираются
        int NumEat;//номер пиццы, которую хотим съесть
        int invalidOrders; //переменная для обнаружения того, что ни одной пиццы не заказано


        public List<Calzone> pizza = new List<Calzone>
        {
            new Calzone("Маргарита", 400, 8, 285, "-"),
            new Calzone("Пепперони", 450, 8, 300, "-"),
            new Calzone("Гавайская", 450, 8, 290, "-"),
            new Calzone("Четыре сыра", 500, 8, 350, "-"),
            new Calzone("Вегетарианская", 400, 8, 270, "-"),
            new Calzone("Мясная", 500, 8, 400, "-"),
            new Calzone("Барбекю с курицей", 500, 8, 350, "-"),
            new Calzone("С морепродуктами", 450, 8, 320, "-"),
            new Calzone("С ананасами", 450, 8, 280, "-"),
            new Calzone("С беконом", 500, 8, 360, "-"),
            new Calzone("С грибами", 450, 8, 310, "-"),
            new Calzone("С ветчиной", 500, 8, 330, "-"),
        };

        public List<Calzone> orders = new List<Calzone>//список для хранения заказов
        { };

        public List<Calzone> cooked = new List<Calzone>//список для хранения заказов
        { };
        public void ShowMenu()
        {
            do
            {
                do
                {
                    Console.WriteLine("\n1 - Добавить пиццу в заказ\n2 - Отправить заказ на кухню приготавливаться\n3 - Удалить пиццу из заказа\n4 - Покушать\n5 - Выйти");
                    string num = Console.ReadLine();

                    if (int.TryParse(num, out Num1) && Num1 <= 5)
                    {
                        a = 1;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: Выберите существующую функцию!");
                    }
                } while (a != 1);
                Num = Num1;
                switch (Num)
                {

                    case 1:
                        do
                        {
                            do
                            {
                                Console.WriteLine("\nВыберите пиццу:\nРАЗВЕСОВКА,КОЛИЧЕСТВО КУСКОВ,КАЛОРИИ ПРИВЕДЕНЫ ДЛЯ МАЛЕНЬКОГО РАЗМЕРА ПИЦЦЫ");
                                Console.WriteLine("");

                                int index = 1;//вспомогательная переменная для нумерации пицц   
                                foreach (var item in pizza)
                                {
                                    Console.WriteLine($"{index,2}) {item.Name,-20} {item.Mass,5}г  {item.Slices,2} кусков  {item.Calories,4} ккал.");
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

                        while (true)
                        {
                            Console.WriteLine("Введите размер пиццы (small,medium,large,extraLarge):");
                            string input = Console.ReadLine();

                            if (Enum.TryParse(input, true, out size) && int.TryParse(input, out quantity) == false) // true = игнорировать регистр
                            {
                                Console.WriteLine($"Вы выбрали размер: {size}");

                                if (size == Param.PizzaSize.medium)
                                {
                                    pizza[Num - 1].Slices += 2;
                                    pizza[Num - 1].Calories += 100;
                                    pizza[Num - 1].Mass += 100;

                                }

                                if (size == Param.PizzaSize.large)
                                {
                                    pizza[Num - 1].Slices += 4;
                                    pizza[Num - 1].Calories += 200;
                                    pizza[Num - 1].Mass += 200;

                                }

                                if (size == Param.PizzaSize.extraLarge)
                                {
                                    pizza[Num - 1].Slices += 6;
                                    pizza[Num - 1].Calories += 300;
                                    pizza[Num - 1].Mass += 300;
                                }

                                break;
                            }
                            else
                            {
                                Console.WriteLine("Ошибка: такого размера нет! Попробуйте снова.");
                            }
                        }

                        do
                        {
                            Console.WriteLine("\nЖелаете ли вы дополнительно порезать пиццу на куски? \n1 - Да\n2 - Нет");
                            string сhoice = Console.ReadLine();

                            if (int.TryParse(сhoice, out Choice))
                            {
                                a = 1;
                                if ((Choice >= 1) && (Choice <= 2))
                                {
                                    a = 1;
                                }
                                else a = 2;
                            }
                            else
                            {
                                Console.WriteLine("Ошибка: это не число!");
                            }
                        } while (a != 1);

                        if (Choice == 1)
                        {
                            pizza[Num - 1].Cut();
                        }
                        if (Pizza.PineappleReminder() == 1)
                        {
                            pizza[Num - 1].Pineapple = "+";
                            pizza[Num - 1].Mass += 50;
                        }

                        orders.Add(pizza[Num - 1]);

                        Console.WriteLine("\nПицца добавлена в заказ!");
                        Console.WriteLine("\nВаш текущий заказ:");
                        int index1 = 1;
                        foreach (var pizza in orders)
                        {
                            Console.WriteLine($"{index1}) {pizza}");
                            index1++;
                        }
                        break;
                    case 2:
                        if (orders.Count > 0)
                        {
                            foreach (var i in orders)
                            {
                                Pizza.Bake(i.Name);

                            }

                            cooked.AddRange(orders);

                            orders.Clear();
                        }
                        else Console.WriteLine("Ни одной пиццы еще не заказано!");

                        break;


                    case 3:
                        if (orders.Count == 0)
                        {
                            Console.WriteLine("Ни одной пиццы еще не заказано!");
                            break;
                        }
                        Console.WriteLine("\nВаш текущий заказ:");
                        int index2 = 1;
                        foreach (var pizza in orders)
                        {
                            Console.WriteLine($"{index2}) {pizza}");
                            index2++;
                        }

                        do
                        {
                            Console.WriteLine("\nВведите номер пиццы, которую хотите удалить:");
                            string quantityDelete = Console.ReadLine();

                            if (int.TryParse(quantityDelete, out QuantityDelete))
                            {
                                a = 1;
                                if ((QuantityDelete <= orders.Count) && (QuantityDelete > 0))
                                {
                                    a = 1;
                                }
                                else a = 2;
                            }
                            else
                            {
                                Console.WriteLine("Ошибка! Это не число!");
                            }
                        } while (a != 1);
                        Console.WriteLine($"\nУдалена пицца {orders[QuantityDelete - 1].Name} ");
                        orders.RemoveAt(QuantityDelete - 1);
                        break;

                    case 4:
                        
                            if (cooked.Count == 0)
                            {
                                Console.WriteLine("Ни одной пиццы еще не приготовлено!");
                                break;
                            }
                      
                        int index3 = 1;
                        foreach (var pizza in cooked)
                        {
                            Console.WriteLine($"{index3}) {pizza}");
                            index3++;
                        }
                        bool validInput = false;
                        do
                        {
                            Console.WriteLine("Введите номер пиццы, которую хотите съесть:");
                            string numEat = Console.ReadLine();

                            if (int.TryParse(numEat, out NumEat) && NumEat > 0 && NumEat <= cooked.Count)
                            {
                                validInput = true;
                            }
                            else
                            {
                                Console.WriteLine("Ошибка! Введите корректный номер пиццы.");
                            }

                        } while (!validInput);


                         cooked[NumEat - 1].Slices = cooked[NumEat - 1].Eat();

                        break;


                    case 5:

                        Console.WriteLine("До свидания!");
                        Environment.Exit(0);
                        break;
                }
            } while (Num1 != 5);

        }

    }
}


