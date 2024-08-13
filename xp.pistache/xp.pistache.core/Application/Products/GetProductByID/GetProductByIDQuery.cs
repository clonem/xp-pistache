using MediatR;
using xp.pistache.core.Domain.DTOs.Products;

namespace xp.pistache.core.Application.Products.GetProductByID
{
    public record GetProductByIDQuery(int ProductID) : IRequest<ProductDTO?>;
}
