using Business.Abstract.Services;
using Business.Concrete.Managers;
using DataAccess.Concrete.EFDals;
using Entities.Concrete.Models;
using System;

namespace UserInterface.Utilities
{
    internal class BrandUtility : Utility
    {
        private static IBrandService _brandManager = new BrandManager(new EfBrandDal());

        public override void Get()
        {
            Console.WriteLine("-------------------------------------------------------------");
            var brands = _brandManager.GetAll();
            Console.WriteLine("Id - Model Adi");
            foreach (var brand in brands.Data)
            {
                Console.WriteLine("{0} - {1}", brand.BrandId, brand.BrandName);
            }
        }

        public override void Add()
        {
            Brand newBrand = CreateData();

            _brandManager.Add(newBrand);
            Get();
        }

        public override void Update()
        {
            Get();

            Console.WriteLine("-------------------------------------------------------------");
            Console.Write("Guncellemek istediginiz markanin ID'sini secin: ");
            int Id = Convert.ToInt32(Console.ReadLine());
            var newBrand = CreateData();
            newBrand.BrandId = Id;

            _brandManager.Update(newBrand);
            Get();
        }

        public override void Delete()
        {
            Get();

            Console.WriteLine("-------------------------------------------------------------");
            Console.Write("Silmek istediginiz markanin ID'sini secin: ");
            int Id = Convert.ToInt32(Console.ReadLine());
            Brand brand = new Brand() { BrandId = Id };

            _brandManager.Delete(brand);
            Get();
        }

        private Brand CreateData()
        {
            Console.Write("Marka Adini Giriniz: ");
            Brand newBrand = new Brand();
            newBrand.BrandName = Console.ReadLine();
            return newBrand;
        }
    }
}
