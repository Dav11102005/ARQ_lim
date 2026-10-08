namespace Application.DTOs;

public sealed record ProductDto(
    Guid Id,
    string Name,
    string Description,
    decimal Price,
    DateTime CreatedAtUtc);

public sealed record CreateProductRequest(
    string Name,
    string Description,
    decimal Price);
