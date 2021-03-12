using Core.Entities;
using System;

namespace Entities.Concrete.DTOs
{
    public class RentalDetailsDto : IDto
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public DateTime RentDate { get; set; }
        public Nullable<DateTime> ReturnDate { get; set; }
    }
}
