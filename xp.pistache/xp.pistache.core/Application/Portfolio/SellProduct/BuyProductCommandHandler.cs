using MediatR;
using xp.pistache.core.Domain.DTOs.Products;
using xp.pistache.core.Domain.Interfaces;

namespace xp.pistache.core.Application.Portfolio.SellProduct
{
    public class SellProductCommandHandler : IRequestHandler<SellProductCommand, int>
    {
        private readonly IDbRepository _dbRepository;

        public SellProductCommandHandler(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public async Task<int> Handle(SellProductCommand request, CancellationToken cancellationToken)
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

        private async Task BusinessValidation(SellProductCommand request)
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


            const string sqlQuantity = "SELECT ISNULL(SUM([ProductQuantity]), 0) AS Quantity FROM [dbo].[ClientProductTransaction] WHERE [ClientID] = @ClientID AND [ProductID] = @ProductID";

            var quantity = await _dbRepository.QueryFirstOrDefaultAsync<int>(sqlQuantity, new { ClientID = request.ClientID, ProductID = request.ProductID });

            if (quantity < (request.ProductQuantity * -1))
            {
                throw new BusinessException("invalid quantity");
            }
        }
    }
}
