using FluentValidation;
using Shop.Domain.Entities;

namespace Shop.Application.Commands.Products.DeleteProduct
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty()
                .WithMessage($"{nameof(Product.Id)} cannot be empty");
        }
    }
}
