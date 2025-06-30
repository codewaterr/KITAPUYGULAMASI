using MediatR;
using BookStore.Api.DTOs;
using BookStore.Api.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Features.Books.Queries;

public record GetBookByIdQuery(int Id) : IRequest<BookDto>;

public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDto>
{
    private readonly BookStoreContext _ctx;
    private readonly IMapper _mapper; 

    public GetBookByIdQueryHandler(BookStoreContext ctx, IMapper mapper)
    {
        _ctx = ctx;
        _mapper = mapper;
    }

    public async Task<BookDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = await _ctx.Books.Include(b => b.Category)
            .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);
        return _mapper.Map<BookDto>(book!);
    }
}