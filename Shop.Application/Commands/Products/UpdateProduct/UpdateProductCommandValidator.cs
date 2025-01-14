using FluentValidation;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Products.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty()
                .WithMessage($"{nameof(Product.Id)} cannot be empty");

            RuleFor(c => c.Name)
           .NotEmpty()
           .WithMessage($"{nameof(Product.Name)} cannot be empty")
           .MaximumLength(100)
           .WithMessage($"{nameof(Product.Name)} cannot be longer than 100 characters");

            RuleFor(c => c.Description)
               .NotEmpty()
               .WithMessage($"{nameof(Product.Description)} cannot be empty")
               .MaximumLength(1000)
               .WithMessage($"{nameof(Product.Description)} cannot be longer than 1000 characters");

            RuleFor(c => c.Price)
              .NotEmpty()
              .WithMessage($"{nameof(Product.Price)} cannot be empty")
              .LessThan(10000)
              .WithMessage($"{nameof(Product.Price)} cannot be more than 9999.99 ")
              .GreaterThanOrEqualTo(1)
              .WithMessage($"{nameof(Product.Price)} cannot be less than 1 ");

            RuleFor(c => c.Price)
             .NotNull()
             .WithMessage($"{nameof(Product.Quantity)} cannot be empty")
             .LessThan(9999)
             .WithMessage($"{nameof(Product.Price)} cannot be more than 9999 ")
             .GreaterThanOrEqualTo(1)
             .WithMessage($"{nameof(Product.Price)} cannot be less than 1 ");
        }
    }
}
