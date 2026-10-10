using Application.DTOs;
using Application.Validators;
using Xunit;

namespace BadCleanArch.Tests;

public class ProductValidatorTests
{
    [Fact]
    public void Validate_ShouldAcceptValidRequest()
    {
        var request = new CreateProductRequest("Laptop", string.Empty, 1500m);

        var ex = Record.Exception(() => ProductValidator.Validate(request));

        Assert.Null(ex);
    }

    [Fact]
    public void Validate_ShouldThrow_WhenNameIsEmpty()
    {
        var request = new CreateProductRequest(string.Empty, string.Empty, 1500m);

        Assert.Throws<ArgumentException>(() => ProductValidator.Validate(request));
    }

    [Fact]
    public void Validate_ShouldThrow_WhenPriceIsZero()
    {
        var request = new CreateProductRequest("Laptop", string.Empty, 0m);

        Assert.Throws<ArgumentOutOfRangeException>(() => ProductValidator.Validate(request));
    }

    [Fact]
    public void Validate_ShouldThrow_WhenRequestIsNull()
    {
        CreateProductRequest request = null!;

        Assert.Throws<ArgumentNullException>(() => ProductValidator.Validate(request));
    }
}
