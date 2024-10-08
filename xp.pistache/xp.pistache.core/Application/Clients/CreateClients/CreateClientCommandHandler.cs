﻿using AutoMapper;
using MediatR;
using xp.pistache.core.Domain.Interfaces;

namespace xp.pistache.core.Application.Clients.CreateClients
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, int>
    {
        private readonly IDbRepository _dbRepository;
        private readonly IMapper _mapper;

        public CreateClientCommandHandler(IDbRepository dbRepository, IMapper mapper)
        {
            _dbRepository = dbRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            const string sql = @"INSERT INTO [dbo].[Client] (
                                        ClientID
                                       ,Name
                                       ,Email
                                       ,CreateAt
                                ) VALUES (
                                        @ClientID
                                       ,@Name
                                       ,@Email
                                       ,GETDATE())";

            // "SELECT CAST(SCOPE_IDENTITY() as int); ";

            var param = new
            {
                ClientID = request.ClientId,
                request.Name,
                request.Email
            };

            await _dbRepository.ExecuteScalarAsync(sql, param);

            return request.ClientId;
        }
    }
}
