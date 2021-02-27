using Core.Entities;

namespace Project.Entities.Concrete.Models
{
    public class Brand : IEntity
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }
}
