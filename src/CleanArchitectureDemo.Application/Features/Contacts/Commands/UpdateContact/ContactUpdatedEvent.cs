using CleanArchitectureDemo.Domain.Common;
using CleanArchitectureDemo.Domain.Entities;

namespace CleanArchitectureDemo.Application.Features.Contacts.Commands.UpdateContact;

public class ContactUpdatedEvent : BaseEvent
{
    public Contact Contact { get; }

    public ContactUpdatedEvent(Contact contact)
    {
        Contact = contact;
    }
}
