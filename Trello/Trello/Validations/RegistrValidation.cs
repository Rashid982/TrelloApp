using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.ViewModel;

namespace Trello.Validations
{
    public class RegistrValidation : AbstractValidator<RegistrationVM>
    {
        public RegistrValidation()
        {
            RuleFor(Name => Name.Name).MinimumLength(3).WithMessage("The name must contain min. 3 character!");
            RuleFor(Surname => Surname.Surname).MinimumLength(3).WithMessage("The surname must contain min. 3 character!");
            RuleFor(FamilyName => FamilyName.FamilyName).MinimumLength(3).WithMessage("The surname must contain min. 3 character!");
            RuleFor(Number => Number.Number).MinimumLength(10);
        }
    }
}
