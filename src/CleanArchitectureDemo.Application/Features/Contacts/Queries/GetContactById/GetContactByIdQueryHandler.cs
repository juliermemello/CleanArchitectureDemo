using AutoMapper;
using CleanArchitectureDemo.Application.Interfaces.Repositories;
using CleanArchitectureDemo.Domain.Entities;
using CleanArchitectureDemo.Shared;
using MediatR;

namespace CleanArchitectureDemo.Application.Features.Contacts.Queries.GetContactById;

internal class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, Result<GetContactByIdDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetContactByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<GetContactByIdDto>> Handle(GetContactByIdQuery query, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.Repository<Contact>().GetByIdAsync(query.Id);

        var contact = _mapper.Map<GetContactByIdDto>(entity);

        return await Result<GetContactByIdDto>.SuccessAsync(contact);
    }
}
