using FluentValidation;

namespace xp.pistache.core.Application.Portfolio.SellProduct
{
    public class SellProductCommandValidator : AbstractValidator<SellProductCommand>
    {
        public SellProductCommandValidator()
        {
            RuleFor(x => x.ProductID)
                .GreaterThan(0);

            RuleFor(x => x.ProductPrice)
                .GreaterThan(0);

            RuleFor(x => x.ProductQuantity)
                .LessThan(0);
        }
    }
}
