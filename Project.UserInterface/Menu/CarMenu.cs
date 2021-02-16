using Project.UserInterface.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.UserInterface.Menu
{
    internal static class CarMenu
    {
        private static CarUtility _carUtility = new CarUtility();
        internal static void Menu()
        {
            #region Arac Menusu
            Console.WriteLine("Araclari Listelemek icin     : 1");
            Console.WriteLine("Id ile Arac Secmek icin      : 2");
            Console.WriteLine("Yeni Arac Eklemek icin       : 3");
            Console.WriteLine("Arac Bilgisi Duzenlemek icin : 4");
            Console.WriteLine("Arac Bilgisi Silmek icin     : 5");
            Console.WriteLine("BrandId ile Arac Secmek icin : 6");
            Console.WriteLine("ColorId ile Arac Secmek icin : 7");
            Console.WriteLine("Menuyu Kapatmak icin         : 0");

            string key;
            do
            {
                Console.WriteLine("Arac Menusu");
                Console.Write("Yeni Islem Secin: ");
                key = Console.ReadLine();
                Console.WriteLine("-------------------------------------------------------------");

                switch (key)
                {
                    case "1": _carUtility.Get(); break;
                    case "2": _carUtility.GetCarById(); break;
                    case "3": _carUtility.Add(); break;
                    case "4": _carUtility.Update(); break;
                    case "5": _carUtility.Delete(); break;
                    case "6": _carUtility.GetCarsByBrand(); break;
                    case "7": _carUtility.GetCarsByColor(); break;
                    case "0": break;
                    default: Console.WriteLine("Hatali giris yaptiniz."); break;
                }
                Console.WriteLine("Islem Tamamlandi..");
            } while (key != "0");

            #endregion
        }
    }
}
