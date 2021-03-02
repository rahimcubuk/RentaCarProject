using Business.Abstract.Services;
using Business.Concrete.Managers;
using DataAccess.Concrete.EFDals;
using Entities.Concrete.Models;
using System;

namespace UserInterface.Utilities
{
    internal class ColorUtility : Utility
    {
        private static IColorService _colorManager = new ColorManager(new EfColorDal());

        public override void Get()
        {
            Console.WriteLine("-------------------------------------------------------------");
            var colors = _colorManager.GetAll();
            Console.WriteLine("Id - Model Adi");
            foreach (var color in colors.Data)
            {
                Console.WriteLine("{0} - {1}", color.ColorId, color.ColorName);
            }
        }

        public override void Add()
        {
            Color newColor = CreateData();

            _colorManager.Add(newColor);
            Get();
        }

        public override void Update()
        {
            Get();

            Console.WriteLine("-------------------------------------------------------------");
            Console.Write("Guncellemek istediginiz rengin ID'sini secin: ");
            int Id = Convert.ToInt32(Console.ReadLine());
            var newColor = CreateData();
            newColor.ColorId = Id;

            _colorManager.Update(newColor);
            Get();
        }

        public override void Delete()
        {
            Get();

            Console.WriteLine("-------------------------------------------------------------");
            Console.Write("Silmek istediginiz rengin ID'sini secin: ");
            int Id = Convert.ToInt32(Console.ReadLine());
            Color color = new Color() { ColorId = Id };

            _colorManager.Delete(color);
            Get();
        }

        private Color CreateData()
        {
            Console.Write("Renk Adini Giriniz: ");
            Color newColor = new Color();
            newColor.ColorName = Console.ReadLine();
            return newColor;
        }
    }
}
