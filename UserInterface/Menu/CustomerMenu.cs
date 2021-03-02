using UserInterface.Utilities;
using System;

namespace UserInterface.Menu
{
    internal static class CustomerMenu
    {
        private static CustomerUtility _customer = new CustomerUtility();
        internal static void Menu()
        {
            #region Kiralama Menusu
            Console.WriteLine("Musteri listesi icin                : 1");
            Console.WriteLine("Musteri eklemek icin                : 2");
            Console.WriteLine("Musteri Bilgisini Guncellemek icin  : 3");
            Console.WriteLine("Musteri Bilgisi Silmek icin         : 4");
            Console.WriteLine("Menuyu Kapatmak icin            : 0");

            string key;
            do
            {
                Console.WriteLine("Musteri Menusu");
                Console.Write("Yeni Islem Secin: ");
                key = Console.ReadLine();
                Console.WriteLine("-------------------------------------------------------------");

                switch (key)
                {
                    case "1": _customer.Get(); break;
                    case "2": _customer.Add(); break;
                    case "3": _customer.Update(); break;
                    case "4": _customer.Delete(); break;
                    case "0": break;
                    default: Console.WriteLine("Hatali giris yaptiniz."); break;
                }
                Console.WriteLine("Islem Tamamlandi..");
            } while (key != "0");

            #endregion
        }
    }
}
