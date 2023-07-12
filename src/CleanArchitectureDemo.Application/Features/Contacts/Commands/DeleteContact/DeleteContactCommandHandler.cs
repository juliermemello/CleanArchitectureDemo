using CleanArchitectureDemo.Application.Interfaces.Repositories;
using CleanArchitectureDemo.Domain.Entities;
using CleanArchitectureDemo.Shared;
using MediatR;

namespace CleanArchitectureDemo.Application.Features.Contacts.Commands.DeleteContact;

internal class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, Result<Contact>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteContactCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Contact>> Handle(DeleteContactCommand command, CancellationToken cancellationToken = default)
    {
        var contact = await _unitOfWork.Repository<Contact>().GetByIdAsync(command.Id);

        if (contact != null)
        {
            await _unitOfWork.Repository<Contact>().DeleteAsync(contact);

            contact.AddDomainEvent(new ContactDeletedEvent(contact));

            await _unitOfWork.Save(cancellationToken);

            return await Result<Contact>.SuccessAsync(contact, "Contact Deleted");
        }

        return await Result<Contact>.FailureAsync("Contact Not Found");
    }
}
