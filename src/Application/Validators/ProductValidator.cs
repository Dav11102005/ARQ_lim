namespace Application.Validators;

using Application.DTOs;

public static class ProductValidator
{
    public static void Validate(CreateProductRequest request)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

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
