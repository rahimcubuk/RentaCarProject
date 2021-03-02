using Entities.Concrete.Models;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    class CarImageValidator : AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(c => c.CarId).NotNull();
            RuleFor(c => c.Id).NotNull();
        }
    }
}
