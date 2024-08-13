using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xp.pistache.core.Domain.DTOs.Products;
using xp.pistache.core.Domain.Interfaces;

namespace xp.pistache.core.Application.Products.GetProductByID
{
    public class GetProductByIDQueryHandler : IRequestHandler<GetProductByIDQuery, ProductDTO?>
    {
        private readonly IDbRepository _dbRepository;

        public GetProductByIDQueryHandler(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public async Task<ProductDTO> Handle(GetProductByIDQuery request, CancellationToken cancellationToken)
        {
            const string sql = "SELECT * FROM [dbo].[Product] WHERE ProductID = @ProductID";

            var result = await _dbRepository.QueryFirstOrDefaultAsync<ProductDTO>(sql, new { ProductID = request.ProductID });

            return result;
        }
    }
}
