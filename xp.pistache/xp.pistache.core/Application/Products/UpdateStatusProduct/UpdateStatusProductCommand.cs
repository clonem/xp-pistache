using MediatR;
using xp.pistache.core.Domain.DTOs.Products;

namespace xp.pistache.core.Application.Products.UpdateStatusProduct
{
    public record UpdateStatusProductCommand(int ProductID, ProductStatusEnum ProductStatusEnum) : IRequest<int>;
}
