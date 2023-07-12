using AutoMapper;
using CleanArchitectureDemo.Domain.Entities;

namespace CleanArchitectureDemo.Application.Features.Contacts.Queries.GetContactsWithPagination;

public class GetContactsWithPaginationMapper : Profile
{
    public GetContactsWithPaginationMapper() 
    {
        CreateMap<GetContactsWithPaginationDto, Contact>().ReverseMap();
    }
}
