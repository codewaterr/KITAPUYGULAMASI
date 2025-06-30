using MediatR;
using BookStore.Api.DTOs;
using BookStore.Api.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Features.Books.Commands;

public record UpdateBookCommand(int Id, UpdateBookDto Dto) : IRequest<BookDto>;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, BookDto>
{
    private readonly BookStoreContext _ctx;
    private readonly IMapper _mapper;

    public UpdateBookCommandHandler(BookStoreContext ctx, IMapper mapper)
    {
        _ctx = ctx;
        _mapper = mapper;
    }

    public async Task<BookDto> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var entity = await _ctx.Books.FindAsync(request.Id);
        _mapper.Map(request.Dto, entity!);
        await _ctx.SaveChangesAsync(cancellationToken);
        return _mapper.Map<BookDto>(entity!);
    }
}