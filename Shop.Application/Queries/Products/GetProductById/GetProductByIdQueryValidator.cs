using FluentValidation;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Queries.Products.GetProductById
{
    public class GetProductByIdQueryValidator: AbstractValidator<GetProductByIdQuery>
    {
        public GetProductByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty()
            .WithMessage($"{nameof(Product.Id)} cannot be empty");
        }
    }
}
