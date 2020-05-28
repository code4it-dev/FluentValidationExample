using FluentValidation;
using FluentValidationExample.Models;

namespace FluentValidationExample.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Missing first name");
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).EmailAddress().WithMessage("Please enter a valid email");
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Password).Must(BeValidPassword);
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Passwords must be the same");
        }

        private bool BeValidPassword(string arg)
        {
            return true;
        }
    }
}
