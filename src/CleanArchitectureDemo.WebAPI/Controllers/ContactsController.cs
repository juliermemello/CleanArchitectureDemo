using CleanArchitectureDemo.Application.Features.Contacts.Commands.CreateContact;
using CleanArchitectureDemo.Application.Features.Contacts.Commands.DeleteContact;
using CleanArchitectureDemo.Application.Features.Contacts.Commands.UpdateContact;
using CleanArchitectureDemo.Application.Features.Contacts.Queries.GetAllContacts;
using CleanArchitectureDemo.Application.Features.Contacts.Queries.GetContactById;
using CleanArchitectureDemo.Application.Features.Contacts.Queries.GetContactsWithPagination;
using CleanArchitectureDemo.Domain.Entities;
using CleanArchitectureDemo.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureDemo.WebAPI.Controllers;

public class ContactsController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public ContactsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<Result<Contact>>> Create(CreateContactCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Result<Contact>>> Update(UpdateContactCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Result<Contact>>> Delete(int id)
    {
        return await _mediator.Send(new DeleteContactCommand(id));
    }

    [HttpGet]
    public async Task<ActionResult<Result<List<GetAllContactsDto>>>> Get()
    {
        return await _mediator.Send(new GetAllContactsQuery());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Result<GetContactByIdDto>>> GetPlayersById(int id)
    {
        return await _mediator.Send(new GetContactByIdQuery(id));
    }

    [HttpGet]
    [Route("paged")]
    public async Task<ActionResult<PaginatedResult<GetContactsWithPaginationDto>>> GetContactsWithPagination([FromQuery] GetContactsWithPaginationQuery query)
    {
        return await _mediator.Send(query);
    }
}
