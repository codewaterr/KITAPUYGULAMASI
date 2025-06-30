using Microsoft.AspNetCore.Mvc;
using MediatR;
using BookStore.Api.DTOs;

namespace BookStore.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IMediator _mediator;
    public BooksController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public Task<IEnumerable<BookDto>> GetAll() =>
        _mediator.Send(new GetAllBooksQuery());

    [HttpGet("{id}")]
    public Task<BookDto> GetById(int id) =>
        _mediator.Send(new GetBookByIdQuery(id));

    [HttpPost]
    public Task<BookDto> Create(CreateBookDto dto) =>
        _mediator.Send(new CreateBookCommand(dto));

    [HttpPut("{id}")]
    public Task<BookDto> Update(int id, UpdateBookDto dto) =>
        _mediator.Send(new UpdateBookCommand(id, dto));

    [HttpDelete("{id}")]
    public Task<Unit> Delete(int id) =>
        _mediator.Send(new DeleteBookCommand(id));
}