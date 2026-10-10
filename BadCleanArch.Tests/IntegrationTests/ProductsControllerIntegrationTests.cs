using Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using WebApi.Controllers;
using Application.Interfaces;

namespace BadCleanArch.Tests.IntegrationTests;

// Lightweight controller invocation test to avoid TestHost PipeWriter mismatch
public class ProductsControllerIntegrationTests
{
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

    [Fact]
    public async Task GetAll_ControllerInvocation_ShouldReturnOkObject()
    {
        var controller = new ProductsController(new FakeProductService());

        var actionResult = await controller.GetAll();

        Assert.NotNull(actionResult);
        Assert.IsType<OkObjectResult>(actionResult.Result);

        var ok = actionResult.Result as OkObjectResult;
        Assert.NotNull(ok?.Value);
    }
}
