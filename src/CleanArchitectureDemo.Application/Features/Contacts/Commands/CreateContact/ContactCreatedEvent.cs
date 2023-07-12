using CleanArchitectureDemo.Domain.Common;
using CleanArchitectureDemo.Domain.Entities;

namespace CleanArchitectureDemo.Application.Features.Contacts.Commands.CreateContact;

public class ContactCreatedEvent : BaseEvent
{
    public Contact Contact { get; }

    public ContactCreatedEvent(Contact contact)
    {
        Contact = contact;
    }
}
