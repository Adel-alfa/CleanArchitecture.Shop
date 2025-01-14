using MediatR;
using Shop.Application.IServices.Infrastructure;
using Shop.Contracts.Exceptions;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Commands.Categories.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
    {
        private readonly ICategoryRepository categoryRepository;
        public DeleteCategoryCommandHandler(ICategoryRepository CategoryRepository) 
        {
            categoryRepository = CategoryRepository;
        }
        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var cateDatabase =await categoryRepository.GetByIdAsync(request.id, cancellationToken);
            if (cateDatabase == null)
            {
                throw new NotFoundException(nameof(Category), request.id.ToString());
            }
            await categoryRepository.DeleteAsync(request.id, cancellationToken);
            
            return Unit.Value;
        }
    }
}
