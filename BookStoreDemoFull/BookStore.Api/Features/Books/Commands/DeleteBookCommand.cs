using MediatR;
using BookStore.Api.Data;

namespace BookStore.Api.Features.Books.Commands;

public record DeleteBookCommand(int Id) : IRequest;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
{
    private readonly BookStoreContext _ctx;

    public DeleteBookCommandHandler(BookStoreContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var entity = await _ctx.Books.FindAsync(request.Id);
        if (entity is not null) _ctx.Books.Remove(entity);
        await _ctx.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}