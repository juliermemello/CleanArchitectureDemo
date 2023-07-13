using AutoMapper;
using CleanArchitectureDemo.Application.Interfaces.Repositories;
using CleanArchitectureDemo.Domain.Entities;
using CleanArchitectureDemo.Shared;
using MediatR;

namespace CleanArchitectureDemo.Application.Features.Contacts.Commands.UpdateContact;

internal class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, Result<Contact>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateContactCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<Contact>> Handle(UpdateContactCommand command, CancellationToken cancellationToken = default)
    {
        var contact = await _unitOfWork.Repository<Contact>().GetByIdAsync(command.Id);

        if (contact != null)
        {
            var contactUpdate = _mapper.Map<Contact>(command);

            contactUpdate.CreatedBy = contact.CreatedBy;
            contactUpdate.CreatedDate = contact.CreatedDate;
            contactUpdate.UpdatedBy = 0;
            contactUpdate.UpdatedDate = DateTime.UtcNow;

            await _unitOfWork.Repository<Contact>().UpdateAsync(contactUpdate);

            contact.AddDomainEvent(new ContactUpdatedEvent(contactUpdate));

            await _unitOfWork.Save(cancellationToken);

            return await Result<Contact>.SuccessAsync(contactUpdate, "Contact Updated");
        }

        return await Result<Contact>.FailureAsync("Contact Not Found");
    }
}