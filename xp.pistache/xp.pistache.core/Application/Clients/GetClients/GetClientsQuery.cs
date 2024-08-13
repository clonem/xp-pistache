using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xp.pistache.core.Domain.DTOs.Client;

namespace xp.pistache.core.Application.Clients.GetClients
{
    public record GetClientsQuery() : IRequest<IEnumerable<ClientDTO>>
    {
    }
}
