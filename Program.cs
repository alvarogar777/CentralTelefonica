using System;
using CentralTelefonica.Entidades;
using System.Collections.Generic;
using CentralTelefonica.App;
using CentralTelefonica.Util;

namespace CentralTelefonica
{
    class Program
    {
        static void Main(string[] args)
        {
            try{
            MenuPricipal menu = new MenuPricipal();
            menu.MostrarMenu();
            }
            catch(OptionMenuException e){
                Console.WriteLine(e.Message);
            }
        }
    }
}
