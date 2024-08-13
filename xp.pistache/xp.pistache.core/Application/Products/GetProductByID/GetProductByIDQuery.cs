using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xp.pistache.core.Domain.DTOs.Products;

namespace xp.pistache.core.Application.Products.GetProductByID
{
    public record GetProductByIDQuery(int ProductID) : IRequest<ProductDTO?>;
}
