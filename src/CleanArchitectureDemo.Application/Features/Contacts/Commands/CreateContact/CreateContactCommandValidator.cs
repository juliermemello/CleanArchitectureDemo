using FluentValidation;

namespace CleanArchitectureDemo.Application.Features.Contacts.Commands.CreateContact;

public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
{
    public CreateContactCommandValidator() 
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("The name field is required.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("The email field is required.")
            .EmailAddress().WithMessage("The email field does not contain a valid value.");
    }
}
