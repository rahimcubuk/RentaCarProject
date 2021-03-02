using Core.Entities.Concrete;
using Project.Business.Abstract.Services;
using Project.Business.Concrete.Managers;
using Project.DataAccess.Concrete.EFDals;
using System;

namespace Project.UserInterface.Utilities
{
    class UserUtility : Utility
    {
        private IUserService _userManager = new UserManager(new EfUserDal());
        public override void Get()
        {
            Console.WriteLine("-------------------------------------------------------------");
            var users = _userManager.GetAll();
            Console.WriteLine("Id - Kullanici Adi - Kullanici SoyAdi - e-mail - sifre");
            foreach (var user in users.Data)
            {
                Console.WriteLine("{0} - {1} - {2} - {3}",
                    user.UserId, user.FirstName, user.LastName, user.Email);
            }
        }

        public override void Add()
        {
            User newUser = CreateData();

            _userManager.Add(newUser);
            Get();
        }

        public override void Delete()
        {
            Get();

            Console.WriteLine("-------------------------------------------------------------");
            Console.Write("Silmek istediginiz kullanicinin ID'sini secin: ");
            int Id = Convert.ToInt32(Console.ReadLine());
            User newUser = new User() { UserId = Id };

            _userManager.Delete(newUser);
            Get();
        }

        public override void Update()
        {
            Get();

            Console.WriteLine("-------------------------------------------------------------");
            Console.Write("Guncellemek istediginiz kullanicinin ID'sini secin: ");
            int Id = Convert.ToInt32(Console.ReadLine());
            var newUser = CreateData();
            newUser.UserId = Id;

            _userManager.Update(newUser);
            Get();
        }

        private User CreateData()
        {
            User newUser = new User();

            Console.Write("Kullanici Adi Giriniz: ");
            newUser.FirstName = Console.ReadLine();

            Console.Write("Kullanici SoyAdi Giriniz: ");
            newUser.LastName = Console.ReadLine();

            Console.Write("Kullanici Maili Giriniz: ");
            newUser.Email = Console.ReadLine();

            Console.Write("Kullanici Sifresi Giriniz: ");
            var Password = Console.ReadLine();

            return newUser;
        }
    }
}
