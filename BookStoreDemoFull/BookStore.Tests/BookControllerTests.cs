using Xunit;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;

namespace BookStore.Tests;

public class BookControllerTests : IClassFixture<WebApplicationFactory<BookStore.Api.Program>>
{
    private readonly HttpClient _client;

    public BookControllerTests(WebApplicationFactory<BookStore.Api.Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetAll_ReturnsSuccess()
    {
        var response = await _client.GetAsync("/api/books");
        response.EnsureSuccessStatusCode();
    }
}