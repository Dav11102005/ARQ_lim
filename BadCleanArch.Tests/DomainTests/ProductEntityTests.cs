using Domain.Entities;
using Xunit;

namespace BadCleanArch.Tests.DomainTests;

public class ProductEntityTests
{
    [Fact]
    public void DefaultValues_AreSet()
    {
        var p = new Product();

        Assert.NotEqual(Guid.Empty, p.Id);
        Assert.Equal(string.Empty, p.Name);
        Assert.True(p.CreatedAtUtc <= DateTime.UtcNow);
    }

    [Fact]
    public void CanSetProperties()
    {
        var p = new Product { Name = "A", Description = "B", Price = 9.9m };

        Assert.Equal("A", p.Name);
        Assert.Equal("B", p.Description);
        Assert.Equal(9.9m, p.Price);
    }
}
