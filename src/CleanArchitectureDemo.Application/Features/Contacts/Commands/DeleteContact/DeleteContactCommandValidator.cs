using FluentValidation;

namespace CleanArchitectureDemo.Application.Features.Contacts.Commands.DeleteContact;

public class DeleteContactCommandValidator : AbstractValidator<DeleteContactCommand>
{
    public DeleteContactCommandValidator() 
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("The id field must be greater than zero.");
    }
}
