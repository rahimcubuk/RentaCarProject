using Core.Entities;

namespace Entities.Concrete.Models
{
    public class Payment : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int RentalId { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
