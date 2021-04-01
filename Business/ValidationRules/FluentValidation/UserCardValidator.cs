using Entities.Concrete.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserCardValidator : AbstractValidator<UserCard>
    {
        public UserCardValidator()
        {
            RuleFor(uc => uc.CardId).NotEmpty();
            RuleFor(uc => uc.UserId).NotEmpty();
        }
    }
}
