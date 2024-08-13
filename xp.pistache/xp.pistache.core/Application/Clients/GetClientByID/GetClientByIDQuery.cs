using MediatR;
using xp.pistache.core.Domain.DTOs.Client;

namespace xp.pistache.core.Application.Clients.GetClientByID
{
    public record GetClientByIDQuery(int clientId) : IRequest<ClientDTO?>
    {
    }
}
