using Core.Entities;

namespace Entities.Concrete.DTOs
{
    public class CustomerDetailsDto : IDto
    {
        public int CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public byte[] Password { get; set; }
    }
}
