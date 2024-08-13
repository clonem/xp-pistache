using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xp.pistache.core.Domain.DTOs.Client;
using xp.pistache.core.Domain.Model;

namespace xp.pistache.core.Application.Clients.GetClientByID
{
    public record GetClientByIDQuery(int clientId) : IRequest<ClientDTO?>
    {
    }
}
