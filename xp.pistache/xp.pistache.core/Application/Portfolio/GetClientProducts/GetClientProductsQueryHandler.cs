using MediatR;
using xp.pistache.core.Domain.DTOs.Portfolio;
using xp.pistache.core.Domain.Interfaces;

namespace xp.pistache.core.Application.Portfolio.GetClientProducts
{
    public class GetClientProductsQueryHandler : IRequestHandler<GetClientProductsQuery, IEnumerable<ResponseGetClientProductsDTO>>
    {
        private readonly IDbRepository _dbRepository;

        public GetClientProductsQueryHandler(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public async Task<IEnumerable<ResponseGetClientProductsDTO>> Handle(GetClientProductsQuery request, CancellationToken cancellationToken)
        {
            const string sql = @"SELECT        
                                    dbo.Product.ProductID, dbo.Product.Name, dbo.Product.Description, dbo.Product.DueDate, 
                                    SUM(dbo.ClientProductTransaction.ProductQuantity) AS Quantity, 
                                    SUM(dbo.Product.Price) AS Price
                                FROM
                                    dbo.ClientProductTransaction INNER JOIN
                                    dbo.Product ON dbo.ClientProductTransaction.ProductID = dbo.Product.ProductID
                                WHERE
                                    (dbo.ClientProductTransaction.ClientID = @ClientID)
                                GROUP BY 
                                    dbo.Product.ProductID, dbo.Product.Name, dbo.Product.Description, dbo.Product.DueDate";

            var param = new
            {
                ClientID = request.ClientId,
            };

            var result = await _dbRepository.QueryAsync<ResponseGetClientProductsDTO>(sql, param);

            return result;
        }
    }
}
