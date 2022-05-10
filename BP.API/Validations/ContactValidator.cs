using BP.API.Models;
using FluentValidation;

namespace BP.API.Validations
{
    public class ContactValidator : AbstractValidator<ContactDVO>
    {
        public ContactValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("FullName cannot be empty");
            RuleFor(x => x.Id).LessThan(100).WithMessage("Id cannot be greater than 100");
        }
    }
}
