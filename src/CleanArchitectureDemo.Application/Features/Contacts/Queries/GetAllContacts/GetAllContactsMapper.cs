using AutoMapper;
using CleanArchitectureDemo.Domain.Entities;

namespace CleanArchitectureDemo.Application.Features.Contacts.Queries.GetAllContacts;

public class GetAllContactsMapper : Profile
{
    public GetAllContactsMapper() 
    { 
        CreateMap<GetAllContactsDto, Contact>().ReverseMap();
    }
}
