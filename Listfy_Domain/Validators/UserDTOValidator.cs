using FluentValidation;
using Listfy_Domain.DTOs;

namespace Listfy_Domain.Validators;

public class UserDTOValidator : AbstractValidator<UserDTO>
{
    public UserDTOValidator()
    {
        RuleFor(user => user.name)
            .NotEmpty().WithMessage("Name is required")
            .Length(2, 50).WithMessage("Name must be between 2 and 50 characters");
        
        RuleFor(user => user.user_name)
            .NotEmpty().WithMessage("Username is required")
            .Length(2, 50).WithMessage("Username must be between 2 and 50 characters");
        
        RuleFor(user => user.email)
            .NotEmpty().WithMessage("The email is required.")
            .EmailAddress().WithMessage("The email must be valid.");

        RuleFor(user => user.password)
            .NotEmpty().WithMessage("The password is required.")
            .MinimumLength(6).WithMessage("The password must be at least 6 characters long.");
    }
}