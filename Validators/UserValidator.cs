using FluentValidation;
using FluentValidationExample.Models;
using System.Text.RegularExpressions;

namespace FluentValidationExample.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.FirstName)
                .MaximumLength(20).WithMessage("Is your first name that long?? Really??")
                .NotEmpty().MinimumLength(3);

            RuleFor(x => x.LastName).NotEmpty();

            RuleFor(x => x.Password)
                .NotNull()
                .Length(5, 15)
                .Must(HasValidPassword);

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password)
                .WithMessage("Passwords must match");
        }


        private bool HasValidPassword(string pw)
        {
            var lowercase = new Regex("[a-z]+");
            var uppercase = new Regex("[A-Z]+");
            var digit = new Regex("(\\d)+");
            var symbol = new Regex("(\\W)+");

            return (lowercase.IsMatch(pw) && uppercase.IsMatch(pw) && digit.IsMatch(pw) && symbol.IsMatch(pw));

        }
    }

}
