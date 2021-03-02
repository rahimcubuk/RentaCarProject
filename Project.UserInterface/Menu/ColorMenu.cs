using UserInterface.Utilities;
using System;

namespace UserInterface.Menu
{
    internal static class ColorMenu
    {
        private static ColorUtility _color = new ColorUtility();
        internal static void Menu()
        {
            #region Renk Menusu
            Console.WriteLine("Renkleri Listelemek icin       : 1");
            Console.WriteLine("Yeni Renk Eklemek icin         : 2");
            Console.WriteLine("Renk Bilgisi Guncellemek icin  : 3");
            Console.WriteLine("Renk Bilgisi Silmek icin       : 4");
            Console.WriteLine("Menuyu Kapatmak icin           : 0");

            string key;
            do
            {
                Console.WriteLine("Renk Menusu");
                Console.Write("Yeni Islem Secin: ");
                key = Console.ReadLine();
                Console.WriteLine("-------------------------------------------------------------");

                switch (key)
                {
                    case "1": _color.Get(); break;
                    case "2": _color.Add(); break;
                    case "3": _color.Update(); break;
                    case "4": _color.Delete(); break;
                    case "0": break;
                    default: Console.WriteLine("Hatali giris yaptiniz."); break;
                }
                Console.WriteLine("Islem Tamamlandi..");
            } while (key != "0");

            #endregion
        }
    }
}
