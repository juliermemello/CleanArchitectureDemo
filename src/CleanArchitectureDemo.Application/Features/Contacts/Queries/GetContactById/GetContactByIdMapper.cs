using AutoMapper;
using CleanArchitectureDemo.Domain.Entities;

namespace CleanArchitectureDemo.Application.Features.Contacts.Queries.GetContactById;

public class GetContactByIdMapper : Profile
{
    public GetContactByIdMapper() 
    {
        CreateMap<GetContactByIdDto, Contact>().ReverseMap();
    }
}
