using MediatR;
using xp.pistache.core.Domain.DTOs.Portfolio;

namespace xp.pistache.core.Application.Portfolio.GetClientProducts
{
    public record GetClientProductsQuery(int ClientId) : IRequest<IEnumerable<ResponseGetClientProductsDTO>>;
}
