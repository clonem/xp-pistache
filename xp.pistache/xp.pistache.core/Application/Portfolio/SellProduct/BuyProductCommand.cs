using MediatR;

namespace xp.pistache.core.Application.Portfolio.SellProduct
{
    public record SellProductCommand(int ClientID, int ProductID, string ProductName, decimal ProductPrice, int ProductQuantity) : IRequest<int>;
}
