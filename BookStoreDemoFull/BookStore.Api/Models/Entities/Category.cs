namespace BookStore.Api.Models.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public ICollection<Book>? Books { get; set; }
}