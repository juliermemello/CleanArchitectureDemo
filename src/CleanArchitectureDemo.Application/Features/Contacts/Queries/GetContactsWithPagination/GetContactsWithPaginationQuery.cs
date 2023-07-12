using CleanArchitectureDemo.Shared;
using MediatR;

namespace CleanArchitectureDemo.Application.Features.Contacts.Queries.GetContactsWithPagination;

public class GetContactsWithPaginationQuery : IRequest<PaginatedResult<GetContactsWithPaginationDto>>
{
    public GetContactsWithPaginationQuery() { }

    public GetContactsWithPaginationQuery(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }

    public int PageNumber { get; set; }

    public int PageSize { get; set; }
}
