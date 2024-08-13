using MediatR;
using xp.pistache.core.Domain.Interfaces;

namespace xp.pistache.core.Application.Products.CreateProducts
{
    public class CreateProductsCommandHandler : IRequestHandler<CreateProductsCommand, int>
    {
        private readonly IDbRepository _dbRepository;

        public CreateProductsCommandHandler(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public async Task<int> Handle(CreateProductsCommand request, CancellationToken cancellationToken)
        {
            const string sql = @"INSERT INTO [dbo].[Product] (
                                        [ProductID]
                                       ,[Name]
                                       ,[Description]
                                       ,[Price]
                                       ,[Status]
                                       ,[CreateAt]
                                 ) VALUES (
                                        @ProductID
                                       ,@Name
                                       ,@Description
                                       ,@Price
                                       ,@Status
                                       ,@CreateAt)";

            var param = new
            {
                ProductID = request.ProductID,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Status = request.Status,
                CreateAt = DateTime.Now
            };

            await _dbRepository.ExecuteScalarAsync(sql, param);

            return request.ProductID;
        }
    }
}
