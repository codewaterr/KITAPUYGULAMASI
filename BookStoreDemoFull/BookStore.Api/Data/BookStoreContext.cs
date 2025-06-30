using Microsoft.EntityFrameworkCore;
using BookStore.Api.Models.Entities;

namespace BookStore.Api.Data;

public class BookStoreContext : DbContext
{
    public BookStoreContext(DbContextOptions<BookStoreContext> options)
        : base(options) { }

    public DbSet<Book> Books => Set<Book>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .Property(b => b.Title)
            .HasMaxLength(200)
            .IsRequired();
    }
}