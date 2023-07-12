using CleanArchitectureDemo.Domain.Common;
using CleanArchitectureDemo.Domain.Entities;

namespace CleanArchitectureDemo.Application.Features.Contacts.Commands.DeleteContact;

public class ContactDeletedEvent : BaseEvent
{
    public Contact Contact { get; }

    public ContactDeletedEvent(Contact contact)
    {
        Contact = contact;
    }
}
