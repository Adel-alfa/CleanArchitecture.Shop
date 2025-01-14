using FluentValidation;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Commands.Categories.DeleteCategory
{
    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidator()
        {
                RuleFor(x=> x.id).NotEmpty()
                .WithMessage($"{nameof(Category.Id)} cannot be empty");
        }
    }
}
