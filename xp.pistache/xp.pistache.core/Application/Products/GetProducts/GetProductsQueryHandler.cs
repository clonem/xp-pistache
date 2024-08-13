using MediatR;
using xp.pistache.core.Domain.DTOs.Products;
using xp.pistache.core.Domain.Interfaces;

namespace xp.pistache.core.Application.Products.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductDTO>>
    {
        private readonly IDbRepository _dbRepository;

        public GetProductsQueryHandler(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public async Task<IEnumerable<ProductDTO>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbRepository.QueryAsync<ProductDTO>("SELECT * from Product where Status = 'ENABLE'");

            return result;
        }
    }
}
