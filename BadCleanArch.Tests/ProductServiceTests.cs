using System.Linq;
using Application.DTOs;
using Application.Services;
using Domain.Entities;
using Infrastructure.Repositories;
using Xunit;

namespace BadCleanArch.Tests;

public class ProductServiceTests
{
    [Fact]
    public async Task GetAllAsync_ReturnsMappedDtos()
    {
        var repo = new InMemoryProductRepository();
        var svc = new ProductService(repo);

        var result = await svc.GetAllAsync();

        Assert.NotNull(result);
        Assert.True(result.Any());
        Assert.All(result, dto => Assert.IsType<ProductDto>(dto));
    }

    [Fact]
    public async Task GetByIdAsync_WhenMissing_ReturnsNull()
    {
        var repo = new InMemoryProductRepository();
        var svc = new ProductService(repo);

        var dto = await svc.GetByIdAsync(Guid.NewGuid());

        Assert.Null(dto);
    }

    [Fact]
    public async Task CreateAsync_TrimsAndReturnsDto()
    {
        var repo = new InMemoryProductRepository();
        var svc = new ProductService(repo);

        var request = new CreateProductRequest("  Name  ", "  Desc  ", 123.45m);
        var created = await svc.CreateAsync(request);

        Assert.NotNull(created);
        Assert.Equal("Name", created.Name);
        Assert.Equal("Desc", created.Description);
        Assert.Equal(123.45m, created.Price);
        Assert.NotEqual(Guid.Empty, created.Id);
    }
}
