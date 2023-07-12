using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitectureDemo.Application.Interfaces.Repositories;
using CleanArchitectureDemo.Domain.Entities;
using CleanArchitectureDemo.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureDemo.Application.Features.Contacts.Queries.GetAllContacts;

internal class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQuery, Result<List<GetAllContactsDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllContactsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<List<GetAllContactsDto>>> Handle(GetAllContactsQuery query, CancellationToken cancellationToken)
    {
        var contacts = await _unitOfWork
            .Repository<Contact>()
            .Entities
            .ProjectTo<GetAllContactsDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return await Result<List<GetAllContactsDto>>.SuccessAsync(contacts);
    }
}
