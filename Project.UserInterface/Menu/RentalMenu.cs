using Project.UserInterface.Utilities;
using System;

namespace Project.UserInterface.Menu
{
    internal static class RentalMenu
    {
        private static RentalUtility _rent = new RentalUtility();
        internal static void Menu()
        {
            #region Kiralama Menusu
            Console.WriteLine("Kiralama listesi icin                : 1");
            Console.WriteLine("Arac Kiralamak icin                  : 2");
            Console.WriteLine("Kiralama Bilgisini Guncellemek icin  : 3");
            Console.WriteLine("Kiralama Bilgisi Silmek icin         : 4");
            Console.WriteLine("Menuyu Kapatmak icin            : 0");

            string key;
            do
            {
                Console.WriteLine("Kiralama Menusu");
                Console.Write("Yeni Islem Secin: ");
                key = Console.ReadLine();
                Console.WriteLine("-------------------------------------------------------------");

                switch (key)
                {
                    case "1": _rent.Get(); break;
                    case "2": _rent.Add(); break;
                    case "3": _rent.Update(); break;
                    case "4": _rent.Delete(); break;
                    case "0": break;
                    default: Console.WriteLine("Hatali giris yaptiniz."); break;
                }
                Console.WriteLine("Islem Tamamlandi..");
            } while (key != "0");

            #endregion
        }
    }
}
