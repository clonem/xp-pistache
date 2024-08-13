using MediatR;
using xp.pistache.core.Domain.DTOs.Client;
using xp.pistache.core.Domain.Interfaces;

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
