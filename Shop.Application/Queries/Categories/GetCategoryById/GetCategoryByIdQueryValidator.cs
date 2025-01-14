using FluentValidation;
using Shop.Domain.Entities;

namespace Shop.Application.Queries.Categories.GetCategoryById
{
    public class GetCategoryByIdQueryValidator : AbstractValidator<GetCategoryByIdQuery>
    {
        public GetCategoryByIdQueryValidator()
        {
            RuleFor(x => x.id).NotEmpty()
           .WithMessage($"{nameof(Category.Id)} cannot be empty");
        }
    }
}
