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

namespace xp.pistache.core.Application.Clients.GetClientByID
{
    public class GetClientByIDQueryHandler : IRequestHandler<GetClientByIDQuery, ClientDTO?>
    {
        private readonly IDbRepository _dbRepository;

        public GetClientByIDQueryHandler(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public async Task<ClientDTO?> Handle(GetClientByIDQuery request, CancellationToken cancellationToken)
        {
            const string sql = "SELECT * FROM [dbo].[Client] WHERE ClientID = @ClientID";

            var result = await _dbRepository.QueryFirstOrDefaultAsync<ClientDTO>(sql, new { ClientID = request.clientId });

            return result;
        }
    }
}
