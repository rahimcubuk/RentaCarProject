using Project.UserInterface.Menu;
using System;

namespace Project.UserInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Arac Kiralama Uygulamasi");

            #region Uygulama Menusu

            Console.WriteLine("Arac Menusu icin          : 1");
            Console.WriteLine("Renkler Menusu icin       : 2");
            Console.WriteLine("Markalar Menusu icin      : 3");
            Console.WriteLine("Kullanicilar Menusu icin  : 4");
            Console.WriteLine("Musteriler Menusu icin    : 5");
            Console.WriteLine("Arac Kiralama Menusu icin : 6");
            Console.WriteLine("Programi Kapatmak icin : 0");

            string key;
            do
            {
                Console.WriteLine("-------------------------------------------------------------");
                Console.Write("Menu Secin: ");
                key = Console.ReadLine();
                switch (key)
                {
                    case "1": CarMenu.Menu(); break;
                    case "2": ColorMenu.Menu(); break;
                    case "3": BrandMenu.Menu(); break;
                    case "4": UserMenu.Menu(); break;
                    case "5": CustomerMenu.Menu(); break;
                    case "6": RentalMenu.Menu(); break;
                    case "0": break;
                    default: Console.WriteLine("Hatali giris yaptiniz."); break;
                }
            } while (key != "0");

            #endregion
        }
    }
}
