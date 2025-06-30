namespace BookStore.Api.DTOs;

public class BookDto
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string Author { get; set; } = default!;
    public string? CategoryName { get; set; }
}