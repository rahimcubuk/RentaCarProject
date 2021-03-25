using Business.Abstract.Services;
using Business.Concrete.Managers;
using DataAccess.Concrete.EFDals;
using Entities.Concrete.Models;
using System;

namespace UserInterface.Utilities
{
    internal class RentalUtility : Utility
    {
        private IRentalService _rentalManager = new RentalManager(new EfRentalDal());
        private CustomerUtility _customerUtility = new CustomerUtility();
        private CarUtility _carUtility = new CarUtility();

        public override void Get()
        {
            Console.WriteLine("-------------------------------------------------------------");
            var rents = _rentalManager.GetRentalDetails();
            Console.WriteLine("Id - M. Adi - Arac Adi - Kiralama Tarihi - Iade Tarihi");
            foreach (var rent in rents.Data)
            {
                Console.WriteLine("{0} - {1} - {2} - {3} - {4}",
                    rent.Id, rent.CustomerFirstName, rent.CarName, rent.RentDate, rent.ReturnDate);
            }
        }

        public override void Add()
        {
            Rental newRent = CreateData();

            _rentalManager.Add(newRent);
            Get();
        }

        public override void Delete()
        {
            Get();

            Console.WriteLine("-------------------------------------------------------------");
            Console.Write("Silmek istediginiz islemin ID'sini secin: ");
            int Id = Convert.ToInt32(Console.ReadLine());
            Rental newRent = new Rental() { Id = Id };

            _rentalManager.Delete(newRent);
            Get();
        }

        public override void Update()
        {
            Get();

            Console.WriteLine("-------------------------------------------------------------");
            Console.Write("Guncellemek istediginiz islemin ID'sini secin: ");
            int Id = Convert.ToInt32(Console.ReadLine());
            var newRent = CreateData();
            newRent.Id = Id;

            _rentalManager.Update(newRent);
            Get();
        }

        private Rental CreateData()
        {
            Rental newRent = new Rental();

            _carUtility.Get();
            Console.Write("Arac Id Giriniz: ");
            newRent.CarId = Convert.ToInt32(Console.ReadLine());

            _customerUtility.Get();
            Console.Write("Musteri Id Giriniz: ");
            newRent.CustomerId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Kiralama Tarihi Giriniz: ");
            newRent.RentDate = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Iyade Tarihi Giriniz: ");
            string returnDate = Console.ReadLine();
            if (returnDate != "") newRent.ReturnDate = Convert.ToDateTime(returnDate);

            return newRent;
        }
    }
}
