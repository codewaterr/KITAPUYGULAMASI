namespace BookStore.Api.DTOs;

public class UpdateBookDto
{
    public string Title { get; set; } = default!;
    public string Author { get; set; } = default!;
    public int CategoryId { get; set; }
}