using Core.Entities;

namespace Entities.Concrete.DTOs
{
    public class UserCardDetailsDto : IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CardId { get; set; }
        public string UserName { get; set; }
        public string NameOnTheCard { get; set; }
        public string CardNumber { get; set; }
        public string CardCvv { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
    }
}
