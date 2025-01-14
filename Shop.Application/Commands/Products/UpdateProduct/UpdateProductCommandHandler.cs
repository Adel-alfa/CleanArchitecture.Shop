using MediatR;
using Shop.Application.IServices.Infrastructure;
using Shop.Contracts.Exceptions;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Commands.Products.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductRepository productRepository;
        public UpdateProductCommandHandler(IProductRepository ProductRepository)
        {
            productRepository = ProductRepository;
        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productDatabase= await productRepository.GetByIdAsync(request.Id,cancellationToken);
            if (productDatabase == null)
            {
                throw new NotFoundException(nameof(Products), request.Id.ToString());
            }
            var product = new Product
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Quantity = request.Quantity,
                CategoryId = request.CategoryId,
                ModificationDate = DateTime.Now,
            };
           await productRepository.UpdateAsync(product, cancellationToken);
            
            return Unit.Value;
        }
    }
}
