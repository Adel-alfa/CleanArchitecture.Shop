using FluentValidation;
using FluentValidation.Validators;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Commands.Categories.CreateCategory
{
    public class CreateCategoryCommandValidator: AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
                RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage($"{nameof(Category.Name)} cannot be empty")
                .MaximumLength(50)
                .WithMessage($"{nameof(Category.Name)} cannot be longer than 50 characters");
        }
    }
}
