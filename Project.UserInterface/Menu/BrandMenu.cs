using Project.UserInterface.Utilities;
using System;

namespace Project.UserInterface.Menu
{
    internal static class BrandMenu
    {
        private static BrandUtility _brand = new BrandUtility();
        internal static void Menu()
        {
            #region Marka Menusu
            Console.WriteLine("Markalari Listelemek icin       : 1");
            Console.WriteLine("Yeni Marka Eklemek icin         : 2");
            Console.WriteLine("Marka Bilgisi Guncellemek icin  : 3");
            Console.WriteLine("Marka Bilgisi Silmek icin       : 4");
            Console.WriteLine("Menuyu Kapatmak icin            : 0");

            string key;
            do
            {
                Console.WriteLine("Marka Menusu");
                Console.Write("Yeni Islem Secin: ");
                key = Console.ReadLine();
                Console.WriteLine("-------------------------------------------------------------");

                switch (key)
                {
                    case "1": _brand.Get(); break;
                    case "2": _brand.Add(); break;
                    case "3": _brand.Update(); break;
                    case "4": _brand.Delete(); break;
                    case "0": break;
                    default: Console.WriteLine("Hatali giris yaptiniz."); break;
                }
                Console.WriteLine("Islem Tamamlandi..");
            } while (key != "0");

            #endregion
        }
    }
}
