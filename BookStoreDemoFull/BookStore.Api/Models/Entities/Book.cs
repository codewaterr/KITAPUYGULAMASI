namespace BookStore.Api.Models.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string Author { get; set; } = default!;
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}