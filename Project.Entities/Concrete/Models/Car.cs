﻿using Project.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Project.Entities.Concrete.Models
{
    public class Car : IEntity
    {
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        [MinLength(2, ErrorMessage = "Arac ismi minimum 2 karakter olmalidir.")]
        public string CarName { get; set; }
        public string ModelYear { get; set; }
        [Range(0, 99999, ErrorMessage = "Arac gunluk fiyati minimum 0(sifir) olmalidir.")]
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
