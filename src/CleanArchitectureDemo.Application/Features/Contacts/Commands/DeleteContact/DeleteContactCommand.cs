using CleanArchitectureDemo.Domain.Entities;
using CleanArchitectureDemo.Shared;
using MediatR;

namespace CleanArchitectureDemo.Application.Features.Contacts.Commands.DeleteContact;

public record DeleteContactCommand : IRequest<Result<Contact>>
{
    public int Id { get; set; }

    public DeleteContactCommand()
    {

    }

    public DeleteContactCommand(int id)
    {
        Id = id;
    }
}
