﻿using MediatR;
using xp.pistache.core.Domain.DTOs.Products;
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
            await BusinessValidation(request);

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

        private async Task BusinessValidation(BuyProductCommand request)
        {
            const string sqlProduct = "SELECT * FROM [dbo].[Product] WHERE ProductID = @ProductID";

            var productDTO = await _dbRepository.QueryFirstOrDefaultAsync<ProductDTO>(sqlProduct, new { ProductID = request.ProductID });

            if (productDTO is null)
            {
                throw new BusinessException();
            }

            if (productDTO.DueDate < DateTime.Today)
            {
                throw new BusinessException("overdue product");
            }
        }
    }
}
