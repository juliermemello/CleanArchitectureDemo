using AutoMapper;
using CleanArchitectureDemo.Domain.Entities;

namespace CleanArchitectureDemo.Application.Features.Contacts.Commands.CreateContact;

public class CreateContactCommandMapper : Profile
{
    public CreateContactCommandMapper() 
    { 
        CreateMap<CreateContactCommand, Contact>().ReverseMap();
    }
}
