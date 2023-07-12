using CleanArchitectureDemo.Shared;
using MediatR;

namespace CleanArchitectureDemo.Application.Features.Contacts.Queries.GetAllContacts;

public class GetAllContactsQuery : IRequest<Result<List<GetAllContactsDto>>>
{
}
