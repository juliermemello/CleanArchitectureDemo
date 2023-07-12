using CleanArchitectureDemo.Shared;
using MediatR;

namespace CleanArchitectureDemo.Application.Features.Contacts.Queries.GetContactById;

public class GetContactByIdQuery : IRequest<Result<GetContactByIdDto>>
{
    public GetContactByIdQuery()
    {

    }

    public GetContactByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
