using Entities.Concrete.Models;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CardValidator : AbstractValidator<FakeCreditCard>
    {
        public CardValidator()
        {
            RuleFor(c => c.CardNumber).NotEmpty();
            RuleFor(c => c.CardNumber).Length(16);

            RuleFor(c => c.CardCvv).NotEmpty();
            RuleFor(c => c.CardCvv).Length(3);

            RuleFor(c => c.NameOnTheCard).NotEmpty();
            RuleFor(c => c.TotalMoney).NotEmpty();
        }
    }
}
