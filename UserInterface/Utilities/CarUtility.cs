using Business.Abstract.Services;
using Business.Concrete.Managers;
using DataAccess.Concrete.EFDals;
using Entities.Concrete.DTOs;
using Entities.Concrete.Models;
using System;
using System.Collections.Generic;

namespace UserInterface.Utilities
{
    internal class CarUtility : Utility
    {
        private ICarService _carManager = new CarManager(new EfCarDal());
        private IColorService _colorManager = new ColorManager(new EfColorDal());
        private IBrandService _brandManager = new BrandManager(new EfBrandDal());
        private ColorUtility _color = new ColorUtility();
        private BrandUtility _brand = new BrandUtility();

        public override void Delete()
        {
            Get();

            Console.WriteLine("-------------------------------------------------------------");
            Console.Write("Silmek istediginiz aracin ID'sini secin: ");
            Car car = new Car() { CarId = Convert.ToInt32(Console.ReadLine()) };

            _carManager.Delete(car);
        }

        public override void Update()
        {
            Get();

            Console.WriteLine("-------------------------------------------------------------");
            Console.Write("Guncellemek istediginiz aracin ID'sini secin: ");
            int Id = Convert.ToInt32(Console.ReadLine());
            var car = CreateCarData();
            car.CarId = Id;

            _carManager.Update(car);
            Get();
        }

        public override void Add()
        {
            Console.WriteLine("Arac Bilgilerini Giriniz..");
            var car = CreateCarData();
            _carManager.Add(car);
            Get();
        }

        public override void Get()
        {
            Console.WriteLine("-------------------------------------------------------------");
            var cars = _carManager.GetCarsDetails();
            ListCar(cars.Data);
        }

        internal void GetCarById()
        {
            Get();

            Console.WriteLine("-------------------------------------------------------------");
            Console.Write("Secmek istediginiz aracin ID'sini secin: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var car = _carManager.GetCarDetailById(id).Data;
            Console.WriteLine("{0} - {1} - {2}  -  {3}  -  {4}  -  {5}   -   {6}",
                            car.CarId, car.CarName, car.BrandName, car.ColorName,
                            car.ModelYear, car.DailyPrice, car.Description);
        }

        internal void GetCarsByColor()
        {
            _color.Get();

            Console.WriteLine("-------------------------------------------------------------");
            Console.Write("Aracin renk numarasini secin: ");
            //int id = Convert.ToInt32(Console.ReadLine());

            var cars = _carManager.GetCarsByColor(Console.ReadLine());
            ListCar(cars.Data);
        }

        internal void GetCarsByBrand()
        {
            _brand.Get();

            Console.WriteLine("-------------------------------------------------------------");
            Console.Write("Aracin Model numarasini secin: ");
            //int id = Convert.ToInt32(Console.ReadLine());

            var cars = _carManager.GetCarsByBrand(Console.ReadLine());
            ListCar(cars.Data);
        }

        private void ListCar(List<Car> cars)
        {
            if (cars.Count == 0) Console.WriteLine("Bu degerlere uygun arac girdisi mevcut degildir.");
            else
            {
                Console.WriteLine("ID - Arac Adi - Brand - Color - ModelYear - DailyPrice - Description");
                foreach (var car in cars)
                {
                    Console.WriteLine("{0} - {1} - {2}  -  {3}  -  {4}  -  {5}   -   {6}",
                            car.CarId, car.CarName, _brandManager.GetById(car.BrandId).Data.BrandName,
                            _colorManager.GetById(car.ColorId).Data.ColorName, car.ModelYear, car.DailyPrice, car.Description);
                }
            }
        }

        private void ListCar(List<CarDetailsDto> cars)
        {
            if (cars.Count == 0) Console.WriteLine("Bu degerlere uygun arac girdisi mevcut degildir.");
            else
            {
                Console.WriteLine("ID - Arac Adi - Brand - Color - ModelYear - DailyPrice - Description");
                foreach (var car in cars)
                {
                    Console.WriteLine("{0} - {1} - {2}  -  {3}  -  {4}  -  {5}   -   {6}",
                            car.CarId, car.CarName, car.BrandName, car.ColorName,
                            car.ModelYear, car.DailyPrice, car.Description);
                }
            }
        }

        private Car CreateCarData()
        {
            Car car = new Car();

            Console.Write("Aracin Adini Giriniz: ");
            car.CarName = Console.ReadLine();

            Console.Write("Aracin BrandId'sini belirleyin: ");
            car.BrandId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Aracin ColorId'sini belirleyin: ");
            car.ColorId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Aracin ModelYear degerini belirleyin: ");
            car.ModelYear = Console.ReadLine();

            Console.Write("Aracin DailyPrice degerini belirleyin: ");
            car.DailyPrice = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Arac Aciklamasini Yaziniz: ");
            car.Description = Console.ReadLine();

            return car;
        }
    }
}
