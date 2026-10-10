using System.Net;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Xunit;
using Application.Interfaces;

namespace BadCleanArch.Tests.IntegrationTests;

public class WebHostProductsTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    private class FakeProductService : IProductService
    {
        public Task<ProductDto> CreateAsync(CreateProductRequest request)
        {
            var dto = new ProductDto(Guid.NewGuid(), request.Name, request.Description, request.Price, DateTime.UtcNow);
            return Task.FromResult(dto);
        }

        public Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            IEnumerable<ProductDto> list = new[] { new ProductDto(Guid.NewGuid(), "P", "D", 1m, DateTime.UtcNow) };
            return Task.FromResult(list);
        }

        public Task<ProductDto?> GetByIdAsync(Guid id)
        {
            var dto = new ProductDto(id, "P", "D", 1m, DateTime.UtcNow);
            return Task.FromResult<ProductDto?>(dto);
        }
    }

    public WebHostProductsTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                services.RemoveAll<IProductService>();
                services.AddSingleton<IProductService, FakeProductService>();
            });
        });
    }

    [Fact]
    public async Task GetAll_Endpoint_ReturnsOk()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/api/Products");

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        Assert.False(string.IsNullOrWhiteSpace(content));
    }
}
