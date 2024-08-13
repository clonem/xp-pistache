using MediatR;
using xp.pistache.core.Domain.DTOs.Client;
using xp.pistache.core.Domain.Interfaces;

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
