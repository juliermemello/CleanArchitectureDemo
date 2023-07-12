using CleanArchitectureDemo.Application.Interfaces.Repositories;
using CleanArchitectureDemo.Domain.Entities;

namespace CleanArchitectureDemo.Persistence.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly IGenericRepository<Contact> _repository;

    public ContactRepository(IGenericRepository<Contact> repository)
    {
        _repository = repository;
    }
}
