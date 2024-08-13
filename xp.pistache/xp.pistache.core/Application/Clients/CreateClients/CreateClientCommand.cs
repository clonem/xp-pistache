using MediatR;

namespace xp.pistache.core.Application.Clients.CreateClients
{
    public record CreateClientCommand(int ClientId, string Name, string? Email) : IRequest<int>;
}
