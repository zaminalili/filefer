using filefer.Entity.Models;
using FluentValidation;

namespace filefer.Service.FluentValidation
{
    public class LoginValidator: AbstractValidator<LoginViewModel>
    {
        public LoginValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Key cannot be empty.")
                .NotNull().WithMessage("Key cannot be empty.")
                .MinimumLength(5).WithMessage("Key length must be 5 characters.")
                .MaximumLength(5).WithMessage("Key length must be 5 characters.");
        }
    }
}
