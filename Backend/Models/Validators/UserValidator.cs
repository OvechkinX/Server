using Backend.DTOs;
using FluentValidation;


namespace Backend.Models.Validators
{
    public class UserValidator : AbstractValidator<UserForRegisterDto>
    {

        public UserValidator()
        {

            RuleFor(user => user.Username)
                .NotEmpty()
                .WithMessage("Nazwa użytkownika jest zbyt krótka");
            RuleFor(user => user.FirstName)
                .NotEmpty()
                .WithMessage("Imię jest wymagane");
            RuleFor(user => user.LastName)
                .NotEmpty()
                .WithMessage("Nazwisko jest wymagane");
            RuleFor(user => user.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Niepoprawny Email");
            RuleFor(user => user.Password)
                .NotEmpty()
                .WithMessage("Hasło jest zbyt krótkie");
            RuleFor(user => user.Role)
                .NotEmpty()
                .WithMessage("Wybierz rolę");

        }

    }
}
