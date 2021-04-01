using Core.Entities;

namespace Entities.Concrete.Models
{
    public class UserCard : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CardId { get; set; }
    }
}
