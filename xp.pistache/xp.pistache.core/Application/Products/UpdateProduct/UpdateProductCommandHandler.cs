using AutoMapper;
using MediatR;
using xp.pistache.core.Domain.Interfaces;

namespace xp.pistache.core.Application.Products.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly IDbRepository _dbRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IDbRepository dbRepository, IMapper mapper)
        {
            _dbRepository = dbRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            const string sql = @"UPDATE 
                                    [dbo].[Product] 
                                SET 
                                     [Status] = @Status
                                    ,[Name] = @Name
                                    ,[Description] = @Description
                                    ,[Price] = @Price
                                    ,[UpdatedAt] = @UpdatedAt
                                WHERE 
                                    ProductID = @ProductID";

            var param = new
            {
                ProductID = request.ProductID,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price, 
                Status = request.Status.ToString(),
                UpdatedAt = DateTime.Now,
            };

            int affected = await _dbRepository.ExecuteAsync(sql, param);

            return affected;
        }
    }
}
