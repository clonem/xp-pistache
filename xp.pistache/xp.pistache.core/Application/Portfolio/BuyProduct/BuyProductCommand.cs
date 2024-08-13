using MediatR;

namespace xp.pistache.core.Application.Portfolio.BuyProduct
{
    public record BuyProductCommand(int ClientID, int ProductID, string ProductName, decimal ProductPrice, int ProductQuantity) : IRequest<int>;
}
