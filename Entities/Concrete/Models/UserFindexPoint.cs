using Core.Entities;

namespace Entities.Concrete.Models
{
    public class UserFindexPoint : IEntity
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public int FindexPoint { get; set; }
    }
}
