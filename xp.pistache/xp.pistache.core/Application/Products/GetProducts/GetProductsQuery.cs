using MediatR;
using xp.pistache.core.Domain.DTOs.Products;

namespace xp.pistache.core.Application.Products.GetProducts
{
    public class GetProductsQuery : IRequest<IEnumerable<ProductDTO>>
    {
    }
}
