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
        public int Calories { set;  get; }
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
            new Calzone("Острая мексиканская кальцоне", 435, 380),
            new Calzone("Кальцоне с лососем и шпинатом", 405, 325),
            new Calzone("Гавайская кальцоне", 420, 335),
            new Calzone("Кальцоне с беконом и яйцом", 440, 385),
            new Calzone("Кальцоне с морепродуктами", 410, 330),
            new Calzone("Кальцоне с прошутто и рукколой", 400, 315),
        };
        
    }
}
