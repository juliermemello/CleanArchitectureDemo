using AutoMapper;
using CleanArchitectureDemo.Application.Interfaces.Repositories;
using CleanArchitectureDemo.Domain.Entities;
using CleanArchitectureDemo.Shared;
using MediatR;

namespace CleanArchitectureDemo.Application.Features.Contacts.Commands.CreateContact;

internal class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, Result<Contact>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateContactCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<Contact>> Handle(CreateContactCommand request, CancellationToken cancellationToken = default)
    {
        var contact = _mapper.Map<Contact>(request);

        contact.CreatedBy = 0;
        contact.CreatedDate = DateTime.Now;
        contact.UpdatedBy = 0;
        contact.UpdatedDate = DateTime.Now;

        await _unitOfWork.Repository<Contact>().AddAsync(contact);

        contact.AddDomainEvent(new ContactCreatedEvent(contact));

        await _unitOfWork.Save(cancellationToken);

        return await Result<Contact>.SuccessAsync(contact, "Contact Created");
    }
}
