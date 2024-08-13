using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xp.pistache.core.Domain.Interfaces;

namespace xp.pistache.core.Application.Portfolio.BuyProduct
{
    public class BuyProductCommandHandler : IRequestHandler<BuyProductCommand, int>
    {
        private readonly IDbRepository _dbRepository;

        public BuyProductCommandHandler(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public async Task<int> Handle(BuyProductCommand request, CancellationToken cancellationToken)
        {
            const string sql = @"INSERT INTO [dbo].[ClientProductTransaction] (
                                        [ClientID]
                                       ,[ProductID]
                                       ,[ProductName]
                                       ,[ProductPrice]
                                       ,[ProductQuantity]
                                       ,[CreateAt]
                                ) VALUES (
                                        @ClientID
                                       ,@ProductID
                                       ,@ProductName
                                       ,@ProductPrice
                                       ,@ProductQuantity
                                       ,@CreateAt
                                )";

            var param = new
            {
                ClientID = request.ClientID,
                ProductID = request.ProductID,
                ProductName = request.ProductName,
                ProductPrice = request.ProductPrice,
                ProductQuantity = request.ProductQuantity,
                CreateAt = DateTime.Now
            };

            int affected = await _dbRepository.ExecuteAsync(sql, param);

            return affected;
        }
    }
}
