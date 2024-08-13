using FluentValidation;

namespace xp.pistache.core.Application.Portfolio.BuyProduct
{
    public class BuyProductCommandValidator : AbstractValidator<BuyProductCommand>
    {
        public BuyProductCommandValidator()
        {
            RuleFor(x => x.ProductID)
                .GreaterThan(0);

            RuleFor(x => x.ProductPrice)
                .GreaterThan(0);

            RuleFor(x => x.ProductQuantity)
                .GreaterThan(0);
        }
    }
}
