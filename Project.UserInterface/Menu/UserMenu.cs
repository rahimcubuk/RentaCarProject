using UserInterface.Utilities;
using System;

namespace UserInterface.Menu
{
    internal static class UserMenu
    {
        private static UserUtility _user = new UserUtility();
        internal static void Menu()
        {
            #region Kiralama Menusu
            Console.WriteLine("Kullanici listesi icin                : 1");
            Console.WriteLine("Kullanici eklemek icin                : 2");
            Console.WriteLine("Kullanici Bilgisini Guncellemek icin  : 3");
            Console.WriteLine("Kullanici Bilgisi Silmek icin         : 4");
            Console.WriteLine("Menuyu Kapatmak icin            : 0");

            string key;
            do
            {
                Console.WriteLine("Kullanici Menusu");
                Console.Write("Yeni Islem Secin: ");
                key = Console.ReadLine();
                Console.WriteLine("-------------------------------------------------------------");

                switch (key)
                {
                    case "1": _user.Get(); break;
                    case "2": _user.Add(); break;
                    case "3": _user.Update(); break;
                    case "4": _user.Delete(); break;
                    case "0": break;
                    default: Console.WriteLine("Hatali giris yaptiniz."); break;
                }
                Console.WriteLine("Islem Tamamlandi..");
            } while (key != "0");

            #endregion
        }
    }
}
