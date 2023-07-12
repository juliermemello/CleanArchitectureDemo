using FluentValidation;

namespace CleanArchitectureDemo.Application.Features.Contacts.Commands.UpdateContact;

public class UpdateContactCommandValidator : AbstractValidator<UpdateContactCommand>
{
    public UpdateContactCommandValidator() 
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("The id field must be greater than zero.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("The name field is required.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("The email field is required.")
            .EmailAddress().WithMessage("The email field does not contain a valid value.");
    }
}
