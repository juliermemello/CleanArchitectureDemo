using AutoMapper;
using CleanArchitectureDemo.Domain.Entities;

namespace CleanArchitectureDemo.Application.Features.Contacts.Commands.UpdateContact;

public class UpdateContactCommandMapper : Profile
{
    public UpdateContactCommandMapper() 
    {
        CreateMap<UpdateContactCommand, Contact>().ReverseMap();
    }
}
