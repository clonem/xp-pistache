using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xp.pistache.core.Application.Portfolio.BuyProduct
{
    public record BuyProductCommand(int ClientID, int ProductID, string ProductName, decimal ProductPrice, int ProductQuantity) : IRequest<int>;
}
