using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xp.pistache.core.Domain.Interfaces;

namespace xp.pistache.core.Application.Products.UpdateStatusProduct
{
    public class UpdateStatusProductCommandHandler : IRequestHandler<UpdateStatusProductCommand, int>
    {
        private readonly IDbRepository _dbRepository;
        private readonly IMapper _mapper;

        public UpdateStatusProductCommandHandler(IDbRepository dbRepository, IMapper mapper)
        {
            _dbRepository = dbRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateStatusProductCommand request, CancellationToken cancellationToken)
        {
            const string sql = @"UPDATE 
                                    [dbo].[Product] 
                                SET 
                                    [Status] = @Status
                                WHERE 
                                    ProductID = @ProductID";

            var param = new
            {
                ProductID = request.ProductID,
                Status = request.ProductStatusEnum.ToString(),
            };

            int affected = await _dbRepository.ExecuteAsync(sql, param);

            return affected;
        }
    }
}
