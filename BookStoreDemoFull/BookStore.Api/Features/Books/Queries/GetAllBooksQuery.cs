using MediatR;
using BookStore.Api.DTOs;
using BookStore.Api.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Features.Books.Queries;

public record GetAllBooksQuery : IRequest<IEnumerable<BookDto>>;

public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<BookDto>>
{
    private readonly BookStoreContext _ctx;
    private readonly IMapper _mapper;

    public GetAllBooksQueryHandler(BookStoreContext ctx, IMapper mapper)
    {
        _ctx = ctx;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await _ctx.Books.Include(b => b.Category).ToListAsync(cancellationToken);
        return _mapper.Map<IEnumerable<BookDto>>(books);
    }
}