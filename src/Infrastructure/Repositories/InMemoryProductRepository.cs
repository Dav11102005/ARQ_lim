namespace Infrastructure.Repositories;

using Domain.Entities;
using Domain.Interfaces;

public sealed class InMemoryProductRepository : IProductRepository
{
    private readonly List<Product> _products = new();

    public InMemoryProductRepository()
    {
        _products.AddRange(new[]
        {
            new Product { Name = "Laptop Pro", Description = "Portátil para trabajo y desarrollo.", Price = 1499.99m },
            new Product { Name = "Monitor 27\"", Description = "Pantalla IPS para productividad.", Price = 799.00m },
            new Product { Name = "Teclado Mecánico", Description = "Teclado con switches lineales.", Price = 129.50m }
        });
    }

    public Task<IEnumerable<Product>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<Product>>(_products.OrderBy(product => product.Name).ToList());
    }

    public Task<Product?> GetByIdAsync(Guid id)
    {
        return Task.FromResult(_products.FirstOrDefault(product => product.Id == id));
    }

    public Task<Product> AddAsync(Product product)
    {
        _products.Add(product);
        return Task.FromResult(product);
    }
}
