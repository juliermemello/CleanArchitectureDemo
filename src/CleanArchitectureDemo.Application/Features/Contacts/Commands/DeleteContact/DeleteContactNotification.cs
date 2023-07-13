using MediatR;

namespace CleanArchitectureDemo.Application.Features.Contacts.Commands.DeleteContact;

public class DeleteContactNotification : INotification
{
    public int Id { get; set; }
}
