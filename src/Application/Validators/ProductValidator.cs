using Application.DTOs;

namespace Application.Validators;

public static class ProductValidator
{
    public static void Validate(CreateProductRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);

        if (string.IsNullOrWhiteSpace(request.Name))
        {
            throw new ArgumentException("El nombre del producto es obligatorio.", nameof(request));
        }

        if (request.Price <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(request), "El precio debe ser mayor que cero.");
        }
    }
}
