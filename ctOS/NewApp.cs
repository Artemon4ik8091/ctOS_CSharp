using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctOS
{
    internal class NewApp
    {
        public void AppMain() 
        {
            var core = new Kernel(); //Для взаимодействия с ядром.

            //Пишем код здесь.
            System.Console.WriteLine("It works!");
        }
    }
}
