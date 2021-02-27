using Core.Entities;

namespace Project.Entities.Concrete.Models
{
    public class Color : IEntity
    {
        public int ColorId { get; set; }
        public string ColorName { get; set; }
    }
}
