using Business.Abstract.Services;
using Business.Concrete.Managers;
using DataAccess.Concrete.EFDals;
using Entities.Concrete.Models;
using System;

namespace UserInterface.Utilities
{
    class CustomerUtility : Utility
    {
        private ICustomerService _customerManager = new CustomerManager(new EfCustomerDal());
        private UserUtility _user = new UserUtility();

        public override void Get()
        {
            Console.WriteLine("-------------------------------------------------------------");
            var customers = _customerManager.GetCustomersDetails();
            Console.WriteLine("Id - M. Adi - M. SoyAdi - M. e-mail - M. Sifresi - M. Sirketi");
            foreach (var cs in customers.Data)
            {
                Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5}",
                    cs.CustomerId, cs.FirstName, cs.LastName, cs.EMail, cs.Password, cs.CompanyName);
            }
        }

        public override void Add()
        {
            Customer newCs = CreateData();

            _customerManager.Add(newCs);
            Get();
        }

        public override void Delete()
        {
            Get();

            Console.WriteLine("-------------------------------------------------------------");
            Console.Write("Silmek istediginiz musterinin ID'sini secin: ");
            int Id = Convert.ToInt32(Console.ReadLine());
            Customer newCs = new Customer() { CustomerId = Id };

            _customerManager.Delete(newCs);
            Get();
        }

        public override void Update()
        {
            Get();

            Console.WriteLine("-------------------------------------------------------------");
            Console.Write("Guncellemek istediginiz islemin ID'sini secin: ");
            int Id = Convert.ToInt32(Console.ReadLine());
            var newCs = CreateData();
            newCs.CustomerId = Id;

            _customerManager.Update(newCs);
            Get();
        }

        private Customer CreateData()
        {
            Customer newCs = new Customer();

            _user.Get();
            Console.Write("User Id Giriniz: ");
            newCs.UserId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Sirket Adini Giriniz: ");
            newCs.CompanyName = Console.ReadLine();

            return newCs;
        }
    }
}
