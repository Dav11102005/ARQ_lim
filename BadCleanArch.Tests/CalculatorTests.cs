using Application.Services;
using Xunit;

namespace BadCleanArch.Tests;

public class CalculatorTests
{
    [Fact]
    public void Add_ShouldReturnSum()
    {
        var result = Calculator.Add(2, 3);

        Assert.Equal(5, result);
    }

    [Fact]
    public void Subtract_ShouldReturnDifference()
    {
        var result = Calculator.Subtract(5, 3);

        Assert.Equal(2, result);
    }
}
