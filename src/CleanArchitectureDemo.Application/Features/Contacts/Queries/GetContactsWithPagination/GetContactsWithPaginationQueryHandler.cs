using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitectureDemo.Application.Extensions;
using CleanArchitectureDemo.Application.Interfaces.Repositories;
using CleanArchitectureDemo.Domain.Entities;
using CleanArchitectureDemo.Shared;
using MediatR;

namespace CleanArchitectureDemo.Application.Features.Contacts.Queries.GetContactsWithPagination;

internal class GetContactsWithPaginationQueryHandler : IRequestHandler<GetContactsWithPaginationQuery, PaginatedResult<GetContactsWithPaginationDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetContactsWithPaginationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PaginatedResult<GetContactsWithPaginationDto>> Handle(GetContactsWithPaginationQuery query, CancellationToken cancellationToken)
    {
        return await _unitOfWork
            .Repository<Contact>()
            .Entities
            .OrderBy(x => x.Name)
            .ProjectTo<GetContactsWithPaginationDto>(_mapper.ConfigurationProvider)
            .ToPaginatedListAsync(query.PageNumber, query.PageSize, cancellationToken);
    }
}
