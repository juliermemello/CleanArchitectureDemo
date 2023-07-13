using CleanArchitectureDemo.Domain.Entities;
using CleanArchitectureDemo.Shared;
using MediatR;

namespace CleanArchitectureDemo.Application.Features.Contacts.Commands.UpdateContact;

public record UpdateContactCommand : IRequest<Result<Contact>>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string MobilePhone { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public string HomePage { get; set; }
}
