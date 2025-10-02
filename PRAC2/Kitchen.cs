using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAC2
{
    internal class Kitchen : IKitchen
    {
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
        public void ShowMenu()
        {

        }
    }
}
