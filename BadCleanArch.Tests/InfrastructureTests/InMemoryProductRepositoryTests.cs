using System.Linq;
using Domain.Entities;
using Infrastructure.Repositories;
using Xunit;

namespace BadCleanArch.Tests.InfrastructureTests;

public class InMemoryProductRepositoryTests
{
    [Fact]
    public async Task GetAllAsync_ReturnsInitialSeedOrdered()
    {
        var repo = new InMemoryProductRepository();

        var all = (await repo.GetAllAsync()).ToList();

        Assert.Equal(3, all.Count);
        var names = all.Select(p => p.Name).ToList();
        var sorted = names.OrderBy(n => n).ToList();
        Assert.Equal(sorted, names);
    }

    [Fact]
    public async Task AddAsync_ThenGetById_ReturnsSame()
    {
        var repo = new InMemoryProductRepository();
        var product = new Product { Name = "X", Description = "Y", Price = 1m };

        var added = await repo.AddAsync(product);
        var fetched = await repo.GetByIdAsync(added.Id);

        Assert.NotNull(fetched);
        Assert.Equal(added.Id, fetched!.Id);
        Assert.Equal("X", fetched.Name);
    }
}
