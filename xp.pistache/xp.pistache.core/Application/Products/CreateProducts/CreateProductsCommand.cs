using MediatR;

namespace xp.pistache.core.Application.Products.CreateProducts
{
    public record CreateProductsCommand(int ProductID, string Name, string? Description, Decimal Price, string Status) : IRequest<int>;
}
