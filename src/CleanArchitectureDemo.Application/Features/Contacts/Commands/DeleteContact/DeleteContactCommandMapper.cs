using AutoMapper;
using CleanArchitectureDemo.Domain.Entities;

namespace CleanArchitectureDemo.Application.Features.Contacts.Commands.DeleteContact
{
    public class DeleteContactCommandMapper : Profile
    {
        public DeleteContactCommandMapper() 
        { 
            CreateMap<DeleteContactCommand, Contact>().ReverseMap();
        }
    }
}
