using MediatR;
using xp.pistache.core.Domain.DTOs.Client;

namespace xp.pistache.core.Application.Clients.GetClients
{
    public record GetClientsQuery() : IRequest<IEnumerable<ClientDTO>>
    {
    }
}
