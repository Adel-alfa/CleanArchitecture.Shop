using MediatR;
using Shop.Application.IServices.Infrastructure;
using Shop.Contracts.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Commands.Products.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IProductRepository productRepository;
        public DeleteProductCommandHandler(IProductRepository ProductRepository) 
        {
            productRepository = ProductRepository;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var productDatabase = await productRepository.GetByIdAsync(request.Id, cancellationToken);
            if (productDatabase == null)
            {
                throw new NotFoundException(nameof(Products), request.Id.ToString());
            }
             await productRepository.DeleteAsync(request.Id, cancellationToken);
          
            return Unit.Value;
        }
    }
}
