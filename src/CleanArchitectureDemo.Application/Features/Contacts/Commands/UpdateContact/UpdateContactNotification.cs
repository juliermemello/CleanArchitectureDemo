using MediatR;

namespace CleanArchitectureDemo.Application.Features.Contacts.Commands.UpdateContact;

public class UpdateContactNotification : INotification
{
    public int Id { get; set; }
}
