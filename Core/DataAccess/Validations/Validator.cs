using System;
using System.Data.Entity.Validation;

namespace Project.Core.DataAccess.Validations
{
    public static class Validator
    {
        public static void ValidationErrors(DbEntityValidationException errors)
        {
            foreach (var error in errors.EntityValidationErrors)
            {
                foreach (var validationError in error.ValidationErrors)
                {
                    Console.WriteLine("Hata: {0}", validationError.ErrorMessage);
                }
            }
        }
    }
}
