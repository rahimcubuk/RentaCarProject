using Core.Entities;

namespace Entities.Concrete.DTOs
{
    public class CarDetailsDto : IDto
    {
        public int CarId { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public string CarName { get; set; }
        public string ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
