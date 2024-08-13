using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xp.pistache.core.Domain.DTOs.Client;
using xp.pistache.core.Domain.Interfaces;
using xp.pistache.core.Domain.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace xp.pistache.core.Application.Clients.GetClients
{
    public class GetClientsQueryHandler : IRequestHandler<GetClientsQuery, IEnumerable<ClientDTO>>
    {
        private readonly IDbRepository _dbRepository;

        public GetClientsQueryHandler(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public async Task<IEnumerable<ClientDTO>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbRepository.QueryAsync<ClientDTO>("SELECT * FROM [dbo].[Client]");

            return result;
        }
    }
}
