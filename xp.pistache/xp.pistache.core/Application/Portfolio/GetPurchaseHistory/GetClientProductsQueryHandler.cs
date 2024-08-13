using MediatR;
using xp.pistache.core.Domain.DTOs.Portfolio;
using xp.pistache.core.Domain.Interfaces;

namespace xp.pistache.core.Application.Portfolio.GetPurchaseHistory
{
    public class GetPurchaseHistoryQueryHandler : IRequestHandler<GetPurchaseHistoryQuery, IEnumerable<ResponseGetPurchaseHistoryDTO>>
    {
        private readonly IDbRepository _dbRepository;

        public GetPurchaseHistoryQueryHandler(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public async Task<IEnumerable<ResponseGetPurchaseHistoryDTO>> Handle(GetPurchaseHistoryQuery request, CancellationToken cancellationToken)
        {
            const string sql = @"SELECT
                                    dbo.Product.ProductID, dbo.Product.Name, dbo.Product.Description, dbo.Product.Price, dbo.Product.Status, 
                                    dbo.ClientProductTransaction.ProductQuantity, dbo.ClientProductTransaction.CreateAt
                                FROM
                                    dbo.ClientProductTransaction INNER JOIN
                                    dbo.Product ON dbo.ClientProductTransaction.ProductID = dbo.Product.ProductID
                                WHERE
                                    dbo.ClientProductTransaction.ClientID = @ClientID";

            var param = new
            {
                ClientID = request.ClientId,
            };

            var result = await _dbRepository.QueryAsync<ResponseGetPurchaseHistoryDTO>(sql, param);

            return result;
        }
    }
}
