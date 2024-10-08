﻿using MediatR;

namespace xp.pistache.core.Application.Products.UpdateProduct
{
    public record UpdateProductCommand(int ProductID, string Name, string? Description, Decimal Price, string Status) : IRequest<int>;
}
