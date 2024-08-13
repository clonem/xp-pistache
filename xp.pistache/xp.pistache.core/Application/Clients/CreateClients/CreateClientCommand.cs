using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xp.pistache.core.Application.Clients.CreateClients
{
    public record CreateClientCommand(int ClientId, string Name, string? Email) : IRequest<int>;
}
