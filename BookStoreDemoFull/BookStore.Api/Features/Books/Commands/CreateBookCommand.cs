using MediatR;
using BookStore.Api.DTOs;
using BookStore.Api.Data;
using AutoMapper;

namespace BookStore.Api.Features.Books.Commands;

public record CreateBookCommand(CreateBookDto Dto) : IRequest<BookDto>;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, BookDto>
{
    private readonly BookStoreContext _ctx;
    private readonly IMapper _mapper;

    public CreateBookCommandHandler(BookStoreContext ctx, IMapper mapper)
    {
        _ctx = ctx;
        _mapper = mapper;
    }

    public async Task<BookDto> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Book>(request.Dto);
        _ctx.Books.Add(entity);
        await _ctx.SaveChangesAsync(cancellationToken);
        return _mapper.Map<BookDto>(entity);
    }
}