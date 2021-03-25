using Core.Entities;
using System;

namespace Entities.Concrete.Models
{
    public class FakeCreditCard : IEntity
    {
        public int Id { get; set; }
        public string NameOnTheCard { get; set; }
        public string CardNumber { get; set; }
        public string CardCvv { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public decimal TotalMoney { get; set; }
    }
}
