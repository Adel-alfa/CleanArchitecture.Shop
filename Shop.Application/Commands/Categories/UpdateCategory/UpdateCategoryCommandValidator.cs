using FluentValidation;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Commands.Categories.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty()
               .WithMessage($"{nameof(Category.Id)} cannot be empty");

            RuleFor(c => c.Name)
               .NotEmpty()
               .WithMessage($"{nameof(Category.Name)} cannot be empty")
               .MaximumLength(50)
               .WithMessage($"{nameof(Category.Name)} cannot be longer than 50 characters");
        }
    }
}
