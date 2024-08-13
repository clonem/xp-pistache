using MediatR;
using xp.pistache.core.Domain.DTOs.Portfolio;

namespace xp.pistache.core.Application.Portfolio.GetPurchaseHistory
{
    public record GetPurchaseHistoryQuery(int ClientId) : IRequest<IEnumerable<ResponseGetPurchaseHistoryDTO>>;
}
