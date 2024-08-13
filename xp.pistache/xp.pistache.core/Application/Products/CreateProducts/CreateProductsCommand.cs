using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xp.pistache.core.Domain.DTOs;

namespace xp.pistache.core.Application.Products.CreateProducts
{
    public record CreateProductsCommand(int ProductID, string Name, string? Description, Decimal Price, string Status) : IRequest<int>;
}
