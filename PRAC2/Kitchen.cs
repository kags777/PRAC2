using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PRAC2.Param;

namespace PRAC2
{
    internal class Kitchen : IKitchen
    {
        private int a = 0;//вспомогательная переменная
        private int Num;//вспомогательная переменная для хранения номера пиццы в заказе
        private int Num1;//вспомогательная переменная для хранения выбора действия 
        private int Choice; //для выбора резать ли пиццу на куски или нет
        private int QuantityDelete; //номер пиццы, которую удалять собираются
        private int NumEat;//номер пиццы, которую хотим съесть
        private int checkInt;//переменная для проверки введенного числа
        private int InvalidChoice;// переменная для проверки введеного числа
        private int NumCalz;//для хранения выбора номера кальцоне
        private int index1; //Для пронумерации позиций в заказе


        public List<Pizza> pizza = new List<Pizza>
        {
            new Pizza("Пицца Маргарита", 400, 8, 285, "-"),
            new Pizza("Пицца Пепперони", 450, 8, 300, "-"),
            new Pizza("Гавайская Пицца", 450, 8, 290, "-"),
            new Pizza("Пицца Четыре сыра", 500, 8, 350, "-"),
            new Pizza("Вегетарианская Пицца", 400, 8, 270, "-"),
            new Pizza("Мясная Пицца", 500, 8, 400, "-"),
            new Pizza("Пицца Барбекю с курицей", 500, 8, 350, "-"),
            new Pizza("Пицца с морепродуктами", 450, 8, 320, "-"),
            new Pizza("Пицца с треской", 450, 8, 280, "-"),
            new Pizza("Пицца с беконом", 500, 8, 360, "-"),
            new Pizza("Пицца с грибами", 450, 8, 310, "-"),
            new Pizza("Пицца с ветчиной", 500, 8, 330, "-"),
        };

        public List<Food> orders = new List<Food>//список для хранения заказов
        { };
        public List<Food> cooked = new List<Food>//список для хранения заказов
        { };
        public void ShowMenu()
        {
            do
            {
                do
                {
                    Console.WriteLine("\n1 - Добавить пиццу в заказ\n2 - Добавить кальцоне\n3 - Посмотреть заказ\n" +
                        "4 - Отправить заказ на кухню приготавливаться\n5 - Удалить позицию из заказа\n6 - Покушать\n7 - Выйти");
                    string num = Console.ReadLine();
                    if (Param.TryParseNumber(num, out Num1) == true && (Num1 <= 7)) checkInt = 1;
                } while (checkInt != 1);

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

                                if (Param.TryParseNumber(num, out Num) == true) checkInt = 2;
                            } while (checkInt != 2);

                            if (Num < 1 || Num > pizza.Count)
                            {
                                Console.WriteLine("Ошибка: выберите пиццу из списка!");
                                InvalidChoice = 3;
                            }
                            else
                            {
                                InvalidChoice = 0;
                            }
                        } while (InvalidChoice == 3);

                        ChoosePizzaSize(pizza, Num - 1);//метод который позволяет выбрать размер пиццы
                      
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
                        break;

                    case 2:

                        NumCalz = Calzone.ChooseCalzone();//выбираю кальцоне
                        Calzone.ChooseCalzoneSize(orders, NumCalz); //выбираю размер кальцоне
                        break;

                    case 3:

                        if (orders.Count == 0 && orders.Count == 0)
                            Console.WriteLine("Вы не сделали заказ");
                        index1 = 1;
                        foreach (var food in orders)
                        {
                            Console.WriteLine($"{index1}) {food}");
                            index1++;
                        }
                        break;
                    case 4:
                        if (orders.Count > 0)
                        {
                            foreach (var i in orders)
                            {
                                Pizza.Bake(i.Name);

                            }

                            cooked.AddRange(orders);

                            orders.Clear();
                        }
                        else Console.WriteLine("Ни одной позиции не заказано!");

                        break;


                    case 5:
                        if (orders.Count == 0)
                        {
                            Console.WriteLine("Ни одной позииции не заказано!");
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
                            Console.WriteLine("\nВведите номер позиции, которую хотите удалить:");
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
                        Console.WriteLine($"\nУдалена позиция {orders[QuantityDelete - 1].Name} ");
                        orders.RemoveAt(QuantityDelete - 1);
                        break;

                    case 6:

                        if (cooked.Count == 0)
                        {
                            Console.WriteLine("Ни одной позиции не приготовлено!");
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
                            Console.WriteLine("Введите номер позиции, которую хотите съесть:");
                            string numEat = Console.ReadLine();

                            if (int.TryParse(numEat, out NumEat) && NumEat > 0 && NumEat <= cooked.Count)
                            {
                                validInput = true;
                            }
                            else
                            {
                                Console.WriteLine("Ошибка! Введите корректный номер позиции.");
                            }

                        } while (!validInput);
                        Pizza.Eat(NumEat);
                        cooked.RemoveAt(NumEat - 1);
                        break;

                    case 7:

                        Console.WriteLine("До свидания!");
                        Environment.Exit(0);
                        break;
                }
            } while (Num1 != 7);
        }
    }
}


