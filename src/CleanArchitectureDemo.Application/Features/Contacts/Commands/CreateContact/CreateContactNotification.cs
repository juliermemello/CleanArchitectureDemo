using MediatR;

namespace CleanArchitectureDemo.Application.Features.Contacts.Commands.CreateContact;

public class CreateContactNotification : INotification
{
    public int Id { get; set; }
}
